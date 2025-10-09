# Clone zero-shot gpt-oss:latest-complete 1 nfr0
from collections import Counter


def task_func(d):
    all_vals = []
    for lst in d.values():
        if not isinstance(lst, list):
            raise TypeError
        for item in lst:
            if not isinstance(item, int):
                raise TypeError
            all_vals.append(item)
    return dict(Counter(all_vals))

# Clone cot gpt-oss:latest-complete 1 nfr4
def task_func(d):
    if not isinstance(d, dict):
        raise TypeError('Input must be a dictionary')
    counts = {}
    for lst in d.values():
        if not isinstance(lst, list):
            raise TypeError('All values must be lists')
        for item in lst:
            if not isinstance(item, int):
                raise TypeError('All list elements must be integers')
            counts[item] = counts.get(item, 0) + 1
    return counts

# Clone few-shot gpt-oss:20b-complete 1 nfr5
import collections
import itertools


def task_func(d):
    if not isinstance(d, dict):
        raise TypeError('Input must be a dictionary')
    all_items = []
    for lst in d.values():
        if not isinstance(lst, list):
            raise TypeError('All dictionary values must be lists')
        for item in lst:
            if not isinstance(item, int):
                raise TypeError('All list elements must be integers')
            all_items.append(item)
    return dict(collections.Counter(all_items))

# Clone cot gpt-oss:20b-complete 1 nfr0
def task_func(d):
    counts = {}
    for lst in d.values():
        if not isinstance(lst, list):
            raise TypeError
        for item in lst:
            if not isinstance(item, int):
                raise TypeError
            counts[item] = counts.get(item, 0) + 1
    return counts

