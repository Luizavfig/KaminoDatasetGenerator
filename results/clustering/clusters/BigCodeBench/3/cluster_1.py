# Clone zero-shot deepseek-r1-minimal 1 nfr4
import random


def task_func(letters):
    """
    Create a dictionary where keys are specified letters and values are lists of random integers.
    Then calculate the mean of these integers for each key and return a dictionary of these means.

    Args:
        letters (list of str): List of single-character strings to be used as keys.

    Returns:
        dict: A dictionary with keys from 'letters' and values being the mean of a randomly generated list.
    """
    if not all(isinstance(letter, str) and len(letter) == 1 for letter in
        letters):
        raise ValueError(
            "All elements in 'letters' must be single-character strings.")
    result = {}
    for letter in letters:
        num_elements = random.randint(1, 10)
        random_list = [random.randint(0, 100) for _ in range(num_elements)]
        mean_value = sum(random_list) / len(random_list)
        result[letter] = round(mean_value, 2)
    return result

# Clone zero-shot deepseek-r1-uml 1 nfr4
import random


def task_func(letters):
    if not isinstance(letters, list) or any(len(letter) != 1 for letter in
        letters):
        raise ValueError('Input must be a list of single-character strings')
    random_dict = {}
    for letter in letters:
        num_elements = random.randint(1, 10)
        numbers = [random.randint(0, 100) for _ in range(num_elements)]
        random_dict[letter] = numbers
    mean_dict = {}
    for letter, numbers in random_dict.items():
        if len(numbers) == 0:
            continue
        total = sum(numbers)
        count = len(numbers)
        mean_value = round(total / count, 2)
        mean_dict[letter] = mean_value
    return mean_dict

# Clone few-shot deepseek-r1-minimal 1 nfr4
import random


def task_func(letters):
    """
    Create a dictionary where keys are specified letters and values are lists of random integers.
    Then calculate the mean of these integers for each key and return a dictionary of these means.

    Args:
        letters (list of str): List of single-character strings to be used as keys.

    Returns:
        dict: A dictionary with keys from `letters` and values being the mean of a randomly generated list of integers.
    """
    if not isinstance(letters, list):
        raise TypeError('Input must be a list of single-character strings.')
    for letter in letters:
        if not isinstance(letter, str) or len(letter) != 1:
            raise ValueError(
                f'Invalid key: {letter}. Each element must be a single-character string.'
                )
    means_dict = {}
    for letter in letters:
        num_integers = random.randint(1, 10)
        integer_list = [random.randint(0, 100) for _ in range(num_integers)]
        mean_value = sum(integer_list) / len(integer_list)
        means_dict[letter] = round(mean_value, 2)
    return means_dict

# Clone few-shot deepseek-r1-uml 1 nfr4
import random


def task_func(letters):
    if not isinstance(letters, list) or any(not isinstance(letter, str) or 
        len(letter) != 1 for letter in letters):
        raise ValueError('Input must be a list of single-character strings')
    random_dict = {}
    for letter in letters:
        num_elements = random.randint(1, 10)
        numbers = [random.randint(0, 100) for _ in range(num_elements)]
        mean_value = sum(numbers) / len(numbers)
        random_dict[letter] = round(mean_value, 2)
    return random_dict

# Clone few-shot deepseek-r1-translation 1 nfr4
import random


def task_func(letters: list[str]) ->dict[str, float]:
    """
    Generate a dictionary with the mean of randomly generated numbers for each letter.

    Args:
        letters: List of single-character strings

    Returns:
        A dictionary where keys are letters and values are their corresponding mean (float)

    Raises:
        TypeError: If input is not a list of strings
    """
    if not isinstance(letters, list) or any(not isinstance(letter, str) for
        letter in letters):
        raise TypeError('Input must be a list of strings')
    random_dict = {}
    for letter in letters:
        size = random.randint(1, 10)
        values = [random.uniform(0, 100) for _ in range(size)]
        random_dict[letter] = values
    mean_dict = {}
    for key, value_list in random_dict.items():
        if len(value_list) == 0:
            mean_dict[key] = 0.0
        else:
            mean = sum(value_list) / len(value_list)
            mean_dict[key] = round(mean, 2)
    return mean_dict

