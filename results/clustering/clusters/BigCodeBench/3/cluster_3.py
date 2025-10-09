# Clone few-shot deepseek-r1-ast 1 nfr5
import random


def task_func(letters):
    random_dict = {letter: [random.randint(0, 100) for _ in range(random.
        randint(1, 10))] for letter in letters}
    mean_dict = {}
    for letter, numbers in random_dict.items():
        if len(numbers) > 0:
            mean_dict[letter] = sum(numbers) / len(numbers)
        else:
            mean_dict[letter] = 0
    return mean_dict

# Clone cot deepseek-r1-uml 1 nfr5
import random


def task_func(letters):
    random_dict = {letter: [random.randint(0, 100) for _ in range(random.
        randint(1, 10))] for letter in letters}
    mean_dict = {}
    for letter, num_list in random_dict.items():
        if len(num_list) > 0:
            mean_dict[letter] = sum(num_list) / len(num_list)
        else:
            mean_dict[letter] = 0
    return mean_dict

