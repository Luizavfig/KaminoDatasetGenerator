# Clone few-shot llama4:latest-requirements 1 nfr2
import random
import math
from typing import Dict, List


def task_func(LETTERS: List[str]=[chr(i) for i in range(ord('a'), ord('z') +
    1)]):
    result: Dict[str, float] = {}
    for letter in LETTERS:
        random_numbers = [random.randint(1, 100) for _ in range(random.
            randint(1, 10))]
        variance = sum((x - sum(random_numbers) / len(random_numbers)) ** 2 for
            x in random_numbers) / len(random_numbers)
        std_dev = math.sqrt(variance)
        result[letter] = std_dev
    return result

# Clone cot llama4:latest-requirements 1 nfr2
import random
import math
from typing import Dict, List


def task_func(LETTERS: List[str]=[chr(i) for i in range(ord('a'), ord('z') +
    1)]):
    result: Dict[str, float] = {}
    for letter in LETTERS:
        random_numbers = [random.randint(1, 100) for _ in range(random.
            randint(1, 10))]
        variance = sum((x - sum(random_numbers) / len(random_numbers)) ** 2 for
            x in random_numbers) / len(random_numbers)
        std_dev = math.sqrt(variance)
        result[letter] = std_dev
    return result

