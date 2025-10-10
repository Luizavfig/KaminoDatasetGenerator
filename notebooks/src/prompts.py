FUNCTION_NAME = "task_func" 
import textwrap



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

SYSTEM_PROMPT_MINIMAL = f"""
You are a Python generation engine.
You produce Python code based on the information given. 
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
- Do not add print() statements to your code
- If needed, library imports should be added before the function definition.
- Generate ONLY the code in a single ```python fenced block.   
- If you cannot generate code, output an empty function stub instead.
"""

NFRS = {
      "nfr0": """
""",
    "nfr1": """
- the generated code must not use any external libraries
""",
  "nfr2": """
- the generated code should use as many external libraries as possible
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

def build_user_prompt_complete(
    strategy: str,
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

{STRATEGIES[strategy]}

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
- Make sure the function follows the following non-functional requirements:
    {NFRS[nfrs]}

In addtion, make sure that:
    {MANDATORY_HINTS}

"""

def build_user_prompt_code(
    strategy: str,
    original_body: str,
    description: str,
    params: str,
    return_text: str,
    nfrs: str
) -> str:
    """
    Build a user prompt to generate type 4 clones.
    Returns:
        A formatted string prompt for the LLM.
    """
    return f"""

{STRATEGIES[strategy]}

You will be shown:
1) A short description.
2) The original function BODY (not including the def line).

Description:
{description}

Original function BODY (indentation represents inside the function):
{textwrap.dedent(original_body).strip()}

Your task:
- Generate a semantically equivalent implementation named `{FUNCTION_NAME}` with the following arguments: {params}. 
- Make sure the syntax and structure of the implementation is as different as possible from the original function BODY.
- The implementation must return something based on this text: {return_text}.
- Make sure the function follows the following non-functional requirements:
    {NFRS[nfrs]}

In addtion, make sure that:
    {MANDATORY_HINTS}

"""

def build_user_prompt_uml(strategy: str, uml: str, params: str, return_text: str, nfrs: str)-> str:
    """
    Build a user prompt for the refactoring LLM without any .
    Args:
        the description of the task
    Returns:
        A formatted string prompt for the LLM.
    """
    return f"""
    {STRATEGIES[strategy]}

    Your task:
    - Generate a python implementation named `{FUNCTION_NAME}` with the following arguments: {params}. 
    - The implementation must return something based on this text: {return_text}.
    - The implementation must have a single function and should replicate the behavior described in this PlantUML state-machine diagram: {uml}.
    Make sure the function follows the following non-functional requirements:
    {NFRS[nfrs]}

    In addtion, make sure that:
    {MANDATORY_HINTS}
    """


def build_user_prompt_ast(strategy: str, gen_ast: str, description: str, params: str, return_text: str, nfrs: str)-> str:
    """
    Build a user prompt for the refactoring LLM with AST .
    Args:
        the description of the task
    Returns:
        A formatted string prompt for the LLM.
    """
    return f"""
    {STRATEGIES[strategy]}

    Your task:
    - Generate a python implementation named `{FUNCTION_NAME}` with the following arguments: {params}. 
    - The implementation must return something based on this text: {return_text}.
    - The implmentation must implement the following behavior: {description}
    - The implementation abstract syntax tree (AST) should be a different as possible from this one: {gen_ast}
    Make sure the function follows the following non-functional requirements:
    {NFRS[nfrs]}

    In addtion, make sure that:
    {MANDATORY_HINTS}
    """


def build_user_prompt_minimal(strategy: str, description: str, params: str, return_text: str, nfrs: str)-> str:
    """
    Build a user prompt for the refactoring LLM without any .
    Args:
        the description of the task
    Returns:
        A formatted string prompt for the LLM.
    """
    return f"""
    {STRATEGIES[strategy]}

    Your task:
    - Generate a python implementation named `{FUNCTION_NAME}` with the following arguments: {params}. 
    - The implementation must have a single function to address this description: {description}.
    - The implementation must return something based on this text: {return_text}.
    - Make sure the function follows the following non-functional requirements:
    {NFRS[nfrs]}

    In addtion, make sure that:
    {MANDATORY_HINTS}
    """

def build_user_prompt_from_translation(strategy: str, translation: str, language: str, params: list, return_text: str, nfrs: str) -> str:
    return f"""
{STRATEGIES[strategy]}

You are given a function code in {language}.

{translation}

Your task:
- Translate this function to Python
- Implement the function as `{FUNCTION_NAME}` with arguments: {params}.
- The implementation must return something based on this text: {return_text}.

Make sure the function follows the following non-functional requirements
{NFRS[nfrs]}

In addtion, make sure that:
{MANDATORY_HINTS}
"""


import textwrap

def build_clone_variation_prompt(
    original_body: str,  
    description: str,
    example_clones: list,
    params: str,  
    return_text: str,      
    nfrs: str,  
) -> str:
    """
    Build a prompt that shows a few existing clones and asks the LLM to generate a new one.
    Returns:
        A formatted string prompt for the LLM.
    """

    examples_text = ""
    for i, clone in enumerate(example_clones, 1):
        examples_text += f"\n### Example {i}\n"
        examples_text += "```python\n" + clone.get("code", "").strip() + "\n```\n"

    return f"""
You are tasked with generating **a new semantically equivalent clone** of the given function.

You will be shown:
1) A short description of the function.
2) The original function BODY.
3) Several existing clones as examples.

Description:
{description} 

Original function BODY (indentation represents inside the function):
{textwrap.dedent(original_body).strip()} 

---

### Existing Example Clones
{examples_text}

---

### Your Task
- Implement a new variation of the function named as `{FUNCTION_NAME}` with arguments: {params}.
- The implementation must return something based on this text: {return_text}.
- It must be semantically equivalent to the original and clones.
- It must be sytactically and structurally different from the original and all clones.
- Make sure the function follows the following non-functional requirements:
    {NFRS[nfrs]}
In addtion, make sure that:
    {MANDATORY_HINTS}
"""


STRATEGIES = {
    "zero-shot": """""",
    "few-shot": """
Here are some examples of what Type-4 (semantic) clones look like.  
Each example shows a description and two different semantically equivalent implementations.
---

Example 1: Compute factorial of a number
Implementation A:
```python
def task_func(n):
    if n == 0 or n == 1:
        return 1
    return n * task_func(n - 1)
Implementation B:
def task_func(n):
    result = 1
    for i in range(2, n + 1):
        result *= i
    return result

Example 2: Check if a string is a palindrome
Implementation A:
def task_func(s):
    return s == s[::-1]
Implementation B:
def task_func(s):
    left, right = 0, len(s) - 1
    while left < right:
        if s[left] != s[right]:
            return False
        left += 1
        right -= 1
    return True

Example 3: Find the maximum element in a list
Implementation A:
def task_func(lst):
    return max(lst)
Implementation B:
def task_func(lst):
    if not lst:
        raise ValueError("Empty list")
    maximum = lst[0]
    for item in lst[1:]:
        if item > maximum:
            maximum = item
    return maximum
""",
"cot": """
Here is an example of a Type-4 (semantic) clone transformation.
The goal is to generate semantically equivalent code (same I/O contract) but with a different implementation style.

Example:
Original code:
def task_func(n):
    if n == 0 or n == 1:
        return 1
    return n * task_func(n - 1)

Now we generated a clone by changing the implementation style. We have to make sure that:

- We compute factorial correctly for all non-negative integers.
- The I/O contract (input: integer n, output: factorial of n) is identical.
- The change is structural (different AST, control flow) but not semantic.
- Since the original used recursion, we can use an iterative approach (with a for loop).

Clone Implementation:
def task_func(n):
    result = 1
    for i in range(2, n + 1):
        result *= i
    return result

Here is another example.
Original code:
def task_func(s):
    return s == s[::-1]

- The original task_func checks whether a string s is equal to its reverse (s[::-1]). This is a palindrome check.
- Instead of slicing with [::-1], Python also provides the reversed() built-in function.
- reversed(s) returns an iterator of the string in reverse order.
- Joining it back into a string with "".join(...) gives the reversed string.

Clone Implementation:
def task_func(s):
    return s == ''.join(reversed(s))

This demonstrates how a Type-4 clone can be generated by changing the syntax and structure of the implementation while preserving its semantics.
You may reason step-by-step internally to produce a correct implementation.
DO NOT output your internal reasoning. Output ONLY the final code snippet (see instructions below).
"""
}

context_builders = { # add more builders to extend the supported contexts
    "minimal": lambda **kwargs: (
        SYSTEM_PROMPT_MINIMAL,
        build_user_prompt_minimal(kwargs["strategy"], kwargs["description"], kwargs["params"], kwargs["return_text"], kwargs["nfrs"])
    ),
    "requirements": lambda **kwargs: (
        SYSTEM_PROMPT_MINIMAL,
        build_user_prompt_minimal(kwargs["strategy"], kwargs["gen_requirement"], kwargs["params"], kwargs["return_text"], kwargs["nfrs"])
    ),
    "uml": lambda **kwargs: (
        SYSTEM_PROMPT_MINIMAL,
        build_user_prompt_uml(kwargs["strategy"], kwargs["gen_uml"], kwargs["params"], kwargs["return_text"], kwargs["nfrs"])
    ),
    "ast": lambda **kwargs: (
        SYSTEM_PROMPT_MINIMAL,
        build_user_prompt_ast(kwargs["strategy"], kwargs["gen_ast"], kwargs["description"], kwargs["params"], kwargs["return_text"], kwargs["nfrs"])
    ),
    "code": lambda **kwargs: (
        SYSTEM_PROMPT_MINIMAL,
        build_user_prompt_code(kwargs["strategy"], kwargs["original_body"], kwargs["description"], kwargs["params"], kwargs["return_text"], kwargs["nfrs"])
    ),
    "complete": lambda **kwargs: (
        SYSTEM_PROMPT_COMPLETE,
        build_user_prompt_complete(kwargs["strategy"], kwargs["original_body"], kwargs["description"], kwargs["libs"], kwargs["tests_snippet"], kwargs["nfrs"])
    ),
    "translation": lambda **kwargs: (
        SYSTEM_PROMPT_COMPLETE,
        build_user_prompt_from_translation(kwargs["strategy"], kwargs["gen_translation"], "Java", kwargs["params"], kwargs["return_text"], kwargs["nfrs"])
    )   
    
}
