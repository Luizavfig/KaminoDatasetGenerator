#  Prevent GUI windows from blocking tests 
import os
os.environ["MPLBACKEND"] = "Agg"          # Disable GUI for matplotlib
os.environ["QT_QPA_PLATFORM"] = "offscreen"  # Disable GUI for Qt/OpenCV
os.environ["DISPLAY"] = ""    # Disable X11 GUI (Linux/macOS environments)

import matplotlib
matplotlib.use("Agg")
import matplotlib.pyplot as plt
plt.show = lambda *a, **kw: None

try:
    import cv2 # type: ignore[import]
    cv2.imshow = lambda *a, **kw: None
    cv2.waitKey = lambda *a, **kw: None
except ImportError:
    pass
#  End of GUI suppression setup 

import json, re
from ..utils.helper_functions import (clean_and_split_clones, remove_function_signature, install_package, extract_required_packages_clones, validate_with_unittest,calc_complete_codebleu) 
from itertools import combinations
from src.config import *

def _compute_codebleu_scores(dataset_path=SAMPLE_1_PATH, out_path=OUT_PATH):
    with open(dataset_path, "r", encoding="utf-8") as f:
        data = json.load(f)
    with open(out_path, "r", encoding="utf-8") as f:
        clone_data = json.load(f)

    data_by_id = {entry["id"]: entry for entry in data}

    for i, clone_entry in enumerate(clone_data, 1):
        entry_id = clone_entry["id"]
        print(f"\nEvaluating Entry {i}/{len(clone_data)} | id={entry_id}")

        if entry_id not in data_by_id:
            print(f"⚠️ No matching entry found for {entry_id}, skipping.")
            continue

        entry = data_by_id[entry_id]
        ref_code = entry.get("original_code")
        if not ref_code:
            print("⚠️ No reference code found, skipping.")
            continue

        ref_body = remove_function_signature(ref_code)
        clones = clone_entry.get("clones", [])

        for idx, clone in enumerate(clones):
            clone.setdefault("metrics", {})
            clone["metrics"].setdefault("codebleu", {})

            # Skip if already computed
            # if "originalcode" in clone["metrics"]["codebleu"]:
            #     print(f"Clone {idx + 1}: CodeBLEU already computed ({clone['metrics']['codebleu']['originalcode']:.4f})")
            #     continue

            try:
                clone_body = remove_function_signature(clone["code"])
                score = calc_complete_codebleu(ref_body, clone_body, lang="python")
                clone["metrics"]["codebleu"]["originalcode"] = score
                print(f"Clone {idx + 1}: CodeBLEU={score:.4f}")
            except Exception as e:
                print(f"  ❌ Error computing CodeBLEU for clone {idx + 1}: {e}")

     
    with open(out_path, "w", encoding="utf-8") as f:
        json.dump(clone_data, f, indent=2)

    print(f"\n✅ Done. Updated dataset with new CodeBLEU scores saved to {out_path}")


def run_codebleu_filtering(raw_path=OUT_PATH, cleaned_path=CLEANED_PATH, filtered_path=FILTERED_PATH_CODEBLEU):
    """
    Merges new clones from out_path into an existing filtered dataset, keeping only those with CodeBLEU <= CODEBLEU_THRESHOLD. The merged dataset is saved to filtered_path.
    """
    print("Starting codebleu against original code process...")
    clean_and_split_clones(raw_path, cleaned_path)
    _compute_codebleu_scores(out_path=cleaned_path) 
    if os.path.exists(filtered_path):
        with open(filtered_path, "r", encoding="utf-8") as f:
            existing_data = json.load(f)
    else:
        existing_data = []

    # Load new clones
    with open(cleaned_path, "r", encoding="utf-8") as f:
        new_data = json.load(f)

    # Build lookup by entry ID
    existing_by_id = {e["id"]: e for e in existing_data}

    added_count = 0
    updated_count = 0

    # Process each entry from cleaned data
    for entry in new_data:
        entry_id = entry["id"]

        if entry_id not in existing_by_id:
            existing_by_id[entry_id] = {"id": entry_id, "clones": []}

        target_clones = existing_by_id[entry_id]["clones"]
        # local lookup for fast access
        local_index = {c["clone_id"]: c for c in target_clones if "clone_id" in c}

        for clone in entry.get("clones", []):
            cid = clone.get("clone_id")
            if not cid:
                continue

            cb = clone.get("metrics", {}).get("codebleu", {})
 
            # UPDATE or ADD 
            if cid in local_index:
                existing_clone = local_index[cid]
                existing_clone["code"] = clone["code"]
                existing_clone["metrics"]["codebleu"] = cb
                updated_clone = existing_clone
                is_update = True
            else:
                target_clones.append(clone)
                local_index[cid] = clone
                updated_clone = clone
                is_update = False
 
            # FILTER STEP 
            if not _is_clone_valid(updated_clone):
                target_clones.remove(updated_clone)
                del local_index[cid]
            else:
                # COUNT ONLY FINAL KEPT CLONES
                if is_update:
                    updated_count += 1
                else:
                    added_count += 1

    # Save final dataset
    merged_data = list(existing_by_id.values())

    with open(filtered_path, "w", encoding="utf-8") as f:
        json.dump(merged_data, f, indent=2)

    print(f"Saved to {filtered_path}")
    print(f"Added clones (kept): {added_count}")
    print(f"Updated clones (kept): {updated_count}")


def run_tests(dataset_path=SAMPLE_1_PATH, filtered_path=FILTERED_PATH_CODEBLEU, skip_entries=True):
    print("Starting testing process...")
    with open(dataset_path, "r", encoding="utf-8") as f:
        data = json.load(f)
    with open(filtered_path, "r", encoding="utf-8") as f:
        clone_data = json.load(f)

    data_by_id = {entry["id"]: entry for entry in data}

    # flag to begin processing only once start_id is found
    
    start_id = "BigCodeBench/0"
    start_processing = (start_id is None)

    for i, clone_entry in enumerate(clone_data, 1):
        entry_id = clone_entry["id"]

        # Skip until we find the start_id
        if not start_processing and skip_entries:
            if entry_id == start_id:
                start_processing = True
            else:
                continue  # skip this entry

        print(f"\nTesting Entry {i}/{len(clone_data)} | id={entry_id}")

        if entry_id not in data_by_id:
            print(f"⚠️ No matching entry found for {entry_id}, skipping.")
            continue

        entry = data_by_id[entry_id]
        tests_list = entry.get("test", [])

        for k, clone in enumerate(clone_entry.get("clones", []), 1):
            try:
                if "test_results" in clone and clone["test_results"]:
                    print(f"  Clone {k}: already has test results, skipping.")
                    continue

                code = clone["code"]
                test_results = validate_with_unittest(code, tests_list)
                clone["test_results"] = test_results

                passed = sum(1 for v in test_results.values() if v == "PASS")
                failed = sum(1 for v in test_results.values() if v == "FAIL")
                error = sum(1 for v in test_results.values() if v.startswith("ERROR"))
                total = len(test_results)
                print(f"  Clone {k}: PASS={passed}, FAIL={failed}, ERROR={error}, Total={total}")

            except Exception as e:
                print(f"  ❌ Unexpected error testing clone {k}: {e}")
                error_results = {}
                for test_code in tests_list:
                    match = re.search(r'def (\w+)\(', test_code)
                    test_name = match.group(1) if match else f"unknown_test_{len(error_results)+1}"
                    error_results[test_name] = "ERROR"
                clone["test_results"] = error_results

        # Save progress
        with open(filtered_path, "w", encoding="utf-8") as f:
            json.dump(clone_data, f, indent=2)

    print(f"\n✅ Done. Saved dataset with test results to {filtered_path}")



def _install_missing_packages(filtered_path=FILTERED_PATH_CODEBLEU):    
    with open(filtered_path, "r", encoding="utf-8") as f:
        clone_data = json.load(f)  
    packages = extract_required_packages_clones(clone_data)
    print(f"Required packages: {packages}")

    for pkg in packages:
        try:
            __import__(pkg)
        except ImportError:
            try:
                print(f"Installing missing package: {pkg}")
                install_package(pkg)
            except Exception as e:
                # Catch all exceptions to prevent script from stopping
                print(f"⚠️ Could not install package {pkg}, skipping. Reason: {e}")
        except Exception as e:
            # Catch any unexpected import errors
            print(f"⚠️ Error importing package {pkg}, skipping. Reason: {e}")

    print("✅ Finished checking/installing packages.")
 

def run_test_filtering(filtered_path=FILTERED_PATH_CODEBLEU, reprompt_path=REPROMPT_PATH_CLEANED, filtered_path_tests=FILTERED_PATH_TESTS):
    print("Staring test filtering process...")
    clean_and_split_clones(REPROMPT_PATH, REPROMPT_PATH_CLEANED)
    _compute_codebleu_scores(out_path=REPROMPT_PATH_CLEANED) 
    _filter_by_codebleu(reprompt_path) 
    run_tests(filtered_path=reprompt_path, skip_entries=False) # test newly created clones
    with open(filtered_path, "r", encoding="utf-8") as f:
        original_data = json.load(f)
 
    reprompt_data = []
    if os.path.exists(reprompt_path) and os.path.getsize(reprompt_path) > 0:
        with open(reprompt_path, "r", encoding="utf-8") as f:
            reprompt_data = json.load(f)
    else:
        print(f"Warning: REPROMPT_PATH missing or empty, using only original dataset")

    orig_dict = _to_dict_by_id(original_data)
    reprompt_dict = _to_dict_by_id(reprompt_data)
    merged_data = []
    all_entry_ids = set(orig_dict.keys()) | set(reprompt_dict.keys())

    for entry_id in all_entry_ids: 
        base_entry = (reprompt_dict.get(entry_id) or orig_dict.get(entry_id) or {}).copy()

        # Collect all clones from both sources
        orig_clones = {c["clone_id"]: c for c in orig_dict.get(entry_id, {}).get("clones", [])}
        reprompt_clones = {c["clone_id"]: c for c in reprompt_dict.get(entry_id, {}).get("clones", [])}        
        merged_clones = {**orig_clones, **reprompt_clones}

        # Keep only clones that pass all tests
        passing_clones = [
            clone.copy()
            for clone in merged_clones.values()
            if clone.get("test_results") and all(r == "PASS" for r in clone["test_results"].values())
        ]
        if passing_clones:
            base_entry["clones"] = passing_clones
            merged_data.append(base_entry)

    with open(filtered_path_tests, "w", encoding="utf-8") as f:
        json.dump(merged_data, f, indent=2, ensure_ascii=False)

    print(f"Filtered dataset saved to {filtered_path_tests}, entries: {len(merged_data)}")


 
def _to_dict_by_id(data):
    """
    Convert to dict keyed by entry ID (each entry has a unique 'id')
    """
    return {entry["id"]: entry for entry in data}

def compute_codebleu_for_all(filtered_path_tests=FILTERED_PATH_TESTS): 
    print("Starting codebleu for all process...")
    with open(filtered_path_tests, "r", encoding="utf-8") as f:
        clone_data = json.load(f)

    for i, clone_entry in enumerate(clone_data, 1):
        entry_id = clone_entry["id"]
        print(f"\nEvaluating Entry {i}/{len(clone_data)} | id={entry_id}")

        clones = clone_entry.get("clones", [])
        n = len(clones)

        for idx1, idx2 in combinations(range(n), 2):
            clone1 = clones[idx1]
            clone2 = clones[idx2]

            clone1_id = clone1.get("clone_id", f"clone_{idx1 + 1}")
            clone2_id = clone2.get("clone_id", f"clone_{idx2 + 1}")

            clone1.setdefault("metrics", {}).setdefault("codebleu", {})
            clone2.setdefault("metrics", {}).setdefault("codebleu", {})

            # Skip if already computed in either direction
            # if clone2_id in clone1["metrics"]["codebleu"] and clone1_id in clone2["metrics"]["codebleu"]:
            #     print(f"  Skipping Clone {idx1 + 1} vs Clone {idx2 + 1} (already computed)")
            #     continue

            try:
                val = calc_complete_codebleu(clone1["code"], clone2["code"], lang="python") 
                clone1["metrics"]["codebleu"][clone2_id] = val
                clone2["metrics"]["codebleu"][clone1_id] = val

                print(f"  Clone {idx1 + 1} vs Clone {idx2 + 1}: CodeBLEU={val:.4f}")
            except Exception as e:
                print(f"  ❌ Error computing CodeBLEU for clones {idx1 + 1} vs {idx2 + 1}: {e}")

        # Save after finishing each entry
        with open(filtered_path_tests, "w", encoding="utf-8") as f:
            json.dump(clone_data, f, indent=2)

    print(f"\n✅ Done. Final dataset with CodeBLEU scores (clone vs clone) saved to {filtered_path_tests}")


def _is_clone_valid(clone):
    cb = clone.get("metrics", {}).get("codebleu", {})
    score = float(cb.get("originalcode", 0.0))

    return (
        score <= CODEBLEU_THRESHOLD
        and clone["code"].strip().lower() != "none"
    )

def _filter_by_codebleu(path): 
    
    with open(path, "r", encoding="utf-8") as f: 
        data = json.load(f) 

    filtered_data = [] 
    removed_count = 0 
    kept_count = 0 

    for entry in data: 
        new_entry = {"id": entry["id"], "clones": []} 
        for clone in entry.get("clones", []): 
            if _is_clone_valid(clone): 
                new_entry["clones"].append(clone) 
                kept_count += 1 
            else: removed_count += 1 # keep entry only if it has valid clones 
        if new_entry["clones"]: 
            filtered_data.append(new_entry) 

    with open(path, "w", encoding="utf-8") as f: 
        json.dump(filtered_data, f, indent=2) 
    
    print(f"Saved to {path}") 
    print(f"Kept clones: {kept_count}") 
    print(f"Removed clones: {removed_count}")
