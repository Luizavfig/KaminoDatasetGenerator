import os, json, random
from concurrent.futures import ThreadPoolExecutor, as_completed
from tqdm import tqdm
from codebleu import calc_codebleu 
from ..utils.prompts import (SYSTEM_PROMPT_MINIMAL, build_user_prompt_retest)
from ..utils.helper_functions import (validate_with_unittest, remove_function_signature)
from .clone_gen import _generate_clones, _load_existing_results
from src.config import *
_codebleu_cache = {}
_test_cache = {}

def run_reprompt():
    with open(SAMPLE_1_PATH, "r", encoding="utf-8") as f:
        original_data = json.load(f)
    original_by_id = {e["id"]: e for e in original_data}

    results = _load_existing_results(FILTERED_PATH_CODEBLEU)
    sample_entries = results[:N_ENTRIES] if N_ENTRIES else results

    with ThreadPoolExecutor(max_workers=MAX_WORKERS) as executor:
        futures = []
        for clone_entry in sample_entries:
            print(f"\n🔄 Processing {clone_entry['id']}")
            entry_id = clone_entry["id"]
            entry = original_by_id[entry_id]
            tests_list = entry.get("test", [])
            clones = clone_entry.get("clones", [])
            for clone in clones:
                test_results = clone.get("test_results", {})
                failing_tests = [
                    t for t, r in test_results.items()
                    if isinstance(r, str) and r.upper() in ("FAIL", "ERROR")
                ]
                codebleu = clone.get("metrics", {}).get("codebleu", {}).get("originalcode", 1.0)

                # Schedule only if clone passes at least one test (partial success)
                # and either fails some tests OR has a high CodeBLEU 
                passed_tests = sum(
                    1 for r in test_results.values()
                    if isinstance(r, str) and r.upper() == "PASS"
                )
                if passed_tests >= MIN_TEST_REPROMPT and (failing_tests or codebleu > CODEBLEU_THRESHOLD): # at least one failing test or too similar
                    futures.append(executor.submit(
                        _process_clone, clone_entry["id"], clone, entry, tests_list, ALL_MODELS, LLM_OPTS, REPROMPT_PATH))


        for f in tqdm(as_completed(futures), total=len(futures), desc="Processing clones"):
            f.result()  # ensure exceptions propagate



def _cached_codebleu(ref_body, clone_body):
    key = (ref_body, clone_body)
    if key in _codebleu_cache:
        return _codebleu_cache[key]
    score = calc_codebleu([ref_body], [clone_body], lang="python")
    value = float(score["codebleu"])
    _codebleu_cache[key] = value
    return value


def _cached_testing(code, tests_list):
    key = (code, tuple(tests_list))
    if key in _test_cache:
        return _test_cache[key]
    result = validate_with_unittest(code, tests_list)
    _test_cache[key] = result
    return result


def _reprompt_clone(clone, entry, tests_list, models, used_models, original_model, LLM_OPTS,n):
    clone_id = clone.get("clone_id", "unknown")
    params = entry.get("metadata", {}).get("params", [])
    return_text = entry.get("metadata", {}).get("return_text", [])
    tests_snippet = "\n".join(tests_list) if tests_list else ""

    # Select model
    available_models = [m for m in models if m != original_model and m not in used_models]
    if not available_models:
        raise RuntimeError(f"No alternative model available for {clone_id}.")
    reprompt_model = random.choice(available_models)
    used_models.append(reprompt_model)

    # Prompt setup
    print(f"⚙️  Reprompting (attempt {n}, model={reprompt_model})")
    user_prompt = build_user_prompt_retest(
        clone_code=clone["code"],
        params=params,
        return_text=return_text,
        tests_snippet=tests_snippet,
        failing_tests=[
            t for t, r in clone.get("test_results", {}).items()
            if isinstance(r, str) and r.upper() in ("FAIL", "ERROR")
        ],
    )
    messages = [
        {"role": "system", "content": SYSTEM_PROMPT_MINIMAL},
        {"role": "user", "content": user_prompt},
    ]
  
    try:
        repaired_code = _generate_clones(
            messages,
            model=reprompt_model,
            options=LLM_OPTS,
            expected_func_name=FUNCTION_NAME,
        ) 
        # Cached evaluation
        test_results = _cached_testing(repaired_code, tests_list)
        failing_tests = [
            t for t, r in test_results.items()
            if isinstance(r, str) and r.upper() in ("FAIL", "ERROR")
        ]
        if repaired_code is None or entry.get("original_code") is None:
            raise ValueError("Original code or repaired code is missing")
        ref_body = remove_function_signature(entry.get("original_code"))
        clone_body = remove_function_signature(repaired_code)
        codebleu = _cached_codebleu(ref_body, clone_body)

        # Update clone info
        clone["code"] = repaired_code
        clone["test_results"] = test_results
        clone["metrics"]["codebleu"]["originalcode"] = codebleu
        clone["reprompt"] = f"test {n} (model={reprompt_model})"

        return clone, failing_tests, codebleu

    except Exception as e:
        print(f"❌ Error reprompting {clone_id}: {e}")
        clone["reprompt"] = f"test {n} (error, model={reprompt_model})"
        return clone, ["ERROR"], 1.0




def _process_clone(entry_id, clone, entry, tests_list, models, LLM_OPTS, out_path): 
    original_model = clone.get("model")
    used_models = []
    n = 0  
    final_failing_tests = []
    final_codebleu = 1.0
    while n < MAX_RETRIES:
        n += 1
        clone, failing_tests, codebleu = _reprompt_clone(
            clone=clone,
            entry=entry,
            tests_list=tests_list,
            models=models,
            used_models=used_models,
            original_model=original_model,
            LLM_OPTS=LLM_OPTS,
            n=n,
        )

        final_codebleu = codebleu
        final_failing_tests = failing_tests

        # Only save if both conditions are satisfied
        if not failing_tests and codebleu <= CODEBLEU_THRESHOLD:
            _update_results(entry_id, clone, out_path) 
            return

        if not failing_tests and codebleu > CODEBLEU_THRESHOLD:
            print(f"⚠️ Clone passes tests but too similar (CodeBLEU={codebleu:.4f})")
            # continue retrying to improve diversity
            continue

        if failing_tests:
            print(f"⚠️ Clone still failing {len(failing_tests)} tests (retry {n}/{MAX_RETRIES})")

    # If reached max retries without a valid clone
    if final_failing_tests or final_codebleu > CODEBLEU_THRESHOLD:
        print(f"❌ Clone discarded — tests={'fail' if final_failing_tests else 'pass'} "
              f"CodeBLEU={final_codebleu:.4f}")


def _update_results(entry_id, clone, out_path):
    """
    Update the results file with a single clone.
    - If the file doesn't exist, create it.
    - If the entry exists, update the clone by clone_id.
    - Otherwise, append the entry with this clone.
    """ 

    # Load existing results or start empty
    if os.path.exists(out_path):
        with open(out_path, "r", encoding="utf-8") as f:
            saved_results = json.load(f)
    else:
        saved_results = []

    # Find entry in saved results
    entry_found = False
    for entry in saved_results:
        if entry["id"] == entry_id:
            # Merge/update clone by clone_id
            clone_map = {c["clone_id"]: c for c in entry.get("clones", [])}
            clone_map[clone["clone_id"]] = clone
            entry["clones"] = list(clone_map.values())
            entry_found = True
            break

    # If entry not found, create it
    if not entry_found:
        saved_results.append({
            "id": entry_id,
            "clones": [clone]
        })

    # Save back to file
    os.makedirs(os.path.dirname(out_path), exist_ok=True)
    with open(out_path, "w", encoding="utf-8") as f:
        json.dump(saved_results, f, indent=2)

    print(f"💾 Updated results saved for clone {clone['clone_id']} of entry {entry_id}")
