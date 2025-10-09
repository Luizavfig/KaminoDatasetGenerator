# Cluster 0 - Representative clone few-shot llama3.1:latest-minimal 1 nfr0
import itertools
import numpy as np


def task_func(numbers=[1, 2, 3, 4, 5, 6, 7, 8, 9, 10]):
    total_sum = 0
    for permutation in itertools.permutations(numbers):
        shuffled_permutation = np.random.permutation(permutation)
        current_sum = 0
        for i in range(len(shuffled_permutation) - 1):
            current_sum += abs(shuffled_permutation[i] -
                shuffled_permutation[i + 1])
        total_sum += current_sum
    return total_sum / len(list(itertools.permutations(numbers)))

# Cluster 1 - Representative clone cot gpt-oss:latest-requirements 1 nfr1
from itertools import permutations


def task_func(numbers=list(range(1, 3))):
    total = 0
    count = 0
    for perm in permutations(numbers):
        diff_sum = 0
        for i in range(len(perm) - 1):
            diff_sum += abs(perm[i] - perm[i + 1])
        total += diff_sum
        count += 1
    return total / count


print(task_func())

# Cluster 2 - Representative clone few-shot gpt-oss:20b-minimal 1 nfr2
import itertools
import numpy as np
import statistics
import math
import random
import functools
import operator


def task_func(numbers=None):
    if numbers is None:
        numbers = list(range(1, 11))
    if not numbers:
        return 0.0
    perms = itertools.permutations(numbers)
    total = 0.0
    count = 0
    for perm in perms:
        arr = np.array(perm)
        diff = np.abs(np.diff(arr))
        total += diff.sum()
        count += 1
    return total / count

# Cluster 3 - Representative clone cot gpt-oss:20b-requirements 1 nfr2
import itertools
import numpy as np
import statistics
import math
import functools
import operator
import collections
import random


def task_func(numbers=list(range(1, 3))):
    perms = list(itertools.permutations(numbers))
    diffs = []
    for p in perms:
        diff_sum = sum(abs(a - b) for a, b in zip(p, p[1:]))
        diffs.append(diff_sum)
    return float(statistics.mean(diffs))

# Cluster 4 - Representative clone zero-shot gpt-oss:20b-ast 1 nfr0
def task_func(numbers=None):
    if numbers is None:
        numbers = [i for i in range(1, 11)]
    import itertools
    import random
    import math
    total = 0.0
    n = len(numbers)
    perm_count = math.factorial(n)
    for perm in itertools.permutations(numbers):
        arr = list(perm)
        random.shuffle(arr)
        total += sum(abs(a - b) for a, b in zip(arr, arr[1:]))
    return total / perm_count

# Cluster 5 - Representative clone zero-shot deepseek-r1-minimal 1 nfr5
import itertools
import math


def task_func(numbers=None):
    """
    Calculates the average of the sums of absolute differences between each pair of consecutive numbers 
    for all permutations of a given list. Each permutation is shuffled before calculating the differences.

    Args:
        numbers (list): A list of numbers. Default is numbers from 1 to 10.

    Returns:
        float: The average of the sums of absolute differences for each shuffled permutation of the list.
    """
    if numbers is None:
        numbers = list(range(1, 11))
    total_sum = 0.0
    count = 0
    for perm in itertools.permutations(numbers):
        s = 0.0
        for i in range(len(perm) - 1):
            s += abs(perm[i] - perm[i + 1])
        total_sum += s
        count += 1
    return total_sum / math.factorial(len(numbers))

# Cluster 6 - Representative clone zero-shot deepseek-r1-ast 1 nfr1
import itertools
import random


def task_func(numbers=None):
    if numbers is None:
        numbers = list(range(1, 11))
    total_sum = 0
    count = 0
    for perm in itertools.permutations(numbers):
        perm_list = list(perm)
        random.shuffle(perm_list)
        diffs = [abs(perm_list[i] - perm_list[i + 1]) for i in range(len(
            perm_list) - 1)]
        total_sum += sum(diffs)
        count += 1
    return total_sum / count

# Cluster 7 - Representative clone zero-shot gpt-oss:latest-minimal 1 nfr5
import itertools
from typing import List, Optional


def task_func(numbers: Optional[List[float]]=None) ->float:
    if numbers is None:
        numbers = list(range(1, 11))
    n = len(numbers)
    if n <= 1:
        return 0.0
    total_diff = 0.0
    for i in range(n):
        for j in range(i + 1, n):
            total_diff += abs(numbers[i] - numbers[j])
    average = 2.0 / n * total_diff
    return average


print(task_func())

# Cluster 8 - Representative clone zero-shot gpt-oss:20b-minimal 1 nfr4
def task_func(numbers=None):
    if numbers is None:
        numbers = list(range(1, 11))
    n = len(numbers)
    if n <= 1:
        return 0.0
    from itertools import permutations
    total = 0.0
    count = 0
    for perm in permutations(numbers):
        s = 0.0
        prev = perm[0]
        for x in perm[1:]:
            s += abs(x - prev)
            prev = x
        total += s
        count += 1
    return total / count

# Cluster 9 - Representative clone few-shot gpt-oss:20b-minimal 1 nfr0
def task_func(numbers=None):
    if numbers is None:
        numbers = list(range(1, 11))
    n = len(numbers)
    if n <= 1:
        return 0.0
    total_diff = 0
    for i in range(n):
        ai = numbers[i]
        for j in range(i + 1, n):
            total_diff += abs(ai - numbers[j])
    return 2.0 / n * total_diff

# Cluster 10 - Representative clone few-shot gpt-oss:20b-complete 1 nfr4
import itertools
import random


def task_func(numbers=list(range(1, 11))):
    if len(numbers) <= 1:
        return 0.0
    perms = list(itertools.permutations(numbers))
    total_diff_sum = 0.0
    for perm in perms:
        perm_list = list(perm)
        random.shuffle(perm_list)
        diff_sum = sum(abs(perm_list[i] - perm_list[i + 1]) for i in range(
            len(perm_list) - 1))
        total_diff_sum += diff_sum
    return total_diff_sum / len(perms)

