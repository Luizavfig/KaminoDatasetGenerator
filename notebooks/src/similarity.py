
import re
# === Tokenizer ===
def tokenize_code(code: str):
    return [tok for tok in re.split(r"(\W)", code) if tok.strip()]


# Convert top-K ngrams to a dictionary mapping ngram -> 1
def is_trivial_ngram(ngram):
    return all(re.fullmatch(r'\W', tok) for tok in ngram)


