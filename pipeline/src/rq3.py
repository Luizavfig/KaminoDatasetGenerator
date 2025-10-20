import argparse
from pathlib import Path
from src.clone_detection.detect import run_clone_evaluation
from src.config import *

if __name__ == "__main__":

    parser = argparse.ArgumentParser(description="Evaluate fine-tuned clone detection model on a new dataset")
    parser.add_argument(
        "--model_name",
        type=str,
        required=True,
        help="Name of the model to evaluate, e.g., 'codebert_base', 'codet5_base', 'sbert_codebert'"
    )
    args = parser.parse_args() 

    print(f"Evaluating model: {args.model_name} with threshold: {DETECTION_THRESHOLD}")

    run_clone_evaluation(
        model_path=FINETUNE_DIR + f"/{args.model_name}",
        dataset_path=DATASET_PATH,
        threshold=DETECTION_THRESHOLD,
        max_negatives=MAX_NEGATIVES
    )