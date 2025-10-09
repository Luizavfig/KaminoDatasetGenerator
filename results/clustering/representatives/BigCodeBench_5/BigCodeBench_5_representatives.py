# Cluster 0 - Representative clone zero-shot llama4:latest-requirements 1 nfr5
import random
import math


def task_func(LETTERS=['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
    'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x',
    'y', 'z']):
    result = {}
    for letter in LETTERS:
        numbers = [random.randint(1, 100) for _ in range(random.randint(1, 10))
            ]
        mean = sum(numbers) / len(numbers)
        variance = sum((x - mean) ** 2 for x in numbers) / len(numbers)
        std_dev = math.sqrt(variance)
        result[letter] = std_dev
    return result

# Cluster 1 - Representative clone few-shot gpt-oss:latest-ast 1 nfr4
import random
import string
import statistics


def task_func(LETTERS=None):
    if LETTERS is None:
        LETTERS = list(string.ascii_lowercase)
    result = {}
    for letter in LETTERS:
        count = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(count)]
        result[letter] = statistics.pstdev(values)
    return result


print(task_func())

# Cluster 2 - Representative clone zero-shot gpt-oss:20b-complete 1 nfr3
import math
import random


def task_func(letters=[chr(i) for i in range(97, 123)]):
    sd_dict = {}
    for letter in letters:
        size = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(size)]
        mean = sum(values) / size
        variance = sum((x - mean) ** 2 for x in values) / size
        sd_dict[letter] = math.sqrt(variance)
    return sd_dict

# Cluster 3 - Representative clone zero-shot gpt-oss:20b-requirements 1 nfr0
import random
import math


def task_func(LETTERS=None):
    if LETTERS is None:
        LETTERS = [chr(i) for i in range(ord('a'), ord('z') + 1)]
    result = {}
    for letter in LETTERS:
        length = random.randint(1, 10)
        numbers = [random.randint(0, 100) for _ in range(length)]
        mean = sum(numbers) / length
        variance = sum((x - mean) ** 2 for x in numbers) / length
        result[letter] = math.sqrt(variance)
    return result

# Cluster 4 - Representative clone few-shot llama4:latest-requirements 1 nfr2
import random
import math
from typing import Dict, List


def task_func(LETTERS: List[str]=[chr(i) for i in range(ord('a'), ord('z') +
    1)]):
    result: Dict[str, float] = {}
    for letter in LETTERS:
        random_numbers = [random.randint(1, 100) for _ in range(random.
            randint(1, 10))]
        variance = sum((x - sum(random_numbers) / len(random_numbers)) ** 2 for
            x in random_numbers) / len(random_numbers)
        std_dev = math.sqrt(variance)
        result[letter] = std_dev
    return result

# Cluster 5 - Representative clone cot llama3.1:latest-requirements 1 nfr2
import random
import math
from string import ascii_lowercase


def task_func(LETTERS=ascii_lowercase):
    result = {}
    for letter in LETTERS:
        length = random.randint(1, 10)
        numbers = [random.randint(-1000, 1000) for _ in range(length)]
        std_dev = math.sqrt(sum((x - sum(numbers) / length) ** 2 for x in
            numbers) / length)
        result[letter] = std_dev
    return result

# Cluster 6 - Representative clone zero-shot deepseek-r1-translation 1 nfr0
import random
from typing import List, Dict, Optional


def task_func(letters: Optional[List[str]]=None) ->Dict[str, float]:
    if letters is None:
        letters = [chr(ord('a') + i) for i in range(26)]
    result_dict = {}
    for char in letters:
        size = random.randint(1, 10)
        num_list = [random.randint(0, 100) for _ in range(size)]
        mean = sum(num_list) / len(num_list)
        variance = sum((x - mean) ** 2 for x in num_list) / len(num_list)
        sd = variance ** 0.5
        result_dict[char] = sd
    return result_dict

# Cluster 7 - Representative clone cot deepseek-r1-minimal 1 nfr2
import random
import statistics


def task_func(letters=None):
    if letters is None:
        letters = [chr(i + ord('a')) for i in range(26)]
    return {letter: round(statistics.pstdev([random.randint(0, 100) for _ in
        range(random.randint(1, 10))]), 1) for letter in letters}

# Cluster 8 - Representative clone zero-shot deepseek-r1-minimal 1 nfr0
import random
import math


def task_func(LETTERS=None):
    if LETTERS is None:
        LETTERS = [chr(i + ord('a')) for i in range(26)]
    else:
        for letter in LETTERS:
            if len(letter) != 1:
                raise ValueError(
                    'Each element in LETTERS must be a single-character string.'
                    )
    result = {}
    for letter in LETTERS:
        n = random.randint(1, 10)
        numbers = [random.randint(0, 100) for _ in range(n)]
        if n == 0:
            continue
        mean = sum(numbers) / n
        variance = sum((x - mean) ** 2 for x in numbers) / n
        std_dev = math.sqrt(variance)
        result[letter] = round(std_dev, 2)
    return result

