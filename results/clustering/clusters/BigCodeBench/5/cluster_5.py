# Clone cot llama3.1:latest-requirements 1 nfr2
import random
import math
from string import ascii_lowercase


def task_func(LETTERS=ascii_lowercase):
    result = {}
    for letter in LETTERS:
        length = random.randint(1, 10)
        numbers = [random.randint(-1000, 1000) for _ in range(length)]
        std_dev = math.sqrt(sum((x - sum(numbers) / length) ** 2 for x in
            numbers) / length)
        result[letter] = std_dev
    return result

