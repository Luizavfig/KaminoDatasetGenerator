⬅️ [Back to Main README](../README.md)

---
### 2. 🤖 Clone Generation

#### Goal
Generate **behaviorally equivalent but syntactically diverse implementations** (Type-IV clones) of a given source function.

This step is the core of the pipeline and directly impacts:
- **Diversity** of the generated dataset
- **Correctness** of candidate clones

---

#### Key Design Requirements

The generation process is designed to:

1. Ensure **variety** in generated code  
   → expose ML models to multiple implementations of the same behavior  

2. Support **heterogeneous datasets**  
   → handle missing elements such as descriptions or metadata  

---

#### Prompt Configuration

Clone generation is controlled through **prompt configurations**, defined as:
``c = (model, context, strategy, refactorings)``


Each configuration specifies how an LLM should generate a clone.

---

#### Configuration Dimensions

##### 🧩 Context (input to the LLM)

Defines what information is provided:

- `code` → original function  
- `tests` → unit tests only  
- `complete` → code + tests  
- `AST` → abstract syntax tree  

> ⚠️ Contexts are **mutually exclusive**

---

##### 🧠 Prompt Strategy

Defines how the LLM is guided:

- `zero-shot`  
  - Minimal guidance  
  - Produces **higher diversity**

- `CoT` (Chain-of-Thought, optionally few-shot)  
  - Step-by-step reasoning  
  - Improves **correctness**, may reduce diversity  

---

##### 🔧 Refactorings (Diversity Drivers)

Refactorings enforce **syntactic and structural variation** without changing semantics.

Supported refactorings:

1. **Algorithmic shift**  
   - e.g., replace bubble sort with `sorted()`

2. **Library exchange**  
   - e.g., use `collections.deque` instead of list  

3. **Data structure transformation**  
   - e.g., replace parallel lists with dictionary  

4. **Formatting variation**  
   - e.g., indentation, line breaks  

5. **Side-effect isolation**  
   - e.g., separate computation from printing  

6. **Security enhancement**  
   - e.g., add null / boundary checks  

7. **Bad smell introduction**  
   - e.g., long functions, unclear variable names  

> ✅ Multiple refactorings can be combined

---

#### Prompt Template (Code Context Example)

```
You are a Python generation engine. You produce Python code based on the information given.

You will be shown:
1) A short description.
2) The original function.

- Your solution must correspond to this description: {description}
- Example solution (you must not use it): {original_code}

Your task:
- Generate an alternative solution named: {function_name}
- With the following arguments: {params}
- Make sure the syntax and structure of your solution are different from the Example solution BODY
- Your solution must return something based on this text: {return_text}
- To ensure syntactic and structural differences, you MUST: {[refactorings]}
- In addition, make sure that: {mandatory_hints}

{strategy}
```
#### Important Prompting Insight

🚫 Avoid using the word "clone" in prompts. LLMs tend to produce syntactically similar code when explicitly asked for "clones". Using terms like "alternative solution" improves diversity.

#### Handling Missing Data

If some inputs are missing:

* Description → generated from code
* Parameters / return info → inferred from tests

This ensures the pipeline works with incomplete datasets.

#### Post-processing

LLM outputs may contain:

Extra text, Invalid syntax, Incorrect function signatures

We apply post-processing to:

* Extract valid Python code
* Enforce correct function signature
* Remove non-code artifacts

#### Multi-Model Generation
Multiple LLMs can be used in parallel with each model runing across all configurations

This increases the diversity of solutions and robustness of the dataset

#### Output

For each input function, this step produces:

* A set of candidate clones
* Each associated with:
    * prompt configuration
    * model used
    * generated code.

