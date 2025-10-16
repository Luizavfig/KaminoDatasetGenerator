import json
import random
import torch
import numpy as np
from sklearn.model_selection import train_test_split
from torch.utils.data import Dataset
from transformers import (
    AutoTokenizer,
    AutoModelForSequenceClassification,
    Trainer,
    TrainingArguments,
)

class CloneDataset(Dataset):
    def __init__(self, pairs, tokenizer, max_length=256):
        self.pairs = pairs
        self.tokenizer = tokenizer
        self.max_length = max_length

    def __len__(self):
        return len(self.pairs)

    def __getitem__(self, idx):
        code1, code2, label = self.pairs[idx]
        enc = self.tokenizer(
            code1,
            code2,
            truncation=True,
            padding="max_length",
            max_length=self.max_length,
            return_tensors="pt",
        )
        return {
            "input_ids": enc["input_ids"].squeeze(),
            "attention_mask": enc["attention_mask"].squeeze(),
            "labels": torch.tensor(label, dtype=torch.long),
        }

def build_pairs(data, max_negatives=1):
    pairs = []
    for entry in data:
        clones = entry.get("clones", [])
        n = len(clones)
        # positive pairs
        for i in range(n):
            for j in range(i + 1, n):
                pairs.append((clones[i]["code"], clones[j]["code"], 1))
        # negative pairs (exclude current entry)
        for i in range(min(n, max_negatives)):
            neg_entry = random.choice([e for e in data if e != entry and e.get("clones")])
            neg_clone = random.choice(neg_entry["clones"])
            pairs.append((clones[i]["code"], neg_clone["code"], 0))
    random.shuffle(pairs)
    return pairs

def finetune_clone_model(dataset_path, model_name, output_dir="./results", epochs=3, batch_size=8):
    # Load dataset
    with open(dataset_path, "r", encoding="utf-8") as f:
        data = json.load(f)

    # Build pairs
    pairs = build_pairs(data)

    # Split train/val
    train_pairs, val_pairs = train_test_split(pairs, test_size=0.2, random_state=42)

    tokenizer = AutoTokenizer.from_pretrained(model_name)
    train_dataset = CloneDataset(train_pairs, tokenizer)
    val_dataset = CloneDataset(val_pairs, tokenizer)

    # Load model for sequence classification
    model = AutoModelForSequenceClassification.from_pretrained(model_name, num_labels=2)

    training_args = TrainingArguments(
        output_dir=output_dir,
        eval_strategy="epoch",
        save_strategy="epoch",
        learning_rate=5e-5,
        per_device_train_batch_size=batch_size,
        per_device_eval_batch_size=batch_size,
        num_train_epochs=epochs,
        weight_decay=0.01,
        logging_dir=f"{output_dir}/logs",
        load_best_model_at_end=True,
        metric_for_best_model="accuracy",
    )

    def compute_metrics(eval_pred):
        logits = eval_pred.predictions
        if isinstance(logits, tuple):
            logits = logits[0]
        labels = eval_pred.label_ids
        # flatten if needed (CodeT5 sometimes returns [batch, seq_len, num_labels])
        if logits.ndim > 2:
            logits = logits[:, 0, :]
        preds = np.argmax(logits, axis=-1)
        accuracy = (preds == labels).mean()
        return {"accuracy": accuracy}

    trainer = Trainer(
        model=model,
        args=training_args,
        train_dataset=train_dataset,
        eval_dataset=val_dataset,
        compute_metrics=compute_metrics,
    )

    trainer.train()
    eval_results = trainer.evaluate()
    print("✅ Validation Results:", eval_results)

    trainer.save_model(output_dir)
    return trainer, tokenizer
