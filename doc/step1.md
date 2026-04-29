⬅️ [Back to Main README](../README.md)

---

### 1. 📦 Normalization

#### Goal
Standardize heterogeneous datasets into a unified representation.

#### Required input
- ✔ Unit tests (**mandatory**)

#### Optional input
- Source code  
- Natural language description  
- Metadata (parameters, return values)

#### Processing
- Extract:
  - function code
  - test cases
  - description
  - parameters / return info
- Generate **AST representation**
- Infer missing fields using LLMs:
  - description ← code
  - parameters / return ← tests

#### Output schema
```json
{
  "id": "task_id",
  "code": "...",
  "tests": "...",
  "description": "...",
  "params": ["..."],
  "return": "...",
  "ast": "...",
  "metadata": {}
}
```