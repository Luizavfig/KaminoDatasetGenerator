# Clone zero-shot gpt-oss:latest-ast 1 nfr3
import random
import string


def task_func(length: int=100):
    if length < 0:
        raise ValueError('length must be non-negative')
    letters = string.ascii_letters
    rand_str = ''.join(random.choices(letters, k=length))
    counts = {}
    for ch in rand_str:
        counts[ch] = counts.get(ch, 0) + 1
    return counts


print(task_func())

# Clone few-shot gpt-oss:latest-ast 1 nfr1
import random


def task_func(length=100):
    if length < 0:
        raise ValueError('length must be non-negative')
    letters = 'abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ'
    s = ''.join(random.choice(letters) for _ in range(length))
    counts = {}
    for ch in s:
        counts[ch] = counts.get(ch, 0) + 1
    return counts


print(task_func())

# Clone few-shot gpt-oss:latest-translation 1 nfr1
import random


def task_func(length=100):
    if length < 0:
        raise ValueError('length must be non-negative')
    letters = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz'
    random_string = ''.join(random.choice(letters) for _ in range(length))
    counts = {}
    for ch in random_string:
        counts[ch] = counts.get(ch, 0) + 1
    return counts


print(task_func(100))

# Clone cot gpt-oss:latest-ast 1 nfr5
import random, string, collections


def task_func(length: int=100):
    if length < 0:
        raise ValueError('length must be non-negative')
    letters = string.ascii_letters
    rand_str = ''.join(random.choice(letters) for _ in range(length))
    counts = {}
    for ch in rand_str:
        counts[ch] = counts.get(ch, 0) + 1
    return counts


print(task_func())

# Clone zero-shot gpt-oss:20b-ast 1 nfr0
import random, string


def task_func(length: int=100) ->dict:
    if length < 0:
        raise ValueError('length must be non-negative')
    letters = string.ascii_letters
    rand_str = ''.join(random.choice(letters) for _ in range(length))
    counts = {}
    for ch in rand_str:
        counts[ch] = counts.get(ch, 0) + 1
    return counts

# Clone zero-shot gpt-oss:20b-ast 1 nfr1
import random


def task_func(length: int=100) ->dict:
    if length < 0:
        raise ValueError('length must be non-negative')
    letters = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz'
    rand_str = ''.join(random.choice(letters) for _ in range(length))
    counts = {}
    for ch in rand_str:
        counts[ch] = counts.get(ch, 0) + 1
    return counts

# Clone few-shot gpt-oss:20b-ast 1 nfr0
import random
import string


def task_func(length: int=100):
    if length < 0:
        raise ValueError('length must be non-negative')
    rand_str = ''.join(random.choice(string.ascii_letters) for _ in range(
        length))
    counts = {}
    for ch in rand_str:
        counts[ch] = counts.get(ch, 0) + 1
    return counts

# Clone few-shot gpt-oss:20b-ast 1 nfr1
import random


def task_func(length=100):
    if length < 0:
        raise ValueError('length must be non-negative')
    uppercase = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ'
    lowercase = 'abcdefghijklmnopqrstuvwxyz'
    chars = []
    for _ in range(length):
        if random.random() < 0.5:
            chars.append(random.choice(uppercase))
        else:
            chars.append(random.choice(lowercase))
    random_string = ''.join(chars)
    counts = {}
    for ch in random_string:
        counts[ch] = counts.get(ch, 0) + 1
    return counts

# Clone few-shot gpt-oss:20b-translation 1 nfr1
import random


def task_func(length: int=100) ->dict:
    if length < 0:
        raise ValueError('length must be non-negative')
    random_string = [random.choice(
        'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz') for _ in
        range(length)]
    char_counts = {}
    for char in random_string:
        char_counts[char] = char_counts.get(char, 0) + 1
    return char_counts

# Clone cot gpt-oss:20b-ast 1 nfr1
import random
import string


def task_func(length=100):
    if length < 0:
        raise ValueError('length must be non-negative')
    letters = string.ascii_letters
    rand_chars = random.choices(letters, k=length)
    counts = {}
    for ch in rand_chars:
        counts[ch] = counts.get(ch, 0) + 1
    return counts

# Clone cot gpt-oss:20b-ast 1 nfr3
import random
import string


def task_func(length: int=100):
    if length < 0:
        raise ValueError('length must be non-negative')
    chars = string.ascii_letters
    rnd_str = ''.join(random.choices(chars, k=length))
    counts = {}
    for ch in rnd_str:
        counts[ch] = counts.get(ch, 0) + 1
    return counts

