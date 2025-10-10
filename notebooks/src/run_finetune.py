# For CodeBERT
#python run_finetune.py --model_name microsoft/codebert-base

# For CodeT5
# python run_finetune.py --model_name Salesforce/codet5-base

import warnings
import argparse
from fine_tune import finetune_clone_model

warnings.filterwarnings("ignore")

# Parse command-line argument for model
parser = argparse.ArgumentParser(description="Fine-tune a clone detection model")
parser.add_argument(
    "--model_name",
    type=str,
    required=True,
    help="HuggingFace model name, e.g., 'microsoft/codebert-base' or 'Salesforce/codet5-base'"
)
args = parser.parse_args()

# Fixed parameters
FINAL_DATASET = "../results/bigcodebench_clone_dataset.json"
EPOCHS = 3
BATCH_SIZE = 8

# Set output directory based on model
if "codebert" in args.model_name.lower():
    output_dir = "../results/clone_detection/codebert"
elif "codet5" in args.model_name.lower():
    output_dir = "../results/clone_detection/codet5"
else:
    output_dir = f"../results/clone_detection/{args.model_name.replace('/', '_')}"

# Run training
trainer, tokenizer = finetune_clone_model(
    dataset_path=FINAL_DATASET,
    model_name=args.model_name,
    output_dir=output_dir,
    epochs=EPOCHS,
    batch_size=BATCH_SIZE,
)
