import parso
from pathlib import Path

 
def get_function_signature_parso(node):
    """
    Build a normalized function signature from a parso function node.
    """
    # Function name
    name = node.name.value
    # Parameters (just the identifiers)
    params = [p.name.value for p in node.get_params()]
    return f"{name}({','.join(params)})"


def extract_function_code_parso(node):
    """
    Extract full source code from a parso function node.
    """
    return node.get_code()



def collect_functions(folder: str):
    """
    Collect original functions and clones correctly:
    - First function per signature is the original
    - Second function per file is considered a clone
    """
    functions_by_signature = {}
    skipped_files = []

    for py_file in Path(folder).rglob("*.py"):
        try:
            source = py_file.read_text(encoding="utf-8")
            tree = parso.parse(source, error_recovery=True)
        except Exception as e:
            print(f"[ERROR] Could not parse file: {py_file}")
            print(f"  {e}")
            skipped_files.append(py_file)
            continue

        # Get all top-level function definitions
        func_nodes = list(tree.iter_funcdefs())

        if len(func_nodes) < 1:
            continue  # no functions found

        # --- Original function ---
        original_node = func_nodes[0]
        original_signature = get_function_signature_parso(original_node)
        original_code = extract_function_code_parso(original_node)

        # Only add the original if signature hasn't been seen yet
        if original_signature not in functions_by_signature:
            functions_by_signature[original_signature] = {
                "original_code": original_code,
                "clones": []
            }

        # --- Clone function ---
        if len(func_nodes) >= 2:
            clone_node = func_nodes[1]
            clone_code = extract_function_code_parso(clone_node)
            functions_by_signature[original_signature]["clones"].append(clone_code)

        # ignore any additional functions in the file

    if skipped_files:
        print("\nSkipped files due to fatal errors:")
        for f in skipped_files:
            print(f"  {f}")

    return functions_by_signature



def build_clonebench_json(functions_by_signature):
    entries = []
    entry_counter = 1

    for signature, data in functions_by_signature.items():
        original_code = data["original_code"]
        clone_codes = data["clones"]

        entry = {
            "id": f"GPTCloneBench/{entry_counter:04d}",
            "language": "python",
            "original_code": original_code,
            "clones": []
        }

        for i, clone_code in enumerate(clone_codes, start=1):
            entry["clones"].append({
                "clone_id": i,
                "code": clone_code
            })

        entries.append(entry)
        entry_counter += 1

    return entries




