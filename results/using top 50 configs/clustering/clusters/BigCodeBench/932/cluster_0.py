# Clone cot llama3.1:latest-test 1 ['refac_2,refac_5,refac_6']
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

