# Clone zero-shot llama3.1:latest-translation 1 nfr3
from collections import defaultdict


def task_func(d):
    count_dict = defaultdict(int)
    for lst in d.values():
        for s in lst:
            count_dict[s] += 1
    return dict(count_dict)

# Clone zero-shot deepseek-r1-minimal 1 nfr3
def task_func(d):
    from collections import defaultdict
    count_dict = defaultdict(int)
    for key, value_list in d.items():
        for num in value_list:
            count_dict[num] += 1
    return dict(count_dict)

# Clone zero-shot deepseek-r1-minimal 1 nfr4
def task_func(d):
    """
    Count the occurrence of each integer in the values of the input dictionary,
    where each value is a list of integers, and return a dictionary with these counts.

    Args:
        d (dict): A dictionary with string keys and list of integers as values.

    Returns:
        dict: A dictionary with integer keys and their respective counts.

    Example:
        Input: {'a': [1, 2, 3], 'b': [2, 3, 4]}
        Output: {1: 1, 2: 2, 3: 2, 4: 1}
    """
    from collections import defaultdict
    count_dict = defaultdict(int)
    for numbers in d.values():
        for num in numbers:
            count_dict[num] += 1
    return dict(count_dict)

# Clone zero-shot deepseek-r1-minimal 1 nfr5
def task_func(d):
    """
    Count the occurrence of each integer in the values of the input dictionary,
    where each value is a list of integers, and return a dictionary with these counts.

    Args:
        d (dict): A dictionary with string keys and list of integers as values.

    Returns:
        dict: A dictionary with integer keys and their respective counts.
    """
    from collections import defaultdict
    count_dict = defaultdict(int)
    for numbers in d.values():
        for num in numbers:
            count_dict[num] += 1
    return dict(count_dict)

# Clone zero-shot deepseek-r1-requirements 1 nfr0
def task_func(d):
    from collections import defaultdict
    count_dict = defaultdict(int)
    for key in d:
        for value in d[key]:
            count_dict[value] += 1
    return dict(count_dict)

# Clone zero-shot deepseek-r1-requirements 1 nfr3
def task_func(d):
    from collections import defaultdict
    count_dict = defaultdict(int)
    for key, value_list in d.items():
        for num in value_list:
            count_dict[num] += 1
    return {k: v for k, v in count_dict.items()}

# Clone zero-shot deepseek-r1-requirements 1 nfr4
def task_func(d):
    from collections import defaultdict
    count_dict = defaultdict(int)
    for key, value_list in d.items():
        for num in value_list:
            count_dict[num] += 1
    return dict(count_dict)

# Clone zero-shot deepseek-r1-translation 1 nfr4
from collections import defaultdict


def task_func(d):
    count_dict = defaultdict(int)
    for sublist in d.values():
        for num in sublist:
            count_dict[num] += 1
    return dict(count_dict)

# Clone zero-shot deepseek-r1-translation 1 nfr5
from collections import defaultdict


def task_func(d: dict) ->dict:
    count_dict = defaultdict(int)
    for key, value_list in d.items():
        for num in value_list:
            count_dict[num] += 1
    return {k: v for k, v in count_dict.items()}

# Clone zero-shot llama4:latest-ast 1 nfr0
from collections import defaultdict


def task_func(d):
    count_dict = defaultdict(int)
    for lst in d.values():
        for num in lst:
            count_dict[num] += 1
    return dict(count_dict)

# Clone zero-shot llama4:latest-translation 1 nfr3
from collections import defaultdict


def task_func(d: dict) ->dict:
    count_dict = defaultdict(int)
    for lst in d.values():
        for num in lst:
            count_dict[num] += 1
    return dict(count_dict)

# Clone few-shot llama3.1:latest-translation 1 nfr3
from collections import defaultdict


def task_func(d):
    count_dict = defaultdict(int)
    for key, value in d.items():
        for s in value:
            count_dict[s] += 1
    return dict(count_dict)

# Clone cot llama3.1:latest-translation 1 nfr0
from collections import defaultdict


def task_func(d):
    count_dict = defaultdict(int)
    for list_ in d.values():
        for s in list_:
            count_dict[s] += 1
    return dict(count_dict)

# Clone cot llama3.1:latest-translation 1 nfr3
from collections import defaultdict


def task_func(d):
    count_dict = defaultdict(int)
    for list_ in d.values():
        for s in list_:
            count_dict[s] += 1
    return dict(count_dict)

# Clone cot llama3.1:latest-translation 1 nfr4
from collections import defaultdict


def task_func(d):
    count_dict = defaultdict(int)
    for list_ in d.values():
        for s in list_:
            count_dict[s] += 1
    return dict(count_dict)

# Clone few-shot deepseek-r1-minimal 1 nfr0
def task_func(d):
    from collections import defaultdict
    count_dict = defaultdict(int)
    for key, value_list in d.items():
        for num in value_list:
            count_dict[num] += 1
    return dict(count_dict)

# Clone few-shot deepseek-r1-minimal 1 nfr1
def task_func(d):
    from collections import defaultdict
    count_dict = defaultdict(int)
    for key in d:
        for num in d[key]:
            count_dict[num] += 1
    return dict(count_dict)

# Clone few-shot deepseek-r1-minimal 1 nfr3
def task_func(d):
    from collections import defaultdict
    count_dict = defaultdict(int)
    for key, value_list in d.items():
        for num in value_list:
            count_dict[num] += 1
    return dict(count_dict)

# Clone few-shot deepseek-r1-minimal 1 nfr4
def task_func(d):
    """
    Count the occurrence of each integer in the values of the input dictionary.

    Args:
        d (dict): A dictionary where keys are strings and values are lists of integers.

    Returns:
        dict: A dictionary with integer keys and their counts as values.
    """
    from collections import defaultdict
    count_dict = defaultdict(int)
    for sublist in d.values():
        for num in sublist:
            count_dict[num] += 1
    return dict(count_dict)

# Clone few-shot deepseek-r1-minimal 1 nfr5
def task_func(d):
    from collections import defaultdict
    count_dict = defaultdict(int)
    for key, value_list in d.items():
        for num in value_list:
            count_dict[num] += 1
    return dict(count_dict)

# Clone few-shot deepseek-r1-requirements 1 nfr0
def task_func(d):
    from collections import defaultdict
    count_dict = defaultdict(int)
    for key in d:
        for value in d[key]:
            count_dict[value] += 1
    return dict(count_dict)

# Clone few-shot deepseek-r1-requirements 1 nfr1
def task_func(d):
    from collections import defaultdict
    count_dict = defaultdict(int)
    for key, value_list in d.items():
        for num in value_list:
            count_dict[num] += 1
    return dict(count_dict)

# Clone few-shot deepseek-r1-requirements 1 nfr3
def task_func(d):
    from collections import defaultdict
    count_dict = defaultdict(int)
    for key, value_list in d.items():
        for num in value_list:
            count_dict[num] += 1
    return dict(count_dict)

# Clone few-shot deepseek-r1-requirements 1 nfr4
def task_func(d):
    from collections import defaultdict
    count_dict = defaultdict(int)
    for key, value_list in d.items():
        for num in value_list:
            count_dict[num] += 1
    return dict(count_dict)

# Clone few-shot deepseek-r1-requirements 1 nfr5
def task_func(d):
    from collections import defaultdict
    count_dict = defaultdict(int)
    for key, value_list in d.items():
        for num in value_list:
            count_dict[num] += 1
    return dict(count_dict)

# Clone few-shot deepseek-r1-translation 1 nfr5
from collections import defaultdict


def task_func(d: dict) ->dict:
    count_dict = defaultdict(int)
    for sublist in d.values():
        for num in sublist:
            count_dict[num] += 1
    return {key: value for key, value in count_dict.items()}

# Clone cot deepseek-r1-minimal 1 nfr3
def task_func(d):
    from collections import defaultdict
    count_dict = defaultdict(int)
    for key in d:
        for num in d[key]:
            count_dict[num] += 1
    return dict(count_dict)

# Clone cot deepseek-r1-minimal 1 nfr5
def task_func(d):
    from collections import defaultdict
    count_dict = defaultdict(int)
    for key in d:
        for num in d[key]:
            count_dict[num] += 1
    return dict(count_dict)

# Clone cot deepseek-r1-requirements 1 nfr0
def task_func(d):
    from collections import defaultdict
    count_dict = defaultdict(int)
    for key in d:
        for value in d[key]:
            count_dict[value] += 1
    return {k: v for k, v in count_dict.items()}

# Clone cot deepseek-r1-requirements 1 nfr1
def task_func(d):
    from collections import defaultdict
    count_dict = defaultdict(int)
    for key in d:
        for value in d[key]:
            count_dict[value] += 1
    return {k: v for k, v in count_dict.items()}

# Clone cot deepseek-r1-requirements 1 nfr3
def task_func(d):
    from collections import defaultdict
    count_dict = defaultdict(int)
    for key in d:
        if isinstance(d[key], list):
            for num in d[key]:
                count_dict[num] += 1
    return dict(count_dict)

# Clone cot deepseek-r1-requirements 1 nfr4
def task_func(d):
    from collections import defaultdict
    count_dict = defaultdict(int)
    for key in d:
        if isinstance(d[key], list):
            for num in d[key]:
                count_dict[num] += 1
    return dict(count_dict)

# Clone cot deepseek-r1-requirements 1 nfr5
def task_func(d):
    from collections import defaultdict
    count_dict = defaultdict(int)
    for key in d:
        if isinstance(d[key], list):
            for num in d[key]:
                count_dict[num] += 1
    return dict(count_dict)

# Clone few-shot llama4:latest-translation 1 nfr2
from collections import defaultdict


def task_func(d):
    count_dict = defaultdict(int)
    for lst in d.values():
        for item in lst:
            count_dict[item] += 1
    return dict(count_dict)

# Clone few-shot llama4:latest-translation 1 nfr3
from collections import defaultdict


def task_func(d):
    count_dict = defaultdict(int)
    for lst in d.values():
        for num in lst:
            count_dict[num] += 1
    return dict(count_dict)

# Clone few-shot llama4:latest-translation 1 nfr4
from collections import defaultdict


def task_func(d):
    count_dict = defaultdict(int)
    for lst in d.values():
        for item in lst:
            count_dict[item] += 1
    return dict(count_dict)

# Clone few-shot llama4:latest-translation 1 nfr5
from collections import defaultdict


def task_func(d):
    count_dict = defaultdict(int)
    for lst in d.values():
        for item in lst:
            count_dict[item] += 1
    return dict(count_dict)

# Clone cot llama4:latest-complete 1 nfr0
from collections import defaultdict


def task_func(d):
    count_dict = defaultdict(int)
    for v in d.values():
        for i in v:
            if not isinstance(i, int):
                raise TypeError('Input list must only contain integers.')
            count_dict[i] += 1
    return dict(count_dict)

# Clone cot llama4:latest-complete 1 nfr2
from collections import defaultdict


def task_func(d):
    count_dict = defaultdict(int)
    for v in d.values():
        for i in v:
            if not isinstance(i, int):
                raise TypeError('Input list must only contain integers.')
            count_dict[i] += 1
    return dict(count_dict)

# Clone cot llama4:latest-ast 1 nfr2
from collections import defaultdict
from itertools import chain


def task_func(d):
    count_dict = defaultdict(int)
    for lst in d.values():
        for num in lst:
            count_dict[num] += 1
    return dict(count_dict)

# Clone cot llama4:latest-translation 1 nfr0
from collections import defaultdict


def task_func(d):
    count_dict = defaultdict(int)
    for lst in d.values():
        for num in lst:
            count_dict[num] += 1
    return dict(count_dict)

# Clone cot llama4:latest-translation 1 nfr2
from collections import defaultdict


def task_func(d):
    count_dict = defaultdict(int)
    for value in d.values():
        for item in value:
            count_dict[item] += 1
    return dict(count_dict)

# Clone cot llama4:latest-translation 1 nfr3
from collections import defaultdict


def task_func(d):
    count_dict = defaultdict(int)
    for lst in d.values():
        for num in lst:
            count_dict[num] += 1
    return dict(count_dict)

# Clone cot llama4:latest-translation 1 nfr4
from collections import defaultdict


def task_func(d):
    count_dict = defaultdict(int)
    for lst in d.values():
        for num in lst:
            count_dict[num] += 1
    return dict(count_dict)

# Clone cot llama4:latest-translation 1 nfr5
from collections import defaultdict


def task_func(d):
    count_dict = defaultdict(int)
    for value in d.values():
        for item in value:
            count_dict[item] += 1
    return dict(count_dict)

# Clone zero-shot gpt-oss:20b-requirements 1 nfr3
from collections import defaultdict


def task_func(d):
    counts = defaultdict(int)
    for items in d.values():
        for num in items:
            counts[num] += 1
    return dict(counts)

# Clone few-shot gpt-oss:20b-complete 1 nfr3
from collections import defaultdict


def task_func(d):
    counts = defaultdict(int)
    for lst in d.values():
        for item in lst:
            if not isinstance(item, int):
                raise TypeError(f'Non-integer value encountered: {item!r}')
            counts[item] += 1
    return dict(counts)

# Clone few-shot gpt-oss:20b-ast 1 nfr2
import pandas as pd
import numpy as np
from functools import reduce
from collections import defaultdict
import itertools
import operator


def task_func(d):
    counts = defaultdict(int)
    for lst in d.values():
        for num in lst:
            counts[num] += 1
    return dict(counts)

# Clone cot gpt-oss:20b-complete 1 nfr4
from collections import defaultdict


def task_func(d):
    counts = defaultdict(int)
    for lst in d.values():
        for item in lst:
            if not isinstance(item, int):
                raise TypeError(f'Non-integer element {item!r} found')
            counts[item] += 1
    return dict(counts)

