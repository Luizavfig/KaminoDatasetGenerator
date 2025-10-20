import argparse
from pathlib import Path
from src.clone_detection.finetune import run_finetuning, merge_datasets
from src.clone_detection.detect import run_clone_evaluation
from src.config import *

# Files that must exist for a trained SentenceTransformer model
EXPECTED_MODEL_FILES = ["config.json", "modules.json", "pytorch_model.bin"]

if __name__ == "__main__":
    parser = argparse.ArgumentParser(description="Evaluate fine-tuned clone detection models")
    parser.add_argument(
        "--model_name",
        type=str,
        required=True,
        help="Name of the model to evaluate, e.g., 'microsoft/codebert-base' or 'Salesforce/codet5-base'",
    )
    args = parser.parse_args()

    model_name = args.model_name
    # Use only the last part of the model name for folder naming
    model_folder_name = model_name.split("/")[-1]
    model_output_dir = Path(FINETUNE_DIR) / model_folder_name

    # Ensure merged dataset exists
    if not Path(MERGED_CLONE_DATASET_TRAIN).exists() or not Path(MERGED_CLONE_DATASET_VAL).exists():
        print("Merged dataset not found — creating it...")
        merge_datasets()
    else:
        print("✅ Using existing merged dataset.")

    # Check if model is fine-tuned and contains expected files
    model_exists = (
        model_output_dir.exists()
        and all((model_output_dir / f).exists() for f in EXPECTED_MODEL_FILES)
    )

    if not model_exists:
        print(f"Fine-tuned model not found or incomplete for '{model_name}'. Starting fine-tuning...")
        run_finetuning(model_name)
    else:
        print(f"✅ Fine-tuned model found at {model_output_dir}")

    # Evaluate
    print(f"🔍 Evaluating '{model_name}' on validation dataset...")
    run_clone_evaluation(str(model_output_dir))
