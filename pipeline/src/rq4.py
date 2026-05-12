import argparse
from pathlib import Path

from src.clone_detection.detect import run_clone_evaluation
from src.clustering import run_clustering
from src.config import *


if __name__ == "__main__":

    print("🚀 Executing RQ4 - Diversity ablation study")

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
            "threshold": 0.8,
            "final_dataset": KAMINO_LD_DATASET
        },
        "Kamino-MD": {
            "threshold": 0.4,
            "final_dataset": KAMINO_MD_DATASET
        },
        "Kamino-HD": {
            "threshold": 0.25,
            "final_dataset": KAMINO_HD_DATASET
        },
    }
 
    languages = ["python", "java", "csharp"]
    datasets = ["SemanticCloneBench", "GPTCloneBench"]
 
    # RQ4 PIPELINE 
    for dataset_name, config in diversity_configs.items():

        print(f"\n=== RQ4 Dataset: {dataset_name} ===")

        cluster_threshold = config["threshold"]
        final_dataset_path = config["final_dataset"]

        
        # 1. CLUSTERING → DATASET CREATION  
        final_dataset_path = Path(final_dataset_path)

        if not final_dataset_path.exists() or final_dataset_path.stat().st_size == 0:

            print(f"🧠 Running clustering for {dataset_name}")

            run_clustering(
                filtered_path_tests=FILTERED_PATH_TESTS,
                sample_path=SAMPLE_1_PATH,
                final_dataset=str(final_dataset_path),
                codebleu_threshold=cluster_threshold
            )

        else:
            print(f"✅ Clustering already done: {final_dataset_path} (skipping)")

        
        # 2. TRAIN + EVALUATE 
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
                        threshold=SIMILARITY_THRESHOLD,
                        results_csv=RQ4_CLONE_DETECTION_RESULTS
                    )