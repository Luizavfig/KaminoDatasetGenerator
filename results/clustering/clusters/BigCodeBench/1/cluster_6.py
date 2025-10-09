# Clone cot gpt-oss:20b-minimal 1 nfr2
import random
import string
import collections
import itertools
import numpy as np
import pandas as pd
from functools import reduce


def task_func(length=100):
    letters = string.ascii_letters
    indices = np.random.randint(0, len(letters), size=length)
    random_string = ''.join(letters[i] for i in indices)
    counts = collections.Counter(random_string)
    return dict(counts)

