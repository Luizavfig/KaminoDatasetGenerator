# Clone cot gpt-oss:20b-complete 1 nfr3
import random
import statistics


def task_func(LETTERS):
    """
    Create a dictionary mapping each letter in LETTERS to a list of random integers.
    The dictionary is sorted by the mean of each list in descending order.
    """
    data = []
    for letter in LETTERS:
        list_length = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(list_length)]
        data.append((letter, values))
    data.sort(key=lambda item: statistics.mean(item[1]), reverse=True)
    return {letter: values for letter, values in data}

