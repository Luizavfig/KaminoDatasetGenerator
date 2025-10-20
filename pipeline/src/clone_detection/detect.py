import json  
from sentence_transformers import SentenceTransformer, InputExample, evaluation
from sentence_transformers.util import cos_sim
import argparse
from pathlib import Path
from src.utils.helper_functions import _build_pairs
from src.config import *

# ------------------------------
# Helper: Evaluate a model on pairs
# ------------------------------
def evaluate_model(model, pairs, threshold=DETECTION_THRESHOLD):
    """
    Evaluate a fine-tuned model on a list of code pairs.
    Returns accuracy and similarity list [(similarity, label), ...]
    """
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


# ------------------------------
# Main function: load model & evaluate
# ------------------------------
def run_clone_evaluation(
    model_path,
    dataset_path=MERGED_CLONE_DATASET,
    max_negatives=MAX_NEGATIVES,
    threshold=DETECTION_THRESHOLD
):
    """
    Loads a fine-tuned model and evaluates it on a dataset.
    """
    print(f"📂 Loading fine-tuned model from: {model_path}")
    model = SentenceTransformer(model_path)

    print(f"📂 Loading dataset from: {dataset_path}")
    with open(dataset_path, "r", encoding="utf-8") as f:
        data = json.load(f)

    pairs = _build_pairs(data, max_negatives=max_negatives)
    print(f"🔹 Built {len(pairs)} code pairs for evaluation")

    accuracy, sims = evaluate_model(model, pairs, threshold=threshold)
    print(f"✅ Evaluation complete. Accuracy (threshold={threshold}): {accuracy:.4f}")

    return accuracy, sims


# ------------------------------
# Example CLI usage
# ------------------------------


