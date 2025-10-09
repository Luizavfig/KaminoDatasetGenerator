# Clone cot gpt-oss:latest-uml 1 nfr4
import secrets
import statistics


def task_func(LETTERS):
    data = {letter: [(secrets.randbelow(100) + 1) for _ in range(5)] for
        letter in LETTERS}
    sorted_items = sorted(data.items(), key=lambda item: statistics.mean(
        item[1]), reverse=True)
    return dict(sorted_items)


print(task_func(['a', 'b', 'c']))

# Clone zero-shot gpt-oss:20b-minimal 1 nfr4
import secrets
import statistics
from typing import List, Dict


def task_func(LETTERS: List[str]) ->Dict[str, List[int]]:
    """
    Creates a dictionary with keys from LETTERS and random integer lists as values.
    The dictionary is sorted by the mean of each list in descending order.

    Args:
        LETTERS: A list of single-character strings to use as keys.

    Returns:
        A dictionary sorted by the mean of the integer lists in descending order.
    """
    result = {}
    for letter in LETTERS:
        if not isinstance(letter, str) or len(letter) != 1:
            continue
        random_ints = [(secrets.randbelow(100) + 1) for _ in range(5)]
        result[letter] = random_ints
    sorted_items = sorted(result.items(), key=lambda item: statistics.mean(
        item[1]), reverse=True)
    return dict(sorted_items)

