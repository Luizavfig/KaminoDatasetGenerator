# Clone cot gpt-oss:20b-requirements 1 nfr2
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

