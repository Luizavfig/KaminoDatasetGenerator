# Clone cot gpt-oss:20b-test 1 ['refac_2,refac_6,refac_7']
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

