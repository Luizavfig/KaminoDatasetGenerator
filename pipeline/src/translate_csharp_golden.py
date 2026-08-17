"""
Driver script for the Python -> C# Golden Dataset (cross-language clone research).

Mirrors the standalone rq2.py / rq3.py / rq4.py driver pattern: it is not wired
into main.py's RQ1 pipeline because it targets a small, manually curated subset
rather than the full 927-entry dataset.

Usage (requires a reachable Ollama server, see README.md "Requirements"):
    cd pipeline
    python -m src.translate_csharp_golden

This regenerates LLM DRAFTS for the entries listed in GOLDEN_ENTRY_IDS using the
"csharp_translate" prompt context (src/utils/prompts.py) and rebuilds the golden
dataset index. It does NOT overwrite the manually verified files under
dataset/golden_dataset_csharp/<entry>/csharp/TaskFunc.cs -- those are the
human-reviewed Golden Dataset artifacts described in
doc/step7_csharp_translation.md. Drafts are written to
results/RQ1/bigcodebench_csharp_drafts.json for comparison/review only.
"""
from src.steps.translate_csharp import run_csharp_translation, build_golden_dataset_index

# The 8 BigCodeBench entries selected for the Golden Dataset subset (see
# doc/step7_csharp_translation.md for the selection rationale of each entry).
GOLDEN_ENTRY_IDS = [
    "BigCodeBench/4",     # dictionaries / maps
    "BigCodeBench/297",   # functions with multiple parameters
    "BigCodeBench/670",   # loops, iteration, nested control flow
    "BigCodeBench/685",   # lists / collections
    "BigCodeBench/747",   # basic expressions and arithmetic
    "BigCodeBench/795",   # conditional logic, dynamic typing, side effects
    "BigCodeBench/818",   # strings and string manipulation
    "BigCodeBench/1108",  # nested control flow, dictionaries
]

if __name__ == "__main__":
    run_csharp_translation(GOLDEN_ENTRY_IDS)
    build_golden_dataset_index()
