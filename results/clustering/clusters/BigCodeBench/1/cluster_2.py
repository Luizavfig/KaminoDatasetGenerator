# Clone zero-shot deepseek-r1-translation 1 nfr0
import random


def task_func(length=100):
    if length < 0:
        raise ValueError('Length must be non-negative')
    random_string = []
    for _ in range(length):
        choice = random.randint(0, 1)
        if choice == 0:
            random_string.append(chr(random.randint(65, 90)))
        else:
            random_string.append(chr(random.randint(97, 122)))
    char_counts = {}
    for c in random_string:
        char_counts[c] = char_counts.get(c, 0) + 1
    return char_counts

# Clone zero-shot deepseek-r1-translation 1 nfr1
import random


def task_func(length=100):
    if length < 0:
        raise ValueError()
    random_string = []
    for _ in range(length):
        choice = random.randint(0, 1)
        if choice == 0:
            random_string.append(chr(random.randint(65, 90)))
        else:
            random_string.append(chr(random.randint(97, 122)))
    char_counts = {}
    for c in random_string:
        char_counts[c] = char_counts.get(c, 0) + 1
    return char_counts

# Clone zero-shot llama4:latest-translation 1 nfr1
import random
from typing import Dict


def task_func(length: int=100) ->Dict[str, int]:
    if length < 0:
        raise ValueError()
    random_string = ''.join(get_random_character() for _ in range(length))
    char_counts = {}
    for char in random_string:
        char_counts[char] = char_counts.get(char, 0) + 1
    return char_counts


def get_random_character() ->str:
    choice = random.randint(0, 1)
    if choice == 0:
        return chr(random.randint(0, 25) + ord('A'))
    else:
        return chr(random.randint(0, 25) + ord('a'))


print(task_func())

# Clone few-shot deepseek-r1-translation 1 nfr3
import random


def task_func(length=100):
    if length < 0:
        raise ValueError()
    random_string = []
    for _ in range(length):
        choice = random.randint(0, 1)
        if choice == 0:
            char = chr(random.randint(65, 90))
        else:
            char = chr(random.randint(97, 122))
        random_string.append(char)
    char_counts = {}
    for c in random_string:
        char_counts[c] = char_counts.get(c, 0) + 1
    return char_counts

# Clone zero-shot gpt-oss:latest-translation 1 nfr1
import random


def task_func(length=100):
    if length < 0:
        raise ValueError
    random_string = []
    for _ in range(length):
        if random.randint(0, 1) == 0:
            random_string.append(chr(random.randint(0, 25) + ord('A')))
        else:
            random_string.append(chr(random.randint(0, 25) + ord('a')))
    char_counts = {}
    for c in random_string:
        char_counts[c] = char_counts.get(c, 0) + 1
    return char_counts


print(task_func())

# Clone zero-shot gpt-oss:latest-translation 1 nfr3
import random


def task_func(length: int=100):
    if length < 0:
        raise ValueError('length must be non-negative')
    counts = {}
    for _ in range(length):
        if random.randint(0, 1) == 0:
            ch = chr(random.randint(0, 25) + ord('A'))
        else:
            ch = chr(random.randint(0, 25) + ord('a'))
        counts[ch] = counts.get(ch, 0) + 1
    return counts


print(task_func())

# Clone zero-shot gpt-oss:latest-translation 1 nfr4
import random


def task_func(length: int=100):
    if length < 0:
        raise ValueError('length must be non-negative')
    random_string = []
    for _ in range(length):
        if random.randint(0, 1) == 0:
            random_string.append(chr(random.randint(0, 25) + ord('A')))
        else:
            random_string.append(chr(random.randint(0, 25) + ord('a')))
    char_counts = {}
    for c in random_string:
        char_counts[c] = char_counts.get(c, 0) + 1
    return char_counts


print(task_func())

# Clone zero-shot gpt-oss:latest-translation 1 nfr5
import random


def task_func(length: int=100):
    if length < 0:
        raise ValueError('length must be non-negative')
    random_string = []
    for _ in range(length):
        if random.randint(0, 1) == 0:
            random_string.append(chr(random.randint(0, 25) + ord('A')))
        else:
            random_string.append(chr(random.randint(0, 25) + ord('a')))
    char_counts = {}
    for c in random_string:
        char_counts[c] = char_counts.get(c, 0) + 1
    return char_counts


print(task_func())

# Clone few-shot gpt-oss:latest-translation 1 nfr0
import random


def task_func(length=100):
    if length < 0:
        raise ValueError('length must be non-negative')
    rng = random.Random()
    chars = []
    for _ in range(length):
        if rng.randint(0, 1) == 0:
            chars.append(chr(rng.randint(0, 25) + ord('A')))
        else:
            chars.append(chr(rng.randint(0, 25) + ord('a')))
    counts = {}
    for c in chars:
        counts[c] = counts.get(c, 0) + 1
    return counts


print(task_func())

# Clone few-shot gpt-oss:latest-translation 1 nfr3
import random
from collections import Counter


def task_func(length: int=100) ->dict:
    if length < 0:
        raise ValueError('length must be non-negative')
    chars = []
    for _ in range(length):
        if random.randint(0, 1) == 0:
            chars.append(chr(random.randint(0, 25) + ord('A')))
        else:
            chars.append(chr(random.randint(0, 25) + ord('a')))
    return dict(Counter(chars))

# Clone few-shot gpt-oss:latest-translation 1 nfr4
import random


def task_func(length: int=100):
    if length < 0:
        raise ValueError('length must be non-negative')
    random_string = []
    for _ in range(length):
        if random.randint(0, 1) == 0:
            random_string.append(chr(random.randint(0, 25) + ord('A')))
        else:
            random_string.append(chr(random.randint(0, 25) + ord('a')))
    char_counts = {}
    for c in random_string:
        char_counts[c] = char_counts.get(c, 0) + 1
    return char_counts


print(task_func())

# Clone few-shot gpt-oss:latest-translation 1 nfr5
import random


def task_func(length: int=100):
    if length < 0:
        raise ValueError('length must be non-negative')
    chars = []
    for _ in range(length):
        if random.randint(0, 1) == 0:
            chars.append(chr(random.randint(ord('A'), ord('Z'))))
        else:
            chars.append(chr(random.randint(ord('a'), ord('z'))))
    counts = {}
    for c in chars:
        counts[c] = counts.get(c, 0) + 1
    return counts


print(task_func())

# Clone cot gpt-oss:latest-translation 1 nfr0
import random


def task_func(length: int=100):
    if length < 0:
        raise ValueError('length must be non-negative')
    rng = random.Random()
    chars = []
    for _ in range(length):
        if rng.randint(0, 1) == 0:
            chars.append(chr(rng.randint(ord('A'), ord('Z'))))
        else:
            chars.append(chr(rng.randint(ord('a'), ord('z'))))
    counts = {}
    for c in chars:
        counts[c] = counts.get(c, 0) + 1
    return counts


print(task_func())

# Clone cot gpt-oss:latest-translation 1 nfr1
import random


def task_func(length=100):
    if length < 0:
        raise ValueError('length must be non-negative')
    chars = []
    for _ in range(length):
        if random.randint(0, 1) == 0:
            chars.append(chr(random.randint(0, 25) + ord('A')))
        else:
            chars.append(chr(random.randint(0, 25) + ord('a')))
    counts = {}
    for c in chars:
        counts[c] = counts.get(c, 0) + 1
    return counts


print(task_func())

# Clone cot gpt-oss:latest-translation 1 nfr4
import random


def task_func(length: int=100) ->dict:
    if length < 0:
        raise ValueError('length must be non-negative')
    rng = random.SystemRandom()
    chars = []
    for _ in range(length):
        if rng.randint(0, 1) == 0:
            chars.append(chr(rng.randint(0, 25) + ord('A')))
        else:
            chars.append(chr(rng.randint(0, 25) + ord('a')))
    counts = {}
    for c in chars:
        counts[c] = counts.get(c, 0) + 1
    return counts


print(task_func())

# Clone zero-shot gpt-oss:20b-translation 1 nfr0
import random


def task_func(length=100):
    if length < 0:
        raise ValueError('length must be non-negative')
    random_gen = random.Random()
    chars = []
    for _ in range(length):
        if random_gen.randint(0, 1) == 0:
            chars.append(chr(random_gen.randint(0, 25) + ord('A')))
        else:
            chars.append(chr(random_gen.randint(0, 25) + ord('a')))
    char_counts = {}
    for c in chars:
        char_counts[c] = char_counts.get(c, 0) + 1
    return char_counts

# Clone zero-shot gpt-oss:20b-translation 1 nfr1
import random


def task_func(length: int=100) ->dict:
    if length < 0:
        raise ValueError('length must be non-negative')
    chars = []
    for _ in range(length):
        if random.randint(0, 1) == 0:
            chars.append(chr(random.randint(0, 25) + ord('A')))
        else:
            chars.append(chr(random.randint(0, 25) + ord('a')))
    counts = {}
    for c in chars:
        counts[c] = counts.get(c, 0) + 1
    return counts

# Clone zero-shot gpt-oss:20b-translation 1 nfr3
import random
from collections import Counter


def task_func(length: int=100) ->dict:
    if length < 0:
        raise ValueError('length must be non-negative')
    chars = []
    for _ in range(length):
        if random.randint(0, 1) == 0:
            chars.append(chr(random.randint(0, 25) + ord('A')))
        else:
            chars.append(chr(random.randint(0, 25) + ord('a')))
    return dict(Counter(chars))

# Clone zero-shot gpt-oss:20b-translation 1 nfr4
import random
from collections import Counter


def task_func(length: int=100) ->dict:
    if length < 0:
        raise ValueError('length must be non-negative')
    chars = []
    for _ in range(length):
        if random.randint(0, 1) == 0:
            chars.append(chr(random.randint(0, 25) + ord('A')))
        else:
            chars.append(chr(random.randint(0, 25) + ord('a')))
    return dict(Counter(chars))

# Clone zero-shot gpt-oss:20b-translation 1 nfr5
import random
from collections import Counter


def task_func(length: int=100) ->dict:
    if length < 0:
        raise ValueError('length must be non-negative')
    chars = []
    for _ in range(length):
        if random.randint(0, 1) == 0:
            chars.append(chr(random.randint(0, 25) + ord('A')))
        else:
            chars.append(chr(random.randint(0, 25) + ord('a')))
    return dict(Counter(chars))

# Clone few-shot gpt-oss:20b-translation 1 nfr0
import random


def task_func(length: int=100):
    if length < 0:
        raise ValueError('length must be non-negative')
    random_string = []
    for _ in range(length):
        if random.randint(0, 1) == 0:
            random_string.append(chr(random.randint(0, 25) + ord('A')))
        else:
            random_string.append(chr(random.randint(0, 25) + ord('a')))
    char_counts = {}
    for c in random_string:
        char_counts[c] = char_counts.get(c, 0) + 1
    return char_counts

# Clone few-shot gpt-oss:20b-translation 1 nfr5
import random
from collections import Counter


def task_func(length: int=100):
    if length < 0:
        raise ValueError('length must be non-negative')
    result = []
    for _ in range(length):
        if random.randint(0, 1) == 0:
            result.append(chr(random.randint(ord('A'), ord('Z'))))
        else:
            result.append(chr(random.randint(ord('a'), ord('z'))))
    return dict(Counter(result))

# Clone cot gpt-oss:20b-translation 1 nfr1
import random


def task_func(length: int=100):
    if length < 0:
        raise ValueError('length must be non-negative')
    chars = []
    for _ in range(length):
        if random.randint(0, 1) == 0:
            chars.append(chr(random.randint(0, 25) + ord('A')))
        else:
            chars.append(chr(random.randint(0, 25) + ord('a')))
    counts = {}
    for c in chars:
        counts[c] = counts.get(c, 0) + 1
    return counts

# Clone cot gpt-oss:20b-translation 1 nfr5
import random
import string
from typing import Dict


def task_func(length: int=100) ->Dict[str, int]:
    """
    Generate a random string of the specified length composed of
    random uppercase and lowercase letters, then count the
    occurrences of each character.

    Parameters
    ----------
    length : int, optional
        The number of characters in the generated string. Must be
        non‑negative. Defaults to 100.

    Returns
    -------
    dict
        A dictionary mapping each character to its frequency in the
        generated string.

    Raises
    ------
    ValueError
        If ``length`` is negative.
    """
    if length < 0:
        raise ValueError('length must be non-negative')
    chars = []
    for _ in range(length):
        if random.getrandbits(1):
            chars.append(chr(random.randint(0, 25) + ord('A')))
        else:
            chars.append(chr(random.randint(0, 25) + ord('a')))
    counts: Dict[str, int] = {}
    for ch in chars:
        counts[ch] = counts.get(ch, 0) + 1
    return counts

