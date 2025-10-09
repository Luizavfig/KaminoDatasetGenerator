# Clone zero-shot gpt-oss:latest-minimal 1 nfr0
import random
import statistics


def task_func(LETTERS):
    data = {}
    for letter in LETTERS:
        data[letter] = [random.randint(1, 100) for _ in range(5)]
    sorted_items = sorted(data.items(), key=lambda kv: statistics.mean(kv[1
        ]), reverse=True)
    return dict(sorted_items)


print(task_func(['a', 'b', 'c']))

# Clone zero-shot gpt-oss:latest-minimal 1 nfr3
import random
import statistics


def task_func(LETTERS):
    rng = random.SystemRandom()
    data = {}
    for letter in LETTERS:
        length = rng.randint(5, 10)
        data[letter] = [rng.randint(1, 100) for _ in range(length)]
    sorted_items = sorted(data.items(), key=lambda kv: statistics.mean(kv[1
        ]), reverse=True)
    return dict(sorted_items)


print(task_func(['a', 'b', 'c', 'd', 'e']))

# Clone zero-shot gpt-oss:latest-minimal 1 nfr4
import random
import statistics


def task_func(LETTERS):
    rng = random.SystemRandom()
    result = {}
    for letter in LETTERS:
        length = rng.randint(5, 10)
        values = [rng.randint(1, 100) for _ in range(length)]
        result[letter] = values
    sorted_items = sorted(result.items(), key=lambda item: statistics.mean(
        item[1]), reverse=True)
    return dict(sorted_items)


print(task_func(['a', 'b', 'c', 'd', 'e']))

# Clone zero-shot gpt-oss:latest-requirements 1 nfr2
import random
import statistics
import collections
import itertools
import functools
import operator
import math


def task_func(LETTERS):
    try:
        import random
        import statistics
    except Exception as exc:
        raise ImportError('Required modules not available') from exc
    unique_keys = list(dict.fromkeys(LETTERS))
    result = {}
    for key in unique_keys:
        length = random.randint(1, 10)
        result[key] = [random.randint(1, 100) for _ in range(length)]
    sorted_items = sorted(result.items(), key=lambda kv: statistics.mean(kv
        [1]), reverse=True)
    return dict(sorted_items)


print(task_func(['A', 'B', 'C', 'A']))

# Clone zero-shot gpt-oss:latest-requirements 1 nfr4
import random
import statistics


def task_func(LETTERS):
    if not isinstance(LETTERS, (list, tuple, set)):
        raise TypeError('LETTERS must be a collection of strings')
    unique_keys = set(LETTERS)
    result = {}
    for key in unique_keys:
        length = random.randint(1, 10)
        values = [random.randint(1, 100) for _ in range(length)]
        result[key] = values
    sorted_items = sorted(result.items(), key=lambda kv: statistics.mean(kv
        [1]), reverse=True)
    return dict(sorted_items)


print(task_func(['A', 'B', 'C']))

# Clone few-shot gpt-oss:latest-minimal 1 nfr0
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

# Clone few-shot gpt-oss:latest-minimal 1 nfr5
import random
import statistics


def task_func(LETTERS):
    """Create a dictionary with letters as keys and random integer lists as values,
    then return it sorted by the mean of the lists in descending order."""
    data = {}
    for letter in LETTERS:
        length = random.randint(1, 10)
        data[letter] = [random.randint(1, 100) for _ in range(length)]
    sorted_items = sorted(data.items(), key=lambda kv: statistics.mean(kv[1
        ]), reverse=True)
    return dict(sorted_items)


print(task_func(['a', 'b', 'c', 'd', 'e']))

# Clone cot gpt-oss:latest-minimal 1 nfr1
import random
import statistics


def task_func(LETTERS):
    data = {}
    for letter in LETTERS:
        data[letter] = [random.randint(1, 100) for _ in range(5)]
    sorted_items = sorted(data.items(), key=lambda kv: statistics.mean(kv[1
        ]), reverse=True)
    return dict(sorted_items)


print(task_func(['a', 'b', 'c', 'd', 'e']))

# Clone cot gpt-oss:latest-minimal 1 nfr4
import random
import statistics


def task_func(LETTERS):
    rng = random.SystemRandom()
    data = {}
    for letter in LETTERS:
        length = rng.randint(1, 5)
        values = [rng.randint(1, 100) for _ in range(length)]
        data[letter] = values
    sorted_items = sorted(data.items(), key=lambda kv: statistics.mean(kv[1
        ]), reverse=True)
    sorted_dict = {k: v for k, v in sorted_items}
    return sorted_dict


print(task_func(['a', 'b', 'c', 'd']))

# Clone cot gpt-oss:latest-requirements 1 nfr1
import random
import statistics


def task_func(LETTERS):
    unique_letters = set(LETTERS) if LETTERS else set()
    result = {}
    for letter in unique_letters:
        length = random.randint(1, 10)
        numbers = [random.randint(1, 100) for _ in range(length)]
        result[letter] = numbers
    sorted_items = sorted(result.items(), key=lambda kv: statistics.mean(kv
        [1]), reverse=True)
    return dict(sorted_items)


if __name__ == '__main__':
    print(task_func(['A', 'B', 'C']))

# Clone zero-shot gpt-oss:20b-minimal 1 nfr2
import random
import statistics
import collections
import itertools
import functools
import operator
import math
import decimal
import fractions
import typing
import datetime
import time
import json
import re
import string
import os
import sys
import pprint
import hashlib
import uuid
import inspect
import logging
import textwrap
import unicodedata
import copy
import types
import builtins
import warnings
import contextlib
import collections.abc
import numbers


def task_func(LETTERS: list[str]) ->dict[str, list[int]]:
    """
    Create a dictionary with keys as the provided letters and values as random lists of integers.
    Sort the dictionary by the mean of each list in descending order.
    """
    data = {}
    for letter in LETTERS:
        list_length = random.randint(3, 10)
        values = [random.randint(1, 100) for _ in range(list_length)]
        data[letter] = values
    sorted_items = sorted(data.items(), key=lambda kv: statistics.mean(kv[1
        ]), reverse=True)
    return dict(sorted_items)

# Clone zero-shot gpt-oss:20b-requirements 1 nfr2
import random
import statistics


def task_func(LETTERS):
    """
    Generate a dictionary mapping each unique letter in LETTERS to a list of random integers.
    The dictionary is sorted by the mean of the integer lists in descending order.
    Each list contains between 1 and 10 integers (inclusive), each between 1 and 100 (inclusive).

    Parameters
    ----------
    LETTERS : collection of str
        Collection of strings representing the keys for the dictionary.

    Returns
    -------
    dict
        Sorted dictionary with letters as keys and lists of integers as values,
        sorted by their mean values in descending order.
    """
    try:
        import random
        import statistics
    except Exception as exc:
        raise RuntimeError(
            "Required modules 'random' or 'statistics' are not available"
            ) from exc
    unique_keys = set(LETTERS) if LETTERS is not None else set()
    result = {}
    for key in unique_keys:
        length = random.randint(1, 10)
        result[key] = [random.randint(1, 100) for _ in range(length)]
    sorted_items = sorted(result.items(), key=lambda kv: statistics.mean(kv
        [1]), reverse=True)
    return dict(sorted_items)

# Clone few-shot gpt-oss:20b-minimal 1 nfr0
import random
import statistics


def task_func(LETTERS):
    """
    Create a dictionary with the given letters as keys and random integer lists as values.
    The dictionary is sorted by the mean of the lists in descending order.

    Parameters
    ----------
    LETTERS : list of str
        List of single-character strings to use as dictionary keys.

    Returns
    -------
    dict
        Ordered dictionary with letters as keys and lists of random integers as values,
        sorted by the mean of the lists in descending order.
    """
    if not LETTERS:
        return {}
    data = {}
    for letter in LETTERS:
        length = random.randint(5, 10)
        data[letter] = [random.randint(1, 100) for _ in range(length)]
    sorted_items = sorted(data.items(), key=lambda kv: statistics.mean(kv[1
        ]), reverse=True)
    sorted_dict = {k: v for k, v in sorted_items}
    return sorted_dict

# Clone few-shot gpt-oss:20b-minimal 1 nfr4
import secrets
import statistics


def task_func(LETTERS):
    """
    Create a dictionary with random letters as keys and lists of random integers as values.
    The dictionary is sorted by the mean of the values in descending order.

    Args:
        LETTERS (list of str): A list of characters used as keys for the dictionary.

    Returns:
        dict: The sorted dictionary with letters as keys and lists of integers as values,
              sorted by their mean values in descending order.
    """
    if not LETTERS:
        return {}
    result = {}
    for letter in LETTERS:
        length = secrets.randbelow(10) + 1
        values = [(secrets.randbelow(100) + 1) for _ in range(length)]
        result[letter] = values
    sorted_items = sorted(result.items(), key=lambda kv: statistics.mean(kv
        [1]), reverse=True)
    return dict(sorted_items)

# Clone few-shot gpt-oss:20b-requirements 1 nfr2
import random
import statistics
from collections import OrderedDict


def task_func(LETTERS):
    """
    Generate a dictionary mapping each unique letter in LETTERS to a list of random integers.
    The dictionary is sorted by the mean of the integer lists in descending order.
    """
    if not LETTERS:
        return {}
    unique_letters = set(LETTERS)
    data = {}
    for letter in unique_letters:
        length = random.randint(1, 10)
        data[letter] = [random.randint(1, 100) for _ in range(length)]
    sorted_items = sorted(data.items(), key=lambda kv: statistics.mean(kv[1
        ]), reverse=True)
    return dict(sorted_items)

# Clone few-shot gpt-oss:20b-requirements 1 nfr5
import random
import statistics


def task_func(LETTERS):
    """
    Generate a dictionary mapping each unique letter to a list of random integers.
    The dictionary is sorted by the mean of the integer lists in descending order.

    Parameters
    ----------
    LETTERS : collection of str
        The keys for the dictionary. Duplicates are removed.

    Returns
    -------
    dict
        Sorted dictionary with letters as keys and lists of integers as values.
    """
    if not LETTERS:
        return {}
    unique_letters = list(dict.fromkeys(LETTERS))
    result = {}
    for letter in unique_letters:
        length = random.randint(1, 10)
        result[letter] = [random.randint(0, 100) for _ in range(length)]
    sorted_items = sorted(result.items(), key=lambda kv: statistics.mean(kv
        [1]), reverse=True)
    return {k: v for k, v in sorted_items}

# Clone cot gpt-oss:20b-minimal 1 nfr4
import secrets
import statistics


def task_func(LETTERS):
    data = {}
    for letter in LETTERS:
        length = secrets.randbelow(8) + 3
        values = [secrets.randbelow(101) for _ in range(length)]
        data[letter] = values
    sorted_items = sorted(data.items(), key=lambda kv: statistics.mean(kv[1
        ]), reverse=True)
    return dict(sorted_items)

# Clone cot gpt-oss:20b-requirements 1 nfr2
import random
import statistics
import collections
import itertools
import functools
import operator
from typing import Iterable, Dict, List, Any


def task_func(LETTERS: Iterable[str]) ->Dict[str, List[int]]:
    """
    Generate a dictionary mapping each unique letter to a list of random integers.
    The dictionary is sorted by the mean of the integer lists in descending order.
    """
    try:
        import random
        import statistics
    except Exception as exc:
        raise RuntimeError('Required modules not available') from exc
    if not LETTERS:
        return {}
    unique_letters = set(LETTERS)
    result: Dict[str, List[int]] = {}
    for letter in unique_letters:
        list_len = random.randint(1, 10)
        nums = [random.randint(1, 100) for _ in range(list_len)]
        result[letter] = nums

    def mean_of(nums: List[int]) ->float:
        return statistics.mean(nums)
    sorted_items = sorted(result.items(), key=lambda kv: mean_of(kv[1]),
        reverse=True)
    return dict(sorted_items)

# Clone cot gpt-oss:20b-requirements 1 nfr4
import random
import statistics


def task_func(LETTERS):
    """
    Generate a dictionary mapping each unique letter in LETTERS to a list of random integers.
    The dictionary is sorted by the mean of the lists in descending order.

    Parameters
    ----------
    LETTERS : collections.abc.Collection[str]
        A collection of strings representing the keys.

    Returns
    -------
    dict
        A dictionary sorted by the mean of the list of integers for each key in descending order.
    """
    try:
        import random as _random
        import statistics as _statistics
    except Exception as exc:
        raise RuntimeError(
            "Required modules 'random' or 'statistics' are not available"
            ) from exc
    if not LETTERS:
        return {}
    seen = set()
    unique_letters = []
    for letter in LETTERS:
        if letter not in seen:
            seen.add(letter)
            unique_letters.append(letter)
    result = {}
    for letter in unique_letters:
        length = _random.randint(1, 10)
        numbers = [_random.randint(1, 100) for _ in range(length)]
        result[letter] = numbers
    sorted_items = sorted(result.items(), key=lambda kv: _statistics.mean(
        kv[1]), reverse=True)
    return dict(sorted_items)

