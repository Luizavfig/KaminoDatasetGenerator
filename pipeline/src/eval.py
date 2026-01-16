
# import json
# from src.config import * 
# from src.utils.preprocess_dataset import collect_functions, build_clonebench_json

# def main():
#     functions_by_signature = collect_functions(GPTCLONEBENCH_CLONES_DIR)
#     dataset = build_clonebench_json(functions_by_signature)

#     with open(GPTCLONEBENCH_DATASET_CLONES_PATH, "w", encoding="utf-8") as f:
#         json.dump(dataset, f, indent=2)

#     print(f"Saved {len(dataset)} entries to {GPTCLONEBENCH_DATASET_CLONES_PATH}")


# if __name__ == "__main__":
#     main()