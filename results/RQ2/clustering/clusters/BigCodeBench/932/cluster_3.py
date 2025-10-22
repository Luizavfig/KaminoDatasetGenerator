# Clone zero-shot deepseek-r1:14b-test 1 ['refac_2,refac_5,refac_6']
from collections import defaultdict


def task_func(word):
    cleaned = [c.lower() for c in word if c.isalpha()]
    if len(cleaned) < 2:
        return []
    pairs = []
    for i in range(len(cleaned) - 1):
        pair = cleaned[i] + cleaned[i + 1]
        pairs.append(pair)
    counts = defaultdict(int)
    for pair in pairs:
        counts[pair] += 1
    max_count = max(counts.values()) if counts else 0
    most_common_pairs = [pair for pair, count in counts.items() if count ==
        max_count]
    return [(most_common_pairs[0], max_count)] if most_common_pairs else []

