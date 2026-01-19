import json
import pandas as pd
from pathlib import Path
from sentence_transformers import SentenceTransformer
from sentence_transformers.util import cos_sim
from src.utils.helper_functions import build_pairs, build_pairs_from_folders
from src.clone_detection.finetune import run_finetuning
from src.config import *

EXPECTED_MODEL_FILES = ["config.json", "modules.json", "model.safetensors"]

def run_clone_evaluation(model_path, full_model_name, dataset_path=CLONE_DATASET_TEST, threshold=DETECTION_THRESHOLD, own_dataset=True, reults_csv=CLONE_DETECTION_RESULTS, language=None):
    model_dir = Path(model_path)
    model_folder_name = model_dir.name
    print(f"Checking model: {model_folder_name}") 
    # Fine-tuning is executed if mode is still not on local folder
    if not model_dir.exists() or not all((model_dir / f).exists() for f in EXPECTED_MODEL_FILES):
        print(f"Model not found or incomplete at {model_dir}")
        run_finetuning(model_name=full_model_name)

   
    print(f"Loading model from: {model_dir}")
    model = SentenceTransformer(str(model_dir))
    
    if(own_dataset): # use our own dataset
        with open(dataset_path, "r", encoding="utf-8") as f:
            data = json.load(f)
        pairs = build_pairs(data)
        dataset_name = 'kamino'
    else: # use GPCloneBench dataset
        if os.path.exists(GPTCLONEBENCH_PAIRS):
            print(f"Loading pairs from {GPTCLONEBENCH_PAIRS}...")
            with open(GPTCLONEBENCH_PAIRS, "r", encoding="utf-8") as f:
                pairs = json.load(f)
        else:
            print("Pairs file not found. Building pairs...")
            pairs = build_pairs_from_folders(pos_folder=GPTCLONEBENCH_JAVA_POS_CLONES_DIR)
        dataset_name = 'GPTCloneBench'

    precision, recall, f1, sims = _evaluate_model(model, pairs, threshold=threshold)
    print(f"✅ Evaluation complete (threshold={threshold}):")
    print(f"Precision: {precision:.4f}, Recall: {recall:.4f}, F1-score: {f1:.4f}") 
    _save_evaluation_to_csv(full_model_name, precision, recall, f1, csv_path=reults_csv, dataset_name=dataset_name)
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

    # Calculate metrics
    precision = TP / (TP + FP) if (TP + FP) > 0 else 0.0
    recall = TP / (TP + FN) if (TP + FN) > 0 else 0.0
    f1 = 2 * (precision * recall) / (precision + recall) if (precision + recall) > 0 else 0.0 

    return precision, recall, f1, similarities

def _save_evaluation_to_csv(full_model_name, precision, recall, f1, threshold=DETECTION_THRESHOLD, csv_path=CLONE_DETECTION_RESULTS, dataset_name=None):
    csv_path = Path(csv_path)
    
    
    metrics_row = {
        "model": full_model_name,
        "dataset": dataset_name,
        "lan": "java",
        "threshold": threshold,
        "precision": precision,
        "recall": recall,
        "f1": f1,
    }

    if csv_path.exists():
        df = pd.read_csv(csv_path)
        # Check if this model + threshold already exists
        mask = (df["model"] == full_model_name) & (df["threshold"] == threshold)
        if mask.any():
            # Update existing row
            df.loc[mask, ["precision", "recall", "f1"]] = [precision, recall, f1]
        else:
            # Append new row
            df = pd.concat([df, pd.DataFrame([metrics_row])], ignore_index=True)
    else:
        df = pd.DataFrame([metrics_row])

    df.to_csv(csv_path, index=False)
    print(f"✅ Saved evaluation results to {csv_path}")
