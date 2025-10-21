import json
from pathlib import Path
from sentence_transformers import SentenceTransformer
from sentence_transformers.util import cos_sim
from src.utils.helper_functions import build_pairs
from src.clone_detection.finetune import run_finetuning
from src.config import *

EXPECTED_MODEL_FILES = ["config.json", "modules.json", "model.safetensors"]

def run_clone_evaluation(model_path, full_model_name, dataset_path=MERGED_CLONE_DATASET_VAL,                          max_negatives=MAX_NEGATIVES, threshold=DETECTION_THRESHOLD):
    model_dir = Path(model_path)
    model_folder_name = model_dir.name
    print(f"Checking fine-tuned model: {model_folder_name}")

    # If folder missing or incomplete, run fine-tuning
    if not model_dir.exists() or not all((model_dir / f).exists() for f in EXPECTED_MODEL_FILES):
        print(f"Fine-tuned model not found or incomplete at {model_dir}")
        run_finetuning(model_name=full_model_name)

    # Load the fine-tuned model
    print(f"Loading fine-tuned model from: {model_dir}")
    model = SentenceTransformer(str(model_dir))

    with open(dataset_path, "r", encoding="utf-8") as f:
        data = json.load(f)

    pairs = build_pairs(data, max_negatives=max_negatives)
    print(f"Built {len(pairs)} code pairs for evaluation")

    precision, recall, f1, sims = _evaluate_model(model, pairs, threshold=threshold)
    print(f"✅ Evaluation complete (threshold={threshold}):")
    print(f"Precision: {precision:.4f}, Recall: {recall:.4f}, F1-score: {f1:.4f}")

    return precision, recall, f1, sims

def _evaluate_model(model, pairs, threshold=DETECTION_THRESHOLD):
    TP = 0  
    FP = 0  
    FN = 0  
    similarities = []

    for code1, code2, label in pairs:
        emb1 = model.encode(code1, convert_to_tensor=True)
        emb2 = model.encode(code2, convert_to_tensor=True)
        sim = cos_sim(emb1, emb2).item()
        pred = 1 if sim >= threshold else 0
        similarities.append((sim, label))

        if pred == 1 and label == 1:
            TP += 1
        elif pred == 1 and label == 0:
            FP += 1
        elif pred == 0 and label == 1:
            FN += 1
        # pred==0 and label==0 is TN, not needed for Precision/Recall/F1

    # Calculate metrics safely
    precision = TP / (TP + FP) if (TP + FP) > 0 else 0.0
    recall = TP / (TP + FN) if (TP + FN) > 0 else 0.0
    f1 = 2 * (precision * recall) / (precision + recall) if (precision + recall) > 0 else 0.0

    return precision, recall, f1, similarities
