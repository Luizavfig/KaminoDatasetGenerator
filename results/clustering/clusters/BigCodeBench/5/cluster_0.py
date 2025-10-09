# Clone zero-shot llama3.1:latest-requirements 1 nfr0
import random
import math


def task_func(LETTERS=['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
    'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x',
    'y', 'z']):
    result = {}
    for letter in LETTERS:
        length = random.randint(1, 10)
        numbers = [random.randint(-1000, 1000) for _ in range(length)]
        std_dev = math.sqrt(sum((x - sum(numbers) / length) ** 2 for x in
            numbers) / length)
        result[letter] = std_dev
    return result

# Clone zero-shot llama3.1:latest-requirements 1 nfr1
import random
import math


def task_func(LETTERS=['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
    'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x',
    'y', 'z']):
    result = {}
    for letter in LETTERS:
        length = random.randint(1, 10)
        numbers = [random.randint(-1000, 1000) for _ in range(length)]
        mean = sum(numbers) / len(numbers)
        variance = sum((x - mean) ** 2 for x in numbers) / len(numbers)
        std_dev = math.sqrt(variance)
        result[letter] = std_dev
    return result

# Clone zero-shot llama3.1:latest-requirements 1 nfr4
import random
import math


def task_func(LETTERS=['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
    'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x',
    'y', 'z']):
    result = {}
    for letter in LETTERS:
        random_numbers = [random.randint(0, 100) for _ in range(random.
            randint(1, 10))]
        std_dev = math.sqrt(sum((x - sum(random_numbers) / len(
            random_numbers)) ** 2 for x in random_numbers) / len(
            random_numbers))
        result[letter] = std_dev
    return result

# Clone zero-shot deepseek-r1-minimal 1 nfr1
import random
import math
LETTERS = ['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
    'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z']


def task_func(letters=LETTERS):
    letter_dict = {}
    for letter in letters:
        num_list = [random.randint(0, 100) for _ in range(random.randint(1,
            10))]
        mean = sum(num_list) / len(num_list)
        variance = sum((x - mean) ** 2 for x in num_list) / len(num_list)
        std_dev = math.sqrt(variance)
        letter_dict[letter] = std_dev
    return letter_dict

# Clone zero-shot deepseek-r1-minimal 1 nfr5
import random
import math
LETTERS = ['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
    'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z']


def task_func(letters=LETTERS):
    data_dict = {}
    for letter in letters:
        num_integers = random.randint(1, 10)
        integer_list = [random.randint(0, 100) for _ in range(num_integers)]
        data_dict[letter] = integer_list
    std_dev_dict = {}
    for letter, numbers in data_dict.items():
        if len(numbers) < 2:
            std_dev_dict[letter] = 0.0
        else:
            mean = sum(numbers) / len(numbers)
            variance = sum((x - mean) ** 2 for x in numbers) / len(numbers)
            std_dev_dict[letter] = math.sqrt(variance)
    return std_dev_dict

# Clone zero-shot deepseek-r1-requirements 1 nfr0
import random
import math


def task_func(LETTERS=['abcdefghijklmnopqrstuvwxyz']):
    if len(LETTERS) == 1 and isinstance(LETTERS[0], str):
        LETTERS = list(LETTERS[0])
    else:
        LETTERS = [letter for letter in LETTERS]
    alphabet_dict = {}
    for letter in LETTERS:
        n = random.randint(1, 10)
        numbers = [random.randint(1, 100) for _ in range(n)]
        if n == 1:
            sd = 0.0
        else:
            mean = sum(numbers) / n
            variance = sum((x - mean) ** 2 for x in numbers) / n
            sd = math.sqrt(variance)
        alphabet_dict[letter] = sd
    return alphabet_dict

# Clone zero-shot deepseek-r1-requirements 1 nfr3
import random
import math


def task_func(LETTERS=['abcdefghijklmnopqrstuvwxyz']):
    if len(LETTERS) == 1 and LETTERS[0] == 'abcdefghijklmnopqrstuvwxyz':
        letters = ['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k',
            'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x',
            'y', 'z']
    else:
        letters = LETTERS
    result = {}
    for letter in letters:
        n = random.randint(1, 10)
        numbers = [random.randint(1, 100) for _ in range(n)]
        if n == 1:
            sd = 0.0
        else:
            mean = sum(numbers) / n
            variance = sum((x - mean) ** 2 for x in numbers) / n
            sd = math.sqrt(variance)
        result[letter] = sd
    return result

# Clone zero-shot deepseek-r1-ast 1 nfr0
import random
import math


def task_func(LETTERS=['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
    'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x',
    'y', 'z']):
    random_dict = {}
    for letter in LETTERS:
        num_values = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(num_values)]
        mean = sum(values) / num_values
        variance = sum((x - mean) ** 2 for x in values) / num_values
        std_dev = math.sqrt(variance)
        random_dict[letter] = values
    sd_dict = {}
    for k, v in random_dict.items():
        if len(v) == 0:
            continue
        mean_val = sum(v) / len(v)
        variance_val = sum((x - mean_val) ** 2 for x in v) / len(v)
        sd_dict[k] = math.sqrt(variance_val)
    return sd_dict

# Clone zero-shot deepseek-r1-ast 1 nfr1
import random
import math
LETTERS = ['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
    'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z']


def task_func(letters=LETTERS):
    random_dict = {}
    for k in letters:
        num_list = []
        for _ in range(random.randint(1, 10)):
            num_list.append(random.randint(0, 100))
        random_dict[k] = num_list
    sd_dict = {}
    for k, v in random_dict.items():
        if len(v) == 0:
            sd_dict[k] = 0.0
        else:
            mean = sum(v) / len(v)
            variance = sum((x - mean) ** 2 for x in v) / len(v)
            sd_dict[k] = math.sqrt(variance)
    return sd_dict

# Clone zero-shot deepseek-r1-ast 1 nfr2
import random
import math
LETTERS = ['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
    'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z']


def task_func(letters=LETTERS):
    random_dict = {}
    for k in letters:
        num_elements = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(num_elements)]
        random_dict[k] = values
    sd_dict = {}
    for k, v in random_dict.items():
        n = len(v)
        mean = sum(v) / n
        variance = sum((x - mean) ** 2 for x in v) / n
        sd_dict[k] = math.sqrt(variance)
    return sd_dict

# Clone zero-shot deepseek-r1-ast 1 nfr4
import random
import math


def task_func(LETTERS=['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
    'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x',
    'y', 'z']):
    random_dict = {letter: [] for letter in LETTERS}
    for letter in LETTERS:
        num_elements = random.randint(1, 10)
        for _ in range(num_elements):
            random_dict[letter].append(random.randint(0, 100))
    sd_dict = {}
    for k, v in random_dict.items():
        if len(v) > 0:
            mean = sum(v) / len(v)
            variance = sum((x - mean) ** 2 for x in v) / len(v)
            sd_dict[k] = math.sqrt(variance)
    return sd_dict

# Clone zero-shot llama4:latest-minimal 1 nfr2
import numpy as np
import random


def task_func(LETTERS=['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
    'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x',
    'y', 'z']):
    result = {}
    for letter in LETTERS:
        random_list = [random.randint(0, 100) for _ in range(random.randint
            (1, 10))]
        result[letter] = np.std(random_list, ddof=0)
    return result

# Clone zero-shot llama4:latest-minimal 1 nfr5
import random
import math


def task_func(LETTERS=['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
    'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x',
    'y', 'z']):
    result = {}
    for letter in LETTERS:
        random_integers = [random.randint(0, 100) for _ in range(random.
            randint(1, 10))]
        mean = sum(random_integers) / len(random_integers)
        variance = sum((x - mean) ** 2 for x in random_integers) / len(
            random_integers)
        std_dev = math.sqrt(variance)
        result[letter] = std_dev
    return result

# Clone zero-shot llama4:latest-requirements 1 nfr0
import random
import math


def task_func(LETTERS=['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
    'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x',
    'y', 'z']):
    result = {}
    for letter in LETTERS:
        random_numbers = [random.randint(1, 100) for _ in range(random.
            randint(1, 10))]
        mean = sum(random_numbers) / len(random_numbers)
        variance = sum((x - mean) ** 2 for x in random_numbers) / len(
            random_numbers)
        std_dev = math.sqrt(variance)
        result[letter] = std_dev
    return result


print(task_func())

# Clone zero-shot llama4:latest-requirements 1 nfr1
import random
import math


def task_func(LETTERS=['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
    'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x',
    'y', 'z']):
    result = {}
    for letter in LETTERS:
        random_numbers = [random.randint(1, 100) for _ in range(random.
            randint(1, 10))]
        mean = sum(random_numbers) / len(random_numbers)
        variance = sum((x - mean) ** 2 for x in random_numbers) / len(
            random_numbers)
        std_dev = math.sqrt(variance)
        result[letter] = std_dev
    return result

# Clone zero-shot llama4:latest-requirements 1 nfr3
import random
import math


def task_func(LETTERS=['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
    'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x',
    'y', 'z']):
    result = {}
    for letter in LETTERS:
        numbers = [random.randint(1, 100) for _ in range(random.randint(1, 10))
            ]
        mean = sum(numbers) / len(numbers)
        variance = sum((x - mean) ** 2 for x in numbers) / len(numbers)
        std_dev = math.sqrt(variance)
        result[letter] = std_dev
    return result


print(task_func())

# Clone zero-shot llama4:latest-requirements 1 nfr4
import random
import math


def task_func(LETTERS=['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
    'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x',
    'y', 'z']):
    result = {}
    for letter in LETTERS:
        numbers = [random.randint(1, 100) for _ in range(random.randint(1, 10))
            ]
        mean = sum(numbers) / len(numbers)
        variance = sum((x - mean) ** 2 for x in numbers) / len(numbers)
        std_dev = math.sqrt(variance)
        result[letter] = std_dev
    return result


print(task_func())

# Clone zero-shot llama4:latest-requirements 1 nfr5
import random
import math


def task_func(LETTERS=['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
    'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x',
    'y', 'z']):
    result = {}
    for letter in LETTERS:
        numbers = [random.randint(1, 100) for _ in range(random.randint(1, 10))
            ]
        mean = sum(numbers) / len(numbers)
        variance = sum((x - mean) ** 2 for x in numbers) / len(numbers)
        std_dev = math.sqrt(variance)
        result[letter] = std_dev
    return result

# Clone few-shot llama3.1:latest-requirements 1 nfr0
import random
import math


def task_func(LETTERS=['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
    'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x',
    'y', 'z']):
    result = {}
    for letter in LETTERS:
        length = random.randint(1, 10)
        numbers = [random.randint(-1000, 1000) for _ in range(length)]
        std_dev = math.sqrt(sum((x - sum(numbers) / length) ** 2 for x in
            numbers) / length)
        result[letter] = std_dev
    return result

# Clone few-shot llama3.1:latest-requirements 1 nfr1
import random
import math


def task_func(LETTERS=['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
    'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x',
    'y', 'z']):
    result = {}
    for letter in LETTERS:
        length = random.randint(1, 10)
        numbers = [random.randint(-1000, 1000) for _ in range(length)]
        std_dev = math.sqrt(sum((x - sum(numbers) / length) ** 2 for x in
            numbers) / length)
        result[letter] = std_dev
    return result

# Clone few-shot llama3.1:latest-requirements 1 nfr2
import random
import math


def task_func(LETTERS=['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
    'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x',
    'y', 'z']):
    result = {}
    for letter in LETTERS:
        length = random.randint(1, 10)
        numbers = [random.randint(-1000, 1000) for _ in range(length)]
        std_dev = math.sqrt(sum((x - sum(numbers) / length) ** 2 for x in
            numbers) / length)
        result[letter] = std_dev
    return result

# Clone cot llama3.1:latest-requirements 1 nfr1
import random
import math


def task_func(LETTERS=['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
    'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x',
    'y', 'z']):
    result = {}
    for letter in LETTERS:
        length = random.randint(1, 10)
        numbers = [random.randint(-1000, 1000) for _ in range(length)]
        std_dev = math.sqrt(sum((x - sum(numbers) / length) ** 2 for x in
            numbers) / length)
        result[letter] = std_dev
    return result

# Clone few-shot deepseek-r1-minimal 1 nfr0
import random
import math
LETTERS = ['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
    'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z']


def task_func(letters=LETTERS):
    letter_dict = {}
    for letter in letters:
        num_list = [random.randint(0, 100) for _ in range(random.randint(1,
            10))]
        mean = sum(num_list) / len(num_list)
        variance = sum((x - mean) ** 2 for x in num_list) / len(num_list)
        std_dev = math.sqrt(variance)
        letter_dict[letter] = std_dev
    return letter_dict

# Clone few-shot deepseek-r1-minimal 1 nfr1
import math
import random
LETTERS = ['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
    'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z']


def task_func(letters=LETTERS):
    letter_dict = {}
    for letter in letters:
        num_list = [random.randint(0, 100) for _ in range(random.randint(1,
            10))]
        mean = sum(num_list) / len(num_list)
        variance = sum((x - mean) ** 2 for x in num_list) / len(num_list)
        std_dev = math.sqrt(variance)
        letter_dict[letter] = std_dev
    return letter_dict

# Clone few-shot deepseek-r1-minimal 1 nfr3
import random
import math
LETTERS = ['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
    'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z']


def task_func(letter_list=LETTERS):
    letter_dict = {}
    for letter in letter_list:
        num_integers = random.randint(1, 10)
        numbers = [random.randint(0, 100) for _ in range(num_integers)]
        mean = sum(numbers) / len(numbers)
        variance = sum((x - mean) ** 2 for x in numbers) / len(numbers)
        std_dev = math.sqrt(variance)
        letter_dict[letter] = std_dev
    return letter_dict

# Clone few-shot deepseek-r1-minimal 1 nfr4
import random
import math
LETTERS = ['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
    'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z']


def task_func(letters=LETTERS):
    if not isinstance(letters, list):
        raise TypeError("The 'letters' argument must be a list.")
    for char in letters:
        if not isinstance(char, str) or len(char) != 1:
            raise ValueError(
                "Each element in the 'letters' list must be a single-character string."
                )
    letter_dict = {}
    for letter in letters:
        num_integers = random.randint(1, 10)
        integer_list = [random.randint(0, 100) for _ in range(num_integers)]
        letter_dict[letter] = integer_list
    std_deviations = {}
    for letter, numbers in letter_dict.items():
        if len(numbers) == 0:
            continue
        mean = sum(numbers) / len(numbers)
        variance = sum((x - mean) ** 2 for x in numbers) / len(numbers)
        std_deviations[letter] = math.sqrt(variance)
    return std_deviations

# Clone few-shot deepseek-r1-minimal 1 nfr5
import random
import math
LETTERS = ['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
    'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z']


def task_func(letter_list=LETTERS):
    result_dict = {}
    for letter in letter_list:
        num_integers = random.randint(1, 10)
        integer_list = [random.randint(0, 100) for _ in range(num_integers)]
        mean = sum(integer_list) / len(integer_list)
        variance = sum((x - mean) ** 2 for x in integer_list) / len(
            integer_list)
        std_dev = math.sqrt(variance)
        result_dict[letter] = std_dev
    return result_dict

# Clone few-shot deepseek-r1-requirements 1 nfr0
import random
import math


def task_func(LETTERS=['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
    'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x',
    'y', 'z']):
    sd_dict = {}
    for letter in LETTERS:
        num_samples = random.randint(1, 10)
        data = [random.randint(1, 100) for _ in range(num_samples)]
        if num_samples == 1:
            sd_dict[letter] = 0.0
        else:
            mean = sum(data) / num_samples
            variance = sum((x - mean) ** 2 for x in data) / num_samples
            sd_dict[letter] = math.sqrt(variance)
    return sd_dict

# Clone few-shot deepseek-r1-requirements 1 nfr3
import random
import math


def task_func(LETTERS=['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
    'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x',
    'y', 'z']):
    sd_dict = {}
    for letter in LETTERS:
        n = random.randint(1, 10)
        numbers = [random.randint(0, 100) for _ in range(n)]
        if n == 0:
            sd_dict[letter] = 0.0
        else:
            mean = sum(numbers) / n
            variance = sum((x - mean) ** 2 for x in numbers) / n
            sd_dict[letter] = math.sqrt(variance)
    return sd_dict

# Clone few-shot deepseek-r1-ast 1 nfr1
import random
import math
LETTERS = ['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
    'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z']


def task_func(letters=LETTERS):
    random_dict = {}
    for char in letters:
        num_elements = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(num_elements)]
        mean = sum(values) / num_elements
        variance = sum((x - mean) ** 2 for x in values) / num_elements
        sd = math.sqrt(variance)
        random_dict[char] = sd
    return random_dict

# Clone few-shot deepseek-r1-ast 1 nfr4
import random
import math


def task_func(LETTERS=['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
    'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x',
    'y', 'z']):
    random_dict = {}
    for letter in LETTERS:
        num_elements = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(num_elements)]
        random_dict[letter] = values
    sd_dict = {}
    for letter, values in random_dict.items():
        if len(values) == 0:
            sd_dict[letter] = 0.0
            continue
        mean = sum(values) / len(values)
        variance = sum((x - mean) ** 2 for x in values) / len(values)
        sd_dict[letter] = math.sqrt(variance)
    return sd_dict

# Clone few-shot deepseek-r1-ast 1 nfr5
import random
import math
LETTERS = ['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
    'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z']


def task_func(letters=LETTERS):
    random_dict = {letter: [random.randint(0, 100) for _ in range(random.
        randint(1, 10))] for letter in letters}
    sd_dict = {}
    for k, v in random_dict.items():
        if len(v) == 0:
            sd_dict[k] = 0.0
        else:
            mean = sum(v) / len(v)
            variance = sum((x - mean) ** 2 for x in v) / len(v)
            sd_dict[k] = math.sqrt(variance)
    return sd_dict

# Clone cot deepseek-r1-minimal 1 nfr0
import random
import math
LETTERS = ['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
    'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z']


def task_func(letter_list=LETTERS):
    letter_dict = {}
    for letter in letter_list:
        num_list = [random.randint(0, 100) for _ in range(random.randint(1,
            10))]
        mean = sum(num_list) / len(num_list)
        variance = sum((x - mean) ** 2 for x in num_list) / len(num_list)
        std_dev = math.sqrt(variance)
        letter_dict[letter] = std_dev
    return letter_dict

# Clone cot deepseek-r1-minimal 1 nfr1
import random
import math
LETTERS = ['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
    'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z']


def task_func(letter_list=LETTERS):
    letter_dict = {}
    for letter in letter_list:
        num_list = [random.randint(0, 100) for _ in range(random.randint(1,
            10))]
        mean = sum(num_list) / len(num_list)
        variance = sum((x - mean) ** 2 for x in num_list) / len(num_list)
        std_dev = math.sqrt(variance)
        letter_dict[letter] = std_dev
    return letter_dict

# Clone cot deepseek-r1-minimal 1 nfr3
import random
import math
LETTERS = ['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
    'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z']


def task_func(letter_list=None):
    if letter_list is None:
        letter_list = LETTERS
    else:
        for letter in letter_list:
            if len(letter) != 1 or not isinstance(letter, str):
                raise ValueError(
                    'Each element in LETTERS must be a single-character string.'
                    )
    result = {}
    for letter in letter_list:
        num_integers = random.randint(1, 10)
        numbers = [random.randint(0, 100) for _ in range(num_integers)]
        if num_integers == 0:
            result[letter] = float('nan')
        else:
            mean = sum(numbers) / num_integers
            variance = sum((x - mean) ** 2 for x in numbers) / num_integers
            std_dev = math.sqrt(variance)
            result[letter] = std_dev
    return result

# Clone cot deepseek-r1-minimal 1 nfr5
import random
import math
LETTERS = ['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
    'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z']


def task_func(letter_list=LETTERS):
    result_dict = {letter: [] for letter in letter_list}
    for letter in letter_list:
        num_integers = random.randint(1, 10)
        for _ in range(num_integers):
            result_dict[letter].append(random.randint(0, 100))
    for letter in letter_list:
        n = len(result_dict[letter])
        if n == 0:
            continue
        mean = sum(result_dict[letter]) / n
        variance = sum((x - mean) ** 2 for x in result_dict[letter]) / n
        std_dev = math.sqrt(variance)
        result_dict[letter] = round(std_dev, 2)
    return result_dict

# Clone cot deepseek-r1-ast 1 nfr3
import random
import math


def task_func(LETTERS=['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
    'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x',
    'y', 'z']):
    letter_dict = {letter: [] for letter in LETTERS}
    for letter in letter_dict.keys():
        num_elements = random.randint(1, 10)
        for _ in range(num_elements):
            letter_dict[letter].append(random.randint(0, 100))
    sd_dict = {}
    for letter, values in letter_dict.items():
        if len(values) == 0:
            continue
        mean = sum(values) / len(values)
        variance = sum((x - mean) ** 2 for x in values) / len(values)
        sd_dict[letter] = math.sqrt(variance)
    return sd_dict

# Clone cot deepseek-r1-ast 1 nfr4
import random
import math


def task_func(LETTERS=['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
    'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x',
    'y', 'z']):
    random_dict = {}
    for letter in LETTERS:
        num_elements = random.randint(1, 10)
        random_dict[letter] = [random.randint(0, 100) for _ in range(
            num_elements)]
    sd_dict = {}
    for letter, values in random_dict.items():
        if len(values) < 2:
            sd_dict[letter] = 0.0
        else:
            mean = sum(values) / len(values)
            variance = sum((x - mean) ** 2 for x in values) / len(values)
            sd_dict[letter] = math.sqrt(variance)
    return sd_dict

# Clone cot deepseek-r1-ast 1 nfr5
import random
import math


def task_func(LETTERS=['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
    'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x',
    'y', 'z']):
    random_dict = {}
    for letter in LETTERS:
        num_elements = random.randint(1, 10)
        random_dict[letter] = [random.randint(0, 100) for _ in range(
            num_elements)]
    sd_dict = {}
    for letter, values in random_dict.items():
        if len(values) < 2:
            sd_dict[letter] = 0.0
        else:
            mean = sum(values) / len(values)
            variance = sum((x - mean) ** 2 for x in values) / len(values)
            sd_dict[letter] = math.sqrt(variance)
    return sd_dict

# Clone few-shot llama4:latest-requirements 1 nfr0
import random
import math


def task_func(LETTERS=['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
    'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x',
    'y', 'z']):
    result = {}
    for letter in LETTERS:
        numbers = [random.randint(1, 100) for _ in range(random.randint(1, 10))
            ]
        variance = sum((x - sum(numbers) / len(numbers)) ** 2 for x in numbers
            ) / len(numbers)
        std_dev = math.sqrt(variance)
        result[letter] = std_dev
    return result


print(task_func())

# Clone few-shot llama4:latest-requirements 1 nfr1
import random
import math


def task_func(LETTERS=['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
    'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x',
    'y', 'z']):
    result = {}
    for letter in LETTERS:
        numbers = [random.randint(1, 100) for _ in range(random.randint(1, 10))
            ]
        variance = sum((x - sum(numbers) / len(numbers)) ** 2 for x in numbers
            ) / len(numbers)
        std_dev = math.sqrt(variance)
        result[letter] = std_dev
    return result

# Clone few-shot llama4:latest-requirements 1 nfr3
import random
import math


def task_func(LETTERS=['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
    'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x',
    'y', 'z']):
    result = {}
    for letter in LETTERS:
        random_numbers = [random.randint(1, 100) for _ in range(random.
            randint(1, 10))]
        variance = sum((x - sum(random_numbers) / len(random_numbers)) ** 2 for
            x in random_numbers) / len(random_numbers)
        std_dev = math.sqrt(variance)
        result[letter] = std_dev
    return result


print(task_func())

# Clone few-shot llama4:latest-requirements 1 nfr4
import random
import math


def task_func(LETTERS=['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
    'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x',
    'y', 'z']):
    result = {}
    for letter in LETTERS:
        numbers = [random.randint(1, 100) for _ in range(random.randint(1, 10))
            ]
        variance = sum((x - sum(numbers) / len(numbers)) ** 2 for x in numbers
            ) / len(numbers)
        std_dev = math.sqrt(variance)
        result[letter] = std_dev
    return result


print(task_func())

# Clone few-shot llama4:latest-requirements 1 nfr5
import random
import math


def task_func(LETTERS=['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
    'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x',
    'y', 'z']):
    result = {}
    for letter in LETTERS:
        numbers = [random.randint(1, 100) for _ in range(random.randint(1, 10))
            ]
        variance = sum((x - sum(numbers) / len(numbers)) ** 2 for x in numbers
            ) / len(numbers)
        std_dev = math.sqrt(variance)
        result[letter] = std_dev
    return result

# Clone cot llama4:latest-requirements 1 nfr0
import random
import math


def task_func(LETTERS=['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
    'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x',
    'y', 'z']):
    result = {}
    for letter in LETTERS:
        numbers = [random.randint(1, 100) for _ in range(random.randint(1, 10))
            ]
        variance = sum((x - sum(numbers) / len(numbers)) ** 2 for x in numbers
            ) / len(numbers)
        std_dev = math.sqrt(variance)
        result[letter] = std_dev
    return result


print(task_func())

# Clone cot llama4:latest-requirements 1 nfr1
import random
import math


def task_func(LETTERS=['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
    'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x',
    'y', 'z']):
    result = {}
    for letter in LETTERS:
        numbers = [random.randint(1, 100) for _ in range(random.randint(1, 10))
            ]
        variance = sum((x - sum(numbers) / len(numbers)) ** 2 for x in numbers
            ) / len(numbers)
        std_dev = math.sqrt(variance)
        result[letter] = std_dev
    return result

# Clone cot llama4:latest-requirements 1 nfr3
import random
import math


def task_func(LETTERS=['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
    'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x',
    'y', 'z']):
    result = {}
    for letter in LETTERS:
        numbers = [random.randint(1, 100) for _ in range(random.randint(1, 10))
            ]
        variance = sum((x - sum(numbers) / len(numbers)) ** 2 for x in numbers
            ) / len(numbers)
        std_dev = math.sqrt(variance)
        result[letter] = std_dev
    return result


print(task_func())

# Clone cot llama4:latest-requirements 1 nfr4
import random
import math


def task_func(LETTERS=['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
    'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x',
    'y', 'z']):
    result = {}
    for letter in LETTERS:
        numbers = [random.randint(1, 100) for _ in range(random.randint(1, 10))
            ]
        variance = sum((x - sum(numbers) / len(numbers)) ** 2 for x in numbers
            ) / len(numbers)
        std_dev = math.sqrt(variance)
        result[letter] = std_dev
    return result


print(task_func())

# Clone cot llama4:latest-requirements 1 nfr5
import random
import math


def task_func(LETTERS=['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
    'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x',
    'y', 'z']):
    result = {}
    for letter in LETTERS:
        numbers = [random.randint(1, 100) for _ in range(random.randint(1, 10))
            ]
        variance = sum((x - sum(numbers) / len(numbers)) ** 2 for x in numbers
            ) / len(numbers)
        std_dev = math.sqrt(variance)
        result[letter] = std_dev
    return result

# Clone cot llama4:latest-ast 1 nfr2
import numpy as np
import random


def task_func(LETTERS=['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
    'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x',
    'y', 'z']):
    random_dict = {k: [random.randint(0, 100) for _ in range(random.randint
        (1, 10))] for k in LETTERS}
    sd_dict = {k: np.std(v) for k, v in random_dict.items()}
    return sd_dict

# Clone zero-shot gemma3:latest-translation 1 nfr3
import random
import math


def task_func(letters=['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
    'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x',
    'y', 'z']):
    sd_dict = {}
    for letter in letters:
        random_list = [random.randint(1, 101) for _ in range(random.randint
            (1, 11))]
        sum_val = sum(random_list)
        mean = sum_val / len(random_list)
        squared_differences = [((x - mean) ** 2) for x in random_list]
        variance = sum(squared_differences) / len(random_list)
        sd = math.sqrt(variance)
        sd_dict[letter] = sd
    return sd_dict

# Clone few-shot gemma3:latest-requirements 1 nfr1
import random
import math


def task_func(LETTERS=['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
    'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x',
    'y', 'z']):
    result = {}
    for letter in LETTERS:
        random_list = []
        for _ in range(random.randint(1, 10)):
            random_list.append(random.randint(1, 100))
        result[letter] = math.sqrt(sum([((x - sum(random_list) / len(
            random_list)) ** 2) for x in random_list]) / len(random_list))
    return result

# Clone few-shot gemma3:latest-requirements 1 nfr2
import random
import math


def task_func(LETTERS=['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
    'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x',
    'y', 'z']):
    """
    Generates a dictionary where each key corresponds to a letter from the input list
    and each value is the population standard deviation of a list of random integers
    associated with that key.
    """
    result = {}
    for letter in LETTERS:
        num_list = []
        for _ in range(random.randint(1, 10)):
            num_list.append(random.randint(1, 100))
        std_dev = math.sqrt(sum([((x - sum(num_list) / len(num_list)) ** 2) for
            x in num_list]) / len(num_list))
        result[letter] = std_dev
    return result

# Clone few-shot gemma3:latest-translation 1 nfr4
import random
import math


def task_func(letters=['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
    'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x',
    'y', 'z']):
    sd_dict = {}
    for letter in letters:
        list_of_integers = []
        size = random.randint(1, 11)
        for _ in range(size):
            list_of_integers.append(random.randint(0, 100))
        mean = sum(list_of_integers) / len(list_of_integers)
        squared_differences = [((x - mean) ** 2) for x in list_of_integers]
        variance = sum(squared_differences) / len(list_of_integers)
        sd = math.sqrt(variance)
        sd_dict[letter] = sd_dict[letter] = sd_dict[letter] = sd
    return sd_dict

# Clone few-shot gemma3:latest-translation 1 nfr5
import random
import math


def task_func(letters=['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
    'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x',
    'y', 'z']):
    sdDict = {}
    for letter in letters:
        list_of_integers = []
        size = random.randint(1, 11)
        for _ in range(size):
            list_of_integers.append(random.randint(0, 100))
        mean = sum(list_of_integers) / len(list_of_integers)
        squared_differences = [((x - mean) ** 2) for x in list_of_integers]
        variance = sum(squared_differences) / len(list_of_integers)
        sd = math.sqrt(variance)
        sdDict[letter] = sdDict[letter] = sd
    return sdDict

# Clone cot gemma3:latest-translation 1 nfr0
import random
import math


def task_func(letters=['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
    'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x',
    'y', 'z']):
    sdDict = {}
    for letter in letters:
        list_of_integers = [random.randint(0, 100) for _ in range(random.
            randint(1, 10))]
        mean = sum(list_of_integers) / len(list_of_integers)
        squared_differences = [((x - mean) ** 2) for x in list_of_integers]
        variance = sum(squared_differences) / len(list_of_integers)
        sd = math.sqrt(variance)
        sdDict[letter] = sd
    return sdDict

# Clone cot gemma3:latest-translation 1 nfr1
import random
import math


def task_func(letters=['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
    'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x',
    'y', 'z']):
    sdDict = {}
    for letter in letters:
        list_of_integers = [random.randint(0, 100) for _ in range(random.
            randint(1, 10))]
        mean = sum(list_of_integers) / len(list_of_integers)
        sd = math.sqrt(sum([((x - mean) ** 2) for x in list_of_integers]) /
            len(list_of_integers))
        sdDict[letter] = sd
    return sdDict

