# Cluster 0 - Representative clone cot gpt-oss:latest-translation 1 nfr2
import random
import string
from collections import Counter


def task_func(length: int=100):
    if length < 0:
        raise ValueError('length must be non-negative')
    random_chars = random.choices(string.ascii_letters, k=length)
    return dict(Counter(random_chars))


print(task_func())

# Cluster 1 - Representative clone cot deepseek-r1-complete 1 nfr2
import random
from collections import Counter as char_counts


def task_func(length=100):
    if length < 0:
        raise ValueError
    valid_chars = string.ascii_uppercase + string.ascii_lowercase
    return dict(char_counts(random.choices(valid_chars, k=length)))

# Cluster 2 - Representative clone few-shot gpt-oss:latest-translation 1 nfr4
import random


def task_func(length: int=100):
    if length < 0:
        raise ValueError('length must be non-negative')
    random_string = []
    for _ in range(length):
        if random.randint(0, 1) == 0:
            random_string.append(chr(random.randint(0, 25) + ord('A')))
        else:
            random_string.append(chr(random.randint(0, 25) + ord('a')))
    char_counts = {}
    for c in random_string:
        char_counts[c] = char_counts.get(c, 0) + 1
    return char_counts


print(task_func())

# Cluster 3 - Representative clone few-shot llama4:latest-translation 1 nfr4
import random
from typing import Dict


def task_func(length: int=100) ->Dict[str, int]:
    if length < 0:
        raise ValueError('Length must be a non-negative integer')
    random_string = ''.join(random.choice(
        'abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ') for _ in
        range(length))
    char_counts = {}
    for char in random_string:
        char_counts[char] = char_counts.get(char, 0) + 1
    return char_counts


print(task_func())

# Cluster 4 - Representative clone zero-shot gpt-oss:20b-ast 1 nfr1
import random


def task_func(length: int=100) ->dict:
    if length < 0:
        raise ValueError('length must be non-negative')
    letters = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz'
    rand_str = ''.join(random.choice(letters) for _ in range(length))
    counts = {}
    for ch in rand_str:
        counts[ch] = counts.get(ch, 0) + 1
    return counts

# Cluster 5 - Representative clone zero-shot deepseek-r1-translation 1 nfr3
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

# Cluster 6 - Representative clone cot gpt-oss:20b-minimal 1 nfr2
import random
import string
import collections
import itertools
import numpy as np
import pandas as pd
from functools import reduce


def task_func(length=100):
    letters = string.ascii_letters
    indices = np.random.randint(0, len(letters), size=length)
    random_string = ''.join(letters[i] for i in indices)
    counts = collections.Counter(random_string)
    return dict(counts)

