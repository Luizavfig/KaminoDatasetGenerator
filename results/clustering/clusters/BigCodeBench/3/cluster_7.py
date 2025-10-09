# Clone zero-shot llama3.1:latest-minimal 1 nfr2
import random
from typing import List, Dict


def task_func(LETTERS: List[str]) ->Dict[str, float]:
    result = {}
    for letter in LETTERS:
        num_list = [random.randint(0, 100) for _ in range(random.randint(1,
            10))]
        result[letter] = sum(num_list) / len(num_list)
    return result

# Clone zero-shot llama3.1:latest-requirements 1 nfr2
import random
from typing import List, Dict


def task_func(LETTERS: List[str]) ->Dict[str, float]:
    result = {}
    for letter in LETTERS:
        num_integers = random.randint(1, 10)
        integers = [random.randint(0, 100) for _ in range(num_integers)]
        result[letter] = sum(integers) / num_integers
    return result

# Clone zero-shot llama4:latest-requirements 1 nfr2
import random
import numpy as np
from typing import List, Dict


def task_func(LETTERS: List[str]) ->Dict[str, float]:
    result = {}
    for letter in LETTERS:
        list_size = random.randint(1, 10)
        random_list = [random.randint(0, 100) for _ in range(list_size)]
        result[letter] = np.mean(random_list)
    return result

# Clone few-shot llama3.1:latest-requirements 1 nfr2
import random
from typing import List, Dict


def task_func(LETTERS: List[str]) ->Dict[str, float]:
    result = {}
    for letter in LETTERS:
        num_values = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(num_values)]
        result[letter] = sum(values) / num_values
    return result

# Clone cot deepseek-r1-uml 1 nfr3
import random
from typing import List, Dict


def task_func(letters: List[str]) ->Dict[str, float]:
    random_dict = {}
    for letter in letters:
        num_integers = random.randint(1, 10)
        numbers = [random.randint(0, 100) for _ in range(num_integers)]
        mean_value = sum(numbers) / len(numbers)
        random_dict[letter] = mean_value
    return random_dict

# Clone zero-shot gpt-oss:latest-minimal 1 nfr4
import secrets
from typing import List, Dict


def task_func(LETTERS: List[str]) ->Dict[str, float]:
    result = {}
    for letter in LETTERS:
        count = secrets.randbelow(10) + 1
        values = [secrets.randbelow(101) for _ in range(count)]
        mean_val = sum(values) / count if count else 0.0
        result[letter] = mean_val
    return result


print(task_func(['a', 'b', 'c']))

# Clone zero-shot gpt-oss:latest-uml 1 nfr5
import random
from typing import List, Dict


def task_func(LETTERS: List[str]) ->Dict[str, float]:
    """
    Generate a dictionary mapping each letter in LETTERS to the mean of a
    randomly generated list of integers.

    For each letter:
        - Create a list of 1 to 10 random integers between 0 and 100.
        - Compute the mean of that list.
        - Store the mean in the result dictionary under the letter key.

    Parameters
    ----------
    LETTERS : List[str]
        List of single-character strings to be used as keys.

    Returns
    -------
    Dict[str, float]
        Dictionary where each key is a letter from LETTERS and the value
        is the mean of the corresponding random integer list.
    """
    result: Dict[str, float] = {}
    for letter in LETTERS:
        count = random.randint(1, 10)
        numbers = [random.randint(0, 100) for _ in range(count)]
        mean_value = sum(numbers) / count if count else 0.0
        result[letter] = mean_value
    return result


print(task_func(['a', 'b', 'c']))

# Clone few-shot gpt-oss:latest-minimal 1 nfr5
import random
from typing import List, Dict


def task_func(LETTERS: List[str]) ->Dict[str, float]:
    result = {}
    for letter in LETTERS:
        count = random.randint(1, 10)
        numbers = [random.randint(0, 100) for _ in range(count)]
        mean_value = sum(numbers) / count
        result[letter] = mean_value
    return result

# Clone few-shot gpt-oss:latest-uml 1 nfr5
import random
from typing import List, Dict


def task_func(LETTERS: List[str]) ->Dict[str, float]:
    result = {}
    for letter in LETTERS:
        count = random.randint(1, 10)
        numbers = [random.randint(0, 100) for _ in range(count)]
        mean_val = sum(numbers) / count
        result[letter] = mean_val
    return result


print(task_func(['A', 'B', 'C']))

# Clone few-shot gpt-oss:latest-translation 1 nfr4
import random
from typing import List, Dict


def task_func(LETTERS: List[str]) ->Dict[str, float]:
    """
    Generate a dictionary mapping each letter to the mean of a randomly generated list of integers.
    Each list contains 1 to 10 integers ranging from 0 to 100 inclusive.
    """
    result = {}
    for letter in LETTERS:
        size = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(size)]
        mean_val = sum(values) / size if size else 0.0
        result[letter] = mean_val
    return result


print(task_func(['a', 'b', 'c']))

# Clone cot gpt-oss:latest-minimal 1 nfr4
import random


def task_func(LETTERS: list[str]) ->dict[str, float]:
    rng = random.SystemRandom()
    result = {}
    for letter in LETTERS:
        count = rng.randint(1, 10)
        numbers = [rng.randint(0, 100) for _ in range(count)]
        mean_val = sum(numbers) / count
        result[letter] = mean_val
    return result


print(task_func(['a', 'b', 'c']))

# Clone cot gpt-oss:latest-minimal 1 nfr5
import random
from typing import List, Dict


def task_func(LETTERS: List[str]) ->Dict[str, float]:
    """Return a dictionary mapping each letter to the mean of a random list of integers."""
    result: Dict[str, float] = {}
    for letter in LETTERS:
        count = random.randint(1, 10)
        numbers = [random.randint(0, 100) for _ in range(count)]
        mean_val = sum(numbers) / count
        result[letter] = mean_val
    return result


if __name__ == '__main__':
    print(task_func(['a', 'b', 'c']))

# Clone zero-shot gpt-oss:20b-minimal 1 nfr0
import random
from typing import List, Dict


def task_func(LETTERS: List[str]) ->Dict[str, float]:
    result = {}
    for letter in LETTERS:
        length = random.randint(1, 10)
        numbers = [random.randint(0, 100) for _ in range(length)]
        mean_value = sum(numbers) / length
        result[letter] = mean_value
    return result

# Clone zero-shot gpt-oss:20b-minimal 1 nfr3
import random
from typing import List, Dict


def task_func(LETTERS: List[str]) ->Dict[str, float]:
    try:
        result: Dict[str, float] = {}
        for letter in LETTERS:
            n = random.randint(1, 10)
            values = [random.randint(0, 100) for _ in range(n)]
            result[letter] = sum(values) / n
        return result
    except Exception:
        return {}

# Clone zero-shot gpt-oss:20b-minimal 1 nfr4
import secrets
from typing import List, Dict, Union


def task_func(LETTERS: List[str]) ->Dict[str, Union[float, int]]:
    """
    Generate a dictionary where each key is a letter from LETTERS and the value is the mean
    of a randomly generated list of integers (1 to 10 integers ranging from 0 to 100).

    Args:
        LETTERS: List of single-character strings.

    Returns:
        Dictionary mapping each letter to the mean of its associated random integer list.
    """
    result: Dict[str, Union[float, int]] = {}
    for letter in LETTERS:
        count = secrets.randbelow(10) + 1
        numbers = [secrets.randbelow(101) for _ in range(count)]
        mean_value = sum(numbers) / count if count else 0
        result[letter] = mean_value
    return result

# Clone zero-shot gpt-oss:20b-minimal 1 nfr5
import random
from typing import List, Dict


def task_func(LETTERS: List[str]) ->Dict[str, float]:
    result = {}
    for letter in LETTERS:
        count = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(count)]
        mean_val = sum(values) / len(values)
        result[letter] = mean_val
    return result

# Clone zero-shot gpt-oss:20b-uml 1 nfr3
import random
from typing import List, Dict


def task_func(LETTERS: List[str]) ->Dict[str, float]:
    result = {}
    for letter in LETTERS:
        count = random.randint(1, 10)
        numbers = [random.randint(0, 100) for _ in range(count)]
        mean = sum(numbers) / count if count else 0.0
        result[letter] = mean
    return result

# Clone zero-shot gpt-oss:20b-uml 1 nfr4
import random
from typing import List, Dict


def task_func(LETTERS: List[str]) ->Dict[str, float]:
    """
    Generate a dictionary where each key is a letter from LETTERS and the value
    is the mean of a randomly generated list of integers.
    Each list contains between 1 and 10 integers, each ranging from 0 to 100.
    """
    if not isinstance(LETTERS, list):
        raise TypeError('LETTERS must be a list of single-character strings.')
    result: Dict[str, float] = {}
    for letter in LETTERS:
        if not isinstance(letter, str) or len(letter) != 1:
            raise ValueError(
                'Each element in LETTERS must be a single-character string.')
        count = random.randint(1, 10)
        numbers = [random.randint(0, 100) for _ in range(count)]
        mean_value = sum(numbers) / count
        result[letter] = mean_value
    return result

# Clone zero-shot gpt-oss:20b-uml 1 nfr5
import random
from typing import List, Dict


def task_func(LETTERS: List[str]) ->Dict[str, float]:
    result: Dict[str, float] = {}
    for letter in LETTERS:
        list_size = random.randint(1, 10)
        numbers = [random.randint(0, 100) for _ in range(list_size)]
        mean_value = sum(numbers) / list_size
        result[letter] = mean_value
    return result

# Clone zero-shot gpt-oss:20b-translation 1 nfr4
import random
from typing import List, Dict


def task_func(LETTERS: List[str]) ->Dict[str, float]:
    """
    Generate a dictionary mapping each letter to the mean of a randomly
    generated list of floats between 0 and 100.

    Each list contains a random number of elements (1 to 10).
    """
    result: Dict[str, float] = {}
    for letter in LETTERS:
        size = random.randint(1, 10)
        values = [(random.random() * 100) for _ in range(size)]
        mean_value = sum(values) / size if values else 0.0
        result[letter] = mean_value
    return result

# Clone zero-shot gpt-oss:20b-translation 1 nfr5
import random
from typing import List, Dict


def task_func(LETTERS: List[str]) ->Dict[str, float]:
    """
    For each letter in LETTERS, generate a random list of 1-10 integers between 0 and 100,
    compute the mean of that list, and return a dictionary mapping the letter to its mean.
    """
    result: Dict[str, float] = {}
    for letter in LETTERS:
        size = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(size)]
        mean_val = sum(values) / size if values else 0.0
        result[letter] = mean_val
    return result

# Clone few-shot gpt-oss:20b-minimal 1 nfr3
import random
from typing import List, Dict


def task_func(LETTERS: List[str]) ->Dict[str, float]:
    result: Dict[str, float] = {}
    for letter in LETTERS:
        count = random.randint(1, 10)
        nums = [random.randint(0, 100) for _ in range(count)]
        result[letter] = sum(nums) / count
    return result

# Clone few-shot gpt-oss:20b-minimal 1 nfr4
import secrets
from typing import List, Dict


def task_func(LETTERS: List[str]) ->Dict[str, float]:
    """
    For each letter in LETTERS, generate a random list of 1 to 10 integers
    (each between 0 and 100 inclusive), compute the mean of that list,
    and return a dictionary mapping each letter to its mean.
    """
    result: Dict[str, float] = {}
    for letter in LETTERS:
        count = secrets.randbelow(10) + 1
        numbers = [secrets.randbelow(101) for _ in range(count)]
        mean_val = sum(numbers) / count
        result[letter] = mean_val
    return result

# Clone few-shot gpt-oss:20b-minimal 1 nfr5
import random
from typing import Dict, List


def task_func(LETTERS: List[str]) ->Dict[str, float]:
    means: Dict[str, float] = {}
    for letter in LETTERS:
        length = random.randint(1, 10)
        numbers = [random.randint(0, 100) for _ in range(length)]
        means[letter] = sum(numbers) / length
    return means

# Clone few-shot gpt-oss:20b-requirements 1 nfr5
import random
from typing import Iterable, Dict


def task_func(LETTERS: Iterable[str]) ->Dict[str, float]:
    """
    Generate a dictionary mapping each letter to the mean of a random list of integers.
    For each letter, a list of random integers (length 1-10, values 0-100) is created.
    The mean of that list is stored as the value. If LETTERS is empty, an empty dict is returned.
    """
    result: Dict[str, float] = {}
    for letter in LETTERS:
        length = random.randint(1, 10)
        numbers = [random.randint(0, 100) for _ in range(length)]
        mean_value = sum(numbers) / length
        result[letter] = mean_value
    return result

# Clone few-shot gpt-oss:20b-uml 1 nfr3
import random
from typing import List, Dict, Union


def task_func(LETTERS: List[str]) ->Dict[str, Union[float, None]]:
    """
    Generate a dictionary mapping each letter in LETTERS to the mean of a
    randomly generated list of integers.

    Each list contains between 1 and 10 integers, each ranging from 0 to 100.
    """
    if not isinstance(LETTERS, list):
        raise TypeError('LETTERS must be a list of single-character strings')
    for letter in LETTERS:
        if not isinstance(letter, str) or len(letter) != 1:
            raise ValueError(
                'Each element in LETTERS must be a single-character string')
    result: Dict[str, Union[float, None]] = {}
    for letter in LETTERS:
        length = random.randint(1, 10)
        numbers = [random.randint(0, 100) for _ in range(length)]
        mean_value = sum(numbers) / length if numbers else None
        result[letter] = mean_value
    return result

# Clone few-shot gpt-oss:20b-uml 1 nfr4
import random
from typing import List, Dict


def task_func(LETTERS: List[str]) ->Dict[str, float]:
    rng = random.SystemRandom()
    result = {}
    for letter in LETTERS:
        count = rng.randint(1, 10)
        numbers = [rng.randint(0, 100) for _ in range(count)]
        mean_val = sum(numbers) / count
        result[letter] = mean_val
    return result

# Clone few-shot gpt-oss:20b-translation 1 nfr3
import random
from typing import List, Dict


def task_func(LETTERS: List[str]) ->Dict[str, float]:
    """
    Generate a dictionary mapping each letter in LETTERS to the mean of a
    randomly generated list of integers.

    Each list contains between 1 and 10 integers, each ranging from 0 to 100.
    """
    result: Dict[str, float] = {}
    for letter in LETTERS:
        size = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(size)]
        mean_value = sum(values) / size
        result[letter] = mean_value
    return result

# Clone few-shot gpt-oss:20b-translation 1 nfr4
import random
from typing import List, Dict


def task_func(LETTERS: List[str]) ->Dict[str, float]:
    """
    Generate a dictionary mapping each letter in LETTERS to the mean of a randomly
    generated list of integers. Each list contains between 1 and 10 integers,
    each ranging from 0 to 100 inclusive.

    Parameters
    ----------
    LETTERS : List[str]
        A list of single-character strings to be used as keys in the output dictionary.

    Returns
    -------
    Dict[str, float]
        A dictionary where each key is a letter from LETTERS and the value is the mean
        of the corresponding random list of integers.
    """
    result: Dict[str, float] = {}
    for letter in LETTERS:
        size = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(size)]
        mean_value = sum(values) / size if size > 0 else 0.0
        result[letter] = mean_value
    return result

# Clone few-shot gpt-oss:20b-translation 1 nfr5
import random
from typing import List, Dict


def task_func(LETTERS: List[str]) ->Dict[str, float]:
    result = {}
    for letter in LETTERS:
        size = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(size)]
        mean_value = sum(values) / size if values else 0.0
        result[letter] = mean_value
    return result

# Clone cot gpt-oss:20b-minimal 1 nfr3
import random
from typing import List, Dict


def task_func(LETTERS: List[str]) ->Dict[str, float]:
    """
    For each letter in LETTERS, generate a random list of 1 to 10 integers
    between 0 and 100 inclusive, compute the mean of the list, and return
    a dictionary mapping each letter to its mean value.
    """
    result: Dict[str, float] = {}
    for letter in LETTERS:
        count = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(count)]
        mean_value = sum(values) / count
        result[letter] = mean_value
    return result

# Clone cot gpt-oss:20b-minimal 1 nfr5
import random
from typing import Dict, List


def task_func(LETTERS: List[str]) ->Dict[str, float]:
    """
    Create a dictionary mapping each letter in LETTERS to the mean of a
    randomly generated list of integers. Each list contains 1 to 10 integers
    between 0 and 100 inclusive.
    """

    def _random_int_list() ->List[int]:
        length = random.randint(1, 10)
        return [random.randint(0, 100) for _ in range(length)]

    def _mean(values: List[int]) ->float:
        return sum(values) / len(values) if values else 0.0
    return {letter: _mean(_random_int_list()) for letter in LETTERS}

# Clone cot gpt-oss:20b-requirements 1 nfr4
import random
from typing import Iterable, Dict


def task_func(LETTERS: Iterable[str]) ->Dict[str, float]:
    result = {}
    for letter in LETTERS:
        length = random.randint(1, 10)
        numbers = [random.randint(0, 100) for _ in range(length)]
        mean_value = sum(numbers) / length
        result[letter] = mean_value
    return result

# Clone cot gpt-oss:20b-uml 1 nfr4
import random
from typing import Dict, List


def task_func(LETTERS: List[str]) ->Dict[str, float]:
    result = {}
    for letter in LETTERS:
        length = random.randint(1, 10)
        numbers = [random.randint(0, 100) for _ in range(length)]
        mean_value = sum(numbers) / length
        result[letter] = mean_value
    return result

# Clone cot gpt-oss:20b-uml 1 nfr5
import random
from typing import List, Dict


def task_func(LETTERS: List[str]) ->Dict[str, float]:
    """
    Generate a dictionary mapping each letter in LETTERS to the mean of a
    randomly generated list of integers. Each list contains between 1 and
    10 integers, each ranging from 0 to 100 inclusive.
    """
    result: Dict[str, float] = {}
    for letter in LETTERS:
        count = random.randint(1, 10)
        numbers = [random.randint(0, 100) for _ in range(count)]
        mean_value = sum(numbers) / count
        result[letter] = mean_value
    return result

# Clone cot gpt-oss:20b-translation 1 nfr3
import random
from typing import Dict, List


def task_func(LETTERS: List[str]) ->Dict[str, float]:
    """
    For each letter in LETTERS, generate a random list of 1–10 integers (0–100 inclusive)
    and compute the mean of that list. Return a dictionary mapping each letter to its mean.
    """
    result: Dict[str, float] = {}
    for letter in LETTERS:
        size = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(size)]
        mean = sum(values) / size if size else 0.0
        result[letter] = mean
    return result

# Clone cot gpt-oss:20b-translation 1 nfr4
import random
from typing import List, Dict


def task_func(letters: List[str]) ->Dict[str, float]:
    result: Dict[str, float] = {}
    for letter in letters:
        size = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(size)]
        mean_value = sum(values) / size if size else 0.0
        result[letter] = mean_value
    return result

