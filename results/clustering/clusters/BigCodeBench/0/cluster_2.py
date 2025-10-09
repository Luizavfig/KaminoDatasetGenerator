# Clone cot gpt-oss:latest-requirements 1 nfr2
import itertools
import numpy as np
import statistics
import functools
import operator
import math
import collections
import random
import pandas as pd
import decimal
import fractions
import re
import json
import csv
import pathlib
import datetime
import typing
import sys
import os


def task_func(numbers=list(range(1, 3))):
    perms = itertools.permutations(numbers)
    sums = []
    for perm in perms:
        arr = np.array(perm)
        diff = np.abs(np.diff(arr))
        sums.append(diff.sum())
    return float(statistics.mean(sums))


print(task_func())

# Clone zero-shot gpt-oss:20b-ast 1 nfr2
import itertools
import random
import numpy as np
import statistics
import functools
import operator
import math
import collections


def task_func(numbers=None):
    if numbers is None:
        numbers = list(range(1, 11))
    perms = itertools.permutations(numbers)
    diff_sums = []
    for perm in perms:
        perm_list = list(perm)
        random.shuffle(perm_list)
        arr = np.array(perm_list, dtype=float)
        diff_sums.append(np.sum(np.abs(np.diff(arr))))
    return statistics.mean(diff_sums)

# Clone few-shot gpt-oss:20b-minimal 1 nfr2
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

# Clone cot gpt-oss:20b-minimal 1 nfr2
import itertools
import numpy as np
import math
import statistics
from functools import reduce
from operator import add


def task_func(numbers=None):
    if numbers is None:
        numbers = list(range(1, 11))
    total = 0.0
    count = 0
    for perm in itertools.permutations(numbers):
        arr = np.array(perm)
        diff = np.abs(np.diff(arr))
        total += diff.sum()
        count += 1
    return total / count if count else 0.0

