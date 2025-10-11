import json, unittest, tempfile, textwrap, importlib.util, sys, os, subprocess, ast, multiprocessing, re, random
import numpy as np 

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

    def addSuccess(self, test):
        super().addSuccess(test)
        self.successes.append(test)

def run_test_module(tmp_path, return_dict):
    """Run tests in a module and store results keyed by TestCase.method name"""
    try:
        spec = importlib.util.spec_from_file_location("tmp_module", tmp_path)
        tmp_module = importlib.util.module_from_spec(spec)
        sys.modules["tmp_module"] = tmp_module
        spec.loader.exec_module(tmp_module)

        loader = unittest.TestLoader()
        suite = loader.loadTestsFromModule(tmp_module)

        stream = open(os.devnull, 'w')  # suppress output
        runner = unittest.TextTestRunner(stream=stream, resultclass=TrackingTestResult)
        result = runner.run(suite)

        for test_case in result.successes:
            # test_case.id() => "tmp_module.TestCases.test_case_1"
            key = ".".join(test_case.id().split(".")[1:])  # "TestCases.test_case_1"
            return_dict[key] = "PASS"

        for test_case, _ in result.failures + result.errors:
            key = ".".join(test_case.id().split(".")[1:])
            return_dict[key] = "FAIL"
    except Exception:
        # If the module fails to load, mark nothing here; main code will assign ERROR
        pass

def validate_with_unittest(code: str, tests: list) -> dict:
    TIMEOUT_SECONDS = 60
    code_d = textwrap.dedent(code)
    tests_d = "\n\n".join(textwrap.dedent(t) for t in tests)

    with tempfile.NamedTemporaryFile("w", suffix=".py", delete=False) as f:
        f.write(code_d + "\n\n" + tests_d)
        tmp_path = f.name

    manager = multiprocessing.Manager()
    return_dict = manager.dict()

    p = multiprocessing.Process(target=run_test_module, args=(tmp_path, return_dict))
    p.start()
    p.join(timeout=TIMEOUT_SECONDS)

    if p.is_alive():
        print("⚠️ Test execution exceeded timeout, terminating process.")
        p.terminate()
        p.join()
        # If timeout, mark all test methods as ERROR
        for t_code in tests:
            for line in t_code.splitlines():
                line = line.strip()
                if line.startswith("def test"):
                    test_name = line.split("(")[0]  # def test_case_1
                    # Combine with class name if available
                    class_name = next((l.split()[1].split("(")[0]
                                       for l in t_code.splitlines() if l.strip().startswith("class ")), "TestCases")
                    return_dict[f"{class_name}.{test_name.replace('def ', '')}"] = "ERROR (timeout)"
    else:
        # Mark unexecuted test methods as ERROR
        executed_names = set(return_dict.keys())
        for t_code in tests:
            class_name = next((l.split()[1].split("(")[0]
                               for l in t_code.splitlines() if l.strip().startswith("class ")), "TestCases")
            for line in t_code.splitlines():
                line = line.strip()
                if line.startswith("def test"):
                    test_name = line.split("(")[0].replace("def ", "")
                    full_name = f"{class_name}.{test_name}"
                    if full_name not in executed_names:
                        return_dict[full_name] = "ERROR"

    os.remove(tmp_path)
    return dict(return_dict)




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

def extract_required_packages_clones(dataset):
    """
    Extract a set of unique Python package names from dataset entries.
    Scans the 'code' field of each clone to detect imports.
    """
    packages = set()
    for entry in dataset:
        clones = entry.get("clones", [])
        for clone in clones:
            code = clone.get("code", "")
            # regex: matches 'import X' or 'from X import ...'
            imports = re.findall(r'^\s*(?:import|from)\s+([\w\d_\.]+)', code, flags=re.MULTILINE)
            for imp in imports:
                top = imp.split('.')[0]
                # skip standard library
                if top not in (
                    "sys", "os", "re", "math", "itertools", "random",
                    "unittest", "json", "time", "subprocess", "typing"
                ):
                    packages.add(top)
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
    with open(original_dataset_file, "r", encoding="utf-8") as f:
        dataset = json.load(f)

    with open(test_results_file, "r", encoding="utf-8") as f:
        test_results = json.load(f)

    filtered_dataset = []

    for entry in dataset:
        entry_id = entry["id"] 

        results = test_results[entry_id].values()

        # Condition 1: all tests passed
        all_tests_passed = all(r == "PASS" for r in results)

        # Condition 2: "split" field in metadata equals "easy"
        is_easy_split = entry.get("metadata", {}).get("split") == "easy"

        # Keep only if both conditions hold
        if all_tests_passed and is_easy_split:
            filtered_dataset.append(entry)

    with open(output_file, "w", encoding="utf-8") as f:
        json.dump(filtered_dataset, f, indent=2, ensure_ascii=False)

    print(f"Filtered dataset saved to {output_file}")
    print(f"Original entries: {len(dataset)}")
    print(f"Filtered entries (all tests pass + easy split): {len(filtered_dataset)}")




    
def sample_random_entries(input_file, experiment_output_file, extension_output_file, sample_size, seed=42):
    """
    Extracts two disjoint random samples of equal size from the dataset.
    Sampling is reproducible with the given seed.
    Args:
        input_file (str): Path to the input JSON file.
        experiment_output_file (str): Path to save the first sampled dataset.
        extension_output_file (str): Path to save the second sampled dataset.
        sample_size (int): Number of entries in each sample.
        seed (int): Random seed for reproducibility.
    """
    with open(input_file, "r", encoding="utf-8") as f:
        dataset = json.load(f)

    random.seed(seed)
    # Randomly shuffle all entries, then split into two groups
    shuffled = dataset.copy()
    random.shuffle(shuffled)
    sample_1 = shuffled[:sample_size]
    sample_2 = shuffled[sample_size:sample_size * 2]

    # Sort the sampled entries by 'id'
    sample_1.sort(key=lambda e: _id_numeric_key(e.get("id", "")))
    sample_2.sort(key=lambda e: _id_numeric_key(e.get("id", "")))

    with open(experiment_output_file, "w", encoding="utf-8") as f:
        json.dump(sample_1, f, indent=2, ensure_ascii=False)

        
    with open(extension_output_file, "w", encoding="utf-8") as f:
        json.dump(sample_2, f, indent=2, ensure_ascii=False)

    print(f"Sampled {sample_size} twice from {len(dataset)} total.")
    print(f"Sampled dataset 1 saved to {experiment_output_file}")
    print(f"Sampled dataset 2 saved to {extension_output_file}")


def _id_numeric_key(id_str: str):
    """
    Return a tuple (prefix, number) to sort naturally by numeric suffix.
    If no trailing number can be found, return (id_str, +inf) so those appear after numeric ones.
    """
    if not id_str:
        return ("", float("inf"))
    # try splitting by last '/' first (common pattern 'prefix/123')
    parts = id_str.rsplit('/', 1)
    if len(parts) == 2 and parts[1].isdigit():
        return (parts[0], int(parts[1]))
    # otherwise try any trailing digits
    m = re.search(r'(\d+)$', id_str)
    if m:
        prefix = id_str[:m.start()]
        return (prefix, int(m.group(1)))
    # no trailing digits -> put after numeric ids, sorted by full string
    return (id_str, float("inf"))