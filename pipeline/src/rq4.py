import argparse
from pathlib import Path

from src.clone_detection.detect import run_clone_evaluation
from src.steps.clustering import run_clustering
from src.config import *


if __name__ == "__main__":

    print("🚀 Executing RQ4 - Diversity ablation study")
    thresholds = [0.5, 0.6, 0.7] # similarity classification thresholds for clone detection
    parser = argparse.ArgumentParser()
    parser.add_argument("--model_name", type=str, required=False)
    args = parser.parse_args()

    full_model_name = args.model_name

    if full_model_name is None:
        models = [
            "microsoft/codebert-base",
            "Salesforce/codet5-base"
        ]
    else:
        models = [full_model_name]

    
    # RQ4 configurations 
    diversity_configs = {
        "Kamino-LD": {
            "max_threshold": 0.9,
            "min_threshold": 0.5,
            "final_dataset": KAMINO_LD_DATASET
        },
        "Kamino-MD": {
            "max_threshold": 0.5,
            "min_threshold": 0.3,
            "final_dataset": KAMINO_MD_DATASET
        },
        "Kamino-HD": {
            "max_threshold": 0.3,
            "min_threshold": 0.0,
            "final_dataset": KAMINO_HD_DATASET
        },
    }
 
    languages = ["python", "java", "csharp"]
    datasets = ["SemanticCloneBench", "GPTCloneBench"]
 
    # RQ4 PIPELINE 
    for dataset_name, config in diversity_configs.items():

        print(f"\n=== RQ4 Dataset: {dataset_name} ===")

        min_threshold = config["min_threshold"]
        max_threshold = config["max_threshold"]
        final_dataset_path = config["final_dataset"]

        
        # 1. CLUSTERING → DATASET CREATION  
        final_dataset_path = Path(final_dataset_path)

        if not final_dataset_path.exists() or final_dataset_path.stat().st_size == 0:

            print(f"🧠 Running clustering for {dataset_name}")

            run_clustering(
                filtered_path_tests=FILTERED_PATH_TESTS,
                sample_path=SAMPLE_1_PATH,
                final_dataset=str(final_dataset_path),
                codebleu_threshold=max_threshold,
                min_codebleu=min_threshold
            )

        else:
            print(f"✅ Clustering already done: {final_dataset_path} (skipping)")

        
        # 2. TRAIN + EVALUATE 
        for threshold in thresholds:
            print(f"evaluation for threshold {threshold}")
            for model in models:
                model_output_dir = Path(FINETUNE_DIR) / dataset_name
                for dataset in datasets:
                    for language in languages:

                        run_clone_evaluation(
                            str(model_output_dir),
                            model,
                            test_dataset_name=dataset,
                            train_dataset_name=dataset_name,
                            dataset_path=final_dataset_path,
                            language=language,
                            threshold=threshold,
                            results_csv=RQ4_CLONE_DETECTION_RESULTS
                        )