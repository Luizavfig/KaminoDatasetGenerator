# Clone few-shot gpt-oss:latest-translation 1 nfr2
import random
import string
from collections import Counter
from typing import Dict


def task_func(length: int=100) ->Dict[str, int]:
    if length < 0:
        raise ValueError('length must be non-negative')
    chars = random.choices(string.ascii_letters, k=length)
    return dict(Counter(chars))


print(task_func(100))

# Clone cot gpt-oss:latest-translation 1 nfr2
import random
import string
from collections import Counter


def task_func(length: int=100):
    if length < 0:
        raise ValueError('length must be non-negative')
    random_chars = random.choices(string.ascii_letters, k=length)
    return dict(Counter(random_chars))


print(task_func())

# Clone few-shot gpt-oss:20b-translation 1 nfr2
import random
import string
from collections import Counter
from typing import Dict


def task_func(length: int=100) ->Dict[str, int]:
    """
    Generate a random string of the specified length composed of uppercase and
    lowercase English letters, then return a dictionary mapping each character
    to its frequency in the string.

    Parameters
    ----------
    length : int, optional
        Number of characters to generate. Must be non-negative.
        Default is 100.

    Returns
    -------
    Dict[str, int]
        Dictionary where keys are characters from the generated string and
        values are the counts of those characters.

    Raises
    ------
    ValueError
        If length is negative.
    """
    if length < 0:
        raise ValueError('length must be non-negative')
    chars = [random.choice(string.ascii_letters) for _ in range(length)]
    return dict(Counter(chars))

# Clone few-shot gpt-oss:20b-translation 1 nfr3
import random
from collections import Counter


def task_func(length: int=100) ->dict:
    if length < 0:
        raise ValueError('length must be non-negative')
    rnd = random.Random()
    chars = [(chr(rnd.randint(0, 25) + ord('A')) if rnd.randint(0, 1) == 0 else
        chr(rnd.randint(0, 25) + ord('a'))) for _ in range(length)]
    return dict(Counter(chars))

# Clone few-shot gpt-oss:20b-translation 1 nfr4
import random
from collections import Counter
from typing import Dict


def task_func(length: int=100) ->Dict[str, int]:
    """
    Generate a random string of the specified length consisting of uppercase
    and lowercase English letters, then return a dictionary mapping each
    character to its frequency count.

    Parameters
    ----------
    length : int, optional
        The number of characters to generate. Must be non-negative.
        Defaults to 100.

    Returns
    -------
    Dict[str, int]
        A dictionary where keys are characters from the generated string
        and values are the corresponding counts.

    Raises
    ------
    ValueError
        If length is negative.
    """
    if length < 0:
        raise ValueError('length must be non-negative')
    rng = random.SystemRandom()
    letters = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz'
    random_string = ''.join(rng.choice(letters) for _ in range(length))
    return dict(Counter(random_string))

# Clone cot gpt-oss:20b-minimal 1 nfr3
import random
import string
from collections import Counter


def task_func(length: int=100) ->dict:
    if not isinstance(length, int) or length < 0:
        raise ValueError('length must be a non-negative integer')
    random_string = ''.join(random.choices(string.ascii_letters, k=length))
    return dict(Counter(random_string))

# Clone cot gpt-oss:20b-translation 1 nfr0
import random
from collections import Counter


def task_func(length: int=100) ->dict:
    if length < 0:
        raise ValueError('length must be non-negative')

    def get_random_character() ->str:
        if random.randint(0, 1) == 0:
            return chr(random.randint(0, 25) + ord('A'))
        else:
            return chr(random.randint(0, 25) + ord('a'))
    random_string = ''.join(get_random_character() for _ in range(length))
    return dict(Counter(random_string))

# Clone cot gpt-oss:20b-translation 1 nfr2
import random
import string
import collections


def task_func(length: int=100) ->dict:
    if length < 0:
        raise ValueError('length must be non-negative')
    chars = string.ascii_letters
    random_string = random.choices(chars, k=length)
    return dict(collections.Counter(random_string))

# Clone cot gpt-oss:20b-translation 1 nfr3
import random
from collections import Counter


def task_func(length: int=100) ->dict:
    if length < 0:
        raise ValueError('length must be non-negative')
    letters = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz'
    random_string = ''.join(random.choice(letters) for _ in range(length))
    return dict(Counter(random_string))

