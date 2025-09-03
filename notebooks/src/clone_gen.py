import re, textwrap, requests, ast, astor
def call_ollama_chat(messages, model, options):
    """
    Call Ollama's /api/chat with role-based messages.
    Returns raw string content from the assistant.
    """
    resp = requests.post(
        "http://localhost:11434/api/chat",
        json={
            "model": model,
            "messages": messages,
            "stream": False,
            "options": options
        },
        timeout=600
    )
    resp.raise_for_status()
    data = resp.json()
    return data["message"]["content"]

def extract_python_code(text: str) -> str:
    """
    Extract the first ```python ... ``` fenced block;
    if none found, return the whole text.
    """
    m = re.search(r"```python\s*(.*?)```", text, flags=re.S)
    if m:
        return m.group(1).strip()
    m = re.search(r"```\s*(.*?)```", text, flags=re.S) 
    return (m.group(1).strip() if m else text.strip())

def force_function_name(code: str, expected="task_func"):
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


# Strategy hints for the refactoring engine
STRATEGY_HINTS = [
    # Keep behavior identical; do shallow refactors
    "- rename locals & args; reorder independent statements; introduce small helper vars; keep library calls and side-effects identical.",
    "- replace simple loops with list/dict comprehensions where safe; adjust arithmetic with equivalent identities; keep signature & imports.",
    "- wrap small expressions into temporary variables; change exception handling style without changing raised exceptions.",
]

# System prompt for the LLM
SYSTEM_PROMPT = """You are a careful Python refactoring engine.
You produce a semantically equivalent variant (Type-4 clone) of the given function.
Rules:
- Output ONLY Python code in a single fenced block.
- Define exactly one function named `task_func` with the correct signature for the tests.
- Keep the same external behavior, side-effects, and library usage (imports allowed).
- Do NOT hardcode any test data or specific URLs or values from tests.
- Keep I/O contract identical (same return types, shapes, and exceptions).
"""

def build_user_prompt(
    original_body: str,
    description: str,
    libs: list,
    tests_snippet: str,
    strategy_hint: str
) -> str:
    """
    Build a user prompt for the refactoring LLM.

    Args:
        original_body: The body of the original function (without 'def' line).
        description: Short textual description of the function's behavior.
        libs: List of allowed/expected libraries.
        tests_snippet: Excerpt of unit tests for the function.
        strategy_hint: One of the STRATEGY_HINTS to guide refactoring.

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
- Emit a semantically equivalent implementation named `task_func`.
- Keep side effects and external calls intact where visible (e.g., urllib/os/json/pandas usage).
- {strategy_hint}

Return ONLY the code in a single ```python fenced block.
"""
