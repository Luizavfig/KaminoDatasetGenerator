# Clone zero-shot deepseek-r1:14b-code 1 ['refac_1,refac_4,refac_5']
from collections import defaultdict


def task_func(word: str) ->list:
    clean_word = ''.join([c.lower() for c in word if c.isalpha()])
    if len(clean_word) < 2:
        return []
    pair_counts = defaultdict(int)
    for i in range(len(clean_word) - 1):
        pair = clean_word[i:i + 2]
        pair_counts[pair] += 1
    max_count = max(pair_counts.values()) if pair_counts else 0
    most_common = [k for k, v in pair_counts.items() if v == max_count]
    return [(most_common[0], max_count)] if most_common else []

