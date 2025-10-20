import json
from sentence_transformers import SentenceTransformer
from sentence_transformers.util import cos_sim
from src.utils.helper_functions import _build_pairs
from src.config import *
from pathlib import Path

# Optional: files to check
EXPECTED_MODEL_FILES = ["config.json", "modules.json", "pytorch_model.bin"]

def evaluate_model(model, pairs, threshold=DETECTION_THRESHOLD):
    """Evaluate a fine-tuned model on code pairs."""
    correct = 0
    similarities = []

    for code1, code2, label in pairs:
        emb1 = model.encode(code1, convert_to_tensor=True)
        emb2 = model.encode(code2, convert_to_tensor=True)
        sim = cos_sim(emb1, emb2).item()
        pred = 1 if sim >= threshold else 0
        correct += (pred == label)
        similarities.append((sim, label))

    accuracy = correct / len(pairs)
    return accuracy, similarities

def run_clone_evaluation(
    model_path,
    dataset_path=MERGED_CLONE_DATASET_VAL,
    max_negatives=MAX_NEGATIVES,
    threshold=DETECTION_THRESHOLD,
):
    """Loads a fine-tuned model and evaluates it on a dataset."""

    model_dir = Path(model_path)

    # Check if model folder exists and has expected files
    if not model_dir.exists() or not all((model_dir / f).exists() for f in EXPECTED_MODEL_FILES):
        raise FileNotFoundError(f"Fine-tuned model not found or incomplete at {model_dir}")

    print(f"Loading fine-tuned model from: {model_dir}")
    model = SentenceTransformer(str(model_dir))

    with open(dataset_path, "r", encoding="utf-8") as f:
        data = json.load(f)

    pairs = _build_pairs(data, max_negatives=max_negatives)
    print(f"Built {len(pairs)} code pairs for evaluation")

    accuracy, sims = evaluate_model(model, pairs, threshold=threshold)
    print(f"✅ Evaluation complete. Accuracy (threshold={threshold}): {accuracy:.4f}")

    return accuracy, sims
