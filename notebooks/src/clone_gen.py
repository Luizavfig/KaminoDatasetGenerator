import re, textwrap, requests, ast, astor, re, os, json 

FUNCTION_NAME = "task_func"  
REMOTE_OLLAMA = False
def call_ollama_chat(messages, model, options):
    """
    Call Ollama's /api/chat with role-based messages.
    Returns raw string content from the assistant.
    """
    
    root_dir = os.path.abspath(os.path.join(os.path.dirname(__file__), "../.."))    
    if(REMOTE_OLLAMA):
        config_file = os.path.join(root_dir, "ollama_config_remote.json")
    else:
        config_file = os.path.join(root_dir, "ollama_config_local.json")
        
    with open(config_file, "r", encoding="utf-8") as f:
        config = json.load(f)

    url = config["url"]
    timeout = config.get("timeout", 600)
    payload = config["json"]
    payload["model"] = model
    payload["messages"] = messages
    payload["options"] = options

    resp = requests.post(url, json=payload, timeout=timeout)
    resp.raise_for_status()
    data = resp.json()
    return data["message"]["content"]

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
    raw = call_ollama_chat(messages, model, options)
    code = extract_python_code(raw)
    code = force_function_name(code, expected_func_name)
    return code

import os, json

import os, json

def load_existing_results(path):
    """Load existing JSON results if the file exists, else return empty list."""
    if os.path.exists(path):
        with open(path, "r", encoding="utf-8") as f:
            return json.load(f)
    return []

def merge_results(existing, new_entry):
    """
    Merge clones into existing results:
    - If entry.id exists, update clones by transformation.
    - If not, append new entry.
    """
    for entry in existing:
        if entry["id"] == new_entry["id"]:
            clone_map = {c["transformation"]: c for c in entry.get("clones", [])}
            for clone in new_entry["clones"]:
                clone_map[clone["transformation"]] = clone
            entry["clones"] = list(clone_map.values())
            return existing
    # Entry not found, add it
    existing.append(new_entry)
    return existing


def build_user_prompt_complete(
    original_body: str,
    description: str,
    libs: list,
    tests_snippet: str,
    nfrs: str
) -> str:
    """
    Build a user prompt to generate type 4 clones.

    Args:
        original_body: The body of the original function (without 'def' line).
        description: Short textual description of the function's behavior.
        libs: List of allowed/expected libraries.
        tests_snippet: Excerpt of unit tests for the function.

    Returns:
        A formatted string prompt for the LLM.
    """
    return f"""
You will be shown:
1) A short description and allowed libraries.
2) The original function BODY (not including the def line).
3) An excerpt of the unit tests (for signature and behavior cues). Do not overfit.

Description:
{description}

Allowed/expected libraries (may import as needed): {libs}

Original function BODY (indentation represents inside the function):
{textwrap.dedent(original_body).strip()}

Unit test excerpt (do not hardcode values; just infer signature/contract):
{textwrap.shorten(textwrap.dedent(tests_snippet), width=2000, placeholder=" ... ")}


Your task:
- Emit a semantically equivalent implementation named `{FUNCTION_NAME}`.
- Keep side effects and external calls intact where visible (e.g., urllib/os/json/pandas usage).


{NFRS[nfrs]}

{MANDATORY_HINTS}
"""


SYSTEM_PROMPT_TO_NL = """You are a code summarizer.
Your task is to read a Python function and explain, in natural language, what the function does.
Be concise but precise, focusing on:
- the purpose of the function
- its parameters and return values
- side effects (file I/O, network, database, etc.)
- important edge cases handled
Do NOT output code, only natural language explanation.
"""

SYSTEM_PROMPT_TO_REQ = """You are a requirements engineer.
Your task is to read a Python function and elict requirements that represent it.
Be concise but precise, focusing on:
- The function signature (including params)
- return values
- important edge cases handled
Do NOT output code, only requirements defintion.
"""

SYSTEM_PROMPT_TO_UML = """You are a UML engineer.
Your task is to read a Python function and create a state-machine diagram in PlanUML that represent it.
Be concise but precise, focusing on:
- The behavior of the function
- Type of Input
- Type of output
- Important edge cases handled
- Avoid using library or function specific names
- Try to make the diagram in a generic way
Do NOT output code or text, only the PlantUML state-machine.
"""

SYSTEM_PROMPT_FROM_UML = f"""You are a Python developer.
You produce a Python code to a given function based on a state-machine representation in PlantUML and function declaration.
Rules:
- Output ONLY Python code in a single fenced block.
- Define exactly one function named `{FUNCTION_NAME}` with the correct signature for the tests.
"""

SYSTEM_PROMPT_MINIMAL = f"""You are a Python generation engine.
You produce a Python code to a given function based on a textual description and function declaration.
Rules:
- Output ONLY Python code in a single fenced block.
- Define exactly one function named `{FUNCTION_NAME}` with the correct signature for the tests.
"""



SYSTEM_PROMPT_COMPLETE = f"""You are a careful Python refactoring engine.
You produce a semantically equivalent variant (Type-4 clone) of the given function.
Rules:
- Output ONLY Python code in a single fenced block.
- Define exactly one function named `{FUNCTION_NAME}` with the correct signature for the tests.
- Keep the same external behavior, side-effects.
- Do NOT hardcode any test data or specific URLs or values from tests.
- Keep I/O contract identical (same return types, shapes, and exceptions).
"""

MANDATORY_HINTS = """
- Do NOT output explanations, comments, reasoning, or any text, **only valid Python code**.
- Do not add print statements
- Do to call the function you generated inside a print statement

 Generate ONLY the code in a single ```python fenced block.   
"""

NFRS = {
      "nfr0": """
""",
    "nfr1": """
- the generated code should use as few libraries as possible
""",
  "nfr2": """
- the generated code should use as many libraries as possible
"""
,
"nfr3":""" 
Runtime & Reliability Quality
- generate code that focuses on Performance Efficiency, by using system resources effectively and delivering fast, responsive performance.
- generate code that focuses on Reliability, by consistent performance, fault tolerance, and the ability to recover from failures.
- generate code that focuses on Safety, by protecting people, assets, and the environment from potential harm, and ensuring fail-safe behavior.""", 

 "nfr4":"""
User Experience & Security
- generate code that focuses on Usability, by ease of use, learnability, user satisfaction, and accessibility for all users.
- generate code that focuses on Security, by protecting data, preventing unauthorized access, and ensuring authenticity and accountability.
- generate code that focuses on Compatibility, by operating smoothly with other products and exchanging information correctly.

""",
 "nfr5":"""
 Maintainability & Adaptability
- generate code that focuses on Maintainability, by ease of modification, testing, analysis, and reuse of software components.
- generate code that focuses on Portability, by adapting software to different environments and ensuring smooth installation and replacement
""",
}

def build_user_prompt_uml(uml: str, params: str, return_text: str, nfrs: str)-> str:
    """
    Build a user prompt for the refactoring LLM without any .
    Args:
        the description of the task
    Returns:
        A formatted string prompt for the LLM.
    """
    return f"""

    Your task:
    - Generate a python implementation named `{FUNCTION_NAME}` with the following arguments: {params}. 
    - The implementation must return something based on this text: {return_text}.
    - The implementation must have a single function and should replicate the behavior described in this PlantUML state-machine diagram: {uml}.
    {NFRS[nfrs]}

    {MANDATORY_HINTS}
    """


def build_user_prompt_ast(gen_ast: str, description: str, params: str, return_text: str, nfrs: str)-> str:
    """
    Build a user prompt for the refactoring LLM with AST .
    Args:
        the description of the task
    Returns:
        A formatted string prompt for the LLM.
    """
    return f"""

    Your task:
    - Generate a python implementation named `{FUNCTION_NAME}` with the following arguments: {params}. 
    - The implementation must return something based on this text: {return_text}.
    - The implmentation must implement the following behavior: {description}
    - The implementation abstract syntax tree (AST) should be a different as possible from this one: {gen_ast}
    {NFRS[nfrs]}

    {MANDATORY_HINTS}
    """


def build_user_prompt_minimal(description: str, params: str, return_text: str, nfrs: str)-> str:
    """
    Build a user prompt for the refactoring LLM without any .
    Args:
        the description of the task
    Returns:
        A formatted string prompt for the LLM.
    """
    return f"""

    Your task:
    - Generate a python implementation named `{FUNCTION_NAME}` with the following arguments: {params}. 
    - The implementation must have a single function to address this description: {description}.
    - The implementation must return something based on this text: {return_text}.
    {NFRS[nfrs]}

    {MANDATORY_HINTS}
    """

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


SYSTEM_PROMPT_TO_NL = """You are a code summarizer.
Your task is to read a Python function and explain, in natural language, what the function does.
Be concise but precise, focusing on:
- the purpose of the function
- its parameters and return values
- side effects (file I/O, network, database, etc.)
- important edge cases handled
Do NOT output code, only natural language explanation.
"""

def add_generated_fields(dataset_path, nl_model, llm_opts, n_entries):
    """
    Loads dataset, adds "gen_" fields to each entry, 
    and saves it back to the same file.
    """
    with open(dataset_path, "r", encoding="utf-8") as f:
        data = json.load(f) 
    for i, entry in enumerate(data[:n_entries], 1):
        print(f"[{i}/{n_entries}] Generating gen_ fields for {entry['id']}")
        code = entry["original_code"]
        try:
            #description_nl = code_to_nl_description(code, nl_model, llm_opts)
            requirement = code_to_req(code, nl_model, llm_opts)
            uml = code_to_uml(code, nl_model, llm_opts)
            ast = code_to_ast(code)
           # entry["gen_description"] = description_nl.strip()
            entry["gen_requirement"] = requirement.strip()
            entry["gen_uml"] = uml.strip()
            entry["gen_ast"] = ast.strip()
        except Exception as e:
            print(f"  Error generating for {entry['id']}: {e}")
           # entry["gen_description"] = ""
            entry["gen_requirement"] = ""
            entry["gen_uml"] = ""
            entry["gen_ast"] = ""

    with open(dataset_path, "w", encoding="utf-8") as f:
        json.dump(data, f, indent=2)

    print(f"Updated dataset with gen_ fields in {dataset_path}")

SYSTEM_PROMPT_TRANSLATION = """You are a software developer.
Your task is to translate a Python function to a different programming language: {language}.
Be concise but precise, focusing on:
- the same behavior of the function
- its parameters and return values
- side effects (file I/O, network, database, etc.)
- important edge cases handled
- Do not add print statements
- Do to call the function you generated inside a print statement

 Generate ONLY the code in a single {language} fenced block.   
"""

def build_user_prompt_from_translation(translation: str, language: str, params: list, return_text: str, nfrs: str) -> str:
    return f"""
You are given a function code in {language}.

{translation}

Your task:
- Translate this function to Python
- Implement the function as `{FUNCTION_NAME}` with arguments: {params}.
- The implementation must return something based on this text: {return_text}.
{NFRS[nfrs]}

{MANDATORY_HINTS}
"""

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
    Loads dataset, adds a "gen_translation" field to each entry, 
    and saves it back to the same file.
    """
    with open(dataset_path, "r", encoding="utf-8") as f:
        data = json.load(f) 
    for i, entry in enumerate(data[:n_entries], 1):
        print(f"[{i}/{n_entries}] Generating code translation to {language} for {entry['id']}")
        code = entry["original_code"]
        try:
            java_translation = code_to_code(code, language ,code_model, llm_opts)
            entry["gen_translation"] = java_translation.strip()
        except Exception as e:
            print(f"  Error generating for {entry['id']}: {e}")
            entry["gen_translation"] = "" 

    with open(dataset_path, "w", encoding="utf-8") as f:
        json.dump(data, f, indent=2)

    print(f"Updated dataset with 'gen_translation' in {dataset_path}")

from src.clone_gen import ( 
    build_user_prompt_minimal,
    build_user_prompt_complete,
    generate_clones,
    load_existing_results,
    merge_results,
)

def run_clone_generation(
    dataset_path,
    out_path,
    n_entries,
    clones_per_entry,
    ollama_model,
    llm_opts,
    context,  
    nfrs
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
        nfrs: non-functional requirements used in the prompt
    """
    with open(dataset_path, "r", encoding="utf-8") as f:
        data = json.load(f)

    sample = data[:n_entries]
    results = load_existing_results(out_path)

    for i, entry in enumerate(sample, 1):
        print(f"\nGenerating clones {i}/{len(sample)} for {entry['id']}")
        clones = []

        original_body = entry["original_code"]
        tests_list    = entry["test"]
        description   = entry.get("description", "")
        #gen_description   = entry.get("gen_description", "")
        gen_requirement = entry.get("gen_requirement", "")
        gen_translation = entry.get("gen_translation", "")
        gen_uml = entry.get("gen_uml", "")
        gen_ast = entry.get("gen_ast", "")
        
        tests_snippet = tests_list[0] if tests_list else ""
        params      = entry.get("metadata", {}).get("params", [])
        return_text = entry.get("metadata", {}).get("return_text", [])
        libs = entry.get("metadata", {}).get("libs", [])

        for k in range(clones_per_entry):
            system_prompt = SYSTEM_PROMPT_MINIMAL
            user_prompt = ""
            if context == "minimal":
                user_prompt = build_user_prompt_minimal(description, params, return_text, nfrs)
            
         #   elif context == "description":
          #     user_prompt = build_user_prompt_minimal(gen_description, params, return_text, nfrs)

            elif context == "requirements":
               user_prompt = build_user_prompt_minimal(gen_requirement, params, return_text, nfrs)
               
            elif context == "uml":
               user_prompt = build_user_prompt_uml(gen_uml, params, return_text, nfrs)
            
            elif context == "ast":
               user_prompt = build_user_prompt_ast(gen_ast, description, params, return_text, nfrs)

            elif context == "complete":
                user_prompt = build_user_prompt_complete(original_body, description, libs, tests_snippet, nfrs)
                system_prompt = SYSTEM_PROMPT_COMPLETE

            elif context == "translation":
                user_prompt = build_user_prompt_from_translation(gen_translation, "Java", params, return_text, nfrs) # this will be an iteration with multi languages
                system_prompt = SYSTEM_PROMPT_COMPLETE
                

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
                    "code": code,
                    "nfrs": nfrs,
                    "transformation": f"{ollama_model}-{context} {k+1} {nfrs}",
                })
            except Exception as e:
                print(f" Error generating clone {k+1}: {e}")

        new_entry = {"id": entry["id"], "clones": clones}
        results = merge_results(results, new_entry)

    os.makedirs(os.path.dirname(out_path), exist_ok=True)
    with open(out_path, "w", encoding="utf-8") as f:
        json.dump(results, f, indent=2)
