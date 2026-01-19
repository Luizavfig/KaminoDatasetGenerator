import argparse
from pathlib import Path 
from src.clone_detection.detect import run_clone_evaluation
from src.clone_detection.finetune import merge_datasets
from src.config import *
 # RQ3 evaluation 

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

   # Ensure dataset exists for finetuning
    if not Path(CLONE_DATASET_TRAIN).exists() or not Path(CLONE_DATASET_TEST).exists():
        print("Dataset not found — creating it...")
        merge_datasets()
    else:
        print("Using existing dataset.")

    threshold = [0.7, 0.8, 0.9] # similarity classification threshold for clone detection
    languages = ["python", "java", "csharp", "c"] # supported languages in GPTCloneBench
    #languages = ["java", "csharp", "c"] # supported languages in GPTCloneBench
    for th in threshold:    
        #run_clone_evaluation(str(model_output_dir), full_model_name, threshold=th, dataset_name="Kamino", language="python") # for our own dataset
        run_clone_evaluation(str(model_output_dir), full_model_name, threshold=th, dataset_name="BigCloneBench", language="java") # for BigCloneBench
        #for language in languages: # for GPTCloneBench
         #   run_clone_evaluation(str(model_output_dir), full_model_name, dataset_name="GPTCloneBench",language=language, threshold=th)
