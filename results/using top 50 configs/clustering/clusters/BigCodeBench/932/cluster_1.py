# Clone cot gpt-oss:20b-test 1 ['refac_2,refac_4,refac_6']
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

