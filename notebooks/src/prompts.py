FUNCTION_NAME = "task_func" 
import textwrap


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
Your task is to read a Python function and elicit requirements that represent it.
Be concise but precise, focusing on:
- The function signature (including params)
- return values
- important edge cases handled
Do NOT output code, only requirements definition.
"""

SYSTEM_PROMPT_TO_UML = """You are a UML engineer.
Your task is to read a Python function and create a state-machine diagram in PlanUML that represents it.
Be concise but precise, focusing on:
- The behavior of the function
- Type of Input
- Type of output
- Important edge cases handled
- Avoid using library or function-specific names
- Try to make the diagram in a generic way
Do NOT output code or text, only the PlantUML state-machine.
"""

SYSTEM_PROMPT_MINIMAL = f"""
You are a Python generation engine.
You produce Python code based on the information given. 
"""



SYSTEM_PROMPT_COMPLETE = f"""You are a careful Python refactoring engine.
You produce an alternative solution to the given function.
Rules:
- Output ONLY Python code in a single fenced block.
- Define exactly one function named `{FUNCTION_NAME}` with the correct signature for the tests.
- Keep the same external behavior, side effects.
- Do NOT hardcode any test data or specific URLs or values from tests.
- Keep I/O contract identical (same return types, shapes, and exceptions).
"""

MANDATORY_HINTS = """
- Do NOT output explanations, reasoning, or any text, **only valid Python code**
- Do NOT add default values to function parameters
- Do NOT add comments or multiline comments to the function 
- Do NOT add **print()** statements to your code
- If needed, library imports should be added before the function definition.
- Generate ONLY the code in a single ```python``` fenced block. 
- If you cannot generate code, output an empty function stub instead.
"""

REFACTORING = {
  "refac_1": ( # Algorithmic reimplementation
    "Generate a Python function to achieve the same behavior using a different algorithmic strategy. You may use built-in Python functions, comprehensions, or alternative logic constructs."
 ),

  "refac_2": ( # Library exchange
    "Generate an alternative solution using different Python libraries. None of the libraries from the example solution should be used."
 ),

  "refac_3": ( # Data representation shift
    "Generate an alternative solution using different data structures or representations. For example, replace lists with dictionaries, tuples, or sets where appropriate."
 ),

  "refac_4": ( # Stylistic and formatting variation
    "Generate an alternative solution with a different coding style and layout. Change indentation, whitespace, comment placement, and formatting. You should add docstrings or rearrange statements."
 ),

  "refac_5": ( # Side-effect isolation and purity
    "Generate an alternative solution that isolates side effects (e.g., I/O operations, state mutations) from pure computations. You should refactor the function to separate concerns."
 ),

  "refac_6": ( # Security and robustness enhancement
    "Generate an alternative solution that enhances security and robustness. You may add input validation, error handling, or logging."
 ),

  "refac_7": ( # Bad smells
    "Generate an alternative solution that introduces common 'bad smells' in code, such as long methods, duplicated code, or others."
 )
}

def build_user_prompt_test(
 strategy: str, 
 description: str,
 tests_snippet: str,
 params: str,
 return_text: str, 
 refacs: list[str],
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
1) A short description of the task.
2) An excerpt of the unit tests.

Your task:
- Generate a solution named `{FUNCTION_NAME}` with the following arguments: {params}. 
- Your solution must PASS all these unit tests:
```
{textwrap.dedent(tests_snippet).strip()}
```
- Your solution must correspond to this description: {description}.
- Your solution must return something based on this text: {return_text}.
- To ensure syntactic and structural differences, you MUST:
  {get_combined_refacs(refacs)}


- In addition, make sure that:
 {MANDATORY_HINTS}

{STRATEGIES[strategy]}
"""



def build_user_prompt_complete(
 strategy: str,
 original_body: str,
 description: str, 
 tests_snippet: str, 
 refacs: list[str],
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
1) A short description and a possible solution.
2) An excerpt of the unit tests.

Your task:
- Generate an alternative solution named `{FUNCTION_NAME}.
- Your solution must correspond to this description: {description}.
- To ensure syntactic and structural differences, you MUST:
{get_combined_refacs(refacs)}
- Your solution must PASS all these unit tests:
```
{textwrap.dedent(tests_snippet).strip()}
```
- Example solution (you must not use it):
```
{textwrap.dedent(original_body).strip()}
```

- In addition, make sure that:
 {MANDATORY_HINTS}
{STRATEGIES[strategy]}
"""

def build_user_prompt_code(
 strategy: str,
 original_body: str,
 description: str,
 params: str,
 return_text: str,
 refacs: list[str],
) -> str:
 """
 Build a user prompt to generate type 4 clones.
 Returns:
 A formatted string prompt for the LLM.
 """

 return f"""

You will be shown:
1) A short description.
2) The original function.

- Your solution must correspond to this description: {description}.
- Example solution (you must not use it):
```
{textwrap.dedent(original_body).strip()}
```
Your task:
- Generate an alternative solution named `{FUNCTION_NAME}` with the following arguments: {params}. 
- Make sure the syntax and structure of your solution are as different as possible from the Example solution BODY.
- Your solution must return something based on this text: {return_text}.
- To ensure syntactic and structural differences, you MUST:
{get_combined_refacs(refacs)}

- In addition, make sure that:
 {MANDATORY_HINTS}

{STRATEGIES[strategy]}
"""


def build_user_prompt_ast(strategy: str, original_body: str, gen_ast: str, description: str, params: str, return_text: str,refacs: list[str])-> str:
 """
 Build a user prompt for the refactoring LLM with AST.
 Args:
 the description of the task
 Returns:
 A formatted string prompt for the LLM.
 """
 return f"""
 You will be shown:
1) A short description.
2) An example solution.

- Your solution must correspond to this description: {description}.
- Example solution (you must not use it):
```
{textwrap.dedent(original_body).strip()}
```

Your task:
- Generate an alternative solution named `{FUNCTION_NAME}` with the following arguments: {params}. 
- Your solution must return something based on this text: {return_text}.
- Make sure the syntax and structure of your solution are as different as possible from the Example solution BODY.
- For that, generate an alternative solution with an AST that is as different as possible from this: {gen_ast}.
- To ensure syntactic and structural differences, you MUST:
{get_combined_refacs(refacs)}

- In addition, make sure that:
 {MANDATORY_HINTS}

{STRATEGIES[strategy]} 
 """
def build_user_prompt(strategy: str, prompt: str,refacs: list[str])-> str:
 """
 Build a user prompt for the refactoring LLM with complete_prompt from bigcodebench.
 """
 return f"""

 Your task:
 - Generate a Python solution named `{FUNCTION_NAME}`. 
 - For that, consider the following complete details:
{prompt}

- To ensure syntactic and structural differences, you MUST:
{get_combined_refacs(refacs)}

 - In addition, make sure that:
 {MANDATORY_HINTS}

{STRATEGIES[strategy]}
 """


def build_user_prompt_minimal(strategy: str, description: str, params: str, return_text: str)-> str:
 """
 Build a user prompt for the refactoring LLM with minimal context.
 Args:
 the description of the task
 Returns:
 A formatted string prompt for the LLM.
 """
 return f"""

 Your task:
 - Generate a python solution named `{FUNCTION_NAME}` with the following arguments: {params}. 
 - Your solution must correspond to this description: {description}.
 - Your solution must return something based on this text: {return_text}.

 - In addition, make sure that:
 {MANDATORY_HINTS}

{STRATEGIES[strategy]}
 """

def build_user_prompt_from_translation(strategy: str, translation: str, language: str, params: list, return_text: str) -> str:
 return f"""
You are given a function code in {language}.

{translation}

Your task:
- Translate this function to Python
- Implement the function as `{FUNCTION_NAME}` with arguments: {params}.
- The solution must return something based on this text: {return_text}.


- In addition, make sure that:
{MANDATORY_HINTS}


{STRATEGIES[strategy]}
"""


import textwrap

def build_clone_variation_prompt(
 original_body: str, 
 description: str,
 example_clones: list,
 params: str, 
 return_text: str,  
) -> str:
 """
 Build a prompt that shows a few existing clones and asks the LLM to generate a new one.
 Returns:
 A formatted string prompt for the LLM.
 """

 examples_text = ""
 for i, clone in enumerate(example_clones, 1):
  examples_text += f"\n### Example {i}\n"
  examples_text += "```\n" + clone.get("code", "").strip() + "\n```\n"

 return f"""
You are tasked with generating **a new semantically equivalent clone** of the given function.

You will be shown:
1) A short description of the function.
2) The original function BODY.
3) Several existing clones as examples.

- Your solution must correspond to this description: {description}.

Original function BODY (indentation represents inside the function):
{textwrap.dedent(original_body).strip()} 

---

### Existing Example Clones
{examples_text}

---

### Your Task
- Implement a new variation of the function named `{FUNCTION_NAME}` with arguments: {params}.
- The solution must return something based on this text: {return_text}.
- It must be semantically equivalent to the original and clones.
- It must be syntactically and structurally different from the original and all clones.
- In addition, make sure that:
 {MANDATORY_HINTS}
"""


STRATEGIES = {
 "zero-shot": """""",
 "few-shot": """
Here are some examples of how to create alternative solutions in Python. 
Each example shows a description and two different semantically equivalent solutions.
---

Example 1: Compute the factorial of a number
```
# solution A:
def task_func(n):
 if n == 0 or n == 1:
 return 1
 return n * task_func(n - 1)

# solution B:
def task_func(n):
 result = 1
 for i in range(2, n + 1):
 result *= i
 return result
``` 
Example 2: Check if a string is a palindrome
```
# solution A:
def task_func(s):
 return s == s[::-1]

# solution B:
def task_func(s):
 left, right = 0, len(s) - 1
 while left < right:
 if s[left] != s[right]:
 return False
 left += 1
 right -= 1
 return True
``` 

Example 3: Find the maximum element in a list
```
# solution A:
def task_func(lst):
 return max(lst)
# solution B:
def task_func(lst):
 if not lst:
 raise ValueError("Empty list")
 maximum = lst[0]
 for item in lst[1:]:
 if item > maximum:
 maximum = item
 return maximum
``` 
""",
"cot": """
Here are some examples of how to create alternative solutions in Python. 
Example:
```
# Original code: compute factorial correctly for all non-negative integers
def task_func(n):
 if n == 0 or n == 1:
 return 1
 return n * task_func(n - 1)
```
Now we generate an alternative solution by changing the implementation style. We have to make sure that:
- The I/O contract (input: integer n, output: factorial of n) is identical.
- The change is structural (different AST, control flow) but not semantic.
- Since the original used recursion, we can use an iterative approach (with a for loop).

Alternative solution:
```
# Alternative solution: checks whether a string s is equal to its reverse (s[::-1]). This is a palindrome check.
def task_func(n):
 result = 1
 for i in range(2, n + 1):
 result *= i
 return result
```
Here is another example.
```
# Original code:
def task_func(s):
 return s == s[::-1]
```
Now we generate an alternative solution by changing the implementation style. We have to make sure that:
- Instead of slicing with [::-1], Python also provides the reversed() built-in function.
- reversed(s) returns an iterator of the string in reverse order.
- Joining it back into a string with "".join(...) gives the reversed string.

Alternative solution:
```
# Alternative solution:
def task_func(s):
 return s == ''.join(reversed(s))
```

You may reason step-by-step internally to produce a correct solution.
DO NOT output your internal reasoning. Output ONLY the final code snippet (see instructions below).
"""
}

context_builders = { # add more builders to extend the supported contexts
 "minimal": lambda **kwargs: (
  SYSTEM_PROMPT_MINIMAL,
  build_user_prompt_minimal(kwargs["strategy"], kwargs["description"], kwargs["params"], kwargs["return_text"])
 ), 
 "ast": lambda **kwargs: (
  SYSTEM_PROMPT_MINIMAL,
  build_user_prompt_ast(kwargs["strategy"], kwargs["original_body"], kwargs["gen_ast"], kwargs["description"], kwargs["params"], kwargs["return_text"], kwargs["refacs"])
 ),
 "code": lambda **kwargs: (
  SYSTEM_PROMPT_MINIMAL,
  build_user_prompt_code(kwargs["strategy"], kwargs["original_body"], kwargs["description"], kwargs["params"], kwargs["return_text"], kwargs["refacs"])
 ),
 "complete": lambda **kwargs: (
  SYSTEM_PROMPT_COMPLETE,
  build_user_prompt_complete(kwargs["strategy"], kwargs["original_body"], kwargs["description"], kwargs["tests_snippet"], kwargs["refacs"])
 ),
"test": lambda **kwargs: (
    SYSTEM_PROMPT_MINIMAL,
  build_user_prompt_test(kwargs["strategy"], kwargs["description"], kwargs["tests_snippet"], kwargs["params"], kwargs["return_text"], kwargs["refacs"])
 ),
 "translation": lambda **kwargs: (
  SYSTEM_PROMPT_COMPLETE,
  build_user_prompt_from_translation(kwargs["strategy"], kwargs["gen_translation"], "Java", kwargs["params"], kwargs["return_text"])
 ), 
"prompt": lambda **kwargs: (
  SYSTEM_PROMPT_MINIMAL,
  build_user_prompt(kwargs["strategy"], kwargs["complete_prompt"])
 ),
 
}


def get_combined_refacs(refacs: list[str]) -> str:
 combined_refacs = "\n".join([f"- {REFACTORING[key]}" for key in refacs if key in REFACTORING])
 return combined_refacs