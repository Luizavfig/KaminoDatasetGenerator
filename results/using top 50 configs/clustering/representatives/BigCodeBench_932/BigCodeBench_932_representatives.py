# Cluster 0 - Representative clone cot llama3.1:latest-test 1 ['refac_2,refac_5,refac_6']
from collections import Counter
import re


def task_func(word):
    cleaned_word = re.sub('[^a-zA-Z]', '', word).lower()
    if len(cleaned_word) < 2:
        return []
    pairs = [cleaned_word[i:i + 2] for i in range(len(cleaned_word) - 1)]
    pair_counts = Counter(pairs)
    most_common_pair = pair_counts.most_common(1)[0]
    return [(most_common_pair[0], most_common_pair[1])]

# Cluster 1 - Representative clone cot gpt-oss:20b-test 1 ['refac_2,refac_4,refac_6']
def task_func(word):
    cleaned = ''.join(ch.lower() for ch in word if ch.isalpha())
    if len(cleaned) < 2:
        return []
    pairs = [cleaned[i:i + 2] for i in range(len(cleaned) - 1)]
    freq = {}
    for p in pairs:
        freq[p] = freq.get(p, 0) + 1
    max_count = max(freq.values())
    for p in pairs:
        if freq[p] == max_count:
            return [(p, max_count)]
    return []

# Cluster 2 - Representative clone cot gpt-oss:20b-test 1 ['refac_2,refac_6,refac_7']
def task_func(word):
    cleaned = ''.join(ch.lower() for ch in word if ch.isalpha())
    if len(cleaned) < 2:
        return []
    counts = {}
    first_index = {}
    for i in range(len(cleaned) - 1):
        pair = cleaned[i:i + 2]
        counts[pair] = counts.get(pair, 0) + 1
        if pair not in first_index:
            first_index[pair] = i
    max_count = max(counts.values())
    candidates = [p for p, c in counts.items() if c == max_count]
    best_pair = min(candidates, key=lambda p: first_index[p])
    return [(best_pair, max_count)]

# Cluster 3 - Representative clone zero-shot deepseek-r1:14b-test 1 ['refac_2,refac_5,refac_6']
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

# Cluster 4 - Representative clone zero-shot deepseek-r1:14b-code 1 ['refac_1,refac_4,refac_5']
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

