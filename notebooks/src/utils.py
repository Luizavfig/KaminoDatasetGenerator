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
    Run code + tests and return per-test results as {test_name: "PASS"/"FAIL"}.
    """
    code_d = textwrap.dedent(code)
    tests_d = "\n\n".join(textwrap.dedent(t) for t in tests)

    with tempfile.NamedTemporaryFile("w", suffix=".py", delete=False) as f:
        f.write(code_d + "\n\n" + tests_d)
        tmp_path = f.name

    try:
        # Load module dynamically
        spec = importlib.util.spec_from_file_location("tmp_module", tmp_path)
        tmp_module = importlib.util.module_from_spec(spec)
        sys.modules["tmp_module"] = tmp_module
        spec.loader.exec_module(tmp_module)

        loader = unittest.TestLoader()
        suite = loader.loadTestsFromModule(tmp_module)

        # Run with our tracking TestResult
        stream = open(os.devnull, 'w')  # suppress default TextTestRunner output
        runner = unittest.TextTestRunner(stream=stream, resultclass=TrackingTestResult)
        result = runner.run(suite)

        test_results = {}
        for test_case, _ in result.failures + result.errors:
            test_results[str(test_case)] = "FAIL"
        for test_case in result.successes:
            test_results[str(test_case)] = "PASS"

        return test_results

    except Exception as e:
        print("Validation error:", e)
        return {}
    finally:
        os.remove(tmp_path)


def run_original_tests(normalized_data, output_file):
    results = {} 
    for i,entry in enumerate(normalized_data): 
        if(i>50):
            break
        tests_list = entry["test"]
        code = entry["original_code"]
        test_results = validate_with_unittest(code,tests_list)
        results[entry["id"]] = test_results

   
    os.makedirs(os.path.dirname(output_file), exist_ok=True)
    # Save test results to JSON
    with open(output_file, "w", encoding="utf-8") as f:
        json.dump(results, f, indent=2, ensure_ascii=False)

    print(f"Saved {len(results)} test results to {output_file}")


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