# Clone zero-shot gpt-oss:20b-complete 1 nfr0
import math
import random


def task_func(LETTERS=[chr(i) for i in range(97, 123)]):
    sd_dict = {}
    for key in LETTERS:
        count = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(count)]
        mean = sum(values) / count
        variance = sum((x - mean) ** 2 for x in values) / count
        sd_dict[key] = math.sqrt(variance)
    return sd_dict

# Clone zero-shot gpt-oss:20b-complete 1 nfr3
import math
import random


def task_func(letters=[chr(i) for i in range(97, 123)]):
    sd_dict = {}
    for letter in letters:
        size = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(size)]
        mean = sum(values) / size
        variance = sum((x - mean) ** 2 for x in values) / size
        sd_dict[letter] = math.sqrt(variance)
    return sd_dict

# Clone zero-shot gpt-oss:20b-complete 1 nfr4
import math
import random


def task_func(letters=[chr(i) for i in range(97, 123)]):
    """
    Generates a dictionary mapping each letter in `letters` to the population
    standard deviation of a randomly generated list of integers.

    Each list contains a random number of integers (between 1 and 10),
    each integer being randomly chosen between 0 and 100 inclusive.
    """
    result = {}
    for letter in letters:
        size = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(size)]
        mean = sum(values) / size
        variance = sum((x - mean) ** 2 for x in values) / size
        result[letter] = math.sqrt(variance)
    return result

# Clone zero-shot gpt-oss:20b-complete 1 nfr5
import random
import math


def task_func(letters=[chr(i) for i in range(97, 123)]):
    sd_dict = {}
    for letter in letters:
        size = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(size)]
        mean = sum(values) / size
        variance = sum((x - mean) ** 2 for x in values) / size
        sd_dict[letter] = math.sqrt(variance)
    return sd_dict

# Clone few-shot gpt-oss:20b-complete 1 nfr4
import math
import random


def task_func(LETTERS=[chr(i) for i in range(97, 123)]):
    result = {}
    for key in LETTERS:
        count = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(count)]
        mean_val = sum(values) / len(values)
        variance = sum((x - mean_val) ** 2 for x in values) / len(values)
        result[key] = math.sqrt(variance)
    return result

# Clone cot gpt-oss:20b-complete 1 nfr0
import math
import random


def task_func(LETTERS=[chr(i) for i in range(97, 123)]):
    random_dict = {}
    for letter in LETTERS:
        size = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(size)]
        random_dict[letter] = values
    sd_dict = {}
    for letter, values in random_dict.items():
        n = len(values)
        mean = sum(values) / n
        sum_sq = 0.0
        for val in values:
            diff = val - mean
            sum_sq += diff * diff
        sd = math.sqrt(sum_sq / n)
        sd_dict[letter] = sd
    return sd_dict

