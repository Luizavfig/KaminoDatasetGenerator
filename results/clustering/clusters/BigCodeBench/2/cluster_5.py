# Clone few-shot deepseek-r1-minimal 1 nfr2
import random
import statistics
from typing import List, Dict


def task_func(letters: List[str]) ->Dict[str, List[int]]:
    my_dict = {letter: [random.randint(1, 100) for _ in range(5)] for
        letter in letters}
    means = {k: statistics.mean(v) for k, v in my_dict.items()}
    sorted_dict = dict(sorted(my_dict.items(), key=lambda item: means[item[
        0]], reverse=True))
    return sorted_dict

# Clone cot deepseek-r1-minimal 1 nfr2
import random
import statistics
from typing import List, Dict


def task_func(letters: List[str]) ->Dict[str, List[int]]:
    result_dict = {letter: [random.randint(1, 100) for _ in range(5)] for
        letter in letters}
    means = {k: statistics.mean(v) for k, v in result_dict.items()}
    sorted_dict = dict(sorted(result_dict.items(), key=lambda item: means[
        item[0]], reverse=True))
    return sorted_dict

# Clone zero-shot gpt-oss:latest-uml 1 nfr0
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

# Clone zero-shot gpt-oss:latest-translation 1 nfr2
import random
import statistics
from collections import OrderedDict
from typing import List, Dict


def task_func(LETTERS: List[str]) ->Dict[str, List[int]]:
    random_dict = {}
    for letter in LETTERS:
        count = random.randint(1, 10)
        random_numbers = [random.randint(0, 100) for _ in range(count)]
        random_dict[letter] = random_numbers
    sorted_items = sorted(random_dict.items(), key=lambda kv: statistics.
        mean(kv[1]), reverse=True)
    sorted_dict = OrderedDict(sorted_items)
    return sorted_dict


if __name__ == '__main__':
    print(task_func(['A', 'B', 'C']))

# Clone zero-shot gpt-oss:20b-minimal 1 nfr5
import random
import statistics
from typing import List, Dict


def task_func(LETTERS: List[str]) ->Dict[str, List[int]]:
    if not LETTERS:
        return {}
    data = {}
    for letter in LETTERS:
        values = [random.randint(1, 100) for _ in range(random.randint(5, 10))]
        data[letter] = values
    sorted_items = sorted(data.items(), key=lambda kv: statistics.mean(kv[1
        ]), reverse=True)
    return dict(sorted_items)

# Clone zero-shot gpt-oss:20b-ast 1 nfr3
import random
import statistics
from typing import List, Dict


def task_func(LETTERS: List[str]) ->Dict[str, List[int]]:
    """
    Create a dictionary with keys from LETTERS and random integer lists as values.
    Sort the dictionary by the mean of each list in descending order.
    """
    random_dict: Dict[str, List[int]] = {}
    for letter in LETTERS:
        count = random.randint(1, 10)
        random_dict[letter] = [random.randint(0, 100) for _ in range(count)]
    sorted_items = sorted(random_dict.items(), key=lambda kv: statistics.
        mean(kv[1]), reverse=True)
    sorted_dict = {k: v for k, v in sorted_items}
    return sorted_dict

# Clone zero-shot gpt-oss:20b-ast 1 nfr5
import random
import statistics
from typing import Dict, List


def task_func(LETTERS: List[str]) ->Dict[str, List[int]]:
    """
    Build a dictionary where each key is a letter from LETTERS and each value
    is a list of random integers. The dictionary is then sorted in descending
    order based on the mean of each list.

    Parameters
    ----------
    LETTERS : List[str]
        The list of characters to be used as keys.

    Returns
    -------
    Dict[str, List[int]]
        The sorted dictionary.
    """
    random_dict: Dict[str, List[int]] = {}
    for key in LETTERS:
        list_length = random.randint(1, 10)
        random_dict[key] = [random.randint(0, 100) for _ in range(list_length)]
    sorted_items = sorted(random_dict.items(), key=lambda kv: statistics.
        mean(kv[1]), reverse=True)
    return dict(sorted_items)

# Clone few-shot gpt-oss:20b-uml 1 nfr2
import random
import numpy as np
import statistics
import collections
import operator
import functools
import itertools
from typing import List, Dict


def task_func(LETTERS: List[str]) ->Dict[str, List[int]]:
    data = {}
    for letter in LETTERS:
        length = random.randint(5, 15)
        data[letter] = [random.randint(1, 100) for _ in range(length)]
    means = {k: np.mean(v) for k, v in data.items()}
    sorted_keys = sorted(means, key=means.get, reverse=True)
    sorted_dict = collections.OrderedDict()
    for key in sorted_keys:
        sorted_dict[key] = data[key]
    return dict(sorted_dict)

# Clone cot gpt-oss:20b-uml 1 nfr5
import random
import statistics
from typing import List, Dict


def task_func(LETTERS: List[str]) ->Dict[str, List[int]]:
    """
    Generate a dictionary where each key is a letter from LETTERS and the value
    is a list of random integers. The dictionary is sorted by the mean of each
    list in descending order.
    """
    if not LETTERS:
        return {}
    random.seed(42)
    data = {}
    for letter in LETTERS:
        data[letter] = [random.randint(1, 100) for _ in range(5)]
    sorted_items = sorted(data.items(), key=lambda kv: statistics.mean(kv[1
        ]), reverse=True)
    return dict(sorted_items)

