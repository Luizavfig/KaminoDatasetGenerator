from sentence_transformers import SentenceTransformer, InputExample, losses, evaluation, models
from torch.utils.data import Dataset, DataLoader
import json
from sklearn.model_selection import train_test_split
import warnings
from src.utils.helper_functions import _build_pairs
from src.config import *

def run_finetuning(model_name, dataset_path=MERGED_CLONE_DATASET, output_dir = FINETUNE_DIR, epochs = EPOCHS, batch_size = BATCH_SIZE):
    """
    Fine-tunes a model (CodeBERT, CodeT5, or SBERT) for semantic clone detection
    using embedding-based similarity loss.
"""
    warnings.filterwarnings("ignore") 
    print(f"🚀 Fine-tuning model: {model_name}")

    # Run finetuning
    _finetune_semantic_model(
        dataset_path=dataset_path,
        model_name=model_name,
        output_dir= output_dir,
        epochs=epochs,
        batch_size=batch_size,
    )

    print(f"✅ Fine-tuning complete. Results saved to: {output_dir}")


# Fine-tuning function
def _finetune_semantic_model(
    dataset_path,
    model_name="microsoft/codebert-base",
    output_dir="./results_semantic",
    epochs=3,
    batch_size=8,
    max_seq_length=256,
):
    """Fine-tunes *any* encoder model for semantic clone detection using similarity loss."""
    # Dataset wrapper for type safety
    class InputExampleDataset(Dataset):
        def __init__(self, examples):
            self.examples = examples
        def __len__(self):
            return len(self.examples)
        def __getitem__(self, idx):
            return self.examples[idx]

    with open(dataset_path, "r", encoding="utf-8") as f:
        data = json.load(f)
    pairs = _build_pairs(data)
    train_pairs, val_pairs = train_test_split(pairs, test_size=0.2, random_state=42)

    train_samples = [InputExample(texts=[a, b], label=float(label)) for a, b, label in train_pairs]
    val_samples = [InputExample(texts=[a, b], label=float(label)) for a, b, label in val_pairs]

    # Build the model
    # If model_name is from transformers, wrap it as a sentence-transformer encoder
    try:
        model = SentenceTransformer(model_name)
    except Exception:
        print(f"⚙️ Building SentenceTransformer from HuggingFace model: {model_name}")
        word_emb = models.Transformer(model_name, max_seq_length=max_seq_length)
        pooler = models.Pooling(word_emb.get_word_embedding_dimension())
        model = SentenceTransformer(modules=[word_emb, pooler])

    # DataLoader
    train_dataset = InputExampleDataset(train_samples)
    train_dataloader = DataLoader(
        train_dataset,
        shuffle=True,
        batch_size=batch_size,
        collate_fn=model.smart_batching_collate,
    )

    # Loss function (semantic similarity)
    train_loss = losses.CosineSimilarityLoss(model)
    evaluator = evaluation.EmbeddingSimilarityEvaluator.from_input_examples(val_samples, name="val-sim")

    # Fine-tune
    model.fit(
        train_objectives=[(train_dataloader, train_loss)],
        evaluator=evaluator,
        epochs=epochs,
        warmup_steps=int(len(train_samples) * 0.1),
        output_path=output_dir,
        show_progress_bar=True,
        use_amp=True,
    )

    print(f"✅ Model fine-tuned for semantic similarity and saved to {output_dir}")
    return model



