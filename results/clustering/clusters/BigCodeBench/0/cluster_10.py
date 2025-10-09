# Clone few-shot gpt-oss:20b-complete 1 nfr4
import itertools
import random


def task_func(numbers=list(range(1, 11))):
    if len(numbers) <= 1:
        return 0.0
    perms = list(itertools.permutations(numbers))
    total_diff_sum = 0.0
    for perm in perms:
        perm_list = list(perm)
        random.shuffle(perm_list)
        diff_sum = sum(abs(perm_list[i] - perm_list[i + 1]) for i in range(
            len(perm_list) - 1))
        total_diff_sum += diff_sum
    return total_diff_sum / len(perms)

