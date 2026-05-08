import json, warnings, sys, torch
from pathlib import Path
from torch.utils.data import Dataset, DataLoader
from sklearn.model_selection import train_test_split
from sentence_transformers import SentenceTransformer, InputExample, losses, evaluation, models
from src.utils.helper_functions import build_pairs, hf_login, build_pairs_from_folders_split
from src.config import * 
from datasets import Dataset, DatasetDict

def run_finetuning(model_name, train_dataset="Kamino", model_path=FINETUNE_DIR, epochs=EPOCHS,
    batch_size=BATCH_SIZE, max_seq_length=256, gpu_id=GPU_IDX): 
    warnings.filterwarnings("ignore")
    hf_login()
    # Force PyTorch to use the selected GPU
    if torch.cuda.is_available():
        device = torch.device(f"cuda:{gpu_id}")
        print(f"Using GPU {gpu_id}: {torch.cuda.get_device_name(device)}")
    else:
        device = torch.device("cpu")
        print("⚠️ CUDA not available, ABORTING ⚠️")
        sys.exit(1) 
    
    # Save in different folders per train dataset, or default
    model_folder_name = model_name.split("/")[-1]

    if "-default" in model_name:
        model_output_dir = os.path.join(model_path, model_folder_name)
    else:
        dataset_name = train_dataset.replace("/", "_")
        model_output_dir = os.path.join(
            model_path,
            dataset_name,
            model_folder_name
        )
    print(f"Loading {model_name} as transformer encoder...")

    # If the model_name has '-default', remove it for Hugging Face loading
    hf_model_name = model_name.replace("-default", "") if model_name.endswith("-default") else model_name 
    word_emb = models.Transformer(hf_model_name, max_seq_length=max_seq_length)
    pooler = models.Pooling(word_emb.get_word_embedding_dimension())
    model = SentenceTransformer(modules=[word_emb, pooler])

    # Move model to selected GPU
    model.to(device)

    # Dataset wrapper
    class InputExampleDataset(Dataset):
        def __init__(self, examples): self.examples = examples
        def __len__(self): return len(self.examples)
        def __getitem__(self, idx): return self.examples[idx]

    if(not model_name.__contains__("-default")): # Train only if no -default 
        print(f"🚀 Fine-tuning model: {model_name}")
         # Load dataset and create train/val splits
         
        if(train_dataset == "Kamino"):    
            with open(CLONE_DATASET_TRAIN, "r", encoding="utf-8") as f:
                data = json.load(f)
            pairs = build_pairs(data)
            train_pairs, val_pairs = train_test_split(pairs, test_size=0.2, random_state=42)
        else:
            train_pairs, val_pairs = build_pairs_from_folders_split(language="python", dataset=train_dataset) 

        train_samples = [InputExample(texts=[a, b], label=float(label)) for a, b, label in train_pairs]
        val_samples = [InputExample(texts=[a, b], label=float(label)) for a, b, label in val_pairs]
        train_dataset = InputExampleDataset(train_samples)
        train_dataloader = DataLoader(
            train_dataset,
            shuffle=True,
            batch_size=batch_size,
            collate_fn=model.smart_batching_collate,
            pin_memory=True,  # speeds up GPU transfer
        )

        train_loss = losses.CosineSimilarityLoss(model)
        evaluator = evaluation.EmbeddingSimilarityEvaluator.from_input_examples(val_samples, name="val-sim")
        model.fit(
            train_objectives=[(train_dataloader, train_loss)],
            evaluator=evaluator,
            epochs=epochs,
            warmup_steps=int(len(train_samples) * 0.1),
            output_path=str(model_output_dir),  
            show_progress_bar=True,
            use_amp=True,
        )

    # Save model
    model.save(str(model_output_dir))
    print(f"✅ Model saved to: {model_output_dir}")

    return str(model_output_dir)


def create_dataset(dataset1_path=FINAL_DATASET, train_output_path=CLONE_DATASET_TRAIN, test_output_path=CLONE_DATASET_TEST,
    split_ratio=0.2):
    with open(dataset1_path, "r", encoding="utf-8") as f:
        data = json.load(f)

    # IMPORTANT: deterministic ordering for reproducibility
    data = sorted(data, key=lambda x: x["id"])
    train_data, test_data = train_test_split(data, test_size=split_ratio, random_state=42)   
    
    with open(train_output_path, "w", encoding="utf-8") as f:
        json.dump(train_data, f, indent=2)
    
    with open(test_output_path, "w", encoding="utf-8") as f:
        json.dump(test_data, f, indent=2)

    dataset_dict = DatasetDict({
        "train": Dataset.from_list(train_data),
        "test": Dataset.from_list(test_data),
    })

    dataset_dict.save_to_disk("../dataset/kamino_clones_dataset")

    print("✅ Split completed")
    print(f"Train: {len(train_data)} entries")
    print(f"Test: {len(test_data)} entries")

 
 


