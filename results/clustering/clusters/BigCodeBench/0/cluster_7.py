# Clone zero-shot gpt-oss:latest-minimal 1 nfr5
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

# Clone few-shot gpt-oss:latest-minimal 1 nfr5
import itertools
from typing import List


def task_func(numbers: List[float]=None) ->float:
    """
    Calculate the average of the sums of absolute differences between each pair
    of consecutive numbers for all permutations of the given list.
    The calculation uses a combinatorial formula to avoid enumerating all
    permutations, ensuring efficiency for larger lists.

    Args:
        numbers (List[float], optional): The list of numbers to process.
            Defaults to the list of integers from 1 to 10.

    Returns:
        float: The average sum of absolute differences across all permutations.
    """
    if numbers is None:
        numbers = list(range(1, 11))
    n = len(numbers)
    if n <= 1:
        return 0.0
    total_abs_diff = 0.0
    for i, j in itertools.permutations(numbers, 2):
        total_abs_diff += abs(i - j)
    expected_abs_diff = total_abs_diff / (n * (n - 1))
    average_sum = (n - 1) * expected_abs_diff
    return average_sum


print(task_func())

# Clone zero-shot gpt-oss:20b-minimal 1 nfr3
import math
from typing import List, Optional


def task_func(numbers: Optional[List[float]]=None) ->float:
    """
    Calculate the average sum of absolute differences between consecutive elements
    across all permutations of the input list.

    Args:
        numbers: A list of numeric values. If None, defaults to [1, 2, ..., 10].

    Returns:
        float: The average sum of absolute differences over all permutations.
    """
    if numbers is None:
        numbers = list(range(1, 11))
    n = len(numbers)
    if n <= 1:
        return 0.0
    total_abs_diff = 0.0
    for i in range(n):
        ai = numbers[i]
        for j in range(i + 1, n):
            total_abs_diff += abs(ai - numbers[j])
    average = 2.0 / n * total_abs_diff
    return average

# Clone zero-shot gpt-oss:20b-minimal 1 nfr5
import itertools
from typing import List, Optional


def task_func(numbers: Optional[List[float]]=None) ->float:
    """
    Calculate the average of the sums of absolute differences between each pair of
    consecutive numbers for all permutations of the given list. If no list is
    provided, the default list is [1, 2, ..., 10].

    Parameters
    ----------
    numbers : list, optional
        A list of numbers. Defaults to [1, 2, ..., 10].

    Returns
    -------
    float
        The average sum of absolute differences across all permutations.
    """
    if numbers is None:
        numbers = list(range(1, 11))
    if len(numbers) <= 1:
        return 0.0
    total_sum = 0.0
    perm_count = 0
    for perm in itertools.permutations(numbers):
        diff_sum = sum(abs(a - b) for a, b in zip(perm, perm[1:]))
        total_sum += diff_sum
        perm_count += 1
    return total_sum / perm_count if perm_count else 0.0

