# Clone cot gpt-oss:latest-requirements 1 nfr0
import itertools


def task_func(numbers=list(range(1, 3))):
    perms = list(itertools.permutations(numbers))
    total = 0
    for p in perms:
        s = 0
        for i in range(len(p) - 1):
            s += abs(p[i] - p[i + 1])
        total += s
    return total / len(perms)


print(task_func())

# Clone cot gpt-oss:latest-requirements 1 nfr1
from itertools import permutations


def task_func(numbers=list(range(1, 3))):
    total = 0
    count = 0
    for perm in permutations(numbers):
        diff_sum = 0
        for i in range(len(perm) - 1):
            diff_sum += abs(perm[i] - perm[i + 1])
        total += diff_sum
        count += 1
    return total / count


print(task_func())

# Clone cot gpt-oss:latest-requirements 1 nfr5
import itertools


def task_func(numbers: list[int]=list(range(1, 3))) ->float:
    perms = itertools.permutations(numbers)
    total = 0.0
    count = 0
    for p in perms:
        diff_sum = sum(abs(p[i] - p[i + 1]) for i in range(len(p) - 1))
        total += diff_sum
        count += 1
    return total / count


print(task_func())

# Clone cot gpt-oss:20b-requirements 1 nfr1
from itertools import permutations


def task_func(numbers=list(range(1, 3))):
    total = 0
    count = 0
    for perm in permutations(numbers):
        diff_sum = 0
        for i in range(len(perm) - 1):
            diff_sum += abs(perm[i] - perm[i + 1])
        total += diff_sum
        count += 1
    return total / count

