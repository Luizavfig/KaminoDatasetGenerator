"""
Reusable verification runner for the Python -> C# Golden Dataset.

For every entry under dataset/golden_dataset_csharp/<entry>/:
  1. Runs the ORIGINAL Python code + tests (python/task_func.py + python/test_task_func.py)
     with the real `unittest` module.
  2. Compiles the C# translation + tests (csharp/TaskFunc.cs + csharp/TaskFuncTests.cs,
     plus the shared harness in _shared/TestHarness.cs) with the legacy C# compiler
     bundled with .NET Framework 4.x (csc.exe -- no .NET SDK / NuGet is available in
     this environment) and runs the resulting executable.
  3. Writes <entry>/verification.json with the REAL captured pass/fail counts and
     output excerpts from both runs, plus the manually-authored notes on equivalence
     and language-specific adaptations for that entry.

This script performs NO fabrication: every number in verification.json comes from an
actual subprocess run executed at the time the script is invoked. Re-run it any time
after editing an entry to re-verify.

Usage:
    python dataset/golden_dataset_csharp/_shared/verify_all.py
(run from the repository root; paths below are relative to this file's location)
"""
import json
import os
import re
import subprocess
import sys
import tempfile
from datetime import datetime, timezone

THIS_DIR = os.path.dirname(os.path.abspath(__file__))
GOLDEN_DIR = os.path.dirname(THIS_DIR)
SHARED_HARNESS = os.path.join(THIS_DIR, "TestHarness.cs")

CSC_CANDIDATES = [
    r"C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe",
    r"C:\Windows\Microsoft.NET\Framework\v4.0.30319\csc.exe",
]


def find_csc():
    for path in CSC_CANDIDATES:
        if os.path.exists(path):
            return path
    from shutil import which
    found = which("csc") or which("csc.exe")
    if found:
        return found
    raise FileNotFoundError(
        "No C# compiler found. Install the .NET SDK (dotnet build) or point "
        "CSC_CANDIDATES to your csc.exe (legacy .NET Framework compiler)."
    )


# Per-entry metadata: BigCodeBench id, construct category, one-line rationale,
# and the key language-specific adaptations applied during translation.
ENTRY_METADATA = {
    "BigCodeBench_4": {
        "bigcodebench_id": "BigCodeBench/4",
        "category": "Dictionaries / maps",
        "rationale": "dict-of-lists aggregated via Counter into a plain dict; single parameter.",
        "adaptations": [
            "dict -> Dictionary<object, List<object>> (kept dynamically typed to allow the mixed-type error-handling test)",
            "Counter -> Dictionary<object, int> built with a manual counting loop",
            "Python's 'unhashable list' TypeError has no direct C# analogue (all C# objects are hashable via reference identity); explicitly re-created by rejecting nested-collection elements",
            "Python None is a valid, hashable dict key; C# Dictionary forbids null keys (ArgumentNullException) -- the C# port's exception fires one element earlier for the one test that mixes None with a nested list, but an exception is still raised either way",
        ],
    },
    "BigCodeBench_297": {
        "bigcodebench_id": "BigCodeBench/297",
        "category": "Functions with multiple parameters",
        "rationale": "two positional parameters (elements, subset_size); itertools.combinations + Counter.",
        "adaptations": [
            "tuple -> IList<long> (long chosen over int to stay closer to Python's arbitrary-precision int for summed values)",
            "itertools.combinations(elements, r) reimplemented explicitly as an index-based generator (no BCL equivalent), preserving Python's enumeration order",
            "Counter -> Dictionary<long, int>",
        ],
    },
    "BigCodeBench_670": {
        "bigcodebench_id": "BigCodeBench/670",
        "category": "Loops, iteration, nested control flow",
        "rationale": "itertools.combinations over a range is really a nested (start, end) loop with an inner conditional max-tracker.",
        "adaptations": [
            "itertools.combinations(range(len(x)+1), 2) rewritten as two explicit nested for-loops (start, end) in the same enumeration order",
            "Python slicing x[start:end] -> string.Substring(start, end - start)",
            "dict.get(c, 0) (default-valued lookup) -> Dictionary<char,int>.TryGetValue with a 0 fallback",
        ],
    },
    "BigCodeBench_685": {
        "bigcodebench_id": "BigCodeBench/685",
        "category": "Lists / collections",
        "rationale": "flattens a list of lists and counts elements; minimal, focused list-processing example.",
        "adaptations": [
            "list of lists -> List<List<long>>",
            "itertools.chain.from_iterable -> nested foreach flattening loop",
            "Counter -> Dictionary<long, int>",
        ],
    },
    "BigCodeBench_747": {
        "bigcodebench_id": "BigCodeBench/747",
        "category": "Basic expressions and arithmetic",
        "rationale": "regex-extracted numbers combined with math.sqrt and sum(); returns a (count, sum) pair.",
        "adaptations": [
            "re.findall(r'\\b\\d+(?:\\.\\d+)?\\b', s) -> System.Text.RegularExpressions.Regex with the same pattern",
            "Python tuple return -> KeyValuePair<int,double> (this Golden Dataset entry targets the legacy C# 5 compiler available in this environment, which predates C# 7 tuple literals)",
            "float(num) parsing forced to InvariantCulture to avoid locale-dependent decimal-separator bugs that Python's locale-independent float() never has",
        ],
    },
    "BigCodeBench_795": {
        "bigcodebench_id": "BigCodeBench/795",
        "category": "Conditional logic + dynamic typing + side effects",
        "rationale": "if/if branching, isinstance-based dynamic type filtering, a print side effect, and deque rotation -- the richest entry for illustrating Python-dynamic-typing pitfalls.",
        "adaptations": [
            "list (freely mixed types) -> List<object>, since test_case_4 requires int/str/float/bool/None in one list",
            "collections.deque(...).rotate(3) has no BCL equivalent; reimplemented as a modulo-indexed rebuild (rotated[i] = original[(i-k) mod n]), matching deque.rotate's exact resulting order for any k",
            "isinstance(item, (int, float)) quirk: Python bool is a SUBCLASS of int, so True/False count as numeric; the C# port explicitly special-cases 'item is bool' to reproduce this, since C#'s bool/int have no such relationship",
            "Python f-string float formatting vs C#'s double.ToString(): NOT guaranteed byte-identical (different shortest-round-trip algorithms); this print output is not asserted by any original test, so it does not affect observable-behavior equivalence for the actual test suite, but it is a real, verified case of locale bugs -- fixed with InvariantCulture after being caught during verification (see notes)",
        ],
    },
    "BigCodeBench_818": {
        "bigcodebench_id": "BigCodeBench/818",
        "category": "Strings and string manipulation",
        "rationale": "regex split + regex substitution + case folding over words; a focused string-processing example.",
        "adaptations": [
            "re.split(r'\\s+', text) -> Regex.Split with the same pattern (including producing empty strings for leading/trailing whitespace, verified by test_string_with_whitespaces)",
            "string.punctuation has no C# constant; inlined literally",
            "BUG CAUGHT DURING VERIFICATION: Python's f'[{string.punctuation}]' works only because string.punctuation happens to contain a backslash immediately before ']' (an ASCII-ordering coincidence), so it 'self-escapes'. A first C# attempt using `Regex.Escape(punctuation)` compiled and ran without error but silently matched nothing, because .NET's Regex.Escape does not escape ']'. Fixed by escaping every punctuation character individually before building the character class.",
            "str.lower() -> ToLowerInvariant() (not culture-specific ToLower(), to avoid the Turkish-I locale bug)",
        ],
    },
    "BigCodeBench_1108": {
        "bigcodebench_id": "BigCodeBench/1108",
        "category": "Nested control flow",
        "rationale": "nested for-loops (dict list -> dict keys) with an inner conditional regex check and a most-common aggregation.",
        "adaptations": [
            "list of dicts -> List<Dictionary<string, object>> (values are dynamically typed in the original; keys are always strings)",
            "Nested `for l_res in result: for j in l_res:` preserved as nested foreach loops rather than flattened via LINQ, to keep the original explicit nested-control-flow structure",
            "re.match (anchored at string start only) reproduced via Regex.Match + checking Index == 0 (the pattern's own trailing '$' already anchors the end)",
            "Counter(...).most_common(1) -> manual first-seen-wins max scan over insertion order, matching CPython's current stable tie-breaking behavior",
        ],
    },
}


def run_python_tests(entry_dir):
    py_dir = os.path.join(entry_dir, "python")
    code = open(os.path.join(py_dir, "task_func.py"), encoding="utf-8").read()
    tests = open(os.path.join(py_dir, "test_task_func.py"), encoding="utf-8").read()
    combined = code + "\n\n" + tests + "\n\nif __name__ == '__main__':\n    unittest.main(verbosity=2)\n"

    with tempfile.NamedTemporaryFile("w", suffix=".py", delete=False, encoding="utf-8") as f:
        f.write(combined)
        tmp_path = f.name

    try:
        proc = subprocess.run(
            [sys.executable, tmp_path],
            capture_output=True, text=True, timeout=60
        )
    finally:
        os.remove(tmp_path)

    output = proc.stdout + proc.stderr
    m = re.search(r"Ran (\d+) test", output)
    ran = int(m.group(1)) if m else 0
    passed_all = proc.returncode == 0 and "OK" in output
    return {
        "tests_ran": ran,
        "tests_passed": ran if passed_all else None,
        "all_passed": passed_all,
        "output_excerpt": output.strip()[-1500:],
    }


def run_csharp_tests(entry_dir, csc_path):
    cs_dir = os.path.join(entry_dir, "csharp")
    task_func = os.path.join(cs_dir, "TaskFunc.cs")
    tests = os.path.join(cs_dir, "TaskFuncTests.cs")
    exe_path = os.path.join(cs_dir, "_verify_tmp.exe")

    compile_proc = subprocess.run(
        [csc_path, "/nologo", "/out:" + exe_path, SHARED_HARNESS, task_func, tests],
        capture_output=True, text=True, timeout=60
    )
    compile_output = compile_proc.stdout + compile_proc.stderr

    if compile_proc.returncode != 0 or not os.path.exists(exe_path):
        return {
            "compiled": False,
            "tests_ran": 0,
            "tests_passed": 0,
            "all_passed": False,
            "output_excerpt": ("COMPILE ERROR:\n" + compile_output).strip()[-1500:],
        }

    try:
        run_proc = subprocess.run([exe_path], capture_output=True, text=True, timeout=60)
    finally:
        if os.path.exists(exe_path):
            os.remove(exe_path)
        pdb_path = exe_path.replace(".exe", ".pdb")
        if os.path.exists(pdb_path):
            os.remove(pdb_path)

    output = run_proc.stdout + run_proc.stderr
    m = re.search(r"(\d+)/(\d+) tests passed \((\d+) failed\)", output)
    if m:
        tests_passed = int(m.group(1))
        tests_ran = int(m.group(2))
        failed = int(m.group(3))
    else:
        tests_passed = tests_ran = 0
        failed = -1

    return {
        "compiled": True,
        "tests_ran": tests_ran,
        "tests_passed": tests_passed,
        "all_passed": failed == 0 and tests_ran > 0,
        "output_excerpt": output.strip()[-1500:],
    }


def main():
    csc_path = find_csc()
    print("Using C# compiler:", csc_path)

    entries = sorted(
        d for d in os.listdir(GOLDEN_DIR)
        if os.path.isdir(os.path.join(GOLDEN_DIR, d)) and not d.startswith("_")
    )

    summary = []
    for entry in entries:
        entry_dir = os.path.join(GOLDEN_DIR, entry)
        meta = ENTRY_METADATA.get(entry, {})
        print(f"\n=== Verifying {entry} ===")

        py_result = run_python_tests(entry_dir)
        print(f"  Python: {py_result['tests_passed']}/{py_result['tests_ran']} passed"
              if py_result["all_passed"] else f"  Python: FAILED ({py_result['tests_ran']} tests ran)")

        cs_result = run_csharp_tests(entry_dir, csc_path)
        print(f"  C#:     {cs_result['tests_passed']}/{cs_result['tests_ran']} passed"
              if cs_result["all_passed"] else f"  C#:     FAILED/NOT COMPILED")

        equivalence_status = (
            "EQUIVALENT"
            if py_result["all_passed"] and cs_result["all_passed"]
            else "NOT_VERIFIED"
        )

        verification = {
            "entry": entry,
            "bigcodebench_id": meta.get("bigcodebench_id", entry.replace("_", "/", 1)),
            "category": meta.get("category", ""),
            "selection_rationale": meta.get("rationale", ""),
            "python_behavior": {
                "tests_ran": py_result["tests_ran"],
                "tests_passed": py_result["tests_passed"],
                "all_passed": py_result["all_passed"],
                "output_excerpt": py_result["output_excerpt"],
            },
            "csharp_behavior": {
                "compiled": cs_result["compiled"],
                "tests_ran": cs_result["tests_ran"],
                "tests_passed": cs_result["tests_passed"],
                "all_passed": cs_result["all_passed"],
                "output_excerpt": cs_result["output_excerpt"],
            },
            "equivalence_status": equivalence_status,
            "language_specific_adaptations": meta.get("adaptations", []),
            "verified_at": datetime.now(timezone.utc).strftime("%Y-%m-%dT%H:%M:%SZ"),
            "verification_method": (
                "Executed the original Python code+tests with `python` (real unittest run) "
                "and compiled+executed the C# translation+tests with the legacy csc.exe "
                "compiler (.NET Framework 4.8, no NuGet/xUnit available in this environment). "
                "Both runs are real subprocess executions captured at verification time, not "
                "estimates."
            ),
        }

        out_path = os.path.join(entry_dir, "verification.json")
        with open(out_path, "w", encoding="utf-8") as f:
            json.dump(verification, f, indent=2, ensure_ascii=False)
        print(f"  Wrote {out_path}")

        summary.append(verification)

    print("\n=== Summary ===")
    for v in summary:
        print(f"{v['entry']:22s} python={v['python_behavior']['tests_passed']}/{v['python_behavior']['tests_ran']:<3d} "
              f"csharp={v['csharp_behavior']['tests_passed']}/{v['csharp_behavior']['tests_ran']:<3d} "
              f"status={v['equivalence_status']}")

    return summary


if __name__ == "__main__":
    main()
