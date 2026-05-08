import argparse
from pathlib import Path 
from src.clone_detection.detect import run_clone_evaluation
from src.clone_detection.finetune import create_dataset
from src.config import *
 # RQ3 evaluation 

if __name__ == "__main__":
    parser = argparse.ArgumentParser(description="Evaluate fine-tuned clone detection models")
    parser.add_argument(
        "--model_name",
        type=str,
        required=False,
        help="Full Hugging Face model name, e.g., 'microsoft/codebert-base'",
    ) 
    args = parser.parse_args()

    full_model_name = args.model_name 
    if (full_model_name is None):
        print("No model name provided. Using default models.")
        models = ['microsoft/codebert-base-default','Salesforce/codet5-base-default','microsoft/codebert-base', 'Salesforce/codet5-base']
    else:
        models = [full_model_name]
    

   # Ensure dataset exists for finetuning
    if not Path(CLONE_DATASET_TRAIN).exists() or not Path(CLONE_DATASET_TEST).exists():
        print("Dataset not found — creating it...")
        create_dataset()
    else:
        print("Using existing dataset.")

    threshold = SIMILARITY_THRESHOLD # similarity classification threshold for clone detection
    languages = ["python", "java", "csharp"] # supported languages in GPTCloneBench/SemanticCloneBench 
    datasets = ["GPTCloneBench", "SemanticCloneBench"]
    for model in models:    
        model_folder_name = model.split("/")[-1]
        model_output_dir = Path(FINETUNE_DIR) / model_folder_name
        for dataset in datasets: # trained on kamino and tested on GPTCloneBench/SemanticCloneBench datasets
            for language in languages: 
                run_clone_evaluation(str(model_output_dir), model, test_dataset_name=dataset, train_dataset_name="Kamino",language=language, threshold=threshold)
        
            # trained on GPTCloneBench/SemanticCloneBench datasets and tested on kamino     
            run_clone_evaluation(str(model_output_dir), model, threshold=threshold, train_dataset_name=dataset,test_dataset_name="Kamino", language="python") 