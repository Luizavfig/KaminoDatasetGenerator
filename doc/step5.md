⬅️ [Back to Main README](../README.md)

---

### 5. 🛠️ Repairing Clone Candidates (Optional)

#### Goal
Recover **near-valid clones** that fail some test cases but still exhibit:
- Partial semantic correctness  
- Sufficient syntactic diversity  

Instead of discarding these clones, this step attempts to **fix them efficiently** using LLMs.

---

#### When is Repairing Applied?

Only clones that satisfy:

```
pass_rate ≥ test_threshold
```

are considered for repair.

- `test_threshold` is configurable (e.g., 0.8)
- Clones below this threshold are discarded

---

#### Key Idea

Repairing focuses on:
- **Correcting behavior**, not introducing diversity  
- **Minimal modifications** to existing code  

This ensures we:
- Preserve useful structure  
- Avoid regenerating solutions from scratch  
- Reduce computational cost  

---

#### Repair Strategy

Each candidate clone is reprocessed using LLMs with:
- The current (failing) implementation  
- The full test suite  
- The subset of failing tests  

The model is instructed to **fix the code so all tests pass**.

---

#### Repair Prompt (Concept)

The LLM receives:
- A failing solution  
- Test cases  
- Failing test subset  

And is asked to:
- Modify the solution minimally  
- Ensure all tests pass  
- Preserve function signature and behavior  

---

#### Multi-Model Collaboration

Unlike generation (independent usage), repairing uses **LLMs collaboratively**:

- A clone is repaired using **different models** than the one that generated it  
- Each model attempts repair sequentially  
- Multiple retries are allowed per model  

This leverages complementary strengths across models.

---

#### Repair Algorithm

```
candidates = [clone for clone in clones if pass_rate(clone) ≥ test_threshold]

for clone in candidates:
    success = False

    for model in models:
        if model != clone.original_model:

            for retry in range(MAX_RETRIES):
                new_clone = reprompt(clone, model)
                test_results = run_tests(new_clone)
                codebleu = compute_codebleu(new_clone)

                if all_tests_pass(test_results) and codebleu < threshold:
                    save_clone(new_clone)
                    success = True
                    break

        if success:
            break

    if not success:
        log_failed(clone)
```

---

#### Acceptance Criteria

A repaired clone is accepted only if:

```
all tests pass AND CodeBLEU < threshold
```

This ensures:
- ✅ Semantic correctness  
- ✅ Continued syntactic diversity  

---

#### Important Constraints

- ❌ No additional refactorings are introduced  
- ❌ No diversity-oriented prompting  
- ✅ Focus is strictly on correctness  

---

#### Efficiency Considerations

- Repairing avoids regenerating all clones  
- Only promising candidates are processed  
- Stops early once a valid repair is found  

---

#### Output

- Successfully repaired clones are:
  - Stored separately or merged into the dataset  
  - Marked as **repaired**

- Failed repairs are:
  - Logged for analysis  
  - Not included in the final dataset  

---
 