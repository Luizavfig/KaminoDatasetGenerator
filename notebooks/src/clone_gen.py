import re, textwrap, requests, ast, astor, re, os, json, time
from .prompts import (SYSTEM_PROMPT_TO_NL, SYSTEM_PROMPT_TO_REQ, SYSTEM_PROMPT_TO_UML, SYSTEM_PROMPT_MINIMAL, SYSTEM_PROMPT_TRANSLATION, context_builders, build_clone_variation_prompt)

FUNCTION_NAME = "task_func"  
REMOTE_OLLAMA = False
max_retries=3
delay=1


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


import re

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
    for attempt in range(max_retries): # GPT models sometimes return nothing
        raw = call_ollama_chat(messages, model, options)

        # Check if there's a ```python fenced block
        if re.search(r"```python[\s\S]*?```", raw):
            break  # valid Python code found

        # If no code block, retry
        if attempt < max_retries - 1:
            time.sleep(delay) 
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

def code_to_nl_description(code, nl_model, llm_opts):
    """
    Ask the LLM to summarize code into natural language.
    """
    messages = [
        {"role": "system", "content": SYSTEM_PROMPT_TO_NL},
        {"role": "user", "content": f"Summarize the following function:\n\n```python\n{code}\n```"}
    ]
    return call_ollama_chat(messages, nl_model, llm_opts)

def code_to_req(code, nl_model, llm_opts):
    """
    Ask the LLM to elict requirements from code.
    """
    messages = [
        {"role": "system", "content": SYSTEM_PROMPT_TO_REQ},
        {"role": "user", "content": f"Elict requirements from the following function:\n\n```python\n{code}\n```"}
    ]
    return call_ollama_chat(messages, nl_model, llm_opts)

def code_to_uml(code, uml_model, llm_opts):
    """
    Ask the LLM to create state-machine from code.
    """
    messages = [
        {"role": "system", "content": SYSTEM_PROMPT_TO_UML},
        {"role": "user", "content": f"Create a PlantUML state-machine diagram from the following function:\n\n```python\n{code}\n```"}
    ]
    return call_ollama_chat(messages, uml_model, llm_opts)

def code_to_ast(code):
    try:
        code_str = code.encode().decode("unicode_escape")
        tree = ast.parse(code_str)
        return ast.dump(tree, indent=2, annotate_fields=True, include_attributes=False)
    
    except SyntaxError as e:
        return f"Invalid Python code: {e}" 

 

def add_generated_fields(dataset_path, nl_model, llm_opts, n_entries):
    """
    Loads dataset, generates 'requirement', 'uml', and 'ast' fields
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
            requirement = code_to_req(code, nl_model, llm_opts)
            uml = code_to_uml(code, nl_model, llm_opts)
            ast = code_to_ast(code)

            # Store generated fields under 'generated_data'
            entry["generated_data"] = {
                "requirement": requirement.strip(),
                "uml": uml.strip(),
                "ast": ast.strip()
            }

        except Exception as e:
            print(f"  Error generating for {entry['id']}: {e}")
            entry["generated_data"] = {
                "requirement": "",
                "uml": "",
                "ast": ""
            }

    # Save back to file
    with open(dataset_path, "w", encoding="utf-8") as f:
        json.dump(data, f, indent=2, ensure_ascii=False)

    print(f"✅ Updated dataset with 'generated_data' fields in {dataset_path}") 



def code_to_code(code, language, nl_model, llm_opts):
    """
    Ask the LLM to translate the code into given language.
    """
    messages = [
        {"role": "system", "content": SYSTEM_PROMPT_TRANSLATION.format(language=language)},
        {"role": "user", "content": f"Translate the following function to {language}:\n\n```python\n{code}\n```"}
    ]
    return call_ollama_chat(messages, nl_model, llm_opts)

def add_generated_translation(dataset_path, code_model, llm_opts, n_entries, language):
    """
    Loads dataset, generates a code translation for each entry,
    stores it inside the 'generated_data' sub-dictionary,
    and saves the updated dataset to the same file.
    """
    with open(dataset_path, "r", encoding="utf-8") as f:
        data = json.load(f)

    for i, entry in enumerate(data[:n_entries], 1):
        print(f"[{i}/{n_entries}] Generating code translation to {language} for {entry['id']}")
        code = entry["original_code"]

        # Ensure 'generated_data' exists so we can append safely
        if "generated_data" not in entry:
            entry["generated_data"] = {}

        try:
            translation = code_to_code(code, language, code_model, llm_opts)
            entry["generated_data"]["translation"] = translation.strip()
        except Exception as e:
            print(f"  Error generating for {entry['id']}: {e}")
            entry["generated_data"]["translation"] = ""

    with open(dataset_path, "w", encoding="utf-8") as f:
        json.dump(data, f, indent=2, ensure_ascii=False)

    print(f"✅ Updated dataset with '{language}' translations in {dataset_path}")

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
        generated = entry.get("generated_data", {})
        gen_requirement = generated.get("requirement", "")
        gen_uml         = generated.get("uml", "")
        gen_ast         = generated.get("ast", "")
        gen_translation = generated.get(f"translation", "")

        tests_snippet   = tests_list[0] if tests_list else ""
        params          = entry.get("metadata", {}).get("params", [])
        return_text     = entry.get("metadata", {}).get("return_text", [])
        libs            = entry.get("metadata", {}).get("libs", [])
        complete_prompt = entry.get("metadata", {}).get("complete_prompt", []) 

        for k in range(clones_per_entry):
            if context not in context_builders:
                raise ValueError(f"Unknown context: {context}")

            
            system_prompt, user_prompt = context_builders[context](
                strategy=strategy,
                description=description,
                gen_requirement=gen_requirement,
                gen_translation=gen_translation,
                gen_uml=gen_uml,
                gen_ast=gen_ast,
                original_body=original_body,
                libs=libs,
                tests_snippet=tests_snippet,
                params=params,
                return_text=return_text, 
                complete_prompt=complete_prompt,
                refacs=refacs
            )
            print(user_prompt)
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

def run_clone_variation_generation(
    dataset_path,
    out_path,
    n_entries,
    clones_per_entry,
    ollama_model,
    llm_opts
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
        libs          = entry.get("metadata", {}).get("libs", [])
        entry_clones  = entry.get("clones", [])  # already existing clones from dataset

        new_clones = []

        for k in range(clones_per_entry):
            # Build prompt with existing clones as few-shot examples
            user_prompt = build_clone_variation_prompt(
                original_body=original_body,
                description=description,
                libs=libs,
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

