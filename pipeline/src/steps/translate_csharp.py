"""
Step 7: Python -> C# Golden Dataset translation.

Extends the Kamino architecture (same Ollama call path, prompt-builder pattern,
and JSON merge/save conventions as steps/clone_gen.py) to generate C# translations
of selected BigCodeBench entries for the cross-language clone-detection Golden Dataset.

Unlike steps/clone_gen.py (which generates many syntactically-diverse Python clones
per entry), this step generates exactly ONE C# translation candidate per selected
entry, using the "csharp_translate" prompt context defined in utils/prompts.py.

LLM-generated output here is a DRAFT. Every entry that ships in the Golden Dataset
(dataset/golden_dataset_csharp/) is manually reviewed, corrected if needed, and
verified by actually compiling and running the C# code and its tests -- see
doc/step7_csharp_translation.md and dataset/golden_dataset_csharp/README.md.
"""
import json, os, re
from .clone_gen import call_ollama_chat, test_LLM_connection
from ..utils.prompts import context_builders
from src.config import *

GOLDEN_DATASET_DIR = os.path.join("..", "dataset", "golden_dataset_csharp")
GOLDEN_DATASET_INDEX = os.path.join(GOLDEN_DATASET_DIR, "golden_dataset.json")
CSHARP_DRAFT_PATH = os.path.join("..", "results", "RQ1", "bigcodebench_csharp_drafts.json")


def _extract_csharp_code(text: str) -> str:
    m = re.search(r"```csharp\s*(.*?)```", text, flags=re.S)
    if m:
        return m.group(1).strip()
    m = re.search(r"```cs\s*(.*?)```", text, flags=re.S)
    if m:
        return m.group(1).strip()
    m = re.search(r"```\s*(.*?)```", text, flags=re.S)
    if m:
        return m.group(1).strip()
    return text.strip()


def _load_selected_entries(dataset_path, entry_ids):
    with open(dataset_path, "r", encoding="utf-8") as f:
        data = json.load(f)
    by_id = {e["id"]: e for e in data}
    missing = [i for i in entry_ids if i not in by_id]
    if missing:
        print(f"Warning: entries not found in {dataset_path}: {missing}")
    return [by_id[i] for i in entry_ids if i in by_id]


def run_csharp_translation(entry_ids, dataset_path=SAMPLE_1_PATH, out_path=CSHARP_DRAFT_PATH,
                            ollama_model=DeepSeek, llm_opts=LLM_OPTS):
    """
    Calls the LLM once per selected entry using the "csharp_translate" prompt context
    and stores raw + extracted C# drafts. Requires a reachable Ollama server (see
    REMOTE_OLLAMA / pipeline/resources/ollama_config_*.json).

    This produces DRAFTS ONLY. Golden Dataset entries under dataset/golden_dataset_csharp/
    are the manually verified result of reviewing (and, where necessary, correcting)
    output produced through this same prompt.
    """
    print("Starting Python -> C# translation drafting...")
    test_LLM_connection()

    entries = _load_selected_entries(dataset_path, entry_ids)
    drafts = []

    for i, entry in enumerate(entries, 1):
        print(f"\nTranslating {i}/{len(entries)}: {entry['id']}")
        original_body = entry["original_code"]
        tests_list = entry.get("test", [])
        tests_snippet = tests_list[0] if tests_list else ""
        description = entry.get("description", "")
        params = entry.get("metadata", {}).get("params", "")
        return_text = entry.get("metadata", {}).get("return_text", "")

        system_prompt, user_prompt = context_builders["csharp_translate"](
            original_body=original_body,
            description=description,
            tests_snippet=tests_snippet,
            params=params,
            return_text=return_text,
        )
        messages = [
            {"role": "system", "content": system_prompt},
            {"role": "user", "content": user_prompt},
        ]
        try:
            raw = call_ollama_chat(messages, ollama_model, llm_opts)
            code = _extract_csharp_code(raw)
        except Exception as e:
            print(f"  Error translating {entry['id']}: {e}")
            raw, code = "", ""

        drafts.append({
            "id": entry["id"],
            "model": ollama_model,
            "context": "csharp_translate",
            "raw_response": raw,
            "code": code,
        })

    os.makedirs(os.path.dirname(out_path), exist_ok=True)
    with open(out_path, "w", encoding="utf-8") as f:
        json.dump(drafts, f, indent=2, ensure_ascii=False)

    print(f"\nSaved {len(drafts)} C# translation draft(s) to {out_path}")
    return drafts


def build_golden_dataset_index(golden_dir=GOLDEN_DATASET_DIR, index_path=GOLDEN_DATASET_INDEX):
    """
    Scans dataset/golden_dataset_csharp/<entry>/{python,csharp} and
    dataset/golden_dataset_csharp/<entry>/verification.json, and rebuilds the
    consolidated golden_dataset.json index that ties every entry's Python code,
    Python tests, C# code, C# tests, and verification record together.
    """
    entries = []
    if not os.path.isdir(golden_dir):
        print(f"No golden dataset directory found at {golden_dir}")
        return entries

    for name in sorted(os.listdir(golden_dir)):
        entry_dir = os.path.join(golden_dir, name)
        if not os.path.isdir(entry_dir) or name.startswith("_"):
            continue

        def rel(*parts):
            return "/".join(["dataset", "golden_dataset_csharp", name, *parts])

        verification_path = os.path.join(entry_dir, "verification.json")
        verification = None
        if os.path.exists(verification_path):
            with open(verification_path, "r", encoding="utf-8") as f:
                verification = json.load(f)

        entries.append({
            "entry": name,
            "bigcodebench_id": name.replace("_", "/", 1),
            "python_code": rel("python", "task_func.py"),
            "python_tests": rel("python", "test_task_func.py"),
            "csharp_code": rel("csharp", "TaskFunc.cs"),
            "csharp_tests": rel("csharp", "TaskFuncTests.cs"),
            "verification": rel("verification.json"),
            "equivalence_status": verification.get("equivalence_status") if verification else None,
        })

    os.makedirs(os.path.dirname(index_path), exist_ok=True)
    with open(index_path, "w", encoding="utf-8") as f:
        json.dump(entries, f, indent=2, ensure_ascii=False)

    print(f"Golden dataset index rebuilt: {index_path} ({len(entries)} entries)")
    return entries
