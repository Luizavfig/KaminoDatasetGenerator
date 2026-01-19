import argparse
from pathlib import Path
from src.clone_detection.finetune import merge_datasets
from src.clone_detection.detect import run_clone_evaluation
from src.config import *
 # RQ2 evaluation 

if __name__ == "__main__":
    parser = argparse.ArgumentParser(description="Evaluate fine-tuned clone detection models")
    parser.add_argument(
        "--model_name",
        type=str,
        required=True,
        help="Full Hugging Face model name, e.g., 'microsoft/codebert-base'",
    )
    args = parser.parse_args()

    full_model_name = args.model_name
    model_folder_name = full_model_name.split("/")[-1]
    model_output_dir = Path(FINETUNE_DIR) / model_folder_name

    # Ensure dataset exists
    if not Path(CLONE_DATASET_TRAIN).exists() or not Path(CLONE_DATASET_TEST).exists():
        print("Dataset not found — creating it...")
        merge_datasets()
    else:
        print("✅ Using existing dataset.")

    # Evaluate (run_finetuning will use full Hugging Face model name)
    threshold = [0.7, 0.8, 0.9] # similarity classification threshold for clone detection
    for th in threshold:
        run_clone_evaluation(str(model_output_dir), full_model_name, threshold=th)