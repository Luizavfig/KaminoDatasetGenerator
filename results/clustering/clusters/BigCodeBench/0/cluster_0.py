# Clone few-shot llama3.1:latest-minimal 1 nfr0
import itertools
import numpy as np


def task_func(numbers=[1, 2, 3, 4, 5, 6, 7, 8, 9, 10]):
    total_sum = 0
    for permutation in itertools.permutations(numbers):
        shuffled_permutation = np.random.permutation(permutation)
        current_sum = 0
        for i in range(len(shuffled_permutation) - 1):
            current_sum += abs(shuffled_permutation[i] -
                shuffled_permutation[i + 1])
        total_sum += current_sum
    return total_sum / len(list(itertools.permutations(numbers)))

# Clone few-shot llama3.1:latest-minimal 1 nfr3
import itertools
import numpy as np


def task_func(numbers=[1, 2, 3, 4, 5, 6, 7, 8, 9, 10]):
    total_sum = 0
    for permutation in itertools.permutations(numbers):
        shuffled_permutation = np.random.permutation(permutation)
        current_sum = 0
        for i in range(len(shuffled_permutation) - 1):
            current_sum += abs(shuffled_permutation[i] -
                shuffled_permutation[i + 1])
        total_sum += current_sum
    return total_sum / len(list(itertools.permutations(numbers)))

# Clone few-shot llama3.1:latest-minimal 1 nfr5
import itertools
import numpy as np


def task_func(numbers=[1, 2, 3, 4, 5, 6, 7, 8, 9, 10]):
    total_sum = 0
    for permutation in itertools.permutations(numbers):
        shuffled_permutation = np.random.permutation(permutation)
        current_sum = 0
        for i in range(len(shuffled_permutation) - 1):
            current_sum += abs(shuffled_permutation[i] -
                shuffled_permutation[i + 1])
        total_sum += current_sum
    return total_sum / len(list(itertools.permutations(numbers)))

# Clone cot llama3.1:latest-minimal 1 nfr3
import itertools
import numpy as np


def task_func(numbers=[1, 2, 3, 4, 5, 6, 7, 8, 9, 10]):
    total_sum = 0
    for perm in itertools.permutations(numbers):
        shuffled_perm = np.random.permutation(perm)
        total_sum += sum(abs(shuffled_perm[i] - shuffled_perm[i - 1]) for i in
            range(1, len(shuffled_perm)))
    return total_sum / len(list(itertools.permutations(numbers)))

# Clone cot deepseek-r1-ast 1 nfr0
import random
from itertools import permutations


def task_func(numbers=[1, 2, 3, 4, 5, 6, 7, 8, 9, 10]):
    total = 0.0
    n = len(numbers)
    for perm in permutations(numbers):
        shuffled_perm = list(perm)
        random.shuffle(shuffled_perm)
        diffs = [abs(shuffled_perm[i] - shuffled_perm[i + 1]) for i in
            range(n - 1)]
        total += sum(diffs)
    return total / len(list(permutations(numbers)))

