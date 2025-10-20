import unittest, tempfile, textwrap, importlib.util, sys, os, subprocess, ast, multiprocessing, re, random
from codebleu import calc_codebleu
from src.config import MAX_NEGATIVES

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
        if spec is None or spec.loader is None:
            raise ImportError(f"Cannot load module from {tmp_path}")
        tmp_module = importlib.util.module_from_spec(spec)
        sys.modules["tmp_module"] = tmp_module
        spec.loader.exec_module(tmp_module)

        loader = unittest.TestLoader()
        suite = loader.loadTestsFromModule(tmp_module)

        stream = open(os.devnull, 'w')  # suppress output
        runner = unittest.TextTestRunner(stream=stream, resultclass=TrackingTestResult)
        result = runner.run(suite)

        for test_case in getattr(result, "successes", []):
            key = ".".join(test_case.id().split(".")[1:])
            return_dict[key] = "PASS"

        for test_case, _ in result.failures + result.errors:
            key = ".".join(test_case.id().split(".")[1:])
            return_dict[key] = "FAIL"
    except Exception:
        # If the module fails to load, mark nothing here; main code will assign ERROR
        pass

def validate_with_unittest(code: str, tests: list) -> dict:
    TIMEOUT_SECONDS = 180
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

 




def install_package(package):
    """Install a Python package using pip."""
    subprocess.check_call([sys.executable, "-m", "pip", "install", package])


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

    

def fix_function_signature(code: str) -> str:
    """
    Fix multiline LLM-generated function definitions:
    - Handles raw strings wrapped in quotes: 'r"..."' -> r"..."
    - Ensures function signature ends with ':'
    - Balances parentheses for multiline signatures
    """
    lines = code.splitlines()
    fixed_lines = []
    in_def = False
    paren_count = 0

    for line in lines:
        stripped = line.strip()

        # Start of a function
        if stripped.startswith("def ") and not in_def:
            in_def = True
            # Fix raw string wrapped in quotes
            line = re.sub(r"['\"]r([\"'].*?[\"'])['\"]", r"r\1", line)
            # Count parentheses
            paren_count = line.count("(") - line.count(")")
        
        elif in_def:
            # Count parentheses for continued lines
            paren_count += line.count("(") - line.count(")")
            # Fix raw string wrapped in quotes in continued lines
            line = re.sub(r"['\"]r([\"'].*?[\"'])['\"]", r"r\1", line)

        fixed_lines.append(line)

        # End of function signature
        if in_def and paren_count <= 0:
            if not stripped.endswith(":"):
                fixed_lines[-1] = line.rstrip() + ":"
            in_def = False

    return "\n".join(fixed_lines)



def add_missing_imports(code: str, common_modules=None) -> str:
    """
    Add imports for standard/common modules that are used but not imported.
    common_modules: optional set of module names to consider
    """
    if common_modules is None:
        common_modules = {"json", "os", "sys", "re", "math", "base64", "zlib", "datetime", "random", "itertools", "collections"}

    try:
        tree = ast.parse(code)
    except SyntaxError:
        return code  # skip if code is broken

    # Collect imported names
    imported_names = set()
    for node in ast.walk(tree):
        if isinstance(node, ast.Import):
            for alias in node.names:
                imported_names.add(alias.asname or alias.name.split(".")[0])
        elif isinstance(node, ast.ImportFrom):
            for alias in node.names:
                imported_names.add(alias.asname or alias.name.split(".")[0])

    # Collect used names
    used_names = set()
    for node in ast.walk(tree):
        if isinstance(node, ast.Name):
            used_names.add(node.id)

    # Determine missing imports
    missing_imports = (used_names & common_modules) - imported_names

    # Add missing imports at the top
    if missing_imports:
        imports_text = "\n".join(f"import {name}" for name in sorted(missing_imports))
        code = imports_text + "\n\n" + code

    return code

def remove_function_signature(code: str) -> str:
    """
    Removes the first function definition line (e.g., 'def func(...):')
    and returns only the body, keeping indentation.
    Works for both single-line and multi-line signatures.
    """
    lines = code.strip().splitlines()
    body_started = False
    cleaned_lines = []
    
    for line in lines:
        # Skip lines until we reach the end of the function signature
        if not body_started:
            # Start of def ...:
            if re.match(r'^\s*def\s+\w+\s*\(.*', line):
                # If it ends with ':', body starts after this line
                if line.strip().endswith(":"):
                    body_started = True
                continue
            else:
                continue
        else:
            cleaned_lines.append(line)
    return "\n".join(cleaned_lines).strip()



def calc_syntactic_codebleu(code1: str, code2: str, lang: str = "python") -> float:
    """
    Compute a syntactic-only CodeBLEU score between two code snippets.
    Ignores the semantic component (dataflow_match_score).
    """
    score = calc_codebleu([code1], [code2], lang=lang)

    # Combine only syntactic components
    syntactic_components = [
        score["ngram_match_score"],
        score["weighted_ngram_match_score"],
        score["syntax_match_score"]
    ]

    # Average them equally
    syntactic_score = sum(syntactic_components) / len(syntactic_components)
    return float(syntactic_score)

# Helper function to build positive and negative pairs
def _build_pairs(data, max_negatives=MAX_NEGATIVES):
    pairs = []
    for entry in data:
        clones = entry.get("clones", [])
        n = len(clones)
        # positive pairs
        for i in range(n):
            for j in range(i + 1, n):
                pairs.append((clones[i]["code"], clones[j]["code"], 1))
        # negative pairs
        for i in range(min(n, max_negatives)):
            neg_entry = random.choice([e for e in data if e != entry and e.get("clones")])
            neg_clone = random.choice(neg_entry["clones"])
            pairs.append((clones[i]["code"], neg_clone["code"], 0))
    random.shuffle(pairs)
    return pairs


def startup():
    banner = r"""
╔══════════════════════════════════════════════════════════════════╗
║                          K A M I N O                             ║
║               Semantic Clone Generation Pipeline                 ║
╚══════════════════════════════════════════════════════════════════╝
"""
    print(banner)
    print("Starting Kamino pipeline...\n")
    print("Check the README.md for setup and usage instructions.")
    print("Make sure to run `pip install -r required_packages.txt` if you haven't already.")
