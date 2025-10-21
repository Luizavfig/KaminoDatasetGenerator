import json, warnings, sys, torch
from pathlib import Path
from torch.utils.data import Dataset, DataLoader
from sklearn.model_selection import train_test_split
from sentence_transformers import SentenceTransformer, InputExample, losses, evaluation, models
from src.utils.helper_functions import build_pairs, hf_login
from src.config import *

def run_finetuning(
    model_name,
    dataset_path=MERGED_CLONE_DATASET_TRAIN,
    output_dir=FINETUNE_DIR,
    epochs=EPOCHS,
    batch_size=BATCH_SIZE,
    max_seq_length=256,
    gpu_id=GPU_IDX 
):
    """Fine-tunes a code embedding model (e.g., CodeBERT, CodeT5) for semantic clone detection on a specific GPU."""
    warnings.filterwarnings("ignore")
    hf_login()
    print(f"🚀 Fine-tuning model: {model_name}")
    # Force PyTorch to use the selected GPU
    if torch.cuda.is_available():
        device = torch.device(f"cuda:{gpu_id}")
        print(f"Using GPU {gpu_id}: {torch.cuda.get_device_name(device)}")
    else:
        device = torch.device("cpu")
        print("⚠️ CUDA not available, ABORTING ⚠️")
        sys.exit(1) 
    
    # Only use last part of model name for folder
    model_folder_name = model_name.split("/")[-1]
    model_output_dir = Path(output_dir) / model_folder_name

    # Load dataset and create train/val splits
    with open(dataset_path, "r", encoding="utf-8") as f:
        data = json.load(f)
    pairs = build_pairs(data)
    train_pairs, val_pairs = train_test_split(pairs, test_size=0.2, random_state=42)

    train_samples = [InputExample(texts=[a, b], label=float(label)) for a, b, label in train_pairs]
    val_samples = [InputExample(texts=[a, b], label=float(label)) for a, b, label in val_pairs]

    # Transformer encoder for code models
    print(f"Loading {model_name} as transformer encoder...")
    word_emb = models.Transformer(model_name, max_seq_length=max_seq_length)
    pooler = models.Pooling(word_emb.get_word_embedding_dimension())
    model = SentenceTransformer(modules=[word_emb, pooler])

    # Move model to selected GPU
    model.to(device)

    # Dataset wrapper
    class InputExampleDataset(Dataset):
        def __init__(self, examples): self.examples = examples
        def __len__(self): return len(self.examples)
        def __getitem__(self, idx): return self.examples[idx]

    train_dataset = InputExampleDataset(train_samples)
    train_dataloader = DataLoader(
        train_dataset,
        shuffle=True,
        batch_size=batch_size,
        collate_fn=model.smart_batching_collate,
        pin_memory=True,  # speeds up GPU transfer
    )

    # Loss and evaluator
    train_loss = losses.CosineSimilarityLoss(model)
    evaluator = evaluation.EmbeddingSimilarityEvaluator.from_input_examples(val_samples, name="val-sim")

    # Fine-tune
    model.fit(
        train_objectives=[(train_dataloader, train_loss)],
        evaluator=evaluator,
        epochs=epochs,
        warmup_steps=int(len(train_samples) * 0.1),
        output_path=str(model_output_dir),  # SentenceTransformer will create folder
        show_progress_bar=True,
        use_amp=True,
    )

    # Save model only after fine-tuning
    model.save(str(model_output_dir))
    print(f"✅ Fine-tuned model saved to: {model_output_dir}")

    return str(model_output_dir)


def merge_datasets(
    dataset1_path=FINAL_DATASET,
    dataset2_path=FINAL_DATASET_RQ2,
    train_output_path=MERGED_CLONE_DATASET_TRAIN,
    val_output_path=MERGED_CLONE_DATASET_VAL,
    split_ratio=0.8,
):
    """Merge two JSON datasets and split into train/val sets (default 80/20)."""
    merged = []
    for path in [dataset1_path, dataset2_path]:
        with open(path, "r", encoding="utf-8") as f:
            merged.extend(json.load(f))

    train_data, val_data = train_test_split(merged, test_size=1 - split_ratio, random_state=42)

    with open(train_output_path, "w", encoding="utf-8") as f:
        json.dump(train_data, f, indent=2)
    with open(val_output_path, "w", encoding="utf-8") as f:
        json.dump(val_data, f, indent=2)

    print(f"✅ Created merged datasets:\nTrain: {len(train_data)} | Val: {len(val_data)}")
