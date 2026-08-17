# Python → C# Golden Dataset

A small, manually verified subset of [BigCodeBench](https://huggingface.co/datasets/bigcode/bigcodebench)
entries, each translated from Python to C#, with both languages' unit tests
translated and both implementations executed to confirm equivalent observable
behavior. This is a **Golden Dataset** for cross-language (Python↔C#) code
clone research: every entry pairs an original implementation with a manually
verified, behaviorally-equivalent translation, which is exactly the kind of
labeled ground truth that Type-IV cross-language clone detectors need to be
trained or evaluated against.

See [`doc/step7_csharp_translation.md`](../../doc/step7_csharp_translation.md)
for the full methodology (selection rationale, translation approach, test
translation, verification process, and known limitations).

## Structure

```
dataset/golden_dataset_csharp/
├── golden_dataset.json          # consolidated index (all 8 entries)
├── README.md                    # this file
├── _shared/
│   ├── TestHarness.cs           # tiny dependency-free C# assertion helper (no NuGet/xUnit needed)
│   └── verify_all.py            # re-runs every entry's Python + C# tests and rewrites verification.json
└── BigCodeBench_<N>/
    ├── python/
    │   ├── task_func.py         # ORIGINAL, unmodified Python implementation (from dataset/bigcodebench_normalized_filtered.json)
    │   └── test_task_func.py    # ORIGINAL, unmodified Python unittest suite
    ├── csharp/
    │   ├── TaskFunc.cs          # C# translation (heavily commented: every language-specific adaptation is explained inline)
    │   └── TaskFuncTests.cs     # C# tests, translated 1:1 from test_task_func.py (same inputs/outputs/edge cases)
    └── verification.json        # REAL captured results from the last verification run (see below)
```

## Selected entries

| Entry | BigCodeBench ID | Primary construct(s) |
|---|---|---|
| `BigCodeBench_4`    | [BigCodeBench/4](python/../BigCodeBench_4/python/task_func.py)    | Dictionaries / maps |
| `BigCodeBench_297`  | BigCodeBench/297  | Functions with multiple parameters |
| `BigCodeBench_670`  | BigCodeBench/670  | Loops, iteration, nested control flow |
| `BigCodeBench_685`  | BigCodeBench/685  | Lists / collections |
| `BigCodeBench_747`  | BigCodeBench/747  | Basic expressions and arithmetic |
| `BigCodeBench_795`  | BigCodeBench/795  | Conditional logic, dynamic typing, side effects |
| `BigCodeBench_818`  | BigCodeBench/818  | Strings and string manipulation |
| `BigCodeBench_1108` | BigCodeBench/1108 | Nested control flow |

Every entry was picked from the pipeline's own
`dataset/bigcodebench_normalized_filtered.json` (the 927 "easy" BigCodeBench
entries whose original Python code already passes 100% of its own tests, per
`pipeline/src/steps/normalization.py`) -- no example here was invented.

## How to re-verify

```bash
python dataset/golden_dataset_csharp/_shared/verify_all.py
```

This re-runs the real original Python tests (`python <combined file>`) and
re-compiles + re-runs the C# tests (with `csc.exe`, since no .NET SDK is
required — see the note in `doc/step7_csharp_translation.md`), and rewrites
every `verification.json` with fresh, real results.

## Extending the dataset

To add a new entry:
1. Pick an id from `dataset/bigcodebench_normalized_filtered.json`.
2. Create `dataset/golden_dataset_csharp/BigCodeBench_<N>/python/{task_func.py,test_task_func.py}` with the **unmodified** original code/tests.
3. Write `csharp/TaskFunc.cs` and `csharp/TaskFuncTests.cs` (see any existing entry for the expected style: heavily commented adaptations, tests mapped 1:1 from the Python suite).
4. Add the entry's metadata (category, rationale, adaptations) to `ENTRY_METADATA` in `_shared/verify_all.py`.
5. Run `python dataset/golden_dataset_csharp/_shared/verify_all.py` to generate `verification.json`.
6. Rebuild the index: `cd pipeline && python -c "from src.steps.translate_csharp import build_golden_dataset_index; build_golden_dataset_index()"`.
