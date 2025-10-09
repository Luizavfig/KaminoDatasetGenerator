# Clone cot deepseek-r1-minimal 1 nfr2
import random
import statistics


def task_func(letters=None):
    if letters is None:
        letters = [chr(i + ord('a')) for i in range(26)]
    return {letter: round(statistics.pstdev([random.randint(0, 100) for _ in
        range(random.randint(1, 10))]), 1) for letter in letters}

# Clone cot deepseek-r1-minimal 1 nfr4
import random
import math


def task_func(letters=None):
    if letters is None:
        letters = [chr(i + ord('a')) for i in range(26)]
    for letter in letters:
        if not isinstance(letter, str) or len(letter) != 1:
            raise ValueError(
                'All elements in LETTERS must be single-character strings.')
    data_dict = {letter: [] for letter in letters}
    for letter in letters:
        num_elements = random.randint(1, 10)
        for _ in range(num_elements):
            data_dict[letter].append(random.randint(0, 100))
    result_dict = {}
    for letter, numbers in data_dict.items():
        if len(numbers) == 0:
            continue
        mean = sum(numbers) / len(numbers)
        variance = sum((x - mean) ** 2 for x in numbers) / len(numbers)
        std_dev = math.sqrt(variance)
        result_dict[letter] = std_dev
    return result_dict

