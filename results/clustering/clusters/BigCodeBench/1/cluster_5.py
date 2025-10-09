# Clone zero-shot deepseek-r1-translation 1 nfr3
import random
from collections import defaultdict


def task_func(length=100):
    if length < 0:
        raise ValueError('Length must be non-negative')
    char_counts = defaultdict(int)
    for _ in range(length):
        rand_val = random.random()
        if rand_val < 0.5:
            char = chr(random.randint(65, 90))
        else:
            char = chr(random.randint(97, 122))
        char_counts[char] += 1
    return dict(char_counts)

