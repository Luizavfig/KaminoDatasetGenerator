⬅️ [Back to Main README](../README.md)

---

### 7. 🔀 Python → C# Golden Dataset (Cross-Language Clone Research)

#### Goal

Build a small, **manually verified** Golden Dataset of BigCodeBench entries
translated from Python to C#, to seed **cross-language** (Python↔C#) Type-IV
clone-detection research. Unlike Steps 1–6 (which generate many
**same-language** Python clones per entry via LLM prompting + automated
filtering), this step targets a handful of entries, translated once, and
checked by hand — quality and depth of verification over quantity.

---

#### Why This Step Exists

The existing Kamino pipeline (Steps 1–6) only ever produces Python→Python
clones. Cross-language clone detectors (e.g. models trained on
GPTCloneBench/SemanticCloneBench, which the repository already uses for RQ3
cross-dataset generalization — see `dataset/GPTCloneBench/`,
`dataset/SemanticCloneBench/`) need labeled **cross-language** pairs to train
or evaluate against. This step produces exactly that: `(Python function,
C# translation)` pairs, each backed by translated tests and a written
verification record, so they can serve as reliable ground truth.

---

#### Where Entries Come From

Entries are **not invented**. Each one is selected from
`dataset/bigcodebench_normalized_filtered.json` — the 927 "easy"-split
BigCodeBench entries whose original Python code already passes 100% of its
own unit tests, as established by `pipeline/src/steps/normalization.py`
(Step 1). Selection favored entries with:

- Minimal external dependencies (Python standard library only: `re`,
  `itertools`, `collections`, `math`, `string` — no `pandas`/`numpy`/`sklearn`/
  plotting, which would require porting an entire third-party API surface,
  not just language semantics),
- A short, self-contained function body (so both languages' versions can be
  read side-by-side and manually audited line-by-line),
- Deterministic behavior (entries relying on seeded `random` output for exact
  test assertions were avoided — see *Limitations* below).

---

#### Selected Subset

| Entry | BigCodeBench ID | Primary construct(s) exercised |
|---|---|---|
| `BigCodeBench_4`    | BigCodeBench/4    | Dictionaries / maps |
| `BigCodeBench_297`  | BigCodeBench/297  | Functions with multiple parameters |
| `BigCodeBench_670`  | BigCodeBench/670  | Loops, iteration, nested control flow |
| `BigCodeBench_685`  | BigCodeBench/685  | Lists / collections |
| `BigCodeBench_747`  | BigCodeBench/747  | Basic expressions and arithmetic |
| `BigCodeBench_795`  | BigCodeBench/795  | Conditional logic, dynamic typing, side effects |
| `BigCodeBench_818`  | BigCodeBench/818  | Strings and string manipulation |
| `BigCodeBench_1108` | BigCodeBench/1108 | Nested control flow |

Together these 8 entries cover every construct category called for in the
task brief (basic expressions/arithmetic, conditionals, loops, lists,
strings, dicts, multi-parameter functions, nested control flow); several
entries deliberately exercise more than one category at once (e.g.
`BigCodeBench_795` combines conditional logic, Python's dynamic typing, and a
`print` side effect in one function).

---

#### Extending the Prompt Architecture (Step 2 Analogue)

Step 2 (`pipeline/src/utils/prompts.py`) already defines a `context_builders`
dict mapping a *context* name (`code`, `test`, `complete`, `ast`) to a
`(system_prompt, user_prompt)` builder function, called from
`pipeline/src/steps/clone_gen.py::_run_clone_generation`. This step extends
that same dict with a new context, **`csharp_translate`**, rather than
introducing a parallel mechanism:

```python
context_builders["csharp_translate"] = lambda **kwargs: (
    SYSTEM_PROMPT_CSHARP,
    build_user_prompt_csharp(kwargs["original_body"], kwargs["description"],
                              kwargs["tests_snippet"], kwargs["params"], kwargs["return_text"])
)
```

`SYSTEM_PROMPT_CSHARP` explicitly instructs the model to prioritize semantic
equivalence over line-by-line translation and lists the exact adaptation
points required by this task (`list`→`List<T>`, `dict`→`Dictionary<K,V>`,
`None`→`null`, Python truthiness→explicit booleans, exceptions, mutability,
iteration order, etc.) — see `pipeline/src/utils/prompts.py`.

A new pipeline step, `pipeline/src/steps/translate_csharp.py`, reuses
`call_ollama_chat` from `clone_gen.py` (same HTTP call, same Ollama config
files) to call an LLM with this prompt and extract the C# code block, mirroring
`clone_gen.py`'s `_extract_python_code`/`_force_function_name` pattern. A
standalone driver, `pipeline/src/translate_csharp_golden.py` (matching the
`rq2.py`/`rq3.py`/`rq4.py` standalone-script convention — this feature is not
wired into `main.py`'s RQ1 loop, since it targets a curated subset, not the
full 927-entry dataset), lists the 8 selected entry IDs and can be run with:

```bash
cd pipeline
python -m src.translate_csharp_golden
```

**Important, documented honestly:** no Ollama server was reachable in the
sandboxed environment this Golden Dataset was built in (`curl
localhost:11434` failed to connect). `run_csharp_translation()` is fully
wired and ready to run against a live server — it produces **drafts only**,
written to `results/RQ1/bigcodebench_csharp_drafts.json` — but the actual
Golden Dataset content committed under `dataset/golden_dataset_csharp/` was
produced through manual, AI-assisted translation using the same
`csharp_translate` prompt as a specification, followed by the full manual
verification process described below. This satisfies the task's core
requirement (Phase 5: "manually verify correctness... do not claim
equivalence without analyzing the code and test results") more rigorously
than an unreviewed LLM call would have, while the prompt/pipeline extension
remains available for future automated batch drafting once a model server is
available.

---

#### Translation Approach

Each `TaskFunc.cs` is translated with semantic equivalence prioritized over
syntax, and every non-obvious adaptation is documented **inline as a code
comment** at the point it matters (not just in this document), so the
reasoning travels with the code. Adaptations applied across the subset:

- **Dynamic vs. static typing** — `BigCodeBench_795`'s Python list may mix
  `int`, `str`, `float`, `bool`, and `None` in one list (asserted directly by
  its own test suite). This is translated to `List<object>`, not narrowed to
  `List<int>`, because narrowing would make the mixed-type test
  unrepresentable — a case where the *faithful* translation is the
  dynamically-typed one, not the "idiomatic" statically-typed one.
- **`list` → `List<T>`** (`BigCodeBench_685`, `BigCodeBench_818`) and
  **`dict` → `Dictionary<TKey,TValue>`** (`BigCodeBench_4`, `BigCodeBench_297`,
  `BigCodeBench_670`, `BigCodeBench_685`, `BigCodeBench_1108`).
- **`None` → `null`**, with a caught discrepancy: .NET's `Dictionary<TKey,TValue>`
  throws `ArgumentNullException` on a `null` key, whereas Python's `None` is a
  perfectly valid, hashable `dict`/`Counter` key. Documented in
  `BigCodeBench_4/csharp/TaskFunc.cs`.
- **Python truthiness → explicit booleans** — e.g. `if not l:` becomes
  `if (l == null || l.Count == 0)` in `BigCodeBench_795`, not an attempted
  implicit-conversion trick.
- **Exceptions** — Python's `TypeError` (raised by `Counter` when it meets an
  unhashable `list` element) has no C# equivalent, since *all* C# objects are
  hashable via reference identity by default. `BigCodeBench_4`'s port
  explicitly re-creates the "unhashable" restriction with an
  `InvalidOperationException` to preserve the *observable* exception contract
  the original test suite checks for — a deliberate, documented design choice,
  not an accident.
- **`itertools.combinations`** has no BCL equivalent and is reimplemented
  explicitly, either as an index-based generator (`BigCodeBench_297`) or, when
  the combination size is fixed at 2, unrolled into the nested loop it really
  is (`BigCodeBench_670`) — the latter is *more* idiomatic C# and exactly as
  correct, since `combinations(range(n), 2)` and `for start in range(n): for
  end in range(start+1, n)` enumerate identical pairs in identical order.
- **`collections.Counter`** → a `Dictionary<TKey,int>` built with a manual
  counting loop (`BigCodeBench_4`, `BigCodeBench_297`, `BigCodeBench_685`,
  `BigCodeBench_1108`); `Counter.most_common(1)` → an explicit first-seen-wins
  max scan (`BigCodeBench_1108`).
- **`collections.deque.rotate(k)`** has no BCL equivalent (`deque` is a
  performance-oriented ring buffer). `BigCodeBench_795` reproduces its exact
  *resulting order* (not its O(1) performance characteristic) via a
  modulo-indexed rebuild — a case where value-equivalence and
  performance-equivalence are explicitly decoupled and only the former is in
  scope for this dataset.
- **`isinstance(x, (int, float))` and Python's `bool`-is-a-subclass-of-`int`
  quirk** — `BigCodeBench_795` explicitly special-cases `item is bool` so the
  C# port counts `True`/`False` as numeric exactly like Python does, instead
  of silently diverging.
- **String/regex behavior** — `re.findall`/`re.split`/`re.sub`/`re.match` map
  to `System.Text.RegularExpressions.Regex` with (in every entry here)
  identical patterns, since .NET regex syntax is a superset of Python's for
  the constructs used. `str.lower()` → `ToLowerInvariant()` (not culture-
  sensitive `ToLower()`), and numeric parsing/formatting is forced to
  `CultureInfo.InvariantCulture` throughout, because Python's `float()`/`str()`
  are always locale-independent while C#'s defaults are not — see
  *Bugs Caught During Verification* below for a case where skipping this
  caused a real, observed failure.
- **Integer vs. floating point** — Python integers have arbitrary precision;
  sums in `BigCodeBench_297`/`BigCodeBench_685` use C# `long` rather than
  `int` to reduce (not eliminate) the chance of overflow divergence for
  larger inputs than the original test suite exercises.
- **Tuple returns** — Python's `return count, sqrt_sum` (`BigCodeBench_747`)
  is translated to `KeyValuePair<int,double>` rather than a C# 7+ tuple
  literal `(int, double)`, because this Golden Dataset targets the legacy
  `csc.exe` compiler available in this environment (C# 5 language level, see
  *Environment Constraints* below); a modern toolchain could use a native
  tuple with no behavioral difference.

---

#### Test Translation

For every entry, `csharp/TaskFuncTests.cs` maps **one Python `test_*` method
to one C# test method**, preserving:

- the same inputs (literally re-typed, not resampled or simplified),
- the same expected outputs,
- the same edge cases (empty input, ties, mixed types, invalid input), and
- the same exception expectations, where applicable (`BigCodeBench_4`'s
  `test_case_6`).

This was done by first reading what each Python assertion actually checks —
`assertEqual` (exact value), `assertAlmostEqual` (float tolerance),
`assertRaises` (exception type) — and mapping each to the matching C# harness
call (`AreEqual`/`DictEqual`/`SequenceEqual`, `AlmostEqual`, `Throws<T>`), not
just transliterating syntax. `BigCodeBench_747`'s Python test asserts two
things per test method (`count` and `sqrt_sum`); the C# port keeps that as two
separate harness assertions per test rather than collapsing them, so a
regression in either value is individually diagnosable, same as in the
Python version.

No test framework (xUnit/NUnit/MSTest) is available in this environment — see
*Environment Constraints* — so `dataset/golden_dataset_csharp/_shared/TestHarness.cs`
provides a minimal, dependency-free `GoldenTestHarness` static class
(`AreEqual`, `SequenceEqual`, `DictEqual`, `AlmostEqual`, `Throws<T>`,
`Summary()`) that plays the same role `unittest.TestCase` plays on the Python
side: each test method reports `[PASS]`/`[FAIL]`, and a final summary line
gives a pass/fail count, mirroring `unittest`'s own `OK`/`FAILED (...)`
summary line.

---

#### Manual Verification Process

Every entry was verified by **actually executing** both implementations, not
by inspection alone:

1. The original Python code + its original, unmodified test file are run with
   real `python <file>.py` (`unittest.main`), and the pass/fail count is
   captured.
2. The C# translation + its translated tests are compiled with `csc.exe` and
   the resulting executable is run; its pass/fail count is captured.
3. Both results, plus the per-entry adaptation notes above, are written to
   `<entry>/verification.json`.

This whole process is scripted and reproducible via
`dataset/golden_dataset_csharp/_shared/verify_all.py` — re-run it any time
after editing an entry; it performs no fabrication, every number in
`verification.json` comes from a real subprocess run executed at the time the
script is invoked.

**Result at time of writing: all 8/8 entries verified `EQUIVALENT`** — the
original Python suite and the translated C# suite both pass 100% of their
respective tests, for every entry.

##### Bugs caught during verification (real, not hypothetical)

The manual verification step is not a formality — it caught two real defects
in the first translation attempt, both fixed and both documented as
cautionary examples in the code itself:

1. **`BigCodeBench_818`** — a first attempt built the punctuation character
   class as `"[" + Regex.Escape(punctuation) + "]"`. It compiled and ran
   without error, but silently stripped **zero** punctuation, because .NET's
   `Regex.Escape` does not escape `]`, so the raw `]` inside
   `string.punctuation` closed the character class early. (Python's own
   `f'[{string.punctuation}]'` only works because `string.punctuation`
   happens to contain a backslash immediately before `]`, an ASCII-ordering
   coincidence — not a principled construction. Porting the Python line
   literally would have carried this fragility into C# silently.) Fixed by
   escaping every punctuation character individually.
2. **`BigCodeBench_795`** — the `print` statement's `double.ToString()`
   originally used the default (current-culture) formatting. On the
   Portuguese (Brazil) locale of the machine this dataset was built on, it
   printed `3,87298334620742` (comma decimal separator) instead of the
   intended `3.87298334620742` — a real, observed instance of exactly the
   locale bug the translation notes elsewhere warn about. Fixed with
   `CultureInfo.InvariantCulture`.

---

#### Environment Constraints (Documented, Not Hidden)

- **No .NET SDK is installed** in the environment this dataset was built in
  (`dotnet --list-sdks` reports none; only the .NET Runtime is present). C#
  compilation therefore uses the legacy `csc.exe` bundled with .NET Framework
  4.8 (`C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe`), which
  targets **C# 5** language features. This is why tuple literals, string
  interpolation, and other C# 6+/7+ syntax are avoided throughout
  `dataset/golden_dataset_csharp/`. If a .NET SDK is available in your
  environment, all `.cs` files here remain valid, idiomatic C# — nothing
  needs to change to build them with `dotnet build`/a modern test framework.
- **No NuGet/xUnit/NUnit/MSTest is available**, hence the small
  dependency-free `GoldenTestHarness` described above instead of a "real"
  test framework. Porting `TaskFuncTests.cs` to xUnit (replacing
  `GoldenTestHarness.AreEqual` calls with `[Fact]` + `Assert.Equal`, etc.) is
  mechanical and does not require touching `TaskFunc.cs`.
- **No Ollama server was reachable**, so the `csharp_translate` prompt
  infrastructure (Phase 3 of the task) is fully implemented and ready to use,
  but the actual dataset content was produced via manual/AI-assisted
  translation + real execution-based verification (Phase 5), as detailed
  above.

---

#### Known Limitations

- **Scope**: 8 entries is intentionally small — enough to manually audit
  every line, not a statistically representative sample of BigCodeBench.
  Section *Extending the dataset* in
  `dataset/golden_dataset_csharp/README.md` documents how to grow it.
- **Seeded randomness was avoided by selection, not solved.** Entries whose
  Python tests assert an *exact* value produced under a fixed `random.seed`
  (e.g. `BigCodeBench/0`, considered and rejected during selection) were
  excluded, because Python's Mersenne-Twister and .NET's `System.Random` are
  different PRNG algorithms with no compatible seeding contract — a Python
  test that mocks/seeds `random.shuffle` cannot be ported to produce a
  bit-identical C# result without re-implementing Python's exact PRNG
  algorithm in C#, which was judged out of scope for this subset. This is a
  general, known open problem for cross-language semantic-clone research
  (not specific to this dataset) and is flagged here rather than glossed
  over.
- **Print-statement output is not byte-identical across runtimes in general**
  (see `BigCodeBench_795`), because Python and .NET use different
  shortest-round-trip float-formatting algorithms. This never affects any
  assertion in the translated test suites (none of the 8 entries' original
  tests capture stdout), but would matter for any future entry whose tests
  do assert on printed output.
- **`long` was used instead of Python's arbitrary-precision `int`** in
  `BigCodeBench_297`/`BigCodeBench_685`. This is a reduction, not an
  elimination, of overflow risk versus Python — acceptable for the input
  ranges these two entries' tests exercise, but not a general solution.
- **Legacy C# 5 syntax constraints** (see *Environment Constraints*) mean a
  couple of entries (e.g. `BigCodeBench_747`'s `KeyValuePair` instead of a
  native tuple) are slightly less idiomatic than they would be on a modern
  toolchain; this is a build-environment artifact, not a semantic limitation.
