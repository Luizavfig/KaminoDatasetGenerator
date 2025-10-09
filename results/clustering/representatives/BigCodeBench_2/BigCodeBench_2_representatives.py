# Cluster 0 - Representative clone few-shot llama3.1:latest-requirements 1 nfr0
import random
import statistics


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        if letter not in result:
            result[letter] = []
        while len(result[letter]) < 1 or len(result[letter]) > 10:
            result[letter].append(random.randint(0, 100))
    return dict(sorted(result.items(), key=lambda item: statistics.mean(
        item[1]), reverse=True))

# Cluster 1 - Representative clone cot deepseek-r1-requirements 1 nfr1
import random
import statistics


def task_func(LETTERS):
    if not hasattr(random, 'random'):
        raise ImportError('random module is required')
    if not hasattr(statistics, 'mean'):
        raise ImportError('statistics module is required')
    result_dict = {}
    for letter in LETTERS:
        if letter in result_dict:
            raise ValueError('Duplicate keys are not allowed')
        length = random.randint(1, 10)
        num_list = [random.randint(-100, 100) for _ in range(length)]
        result_dict[letter] = num_list
    sorted_dict = {}
    while result_dict:
        key_with_max_mean = None
        max_mean = -float('inf')
        for key, value in result_dict.items():
            current_mean = statistics.mean(value)
            if current_mean > max_mean:
                max_mean = current_mean
                key_with_max_mean = key
        if key_with_max_mean is not None:
            sorted_dict[key_with_max_mean] = result_dict.pop(key_with_max_mean)
    return sorted_dict

# Cluster 2 - Representative clone zero-shot deepseek-r1-minimal 1 nfr5
import random
import statistics


def task_func(letters):
    """
    Create a dictionary with keys from LETTERS and values as lists of random integers.
    Then sort the dictionary by the mean of the values in descending order.

    Args:
        letters (list of str): List of characters to use as keys.

    Returns:
        dict: Sorted dictionary by mean of values in descending order.
    """
    my_dict = {}
    for letter in letters:
        values = [random.randint(1, 100) for _ in range(5)]
        my_dict[letter] = values
    sorted_dict = {k: v for k, v in sorted(my_dict.items(), key=lambda item:
        statistics.mean(item[1]), reverse=True)}
    return sorted_dict

# Cluster 3 - Representative clone few-shot gpt-oss:latest-ast 1 nfr1
import random
import statistics


def task_func(LETTERS):
    random_dict = {}
    for letter in LETTERS:
        length = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(length)]
        random_dict[letter] = values
    mean_list = []
    for key, vals in random_dict.items():
        mean_val = statistics.mean(vals)
        mean_list.append((key, vals, mean_val))
    mean_list.sort(key=lambda x: x[2], reverse=True)
    sorted_dict = {}
    for key, vals, _ in mean_list:
        sorted_dict[key] = vals
    return sorted_dict


print(task_func(['a', 'b', 'c', 'd']))

# Cluster 4 - Representative clone cot gpt-oss:20b-complete 1 nfr3
import random
import statistics


def task_func(LETTERS):
    """
    Create a dictionary mapping each letter in LETTERS to a list of random integers.
    The dictionary is sorted by the mean of each list in descending order.
    """
    data = []
    for letter in LETTERS:
        list_length = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(list_length)]
        data.append((letter, values))
    data.sort(key=lambda item: statistics.mean(item[1]), reverse=True)
    return {letter: values for letter, values in data}

# Cluster 5 - Representative clone zero-shot gpt-oss:latest-uml 1 nfr0
import random
import statistics
from typing import List, Dict


def task_func(LETTERS: List[str]) ->Dict[str, List[int]]:
    data = {}
    for letter in LETTERS:
        length = random.randint(5, 10)
        data[letter] = [random.randint(1, 100) for _ in range(length)]
    sorted_items = sorted(data.items(), key=lambda kv: statistics.mean(kv[1
        ]), reverse=True)
    return {k: v for k, v in sorted_items}


print(task_func(['a', 'b', 'c']))

# Cluster 6 - Representative clone zero-shot gpt-oss:latest-uml 1 nfr2
import random
import statistics
import collections
import numpy as np
import pandas as pd
import itertools
import functools
import operator
from typing import List, Dict


def task_func(LETTERS: List[str]) ->Dict[str, List[int]]:
    data = {letter: np.random.randint(1, 101, size=10).tolist() for letter in
        LETTERS}
    means = {letter: statistics.mean(values) for letter, values in data.items()
        }
    sorted_letters = sorted(means, key=means.get, reverse=True)
    sorted_dict = collections.OrderedDict((letter, data[letter]) for letter in
        sorted_letters)
    return dict(sorted_dict)


print(task_func(['a', 'b', 'c', 'd']))

# Cluster 7 - Representative clone zero-shot gpt-oss:20b-complete 1 nfr2
import random
import statistics
import operator
import itertools
from functools import partial
from typing import Dict, List


def task_func(LETTERS: List[str]) ->Dict[str, List[int]]:
    """Generate a dictionary mapping each letter in LETTERS to a list of random integers,
    then sort the dictionary by the mean of those lists in descending order."""
    random_int_list = lambda : [random.randint(0, 100) for _ in itertools.
        repeat(None, random.randint(1, 10))]
    random_dict = {letter: random_int_list() for letter in LETTERS}
    mean_key = partial(statistics.mean)
    sorted_items = sorted(random_dict.items(), key=lambda item: mean_key(
        item[1]), reverse=True)
    return dict(sorted_items)

# Cluster 8 - Representative clone cot gpt-oss:latest-uml 1 nfr4
import secrets
import statistics


def task_func(LETTERS):
    data = {letter: [(secrets.randbelow(100) + 1) for _ in range(5)] for
        letter in LETTERS}
    sorted_items = sorted(data.items(), key=lambda item: statistics.mean(
        item[1]), reverse=True)
    return dict(sorted_items)


print(task_func(['a', 'b', 'c']))

# Cluster 9 - Representative clone cot gemma3:latest-translation 1 nfr2
import random
import statistics
from collections import OrderedDict


def task_func(letters):
    randomDict = {}
    for letter in letters:
        count = random.randint(1, 10)
        randomNumbers = [random.randint(1, 101) for _ in range(count)]
        randomDict[letter] = randomNumbers
    sortedList = sorted(randomDict.items(), key=lambda item: statistics.
        mean(item[1]), reverse=True)
    sortedDict = OrderedDict()
    for letter, numbers in sortedList:
        sortedDict[letter] = numbers
    return sortedDict

# Cluster 10 - Representative clone few-shot gpt-oss:latest-minimal 1 nfr0
import random
import statistics


def task_func(LETTERS):
    data = {}
    for letter in LETTERS:
        length = random.randint(1, 10)
        values = [random.randint(1, 100) for _ in range(length)]
        data[letter] = values
    sorted_items = sorted(data.items(), key=lambda kv: statistics.mean(kv[1
        ]), reverse=True)
    return dict(sorted_items)


print(task_func(['a', 'b', 'c']))

# Cluster 11 - Representative clone few-shot gpt-oss:20b-ast 1 nfr3
import random
import statistics


def task_func(LETTERS):
    if not LETTERS:
        return {}
    data = {}
    for letter in LETTERS:
        length = random.randint(1, 10)
        numbers = []
        for _ in range(length):
            numbers.append(random.randint(0, 100))
        data[letter] = numbers

    def mean_of_pair(pair):
        return statistics.mean(pair[1])
    sorted_items = sorted(data.items(), key=mean_of_pair, reverse=True)
    sorted_dict = {}
    for k, v in sorted_items:
        sorted_dict[k] = v
    return sorted_dict

# Cluster 12 - Representative clone zero-shot gpt-oss:20b-ast 1 nfr2
import random
import statistics
import numpy as np
import pandas as pd
from collections import defaultdict
from itertools import repeat
from functools import reduce
from operator import itemgetter
import math


def task_func(LETTERS):
    random_dict = {}
    for letter in LETTERS:
        size = random.randint(5, 15)
        values = np.random.randint(0, 101, size=size).tolist()
        random_dict[letter] = values
    means = {k: statistics.mean(v) for k, v in random_dict.items()}
    sorted_items = sorted(random_dict.items(), key=lambda kv: means[kv[0]],
        reverse=True)
    sorted_dict = {k: v for k, v in sorted_items}
    return sorted_dict

# Cluster 13 - Representative clone zero-shot gpt-oss:latest-uml 1 nfr5
import random
import statistics


def task_func(LETTERS):
    """
    Generate random integer lists for each letter, compute their means,
    and return a dictionary sorted by mean values in descending order.
    """
    data = {letter: [random.randint(1, 100) for _ in range(10)] for letter in
        LETTERS}
    means = {letter: statistics.mean(values) for letter, values in data.items()
        }
    sorted_letters = sorted(means, key=means.get, reverse=True)
    sorted_dict = {letter: data[letter] for letter in sorted_letters}
    return sorted_dict


if __name__ == '__main__':
    print(task_func(['a', 'b', 'c']))

# Cluster 14 - Representative clone cot gpt-oss:20b-complete 1 nfr0
import random
import statistics


def task_func(LETTERS):
    rand_dict = {k: random.choices(range(101), k=random.randint(1, 10)) for
        k in LETTERS}
    sorted_keys = sorted(rand_dict, key=lambda k: statistics.mean(rand_dict
        [k]), reverse=True)
    return {k: rand_dict[k] for k in sorted_keys}

