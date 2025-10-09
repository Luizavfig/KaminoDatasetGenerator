# Clone zero-shot deepseek-r1-minimal 1 nfr4
import random
import statistics


def task_func(letters):
    """
    Create a dictionary with keys from the provided list and values as lists of random integers.
    The dictionary is sorted by the mean of the values in descending order.

    Args:
        letters (list of str): List of characters to use as dictionary keys.

    Returns:
        dict: Dictionary sorted by mean of values in descending order.
    """
    if not isinstance(letters, list) or len(letters) == 0:
        raise ValueError('Input must be a non-empty list')
    result_dict = {}
    for letter in letters:
        values = [random.randint(1, 100) for _ in range(5)]
        result_dict[letter] = values
    sorted_dict = {k: v for k, v in sorted(result_dict.items(), key=lambda
        item: statistics.mean(item[1]), reverse=True)}
    return sorted_dict

# Clone zero-shot deepseek-r1-minimal 1 nfr5
import random
import statistics


def task_func(letters):
    """
    Create a dictionary with keys from LETTERS and values as lists of random integers.
    Then sort the dictionary by the mean of the values in descending order.

    Args:
        letters (list of str): List of characters to use as keys.

    Returns:
        dict: Sorted dictionary by mean of values in descending order.
    """
    my_dict = {}
    for letter in letters:
        values = [random.randint(1, 100) for _ in range(5)]
        my_dict[letter] = values
    sorted_dict = {k: v for k, v in sorted(my_dict.items(), key=lambda item:
        statistics.mean(item[1]), reverse=True)}
    return sorted_dict

# Clone zero-shot deepseek-r1-requirements 1 nfr2
import random
import statistics
from typing import List, Dict, Union


def task_func(LETTERS: List[str]) ->Dict[str, List[int]]:
    """
    Generates a dictionary with keys from LETTERS and each key has a list of random integers.
    The lists have lengths between 1 and 10 (inclusive). The dictionary is sorted by the mean
    of the list for each key in descending order.

    Args:
        LETTERS: A list of strings representing the keys.

    Returns:
        A dictionary with letters as keys and lists of integers as values, sorted by mean in descending order.

    Raises:
        Exception: If 'random' or 'statistics' modules are not available.
    """
    if not hasattr(random, 'choices'):
        raise Exception("The 'random' module is required but not available.")
    if not hasattr(statistics, 'mean'):
        raise Exception(
            "The 'statistics' module is required but not available.")
    result_dict = {}
    for letter in LETTERS:
        length = random.randint(1, 10)
        num_list = random.choices(range(0, 101), k=length)
        result_dict[letter] = num_list
    sorted_dict = {k: v for k, v in sorted(result_dict.items(), key=lambda
        item: statistics.mean(item[1]), reverse=True)}
    return sorted_dict

# Clone zero-shot deepseek-r1-requirements 1 nfr5
import random
import statistics


def task_func(LETTERS):
    """
    Generates a dictionary with keys from LETTERS and each key has a list of random integers.
    The lists have lengths between 1 and 10, inclusive. The dictionary is sorted by the mean 
    of the values (the list) in descending order.

    Args:
        LETTERS: A collection of strings (list, tuple, set) representing keys.

    Returns:
        dict: A dictionary with letters as keys and lists of integers as values, sorted by mean.

    Raises:
        Exception: If 'random' or 'statistics' modules are not available.
    """
    if not LETTERS:
        return {}
    unique_letters = set(LETTERS)
    if len(unique_letters) < len(LETTERS):
        raise ValueError(
            'Input contains duplicate keys. Only unique keys will be used.')
    result_dict = {}
    for letter in LETTERS:
        length = random.randint(1, 10)
        num_list = [random.randint(-100, 100) for _ in range(length)]
        result_dict[letter] = num_list
    sorted_dict = {k: v for k, v in sorted(result_dict.items(), key=lambda
        item: statistics.mean(item[1]), reverse=True)}
    return sorted_dict

# Clone few-shot deepseek-r1-minimal 1 nfr5
import statistics
import random


def task_func(letters):
    result_dict = {}
    for letter in letters:
        value_list = [random.randint(1, 100) for _ in range(5)]
        result_dict[letter] = value_list
    sorted_dict = {k: v for k, v in sorted(result_dict.items(), key=lambda
        item: statistics.mean(item[1]), reverse=True)}
    return sorted_dict

# Clone few-shot deepseek-r1-requirements 1 nfr5
import random
import statistics


def task_func(LETTERS):
    """
    Generate a dictionary with keys from LETTERS and each key's value is a list of random integers.
    The lists have lengths between 1 and 10, and the dictionary is sorted by the mean of the lists in descending order.

    Args:
        LETTERS (list of str): List of characters to be used as keys.

    Returns:
        dict: Dictionary with letters as keys and their corresponding list of integers as values, sorted by mean.

    Raises:
        ValueError: If LETTERS is empty or contains duplicate keys.
        ImportError: If required modules are not available.
    """
    if not isinstance(LETTERS, (list, tuple, set)):
        raise TypeError('Input must be a collection type (list, tuple, set)')
    if len(set(LETTERS)) != len(LETTERS):
        raise ValueError('Input contains duplicate keys')
    if not LETTERS:
        raise ValueError('Input collection is empty')
    output_dict = {}
    for letter in LETTERS:
        length = random.randint(1, 10)
        num_list = [random.randint(-100, 100) for _ in range(length)]
        output_dict[letter] = num_list
    sorted_dict = {k: v for k, v in sorted(output_dict.items(), key=lambda
        item: statistics.mean(item[1]), reverse=True)}
    return sorted_dict

# Clone cot deepseek-r1-requirements 1 nfr2
import random
import statistics
from typing import List, Dict, Union


def task_func(LETTERS: List[str]) ->Dict[str, List[int]]:
    if not hasattr(random, 'random'):
        raise ImportError('random module is required')
    if not hasattr(statistics, 'mean'):
        raise ImportError('statistics module is required')
    result_dict = {}
    for letter in LETTERS:
        if letter in result_dict:
            raise ValueError(
                f"Duplicate key '{letter}' found. Keys must be unique.")
        num_elements = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(num_elements)]
        result_dict[letter] = values
    sorted_dict = {k: v for k, v in sorted(result_dict.items(), key=lambda
        item: statistics.mean(item[1]), reverse=True)}
    return sorted_dict

