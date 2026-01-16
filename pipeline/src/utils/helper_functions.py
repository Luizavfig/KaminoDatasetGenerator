import unittest, tempfile, textwrap, importlib.util, sys, os, subprocess, ast, multiprocessing, re, random, os, math
from huggingface_hub import login
from pathlib import Path
from dotenv import load_dotenv
from codebleu import calc_codebleu
from src.config import GPTCLONEBENCH_POS_CLONES_DIR,  GPTCLONEBENCH_NEG_CLONES_DIR

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
    Extract a set of unique Python package names from dataset entries.  Scans the 'code' field of each clone to detect imports.
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
                # skip standard libraries
                if top not in (
                    "sys", "os", "re", "math", "itertools", "random",
                    "unittest", "json", "time", "subprocess", "typing"
                ):
                    packages.add(top)
    return packages


def remove_function_signature(code: str) -> str:
    """
    Removes the first function definition line (e.g., 'def func(...):') and returns only the body, keeping indentation.
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

def build_pairs(data, seed=42, target_ratio=1.0):
    """
    Build positive and negative code pairs using _calculate_max_negatives for balancing.
    """
    rng = random.Random(seed)
    pairs = []

    #  Positive pairs 
    clones_per_entry = []
    for entry in data:
        clones = entry.get("clones", [])
        n = len(clones)
        if n < 2:
            clones_per_entry.append([]) # ignore entries with less than 2 clones
            continue

        for i in range(n):
            for j in range(i + 1, n):
                pairs.append((
                    remove_function_signature(clones[i]["code"]),
                    remove_function_signature(clones[j]["code"]), 
                    1
                ))
        clones_per_entry.append(clones)

    #  Compute total negatives needed 
    total_negatives_needed = _calculate_max_negatives(data, target_ratio=target_ratio)

    #  generate negatives 
    generated_negatives = 0
    total_entries = len(data)
    while generated_negatives < total_negatives_needed:
        entry_idx = rng.randrange(total_entries)
        clones = clones_per_entry[entry_idx]
        if not clones:
            continue

        pos_clone = rng.choice(clones)

        neg_candidates = [e for i, e in enumerate(clones_per_entry) if i != entry_idx and e]
        if not neg_candidates:
            continue

        neg_entry = rng.choice(neg_candidates)
        neg_clone = rng.choice(neg_entry)

        pairs.append((
            remove_function_signature(pos_clone["code"]),
            remove_function_signature(neg_clone["code"]),
            0
        ))
        generated_negatives += 1

    rng.shuffle(pairs)
    positives = sum(1 for _, _, l in pairs if l == 1)
    negatives = sum(1 for _, _, l in pairs if l == 0)
    print(f"Built {len(pairs)} code pairs (Positives: {positives}, Negatives: {negatives})")
    return pairs

def build_pairs_from_folders(pos_folder=GPTCLONEBENCH_POS_CLONES_DIR, neg_folder=GPTCLONEBENCH_NEG_CLONES_DIR):
    """
    Build code pairs from two folders:
    - pos_folder: contains .py files with positive pairs
    - neg_folder: contains .py files with negative pairs

    Returns:
        List of tuples: (code1, code2, label)
    """
    pairs = []

    def read_functions_from_file(path):
        """Read all functions in a file, separated by at least one blank line."""
        with open(path, "r", encoding="utf-8") as f:
            code = f.read()
        # Split by two or more newlines (robust against extra blank lines)
        funcs = [remove_function_signature(fn.strip()) for fn in code.split("\n\n") if fn.strip()]
        return funcs

    # Process positive pairs
    for filename in os.listdir(pos_folder):
        if filename.endswith(".py"):
            path = os.path.join(pos_folder, filename)
            funcs = read_functions_from_file(path)
            if len(funcs) >= 2:
                pairs.append((funcs[0], funcs[1], 1))

    # Process negative pairs
    for filename in os.listdir(neg_folder):
        if filename.endswith(".py"):
            path = os.path.join(neg_folder, filename)
            funcs = read_functions_from_file(path)
            if len(funcs) >= 2:
                pairs.append((funcs[0], funcs[1], 0))

    # Shuffle the resulting list
    random.shuffle(pairs)

    positives = sum(1 for _, _, l in pairs if l == 1)
    negatives = sum(1 for _, _, l in pairs if l == 0)
    print(f"Built {len(pairs)} code pairs (Positives: {positives}, Negatives: {negatives})")
    return pairs

def _calculate_max_negatives(data, target_ratio=1.0):
    """
    Compute the total number of negative pairs needed to roughly balance positives. 
    """
    total_positives = 0
    for entry in data:
        clones = entry.get("clones", [])
        n = len(clones)
        if n < 2:
            continue
        total_positives += n * (n - 1) // 2  # n choose 2

    total_negatives = math.ceil(total_positives * target_ratio) 
    return total_negatives

def hf_login():
    # Load .env from the root of your project
    root_env = Path(__file__).resolve().parents[3] / ".env"
    if not root_env.exists():
        raise FileNotFoundError(f".env file not found at {root_env}")
    
    load_dotenv(dotenv_path=root_env)
    
    token = os.getenv("HF_TOKEN")
    if not token:
        raise ValueError("HF_TOKEN not found in .env")
    
    login(token=token)
    print("✅ Hugging Face login successful!")


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
