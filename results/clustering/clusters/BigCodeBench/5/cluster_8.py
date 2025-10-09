# Clone zero-shot deepseek-r1-minimal 1 nfr0
import random
import math


def task_func(LETTERS=None):
    if LETTERS is None:
        LETTERS = [chr(i + ord('a')) for i in range(26)]
    else:
        for letter in LETTERS:
            if len(letter) != 1:
                raise ValueError(
                    'Each element in LETTERS must be a single-character string.'
                    )
    result = {}
    for letter in LETTERS:
        n = random.randint(1, 10)
        numbers = [random.randint(0, 100) for _ in range(n)]
        if n == 0:
            continue
        mean = sum(numbers) / n
        variance = sum((x - mean) ** 2 for x in numbers) / n
        std_dev = math.sqrt(variance)
        result[letter] = round(std_dev, 2)
    return result

# Clone zero-shot deepseek-r1-minimal 1 nfr2
import random
import statistics


def task_func(LETTERS=None):
    if LETTERS is None:
        LETTERS = [chr(i + ord('a')) for i in range(26)]
    else:
        for letter in LETTERS:
            if len(letter) != 1 or not isinstance(letter, str):
                raise ValueError(
                    'LETTERS must be a list of single-character strings')
    result = {}
    for letter in LETTERS:
        num_list = [random.randint(0, 100) for _ in range(random.randint(1,
            10))]
        std_dev = statistics.pstdev(num_list)
        result[letter] = round(std_dev, 2)
    return result

# Clone zero-shot deepseek-r1-minimal 1 nfr3
import random
import math


def task_func(letters=None):
    if letters is None:
        letters = [chr(i + ord('a')) for i in range(26)]
    else:
        letters = list(set(letters))
    result = {}
    for letter in letters:
        n = random.randint(1, 10)
        numbers = [random.randint(0, 100) for _ in range(n)]
        if n == 0:
            continue
        mean = sum(numbers) / n
        variance = sum((x - mean) ** 2 for x in numbers) / n
        std_dev = math.sqrt(variance)
        result[letter] = std_dev
    return result

# Clone zero-shot deepseek-r1-minimal 1 nfr4
import random
import math


def task_func(LETTERS=None):
    if LETTERS is None:
        LETTERS = [chr(i + ord('a')) for i in range(26)]
    else:
        for letter in LETTERS:
            if not isinstance(letter, str) or len(letter) != 1:
                raise ValueError(
                    'LETTERS must be a list of single-character strings')
    result = {}
    for letter in LETTERS:
        num_integers = random.randint(1, 10)
        numbers = [random.randint(0, 100) for _ in range(num_integers)]
        if num_integers == 1:
            std_dev = 0.0
        else:
            mean = sum(numbers) / num_integers
            variance = sum((x - mean) ** 2 for x in numbers) / num_integers
            std_dev = math.sqrt(variance)
        result[letter] = std_dev
    return result


if __name__ == '__main__':
    print(task_func())

