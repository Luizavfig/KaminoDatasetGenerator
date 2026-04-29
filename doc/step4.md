⬅️ [Back to Main README](../README.md)

---

### 4. 🧪 Semantic Testing

#### Goal
Ensure that generated clones are **behaviorally equivalent** to the original implementation.

This step validates that each clone preserves the intended functionality, which is essential for qualifying as a **Type-IV clone**.

---

#### Key Requirement

- ✅ The dataset must include **executable unit tests**

> ⚠️ Test cases are the **only mandatory artifact** required by the pipeline.  
Without tests, semantic equivalence cannot be verified automatically.

---

#### Approach

Each clone that passes syntactic filtering is evaluated using **automated test execution**.

For every clone:

1. A dedicated test file is generated  
2. The clone replaces the original implementation  
3. All unit tests are executed  
4. Results are recorded  

---

#### Execution Workflow

```
for each clone:
    generate_test_file(clone)
    results = run_tests(clone)
    pass_rate = compute_pass_rate(results)
```

---

#### Test Outcomes

Each clone falls into one of three categories:

- ✅ **Pass all tests**
  - Clone is considered **semantically equivalent**
  - Passed to the next stage

- ⚠️ **Partial pass**
  - Clone is **partially correct**
  - Becomes a candidate for the **repairing step**

- ❌ **Fail all (or most) tests**
  - Clone is discarded

---

#### Pass Rate Definition

The pass rate is defined as:

```
pass_rate = (# passed tests) / (total # tests)
```

This metric is used to:
- Determine semantic correctness  
- Identify candidates for repair  

---

#### Semantic Filtering Rule

```
if pass_rate == 1.0:
    accept clone
elif pass_rate ≥ test_threshold:
    send to repairing
else:
    discard clone
```

- `test_threshold` is configurable (e.g., 0.8)

---

#### Test Isolation

To ensure reliable execution:

- Each clone is tested **independently**
- No shared state between executions
- Environment is reset per run (if needed)

---

#### Output

Each clone is enriched with:
- `test_results`
- `pass_rate`

Only clones that:
- Pass all tests  
- or qualify for repair  

are forwarded to the next stage.

---