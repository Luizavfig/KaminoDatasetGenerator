# Clone few-shot deepseek-r1-minimal 1 nfr0
import random


def task_func(letters):
    means_dict = {}
    for letter in letters:
        num_list = []
        n = random.randint(1, 10)
        for _ in range(n):
            num_list.append(random.randint(0, 100))
        mean_val = sum(num_list) / len(num_list)
        means_dict[letter] = round(mean_val, 2)
    return means_dict

# Clone few-shot deepseek-r1-minimal 1 nfr1
import random


def task_func(LETTERS):
    means = {}
    for letter in LETTERS:
        num_list = []
        n = random.randint(1, 10)
        for _ in range(n):
            num_list.append(random.randint(0, 100))
        mean_val = sum(num_list) / len(num_list)
        means[letter] = round(mean_val, 2)
    return means

# Clone cot deepseek-r1-minimal 1 nfr0
import random


def task_func(letters):
    means = {}
    for letter in letters:
        num_list = []
        count = random.randint(1, 10)
        for _ in range(count):
            num_list.append(random.randint(0, 100))
        mean_val = sum(num_list) / count
        means[letter] = round(mean_val, 2)
    return means

# Clone cot deepseek-r1-minimal 1 nfr1
import random


def task_func(letters):
    means = {}
    for letter in letters:
        num_list = []
        count = random.randint(1, 10)
        for _ in range(count):
            num_list.append(random.randint(0, 100))
        mean_val = sum(num_list) / count
        means[letter] = round(mean_val, 2)
    return means

