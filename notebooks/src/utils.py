import json, unittest, tempfile, textwrap, importlib.util, sys, os, subprocess, ast

def normalize(dataset_split):
    normalized = []
    for entry in dataset_split: 
        doc_struct_raw = entry.get("doc_struct", "{}")
        try:
            doc_struct = json.loads(doc_struct_raw)
        except json.JSONDecodeError:
            doc_struct = {}

        # Extract description
        description_list = doc_struct.get("description", [])
        description_text = " ".join(description_list)

        # Extract return
        returns_list = doc_struct.get("returns", [])
        return_text = " ".join(returns_list)

        
        # Extract params
        params_list = doc_struct.get("params", [])
        params = " ".join(params_list)

        # Original code
        original_code = entry.get("canonical_solution", "")

        # Append part of complete_prompt until """ or '''
        complete_prompt = entry.get("complete_prompt", "")

        for delimiter in ('"""', "'''"):
            if delimiter in complete_prompt:
                snippet = complete_prompt.split(delimiter, 1)[0].rstrip()
                original_code = snippet + "\n" + original_code
                break
         
        normalized.append({
            "id": entry.get("task_id", ""),
            "language": entry.get("language", "python"),
            "original_code": original_code,
            "test": [entry.get("test", "")],
            "description": description_text,
            "metadata": {
                "libs": entry.get("libs", []),
                "params": params,
                "return_text": return_text,
                "complete_prompt": complete_prompt
            }
        })
    return normalized

class TrackingTestResult(unittest.TextTestResult):
    def __init__(self, *args, **kwargs):
        super().__init__(*args, **kwargs)
        self.successes = []

    def addSuccess(self, test): # keeps track of successful tests in a separate list
        super().addSuccess(test)
        self.successes.append(test)

def validate_with_unittest(code: str, tests: list) -> dict:
    """
    Run code + tests and return per-test results as {test_name: "PASS"/"FAIL"/"ERROR"}.
    If any test fails to run due to an exception, mark it as "ERROR".
    """
    code_d = textwrap.dedent(code)
    tests_d = "\n\n".join(textwrap.dedent(t) for t in tests)

    with tempfile.NamedTemporaryFile("w", suffix=".py", delete=False) as f:
        f.write(code_d + "\n\n" + tests_d)
        tmp_path = f.name

    test_results = {}
    try:
        # Load module dynamically
        spec = importlib.util.spec_from_file_location("tmp_module", tmp_path)
        tmp_module = importlib.util.module_from_spec(spec)
        sys.modules["tmp_module"] = tmp_module
        spec.loader.exec_module(tmp_module)

        loader = unittest.TestLoader()
        suite = loader.loadTestsFromModule(tmp_module)

        # Run tests with tracking
        stream = open(os.devnull, 'w')  # suppress default output
        runner = unittest.TextTestRunner(stream=stream, resultclass=TrackingTestResult)
        result = runner.run(suite)

        # Mark successes
        for test_case in result.successes:
            test_results[str(test_case)] = "PASS"
        # Mark failures and errors
        for test_case, _ in result.failures + result.errors:
            test_results[str(test_case)] = "FAIL"

        # If some tests in `tests` list were not executed due to validation issues, mark them as ERROR
        executed_names = set(test_results.keys())
        for t_code in tests:
            first_line = t_code.strip().splitlines()[0]

            # Skip if it's not a test function/class definition
            if not (first_line.startswith("def test") or first_line.startswith("class ")):
                continue

            if first_line not in executed_names:
                test_results[first_line] = "ERROR"

    except Exception as e:
        # If code itself fails to load, mark all tests as ERROR
        for t_code in tests:
            first_line = t_code.strip().splitlines()[0]
            test_results[first_line] = "ERROR"
    finally:
        os.remove(tmp_path)

    return test_results


def run_original_tests(normalized_data, output_file): 
    if os.path.exists(output_file):
        with open(output_file, "r", encoding="utf-8") as f:
            try:
                results = json.load(f)
            except json.JSONDecodeError:
                results = {}
    else:
        results = {}
        
    for entry in normalized_data:
        tests_list = entry["test"]
        code = entry["original_code"]
        test_results = validate_with_unittest(code, tests_list) 
        results[entry["id"]] = test_results 
        with open(output_file, "w", encoding="utf-8") as f:
            json.dump(results, f, indent=2, ensure_ascii=False) 



def install_package(package):
    """Install a Python package using pip."""
    subprocess.check_call([sys.executable, "-m", "pip", "install", package])

def extract_required_packages(dataset):
    """
    Extract a set of unique Python package names from dataset entries. 
    """
    packages = set()
    for entry in dataset:
        libs_val = entry.get("metadata", {}).get("libs", [])
        # Convert string representation of a list to an actual list
        if isinstance(libs_val, str):
            try:
                libs_val = ast.literal_eval(libs_val)
            except Exception:
                libs_val = []
        if isinstance(libs_val, list):
            packages.update(libs_val)
    return packages

def analyze_test_results(data):
    total_pass = 0
    total_fail = 0
    entries_with_failures = []
    entries_all_fail = []

    for entry_id, tests in data.items():
        test_results = list(tests.values())
        pass_count = test_results.count("PASS")
        fail_count = test_results.count("FAIL")

        total_pass += pass_count
        total_fail += fail_count

        # At least one FAIL
        if fail_count > 0:
            entries_with_failures.append(entry_id)

        # All FAIL
        if fail_count == len(test_results):
            entries_all_fail.append(entry_id)

    summary = {
        "total_pass": total_pass,
        "total_fail": total_fail,
        "num_entries_with_failures": len(entries_with_failures),
        "num_entries_all_fail": len(entries_all_fail),
        "entries_with_failures": entries_with_failures,
        "entries_all_fail": entries_all_fail,
    }
    return summary
 

def filter_dataset(original_dataset_file, test_results_file, output_file):
    # Load dataset (list of dicts with "id", "original_code", etc.)
    with open(original_dataset_file, "r", encoding="utf-8") as f:
        dataset = json.load(f) 

    with open(test_results_file, "r", encoding="utf-8") as f:
        test_results = json.load(f)

    filtered_dataset = []

    for entry in dataset:
        entry_id = entry["id"] 

        results = test_results[entry_id].values()

        # Keep only if ALL tests pass
        if all(r == "PASS" for r in results):
            filtered_dataset.append(entry)

    with open(output_file, "w", encoding="utf-8") as f:
        json.dump(filtered_dataset, f, indent=2, ensure_ascii=False)

    print(f"Filtered dataset saved to {output_file}")
    print(f"Original entries: {len(dataset)}")
    print(f"Filtered entries (all tests pass): {len(filtered_dataset)}")
