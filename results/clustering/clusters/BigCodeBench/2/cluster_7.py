# Clone zero-shot gpt-oss:20b-complete 1 nfr2
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

