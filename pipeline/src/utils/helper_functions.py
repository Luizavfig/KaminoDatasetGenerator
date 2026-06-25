import unittest, tempfile, textwrap, importlib.util, sys, os, subprocess, ast, multiprocessing, re, random, os, math, json, parso, uuid, Levenshtein
from huggingface_hub import login
from pathlib import Path
from dotenv import load_dotenv
from codebleu import calc_codebleu
from datasets import load_dataset
from sklearn.model_selection import GroupShuffleSplit
from collections import defaultdict
from itertools import combinations

from src.config import *

class TrackingTestResult(unittest.TextTestResult):
    def __init__(self, *args, **kwargs):
        super().__init__(*args, **kwargs)
        self.successes = []

    def addSuccess(self, test):
        super().addSuccess(test)
        self.successes.append(test)

def run_test_module(tmp_path, return_dict):
    """Run tests in a module and store results keyed by TestCase.method name"""

    test_dir = os.path.dirname(tmp_path)
    old_cwd = os.getcwd()

    try:
        # sandbox everything
        os.chdir(test_dir)

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
        pass

    finally:
        # restore original working dir
        os.chdir(old_cwd)

def validate_with_unittest(code: str, tests: list) -> dict:
    TIMEOUT_SECONDS = 180
    test_dir = os.path.join(TEST_DIR, str(uuid.uuid4()))
    # Ensure directory exists
    os.makedirs(test_dir, exist_ok=True)

    code_d = textwrap.dedent(code)
    tests_d = "\n\n".join(textwrap.dedent(t) for t in tests)

    # Create temp file INSIDE test_folder
    with tempfile.NamedTemporaryFile(
        "w",
        suffix=".py",
        dir=test_dir,
        delete=False
    ) as f:
        f.write(code_d + "\n\n" + tests_d)
        tmp_path = f.name

    manager = multiprocessing.Manager()
    return_dict = manager.dict()

    p = multiprocessing.Process(target=run_test_module, args=(tmp_path, return_dict))
    p.start()
    p.join(timeout=TIMEOUT_SECONDS)

    if p.is_alive():
        print(" Test execution exceeded timeout, terminating process.")
        p.terminate()
        p.join()

        for t_code in tests:
            for line in t_code.splitlines():
                line = line.strip()
                if line.startswith("def test"):
                    test_name = line.split("(")[0]
                    class_name = next(
                        (l.split()[1].split("(")[0]
                         for l in t_code.splitlines()
                         if l.strip().startswith("class ")),
                        "TestCases"
                    )
                    return_dict[f"{class_name}.{test_name.replace('def ', '')}"] = "ERROR (timeout)"
    else:
        executed_names = set(return_dict.keys())
        for t_code in tests:
            class_name = next(
                (l.split()[1].split("(")[0]
                 for l in t_code.splitlines()
                 if l.strip().startswith("class ")),
                "TestCases"
            )
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

def calc_complete_codebleu(code1: str, code2: str, lang: str = "python") -> float:
    """
    Compute a CodeBLEU score between two code snippets.
    """
    score = calc_codebleu([code1], [code2], lang=lang)
     
    return score["codebleu"]


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
    Build positive and negative code pairs.
    Negatives are guaranteed to come from different entries.
    Duplicate pairs are avoided.
    """

    rng = random.Random(seed)
    pairs = []
    seen_pairs = set()

    clones_per_entry = []
 
    # Positive pairs 
    for entry in data:
        clones = entry.get("clones", [])
        n = len(clones)

        if n < 2:
            clones_per_entry.append([])
            continue

        for i in range(n):
            for j in range(i + 1, n):

                c1 = remove_function_signature(clones[i]["code"])
                c2 = remove_function_signature(clones[j]["code"])

                key = tuple(sorted([c1, c2])) + (1,)

                if key not in seen_pairs:
                    seen_pairs.add(key)
                    pairs.append((c1, c2, 1))

        clones_per_entry.append(clones)
 
    # Compute negatives needed 
    actual_positives = len(pairs)
    total_negatives_needed = math.ceil(actual_positives * target_ratio)

    generated_negatives = 0
    total_entries = len(data)
 
    # Negative pairs 
    while generated_negatives < total_negatives_needed:

        entry_idx = rng.randrange(total_entries)

        clones = clones_per_entry[entry_idx]

        if not clones:
            continue

        pos_clone = rng.choice(clones)
 
        neg_candidates = [
            e for i, e in enumerate(clones_per_entry)
            if i != entry_idx and e
        ]

        if not neg_candidates:
            continue

        neg_entry = rng.choice(neg_candidates)
        neg_clone = rng.choice(neg_entry)

        c1 = remove_function_signature(pos_clone["code"])
        c2 = remove_function_signature(neg_clone["code"])

        key = tuple(sorted([c1, c2])) + (0,)

        if key in seen_pairs:
            continue

        seen_pairs.add(key)

        pairs.append((c1, c2, 0))
        generated_negatives += 1

    rng.shuffle(pairs)

    positives = sum(1 for _, _, l in pairs if l == 1)
    negatives = sum(1 for _, _, l in pairs if l == 0)

    print(
        f"Built {len(pairs)} code pairs "
        f"(Positives: {positives}, Negatives: {negatives})"
    )

    return pairs


def build_pairs_rq4(data, seed=42, target_ratio=1.0, max_positives=MAX_POSITIVE_PAIRS):
    """
    Build positive and negative code pairs.

    - Preserves all entries
    - Caps total positives globally
    - Negatives come from different entries
    - Duplicate pairs are avoided
    """

    rng = random.Random(seed)

    positives = []
    negatives = []
    seen = set()

    processed_entries = []

    # Preprocess
    for entry in data:

        clones = []

        for clone in entry.get("clones", []):

            code = remove_function_signature(clone["code"]).strip()

            if code:
                clones.append(code)

        processed_entries.append(clones)

    # Generate positives
    for clones in processed_entries:

        if len(clones) < 2:
            continue

        for c1, c2 in combinations(clones, 2):

            key = tuple(sorted((c1, c2))) + (1,)

            if key in seen:
                continue

            seen.add(key)
            positives.append((c1, c2, 1))

    # Apply cap
    if max_positives is not None and len(positives) > max_positives:
        positives = rng.sample(positives, max_positives)

    # Negative target
    target_negatives = math.ceil(len(positives) * target_ratio)

    # Generate negatives
    while len(negatives) < target_negatives:

        idx1, idx2 = rng.sample(range(len(processed_entries)), 2)

        clones1 = processed_entries[idx1]
        clones2 = processed_entries[idx2]

        if not clones1 or not clones2:
            continue

        c1 = rng.choice(clones1)
        c2 = rng.choice(clones2)

        key = tuple(sorted((c1, c2))) + (0,)

        if key in seen:
            continue

        seen.add(key)
        negatives.append((c1, c2, 0))

    pairs = positives + negatives

    rng.shuffle(pairs)

    print(
        f"Built {len(pairs)} pairs "
        f"(Positives: {len(positives)}, "
        f"Negatives: {len(negatives)})"
    )

    return pairs



def build_pairs_from_folders(seed=42,language="python",dataset="GPTCloneBench"):
    """
    Build positive and negative pairs from a folder containing source files.
    Logic for number of positives and negatives is unchanged.
    """
    
    if language not in GPT_LANGUAGE_ADAPTERS or language not in SEMANTIC_LANGUAGE_ADAPTERS:
        raise ValueError(f"Unsupported language: {language}")

    adapter = (
        GPT_LANGUAGE_ADAPTERS[language]
        if dataset == "GPTCloneBench"
        else SEMANTIC_LANGUAGE_ADAPTERS[language]
    )


    pos_folder = adapter["pairs_folder"]
    output_file = adapter["output_file"]
    extension = adapter["extension"]
    extract = adapter["extract"]
    remove_sig = adapter["remove_signature"]
    get_sig = adapter["get_signature"]

    if os.path.exists(output_file):
            print(f"Loading {language} pairs from {output_file}...")
            with open(output_file, "r", encoding="utf-8") as f:
                pairs = json.load(f)
            return pairs
    else:
        print(f"Pairs file not found. Building {language} pairs...")
        
    rng = random.Random(seed)
    pairs = []

    # Step 1: Read all functions from all files 
    file_functions = []
    all_files = [f for f in os.listdir(pos_folder) if f.endswith(extension)]

    for filename in all_files:
        path = os.path.join(pos_folder, filename)
        funcs = extract(path)

        if len(funcs) >= 2:
            # POSITIVE PAIR
            pairs.append((
                remove_sig(funcs[0]),
                remove_sig(funcs[1]),
                1
            ))

        if funcs:
            file_functions.append(funcs)

    total_positives = sum(1 for _, _, l in pairs if l == 1)

    # Step 2: Generate the same number of negative pairs 
    negatives = []
    total_files = len(file_functions)

    if total_files < 2:
        print("Not enough files to generate negative pairs.")
    else:
        attempts = 0
        while len(negatives) < total_positives and attempts < total_positives * 10:
            i, j = rng.sample(range(total_files), 2)
            funcs_i = file_functions[i]
            funcs_j = file_functions[j]

            func_a = rng.choice(funcs_i)
            sig_a = get_sig(func_a)

            func_b_candidates = [
                f for f in funcs_j
                if get_sig(f) != sig_a
            ]

            if not func_b_candidates:
                attempts += 1
                continue

            func_b = rng.choice(func_b_candidates)

            negatives.append((
                remove_sig(func_a),
                remove_sig(func_b),
                0
            ))
            attempts += 1

    # Combine and shuffle 
    pairs.extend(negatives)
    rng.shuffle(pairs)

    positives = sum(1 for _, _, l in pairs if l == 1)
    negatives_count = sum(1 for _, _, l in pairs if l == 0)

    print(
        f"Built {len(pairs)} {language} code pairs for {dataset} dataset"
        f"(Positives: {positives}, Negatives: {negatives_count})"
    )

    os.makedirs(os.path.dirname(output_file), exist_ok=True)
    with open(output_file, "w", encoding="utf-8") as f:
        json.dump(pairs, f, indent=2)

    print(f"Saved {language} pairs to {output_file}")
    return pairs
 

def build_pairs_from_folders_split(seed=42, language="python", dataset="GPTCloneBench", test_size=0.2):

    if language not in GPT_LANGUAGE_ADAPTERS or language not in SEMANTIC_LANGUAGE_ADAPTERS:
        raise ValueError(f"Unsupported language: {language}")

    adapter = (
        GPT_LANGUAGE_ADAPTERS[language]
        if dataset == "GPTCloneBench"
        else SEMANTIC_LANGUAGE_ADAPTERS[language]
    )

    pos_folder = adapter["pairs_folder"]
    output_file = adapter["output_file"]
    extension = adapter["extension"]
    extract = adapter["extract"]
    remove_sig = adapter["remove_signature"]

    identity_fn = (
        adapter["get_signature"]
        if dataset == "GPTCloneBench"
        else adapter["get_name"]
    )

    cache_file = output_file.replace(".json", f"_split_seed{seed}.json")

    if os.path.exists(cache_file):
        print(f"Loading split cache from {cache_file}")
        with open(cache_file, "r", encoding="utf-8") as f:
            cached = json.load(f)
        return cached["train"], cached["test"]

    rng = random.Random(seed)

    all_files = [f for f in os.listdir(pos_folder) if f.endswith(extension)]

    file_entries = []

    for filename in all_files:

        path = os.path.join(pos_folder, filename)
        funcs = extract(path)

        if len(funcs) < 2:
            continue

        group_id = identity_fn(funcs[0])

        file_entries.append({
            "group": group_id,
            "funcs": funcs
        })

    groups = [x["group"] for x in file_entries]

    gss = GroupShuffleSplit(
        n_splits=1,
        test_size=test_size,
        random_state=seed
    )

    indices = list(range(len(file_entries)))

    train_idx, test_idx = next(
        gss.split(indices, groups=groups)
    )

    train_files = [file_entries[i]["funcs"] for i in train_idx]
    test_files = [file_entries[i]["funcs"] for i in test_idx]

    def _build_pairs(files):

        pairs = []

        for funcs in files:

            if len(funcs) >= 2:

                pairs.append((
                    remove_sig(funcs[0]),
                    remove_sig(funcs[1]),
                    1
                ))

        total_positives = len(pairs)

        negatives = []

        total_files = len(files)

        attempts = 0

        while len(negatives) < total_positives and attempts < total_positives * 10:

            i, j = rng.sample(range(total_files), 2)

            funcs_i = files[i]
            funcs_j = files[j]

            func_a = rng.choice(funcs_i)

            a_id = identity_fn(func_a)

            if dataset == "SemanticCloneBench":

                func_b_candidates = [
                    f for f in funcs_j
                    if _name_similarity(identity_fn(f), a_id) < 0.7
                ]

            else:

                func_b_candidates = [
                    f for f in funcs_j
                    if identity_fn(f) != a_id
                ]

            if not func_b_candidates:
                attempts += 1
                continue

            func_b = rng.choice(func_b_candidates)

            negatives.append((
                remove_sig(func_a),
                remove_sig(func_b),
                0
            ))

            attempts += 1

        pairs.extend(negatives)

        rng.shuffle(pairs)

        return pairs

    train_pairs = _build_pairs(train_files)
    test_pairs = _build_pairs(test_files)

    cache_data = {
        "train": train_pairs,
        "test": test_pairs
    }

    with open(cache_file, "w", encoding="utf-8") as f:
        json.dump(cache_data, f, indent=2)

    print(
        f"Created split for {dataset} "
        f"with {len(train_pairs)} train pairs and "
        f"{len(test_pairs)} test pairs"
    )

    return train_pairs, test_pairs



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
    print(" Hugging Face login successful!")

def _get_function_signature(code):
    """
    Extracts the function signature from a function code string.
    Returns: a string like 'def func_name(arg1, arg2):'
    """
    try:
        tree = ast.parse(code)
        for node in tree.body:
            if isinstance(node, ast.FunctionDef):
                args = [a.arg for a in node.args.args]
                return f"{node.name}({', '.join(args)})"
    except Exception as e:
        # Fallback if parsing fails: use first line
        return code.splitlines()[0].strip()
    return None

def _get_function_name(code):
    """
    Extracts only the Python function name.
    Returns: 'func_name'
    """
    try:
        tree = ast.parse(code)
        for node in tree.body:
            if isinstance(node, ast.FunctionDef):
                return node.name
    except Exception:
        pass

    # fallback: try regex if AST fails
    import re
    match = re.search(r"def\s+([a-zA-Z_][a-zA-Z0-9_]*)", code)
    if match:
        return match.group(1)

    return None

def _extract_functions_from_file(path):
    """
    Returns a list of function code strings from a Python file using parso.
    """
    code = _read_source_file(path)

    funcs = []
    try:
        module = parso.parse(code)
        for node in module.iter_funcdefs():
            func_code = node.get_code().strip()
            if func_code:
                funcs.append(func_code)
    except Exception as e:
        print(f"Failed to parse {path} with parso: {e}")
    return funcs

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

def _extract_java_methods_from_file(path):
    """
    Extracts Java method code blocks from a .java file.
    Returns a list of full method strings (signature + body).
    """
    code = _read_source_file(path)

    methods = []

    # Rough matcher for method signatures (not constructors)
    signature_pattern = re.compile(
        r'''
        (public|protected|private)?\s*          # visibility
        (static\s+)?                            # static
        ([\w\<\>\[\]]+\s+)+                    # return type
        (\w+)\s*                                # method name
        \([^)]*\)\s*                            # parameters
        (throws\s+[\w,\s]+)?\s*                # throws clause
        \{                                      # method body start
        ''',
        re.VERBOSE | re.MULTILINE
    )

    for match in signature_pattern.finditer(code):
        start = match.start()
        brace_count = 0
        i = match.end() - 1

        while i < len(code):
            if code[i] == "{":
                brace_count += 1
            elif code[i] == "}":
                brace_count -= 1
                if brace_count == 0:
                    methods.append(code[start:i+1].strip())
                    break
            i += 1

    return methods

def _remove_java_method_signature(code: str) -> str:
    """
    Removes Java method signature and outer braces.
    Returns only the method body.
    """
    code = code.strip()

    # Find first opening brace of the method
    first_brace = code.find("{")
    last_brace = code.rfind("}")

    if first_brace == -1 or last_brace == -1:
        return ""

    body = code[first_brace + 1:last_brace]

    # Normalize indentation
    lines = body.splitlines()

    # Remove empty leading/trailing lines
    while lines and not lines[0].strip():
        lines.pop(0)
    while lines and not lines[-1].strip():
        lines.pop()

    # Compute minimum indentation
    indents = [
        len(line) - len(line.lstrip())
        for line in lines
        if line.strip()
    ]
    min_indent = min(indents) if indents else 0

    cleaned = [line[min_indent:] for line in lines]
    return "\n".join(cleaned)
 
def _get_java_method_signature(code: str):
    """
    Extracts Java method signature from method code.
    Returns: 'methodName(type1 arg1, type2 arg2)'
    """
    code = code.strip().replace("\n", " ")

    pattern = re.compile(
        r'''
        (public|protected|private)?\s*
        (static\s+)?(final\s+)?(synchronized\s+)?   # modifiers
        ([\w\<\>\[\]]+\s+)+                          # return type
        (?P<name>\w+)\s*
        \((?P<params>[^)]*)\)
        ''',
        re.VERBOSE
    )

    match = pattern.search(code)
    if not match:
        return None

    name = match.group("name")
    params = match.group("params").strip()

    return f"{name}({params})"

def _get_java_method_name(code: str):
    """
    Extracts only the Java method name.
    Returns: 'methodName'
    """
    code = code.strip().replace("\n", " ")

    pattern = re.compile(
        r'''
        (public|protected|private)?\s*
        (static\s+)?(final\s+)?(synchronized\s+)?   # modifiers
        ([\w\<\>\[\]]+\s+)+                         # return type
        (?P<name>\w+)\s*
        \(
        ''',
        re.VERBOSE
    )

    match = pattern.search(code)
    if not match:
        return None

    return match.group("name")

def _extract_csharp_methods_from_file(path):
    """
    Extracts C# method code blocks from a .cs file.
    Returns a list of full method strings (signature + body).
    """
    code = _read_source_file(path)

    methods = []

    signature_pattern = re.compile(
        r'''
        (public|private|protected|internal)?\s*
        (static\s+|virtual\s+|override\s+|async\s+)*   # modifiers
        ([\w\<\>\[\],]+\s+)+                           # return type
        (?P<name>\w+)\s*
        \((?P<params>[^\)]*)\)\s*
        (where\s+[\w\s,:<>]+)?\s*                      # generic constraints
        \{
        ''',
        re.VERBOSE | re.MULTILINE
    )

    for match in signature_pattern.finditer(code):
        start = match.start()
        brace_count = 0
        i = match.end() - 1

        while i < len(code):
            if code[i] == "{":
                brace_count += 1
            elif code[i] == "}":
                brace_count -= 1
                if brace_count == 0:
                    methods.append(code[start:i + 1].strip())
                    break
            i += 1

    return methods


def _remove_csharp_method_signature(code: str) -> str:
    """
    Removes C# method signature and outer braces.
    Returns only the method body.
    """
    code = code.strip()

    first_brace = code.find("{")
    last_brace = code.rfind("}")

    if first_brace == -1 or last_brace == -1:
        return ""

    body = code[first_brace + 1:last_brace]

    lines = body.splitlines()

    while lines and not lines[0].strip():
        lines.pop(0)
    while lines and not lines[-1].strip():
        lines.pop()

    indents = [
        len(line) - len(line.lstrip())
        for line in lines
        if line.strip()
    ]
    min_indent = min(indents) if indents else 0

    return "\n".join(line[min_indent:] for line in lines)

def _get_csharp_method_signature(code: str):
    """
    Extracts C# method signature.
    Returns: 'MethodName(type1 arg1, type2 arg2)'
    """
    code = code.strip().replace("\n", " ")

    pattern = re.compile(
        r'''
        (public|private|protected|internal)?\s*
        (static\s+|virtual\s+|override\s+|async\s+)*
        ([\w\<\>\[\],]+\s+)+
        (?P<name>\w+)\s*
        \((?P<params>[^\)]*)\)
        ''',
        re.VERBOSE
    )

    match = pattern.search(code)
    if not match:
        return None

    return f"{match.group('name')}({match.group('params').strip()})"

def _get_csharp_method_name(code: str):
    """
    Extracts only the C# method name.
    Returns: 'MethodName'
    """
    code = code.strip().replace("\n", " ")

    pattern = re.compile(
        r'''
        (public|private|protected|internal)?\s*
        (static\s+|virtual\s+|override\s+|async\s+)*

        ([\w\<\>\[\],]+\s+)+   # return type(s)

        (?P<name>\w+)\s*       # method name

        \(
        ''',
        re.VERBOSE
    )

    match = pattern.search(code)
    if not match:
        return None

    return match.group("name")


def build_pairs_bigclonebench(output_file=BIGCLONEBENCH_PAIRS, split="test"):
    """
    Converts BigCloneBench (CodeXGLUE) dataset to JSON pairs.
    Output format: [code1, code2, label]
    """
    if os.path.exists(output_file):
        print(f"Loading BigCloneBench pairs from {output_file}...")
        with open(output_file, "r", encoding="utf-8") as f:
            pairs = json.load(f)
        return pairs

    print("Pairs file not found. Building BigCloneBench pairs...")
    hf_login()
    dataset = load_dataset("google/code_x_glue_cc_clone_detection_big_clone_bench",  split=split)
    
    pairs = []

    for example in dataset:
        code1 = example["func1"]
        code2 = example["func2"]
        label = int(example["label"])
        code1_body = _remove_java_method_signature(code1)
        code2_body = _remove_java_method_signature(code2)

        pairs.append((code1_body, code2_body, label))

    os.makedirs(os.path.dirname(output_file), exist_ok=True)
    with open(output_file, "w", encoding="utf-8") as f:
        json.dump(pairs, f, indent=2)

    positives = sum(1 for _, _, l in pairs if l == 1)
    negatives = sum(1 for _, _, l in pairs if l == 0)

    print(
        f"Saved {len(pairs)} pairs to {output_file} "
        f"(Positives: {positives}, Negatives: {negatives})"
    )
    return pairs


def clean_and_split_clones(raw_path: str, cleaned_path: str) -> None:
    print(f"Cleaning and splitting clones from {raw_path} to {cleaned_path}...")
    def _extract_imports(tree: ast.Module, source: str) -> str:
        lines = source.splitlines(keepends=True)
        import_lines = []
        for node in tree.body:
            if isinstance(node, (ast.Import, ast.ImportFrom)):
                chunk = "".join(lines[node.lineno - 1: node.end_lineno])
                import_lines.append(chunk)
        return "".join(import_lines)

    def _node_source(node: ast.stmt, src_lines: list[str]) -> str:
        return "".join(src_lines[node.lineno - 1: node.end_lineno])

    def _rename_funcdef_to_task_func(code_block: str) -> str:
        """
        Replace the function name in the 'def <name>(' line with 'task_func',
        leaving the signature and body completely untouched.
        """
        return re.sub(
            r'^(\s*def\s+)\w+(\s*\()',
            r'\1task_func\2',
            code_block.strip(),
            count=1,
            flags=re.MULTILINE,
        )

    def _build_class_wrapper(
        class_node: ast.ClassDef,
        method_node: ast.FunctionDef,
        class_src: str,
    ) -> str:
        """
        Given the full class source and the method inside it that contains
        task_func logic, return:

            <full class source>


            def task_func(<same signature minus self>):
                return <ClassName>().<method_name>(<args>)
        """
        # --- signature: drop 'self' from parameters ---
        args = method_node.args

        # positional params (skip self which is always first)
        param_names = [a.arg for a in args.args[1:]]

        # defaults are right-aligned against args.args
        num_args = len(args.args[1:])          # excluding self
        num_defaults = len(args.defaults)
        default_offset = num_args - num_defaults

        param_parts = []
        for i, name in enumerate(param_names):
            default_idx = i - default_offset
            if default_idx >= 0:
                default_node = args.defaults[default_idx]
                default_src = ast.unparse(default_node)
                param_parts.append(f"{name}={default_src}")
            else:
                param_parts.append(name)

        # *args
        if args.vararg:
            param_parts.append(f"*{args.vararg.arg}")

        # keyword-only args
        for i, kwarg in enumerate(args.kwonlyargs):
            kw_default = args.kw_defaults[i]
            if kw_default is not None:
                param_parts.append(f"{kwarg.arg}={ast.unparse(kw_default)}")
            else:
                param_parts.append(kwarg.arg)

        # **kwargs
        if args.kwarg:
            param_parts.append(f"**{args.kwarg.arg}")

        sig = ", ".join(param_parts)

        # call args (just the names, no defaults)
        call_positional = param_names
        call_vararg = [f"*{args.vararg.arg}"] if args.vararg else []
        call_kwargs = [k.arg for k in args.kwonlyargs]
        call_kwarg = [f"**{args.kwarg.arg}"] if args.kwarg else []
        call_args = ", ".join(call_positional + call_vararg + call_kwargs + call_kwarg)

        wrapper = (
            f"def task_func({sig}):\n"
            f"    return {class_node.name}().{method_node.name}({call_args})\n"
        )
        return class_src.rstrip("\n") + "\n\n\n" + wrapper

    def _extract_task_funcs(
        source: str,
        tree: ast.Module,
        src_lines: list[str],
    ) -> list[tuple[str, bool, ast.ClassDef | None, ast.FunctionDef]]:
        """
        Returns a list of tuples:
            (code_block, is_class_wrapped, class_node_or_None, func_node)

        code_block          - the source string to use for this clone
        is_class_wrapped    - True when the function was found inside a class
        class_node_or_None  - the ClassDef node (for wrapper generation)
        func_node           - the FunctionDef node
        """
        results = []

        # Top-level functions
        for node in tree.body:
            if isinstance(node, ast.FunctionDef) and "task_func" in node.name:
                func_src = _node_source(node, src_lines)
                results.append((func_src, False, None, node))

        # Functions inside top-level classes
        for node in tree.body:
            if isinstance(node, ast.ClassDef):
                task_func_methods = [
                    item for item in node.body
                    if isinstance(item, ast.FunctionDef)
                    and "task_func" in item.name
                    and item.name != "__init__"
                ]
                # Only split if at least one method contains task_func in its name
                if task_func_methods:
                    class_src = _node_source(node, src_lines)
                    for item in task_func_methods:
                        results.append((class_src, True, node, item))

        return results

    def _increment_clone_id(clone_id: str, new_index: int) -> str:
        return re.sub(
            r'(?<![:\w])(\d+)(?=\s)',
            str(new_index),
            clone_id,
            count=1,
        )

    def _split_clone(clone: dict) -> list[dict]:
        source = clone.get("code", "")
        try:
            tree = ast.parse(source)
        except SyntaxError:
            return [clone]

        src_lines = source.splitlines(keepends=True)
        import_src = _extract_imports(tree, source)
        task_funcs = _extract_task_funcs(source, tree, src_lines)

        if len(task_funcs) <= 1:
            return [clone]

        clone_id = clone.get("clone_id", "")
        counter_match = re.search(r'(?<![:\w])(\d+)(?=\s)', clone_id)
        base_counter = int(counter_match.group(1)) if counter_match else 1

        new_clones = []
        for idx, (code_block, is_class_wrapped, class_node, func_node) in enumerate(task_funcs):

            if is_class_wrapped:
                func_body = _build_class_wrapper(class_node, func_node, code_block)
            else:
                func_body = _rename_funcdef_to_task_func(code_block) 

            # Prepend shared imports
            if import_src.strip():
                full_code = import_src.rstrip("\n") + "\n\n\n" + func_body
            else:
                full_code = func_body
 
            new_clone = dict(clone)
            new_clone["code"] = full_code
            new_clone["clone_id"] = _increment_clone_id(clone_id, base_counter + idx)
            new_clone.pop("metrics", None)
            new_clone.pop("test_results", None)
            new_clones.append(new_clone)

        return new_clones

    with open(raw_path, "r", encoding="utf-8") as f:
        data = json.load(f)

    for entry in data:
        expanded = []
        for clone in entry.get("clones", []):
            code = clone.get("code")
            # Skip invalid clones
            if not isinstance(code, str) or code.strip() in {"", "None"}:
                continue
            split = _split_clone(clone)
            for c in split:
                c["code"] = _remove_comments(_remove_tests(c["code"])) 
            expanded.extend(split)
        entry["clones"] = expanded

    with open(cleaned_path, "w", encoding="utf-8") as f:
        json.dump(data, f, indent=2)

    print(f"clean_and_split_clones: saved {len(data)} entries → {cleaned_path}")

def _remove_comments(source: str) -> str:
    # Step 1: remove # comments via regex
    source = re.sub(r'#[^\n]*', '', source)
    source = re.sub(r'""".*?"""|\'\'\'.*?\'\'\'', '', source, flags=re.DOTALL)
    # Step 2: remove docstrings by finding them in AST and cutting their lines
    try:
        tree = ast.parse(source)
    except SyntaxError:
        return source

    lines = source.splitlines(keepends=True)
    lines_to_remove = set()

    for node in ast.walk(tree):
        if isinstance(node, (ast.Module, ast.FunctionDef, ast.AsyncFunctionDef, ast.ClassDef)):
            if (node.body
                    and isinstance(node.body[0], ast.Expr)
                    and isinstance(node.body[0].value, ast.Constant)
                    and isinstance(node.body[0].value.value, str)):
                docstring_node = node.body[0]
                for lineno in range(docstring_node.lineno, docstring_node.end_lineno + 1):
                    lines_to_remove.add(lineno)

    result = [
        line for i, line in enumerate(lines, start=1)
        if i not in lines_to_remove
    ]
    return "".join(result)

def _remove_tests(source: str) -> str:
    # First remove test functions (before class cleanup)
    source = re.sub(
        r'\n+[ \t]*def\s+\w*[Tt]est\w*\s*\(.*?\).*?(?=\n\S|\Z)',
        '',
        source,
        flags=re.DOTALL
    )
    # Then remove empty/incomplete test class definitions
    source = re.sub(
        r'\n+[ \t]*class\s+\w*[Tt]est\w*\s*(\(.*?\))?\s*:\s*$',
        '',
        source,
        flags=re.MULTILINE
    )
    try:
        tree = ast.parse(source)
    except SyntaxError:
        return source

    lines = source.splitlines(keepends=True)
    lines_to_remove = set()

    for node in tree.body:
        is_test_class = isinstance(node, ast.ClassDef) and 'test' in node.name.lower()
        is_main_block = (isinstance(node, ast.If) and
                        isinstance(node.test, ast.Compare) and
                        isinstance(node.test.left, ast.Name) and
                        node.test.left.id == '__name__')
        is_test_import = (isinstance(node, (ast.Import, ast.ImportFrom)) and
                         any(n in ('unittest', 'doctest', 'pytest')
                             for n in ([a.name for a in node.names] if isinstance(node, ast.Import)
                                      else [node.module]) if n))

        if is_test_class or is_main_block or is_test_import:
            # Remove from the last line of previous node to end of this node
            for lineno in range(node.lineno, node.end_lineno + 1):
                lines_to_remove.add(lineno)

    result = [line for i, line in enumerate(lines, start=1) if i not in lines_to_remove]
    # Strip trailing blank lines left by removal
    return "".join(result).rstrip() + "\n"


def _name_similarity(a: str, b: str) -> float:
    """
    Returns normalized similarity in [0, 1]
    1 = identical
    0 = completely different
    """
    if not a and not b:
        return 1.0

    dist = Levenshtein.distance(a, b)
    max_len = max(len(a), len(b))

    if max_len == 0:
        return 1.0

    return 1.0 - (dist / max_len)
 
 

def _read_source_file(path: str) -> str:
    """
    Robust source file reader with encoding fallbacks.
    """

    encodings = ["utf-8", "utf-8-sig", "cp1252", "latin-1"]

    for enc in encodings:
        try:
            with open(path, "r", encoding=enc) as f:
                return f.read()
        except UnicodeDecodeError:
            continue

    raise UnicodeDecodeError("unknown",
        b"",
        0,
        1,
        f"Could not decode file: {path}"
    )

GPT_LANGUAGE_ADAPTERS = {
    "python": {
        "extension": ".py",
        "pairs_folder": GPTCLONEBENCH_PY_POS_CLONES_DIR,
        "output_file": GPTCLONEBENCH_PY_PAIRS,
        "extract": _extract_functions_from_file,
        "remove_signature": remove_function_signature,
        "get_signature": _get_function_signature,
        "get_name": _get_function_name,
    },
    "java": {
        "extension": ".java",
        "pairs_folder": GPTCLONEBENCH_JAVA_POS_CLONES_DIR,
        "output_file": GPTCLONEBENCH_JAVA_PAIRS,
        "extract": _extract_java_methods_from_file,
        "remove_signature": _remove_java_method_signature,
        "get_signature": _get_java_method_signature,
        "get_name": _get_java_method_name,
    },
    "csharp": {
        "extension": ".cs",
        "pairs_folder": GPTCLONEBENCH_CS_POS_CLONES_DIR,
        "output_file": GPTCLONEBENCH_CS_PAIRS,
        "extract": _extract_csharp_methods_from_file,
        "remove_signature": _remove_csharp_method_signature,
        "get_signature": _get_csharp_method_signature,
        "get_name": _get_csharp_method_name,
    },
}

SEMANTIC_LANGUAGE_ADAPTERS = {
    "python": {
        "extension": ".py",
        "pairs_folder": SCLONEBENCH_PY_POS_CLONES_DIR,
        "output_file": SCLONEBENCH_PY_PAIRS,
        "extract": _extract_functions_from_file,
        "remove_signature": remove_function_signature,
        "get_signature": _get_function_signature,
        "get_name": _get_function_name,
    },
    "java": {
        "extension": ".java",
        "pairs_folder": SCLONEBENCH_JAVA_POS_CLONES_DIR,
        "output_file": SCLONEBENCH_JAVA_PAIRS,
        "extract": _extract_java_methods_from_file,
        "remove_signature": _remove_java_method_signature,
        "get_signature": _get_java_method_signature,
        "get_name": _get_java_method_name,
    },
    "csharp": {
        "extension": ".cs",
        "pairs_folder": SCLONEBENCH_CS_POS_CLONES_DIR,
        "output_file": SCLONEBENCH_CS_PAIRS,
        "extract": _extract_csharp_methods_from_file,
        "remove_signature": _remove_csharp_method_signature,
        "get_signature": _get_csharp_method_signature,
        "get_name": _get_csharp_method_name,
    },
}