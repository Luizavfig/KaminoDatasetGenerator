# Clone cot deepseek-r1-requirements 1 nfr3
import random


def task_func(LETTERS):
    return {letter: round(random.uniform(0, 100), 2) for letter in LETTERS}

# Clone cot gpt-oss:20b-requirements 1 nfr1
import random


def task_func(LETTERS):
    if not LETTERS:
        return {}
    return {l: (sum(random.randint(0, 100) for _ in range(random.randint(1,
        10))) / 10) for l in LETTERS}

