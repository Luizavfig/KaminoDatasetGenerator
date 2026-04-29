⬅️ [Back to Main README](../README.md)

---
### 3. 🔍 Syntactic Filtering

#### Goal
Remove generated clones that are **too similar to the original implementation**, ensuring that only **true Type-IV clones** (i.e., syntactically different but semantically equivalent) are retained.

This step prevents the inclusion of:
- Type I clones (identical code)
- Type II clones (renamed variables)
- Type III clones (minor edits)

---

#### Approach

We apply a **CodeBLEU-based similarity filter** immediately after clone generation.

Each generated clone is compared to the original function, and a similarity score is computed.

---

#### CodeBLEU Metric

We use a **restricted version of CodeBLEU** focused on syntactic similarity:

Included components:
- **n-gram match** → token-level similarity  
- **weighted n-gram match** → emphasizes keywords  
- **syntax match** → based on AST structure  

Excluded component:
- ❌ **data-flow match** (semantic information)

> 🎯 Rationale: We want to measure **structural similarity**, not semantic similarity.

---

#### Filtering Rule

```
if CodeBLEU(clone, original) > threshold:
    discard clone
```
* threshold (θ) is a configurable parameter
* Higher values → stricter filtering
* Lower values → more permissive (less diversity)

#### Comparison Scope
* Only the function body is compared
* Function signatures are excluded (they are fixed across clones)

---
### Edge Case: Missing Original Code

If the dataset does not include the original implementation:

* This step is skipped
* Syntactic diversity is enforced later during Representative Selection (Clustering)

#### Output

Each clone is enriched with codebleu_score as in CodeBLEU ≤ threshold are passed to the next stage (Semantic Testing).