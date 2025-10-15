import re, textwrap, requests, ast, astor, re, os, json, time, random
from .utils import (validate_with_unittest, remove_function_signature,CODEBLEU_THRESHOLD)
from .prompts import (SYSTEM_PROMPT_MINIMAL, context_builders, build_clone_variation_prompt, build_user_prompt_retest,build_user_prompt_codebleu)
from concurrent.futures import ThreadPoolExecutor, as_completed
from tqdm import tqdm
from codebleu import calc_codebleu

FUNCTION_NAME = "task_func"  
REMOTE_OLLAMA = True
N_ENTRIES = 12
CLONES_PER_ENTRY = 1
MAX_RETRIES=3
DELAY=3
MAX_WORKERS = 6  # increase for more parallelism

def call_ollama_chat(messages, model, options):
    """
    Call Ollama-native models using the URL from the correct config file.
       
    Returns:
    - str: assistant content
    """
    root_dir = os.path.abspath(os.path.join(os.path.dirname(__file__), "../.."))

    # Pick the right config file
    if REMOTE_OLLAMA:
        config_file = os.path.join(root_dir, "ollama_config_remote.json")
    else:  # default to local
        config_file = os.path.join(root_dir, "ollama_config_local.json")

    with open(config_file, "r", encoding="utf-8") as f:
        config = json.load(f) 
    url = config["url"]        
    timeout = config.get("timeout", 600)

    # Prepare payload
    payload = config["json"]
    payload["model"] = model
    payload["messages"] = messages
    payload["options"] = options

    # Send request
    resp = requests.post(url, json=payload, timeout=timeout)
    resp.raise_for_status()
    data = resp.json()

    # Parse Ollama-native response
    if "message" in data and "content" in data["message"]:
        return data["message"]["content"]

    raise ValueError(f"Unexpected response format: {data}") 

def extract_python_code(text: str) -> str:
    """
    Extract the first ```python ... ``` fenced block;
    if none found, return the whole text up to the first ```...```.
    If extra text follows after the code block, it will be ignored.
    """
    # Case 1: explicit python fence
    m = re.search(r"```python\s*(.*?)```", text, flags=re.S)
    if m:
        return m.group(1).strip()

    # Case 2: any fenced block (not explicitly python)
    m = re.search(r"```\s*(.*?)```", text, flags=re.S)
    if m:
        return m.group(1).strip()

    # Case 3: no fenced block → just return the whole thing
    return text.strip()



def force_function_name(code: str, expected=FUNCTION_NAME):
    """
    Ensure the function is named `expected`.
    If the model wrote a different name, rename the top-level function.
    """
    
    try:
        tree = ast.parse(textwrap.dedent(code))
        for node in tree.body:
            if isinstance(node, ast.FunctionDef):
                node.name = expected
                break
        ast.fix_missing_locations(tree)
        return astor.to_source(tree)
    except Exception:
        return code  # if parsing fails, return as-is; validation will catch issues 
    
def generate_clones(messages, model, options, expected_func_name):
    """
    Call Ollama chat with the given messages, extract Python code, 
    and ensure the function has the expected name.
    
    Args:
        messages: List of messages to send to the LLM.
        expected_name: The required function name in the output code.
        
    Returns:
        The extracted and renamed Python code as a string.
    """
    for attempt in range(MAX_RETRIES): # GPT models sometimes return nothing
        raw = call_ollama_chat(messages, model, options)

        # Check if there's a ```python fenced block
        if re.search(r"```python[\s\S]*?```", raw):
            break  # valid Python code found

        # If no code block, retry
        if attempt < MAX_RETRIES - 1:
            time.sleep(DELAY) 
    code = extract_python_code(raw)
    code = force_function_name(code, expected_func_name)
    return code

def load_existing_results(path):
    """Load existing JSON results if the file exists, else return empty list."""
    if os.path.exists(path):
        with open(path, "r", encoding="utf-8") as f:
            return json.load(f)
    return []

def merge_results(existing, new_entry):
    """
    Merge clones into existing results:
    - If entry.id exists, update clones by clone_id.
    - If not, append new entry.
    """
    for entry in existing:
        if entry["id"] == new_entry["id"]:
            clone_map = {c["clone_id"]: c for c in entry.get("clones", [])}
            for clone in new_entry["clones"]:
                clone_map[clone["clone_id"]] = clone
            entry["clones"] = list(clone_map.values())
            return existing
    # Entry not found, add it
    existing.append(new_entry)
    return existing

def code_to_ast(code):
    try:
        code_str = code.encode().decode("unicode_escape")
        tree = ast.parse(code_str)
        return ast.dump(tree, indent=2, annotate_fields=True, include_attributes=False)
    
    except SyntaxError as e:
        return f"Invalid Python code: {e}" 


def add_generated_fields(dataset_path, n_entries):
    """
    Loads dataset, generates, 'uml', and 'ast' fields
    for each entry, stores them inside a 'generated_data' sub-dictionary,
    and saves the updated dataset to the same file.
    """
    with open(dataset_path, "r", encoding="utf-8") as f:
        data = json.load(f)

    for i, entry in enumerate(data[:n_entries], 1):
        print(f"[{i}/{n_entries}] Generating fields for {entry['id']}")
        code = entry["original_code"]
        try:
            # Generate fields 
            ast = code_to_ast(code) 
            entry["metadata"] = {
                "ast": ast.strip()
            }

        except Exception as e:
            print(f"  Error generating for {entry['id']}: {e}")
            entry["metadata"] = {
                "ast": "",  
            }

    # Save back to file
    with open(dataset_path, "w", encoding="utf-8") as f:
        json.dump(data, f, indent=2, ensure_ascii=False)

    print(f"✅ Updated dataset with 'metadata' fields in {dataset_path}") 

def run_clone_generation(
    dataset_path,
    out_path,
    n_entries,
    clones_per_entry,
    ollama_model,
    llm_opts,
    context,  
    refacs,
    strategy="zero-shot",
    context_builders=context_builders # pass as parameter to change them
):
    """
    Run clone generation for dataset entries.

    Args:
        dataset_path: Path to dataset JSON.
        out_path: Where to save results.
        n_entries: Number of entries to process.
        clones_per_entry: Number of clones per entry.
        ollama_model: Model name.
        llm_opts: Dict of LLM options.
        context: changes prompt strategy. 
        strategy: prompt strategy (default: "zero-shot")
        context_builders: dict mapping context -> callable returning (system_prompt, user_prompt)
    """
    with open(dataset_path, "r", encoding="utf-8") as f:
        data = json.load(f)

    sample = data[:n_entries]
    results = load_existing_results(out_path)

    for i, entry in enumerate(sample, 1):
        print(f"\nGenerating clones {i}/{len(sample)} for {entry['id']}")
        clones = []

        # Extract fields from entry 
        original_body   = entry["original_code"]
        tests_list      = entry["test"]
        description     = entry.get("description", "") 

        tests_snippet   = tests_list[0] if tests_list else ""
        params          = entry.get("metadata", {}).get("params", [])
        return_text     = entry.get("metadata", {}).get("return_text", []) 
        complete_prompt = entry.get("metadata", {}).get("complete_prompt", []) 
        gen_ast         = entry.get("metadata", {}).get("ast", "")

        for k in range(clones_per_entry):
            if context not in context_builders:
                raise ValueError(f"Unknown context: {context}")

            
            system_prompt, user_prompt = context_builders[context](
                strategy=strategy,
                description=description,
                gen_ast=gen_ast,
                original_body=original_body, 
                tests_snippet=tests_snippet,
                params=params,
                return_text=return_text, 
                complete_prompt=complete_prompt,
                refacs=refacs
            ) 
            messages = [
                {"role": "system", "content": system_prompt},
                {"role": "user",   "content": user_prompt},
            ]
            try:
                code = generate_clones(
                    messages,
                    model=ollama_model,
                    options=llm_opts,
                    expected_func_name=FUNCTION_NAME,
                )
                clones.append({
                    "model": ollama_model,
                    "context": context,                    
                    "strategy": strategy,
                    "code": code, 
                    "refacs": refacs,
                    "clone_id": f"{strategy} {ollama_model}-{context} {k+1} {refacs}",
                })
            except Exception as e:
                print(f" Error generating clone {k+1}: {e}")

        new_entry = {"id": entry["id"], "clones": clones}
        results = merge_results(results, new_entry)

    os.makedirs(os.path.dirname(out_path), exist_ok=True)
    with open(out_path, "w", encoding="utf-8") as f:
        json.dump(results, f, indent=2) 


 


# Cache for CodeBLEU and test runs (avoid recomputation)
_codebleu_cache = {}
_test_cache = {}


def cached_codebleu(ref_body, clone_body):
    key = (ref_body, clone_body)
    if key in _codebleu_cache:
        return _codebleu_cache[key]
    score = calc_codebleu([ref_body], [clone_body], lang="python")
    value = float(score["codebleu"])
    _codebleu_cache[key] = value
    return value


def cached_testing(code, tests_list):
    key = (code, tuple(tests_list))
    if key in _test_cache:
        return _test_cache[key]
    result = validate_with_unittest(code, tests_list)
    _test_cache[key] = result
    return result


def reprompt_clone(clone, entry, tests_list, models, used_models, original_model, llm_opts,n):
    clone_id = clone.get("clone_id", "unknown")
    params = entry.get("metadata", {}).get("params", [])
    return_text = entry.get("metadata", {}).get("return_text", [])
    tests_snippet = "\n".join(tests_list) if tests_list else ""

    # Select model
    available_models = [m for m in models if m != original_model and m not in used_models]
    if not available_models:
        raise RuntimeError(f"No alternative model available for {clone_id}.")
    reprompt_model = random.choice(available_models)
    used_models.append(reprompt_model)

    # Prompt setup
    print(f"⚙️  Reprompting (attempt {n}, model={reprompt_model})")
    user_prompt = build_user_prompt_retest(
        clone_code=clone["code"],
        params=params,
        return_text=return_text,
        tests_snippet=tests_snippet,
        failing_tests=[
            t for t, r in clone.get("test_results", {}).items()
            if isinstance(r, str) and r.upper() in ("FAIL", "ERROR")
        ],
    )
    messages = [
        {"role": "system", "content": SYSTEM_PROMPT_MINIMAL},
        {"role": "user", "content": user_prompt},
    ]

    try:
        repaired_code = generate_clones(
            messages,
            model=reprompt_model,
            options=llm_opts,
            expected_func_name=FUNCTION_NAME,
        )

        # Cached evaluation
        test_results = cached_testing(repaired_code, tests_list)
        failing_tests = [
            t for t, r in test_results.items()
            if isinstance(r, str) and r.upper() in ("FAIL", "ERROR")
        ]

        ref_body = remove_function_signature(entry.get("original_code"))
        clone_body = remove_function_signature(repaired_code)
        codebleu = cached_codebleu(ref_body, clone_body)

        # Update clone info
        clone["code"] = repaired_code
        clone["test_results"] = test_results
        clone["metrics"]["codebleu"]["originalcode"] = codebleu
        clone["reprompt"] = f"test {n} (model={reprompt_model})"

        return clone, failing_tests, codebleu

    except Exception as e:
        print(f"❌ Error reprompting {clone_id}: {e}")
        clone["reprompt"] = f"test {n} (error, model={reprompt_model})"
        return clone, ["ERROR"], 1.0


def run_reprompt(
    dataset_path,
    clone_dataset_path,
    n_entries,
    llm_opts,
    models,
    out_path,
):
    with open(dataset_path, "r", encoding="utf-8") as f:
        original_data = json.load(f)
    original_by_id = {e["id"]: e for e in original_data}

    results = load_existing_results(clone_dataset_path)
    sample_entries = results[:n_entries] if n_entries else results

    with ThreadPoolExecutor(max_workers=MAX_WORKERS) as executor:
        futures = []
        for clone_entry in sample_entries:
            print(f"\n🔄 Processing {clone_entry['id']}")
            entry_id = clone_entry["id"]
            entry = original_by_id[entry_id]
            tests_list = entry.get("test", [])
            clones = clone_entry.get("clones", [])
            for clone in clones:
                test_results = clone.get("test_results", {})
                failing_tests = [
                    t for t, r in test_results.items()
                    if isinstance(r, str) and r.upper() in ("FAIL", "ERROR")
                ]
                codebleu = clone.get("metrics", {}).get("codebleu", {}).get("originalcode", 1.0)

                # Schedule only if clone passes at least one test (partial success)
                # and either fails some tests OR has a high CodeBLEU 
                passed_tests = sum(
                    1 for r in test_results.values()
                    if isinstance(r, str) and r.upper() == "PASS"
                )
                if passed_tests > 0 and (failing_tests or codebleu > CODEBLEU_THRESHOLD):
                    futures.append(executor.submit(
                        process_clone,
                        clone_entry["id"],
                        clone,
                        entry,
                        tests_list,
                        models,
                        llm_opts,
                        out_path
                    ))


        for f in tqdm(as_completed(futures), total=len(futures), desc="Processing clones"):
            f.result()  # ensure exceptions propagate


def process_clone(entry_id, clone, entry, tests_list, models, llm_opts, out_path): 
    original_model = clone.get("model")
    used_models = []
    n = 0  

    while n < MAX_RETRIES:
        n += 1
        clone, failing_tests, codebleu = reprompt_clone(
            clone=clone,
            entry=entry,
            tests_list=tests_list,
            models=models,
            used_models=used_models,
            original_model=original_model,
            llm_opts=llm_opts,
            n=n,
        )

        final_codebleu = codebleu
        final_failing_tests = failing_tests

        # Only save if both conditions are satisfied
        if not failing_tests and codebleu <= CODEBLEU_THRESHOLD:
            update_results(entry_id, clone, out_path) 
            return

        if not failing_tests and codebleu > CODEBLEU_THRESHOLD:
            print(f"⚠️ Clone passes tests but too similar (CodeBLEU={codebleu:.4f})")
            # continue retrying to improve diversity
            continue

        if failing_tests:
            print(f"⚠️ Clone still failing {len(failing_tests)} tests (retry {n}/{MAX_RETRIES})")

    # If reached max retries without a valid clone
    if final_failing_tests or final_codebleu > CODEBLEU_THRESHOLD:
        print(f"❌ Clone discarded — tests={'fail' if final_failing_tests else 'pass'} "
              f"CodeBLEU={final_codebleu:.4f}")


def update_results(entry_id, clone, out_path):
    """
    Update the results file with a single clone.
    - If the file doesn't exist, create it.
    - If the entry exists, update the clone by clone_id.
    - Otherwise, append the entry with this clone.
    """ 

    # Load existing results or start empty
    if os.path.exists(out_path):
        with open(out_path, "r", encoding="utf-8") as f:
            saved_results = json.load(f)
    else:
        saved_results = []

    # Find entry in saved results
    entry_found = False
    for entry in saved_results:
        if entry["id"] == entry_id:
            # Merge/update clone by clone_id
            clone_map = {c["clone_id"]: c for c in entry.get("clones", [])}
            clone_map[clone["clone_id"]] = clone
            entry["clones"] = list(clone_map.values())
            entry_found = True
            break

    # If entry not found, create it
    if not entry_found:
        saved_results.append({
            "id": entry_id,
            "clones": [clone]
        })

    # Save back to file
    os.makedirs(os.path.dirname(out_path), exist_ok=True)
    with open(out_path, "w", encoding="utf-8") as f:
        json.dump(saved_results, f, indent=2)

    print(f"💾 Updated results saved for clone {clone['clone_id']} of entry {entry_id}")



def run_clone_variation_generation(
    dataset_path,
    out_path,
    n_entries,
    clones_per_entry,
    ollama_model,
    llm_opts,
):
    """
    Run clone generation for dataset entries, reusing existing clones
    as examples in the prompt to generate new variations.

    Args:
        dataset_path: Path to dataset JSON.
        out_path: Where to save results.
        n_entries: Number of entries to process.
        clones_per_entry: Number of new clones per entry.
        ollama_model: Model name.
        llm_opts: Dict of LLM options. 
    """
    with open(dataset_path, "r", encoding="utf-8") as f:
        data = json.load(f)

    sample = data[:n_entries]
    results = load_existing_results(out_path)

    for i, entry in enumerate(sample, 1):
        print(f"\n🔄 Generating clones {i}/{len(sample)} for {entry['id']}")

        # Extract entry info
        original_body = entry["original_code"]
        description   = entry.get("description", "") 
        entry_clones  = entry.get("clones", [])  # already existing clones from dataset

        new_clones = []

        for k in range(clones_per_entry):
            # Build prompt with existing clones as few-shot examples
            user_prompt = build_clone_variation_prompt(
                original_body=original_body,
                description=description, 
                example_clones=entry_clones
            )

            messages = [
                {"role": "system", "content": SYSTEM_PROMPT_MINIMAL},
                {"role": "user",   "content": user_prompt},
            ]

            try:
                code = generate_clones(
                    messages,
                    model=ollama_model,
                    options=llm_opts,
                    expected_func_name=FUNCTION_NAME,
                )
                new_clones.append({
                    "model": ollama_model,
                    "context": "variation",
                    "strategy": "few-shot variation",
                    "code": code,
                    "clone_id": f"few-shot variation {ollama_model}-variation {k+1}",
                })
            except Exception as e:
                print(f" ❌ Error generating clone {k+1}: {e}")

        # Merge old clones + new clones
        all_clones = entry_clones + new_clones

        new_entry = {"id": entry["id"], "clones": all_clones}
        results = merge_results(results, new_entry)

    os.makedirs(os.path.dirname(out_path), exist_ok=True)
    with open(out_path, "w", encoding="utf-8") as f:
        json.dump(results, f, indent=2)

