# Clone zero-shot gpt-oss:20b-ast 1 nfr2
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

