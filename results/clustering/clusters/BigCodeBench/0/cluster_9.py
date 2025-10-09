# Clone zero-shot gpt-oss:latest-minimal 1 nfr3
def task_func(numbers=None):
    if numbers is None:
        numbers = list(range(1, 11))
    n = len(numbers)
    if n <= 1:
        return 0.0
    sorted_nums = sorted(numbers)
    total = 0
    for idx, val in enumerate(sorted_nums):
        total += val * (2 * idx - n + 1)
    average_sum = 2.0 / n * total
    return float(average_sum)


print(task_func())

# Clone few-shot gpt-oss:latest-ast 1 nfr3
def task_func(numbers=None):
    if numbers is None:
        numbers = list(range(1, 11))
    n = len(numbers)
    if n <= 1:
        return 0.0
    total = 0
    for i in range(n):
        ai = numbers[i]
        for j in range(i + 1, n):
            total += abs(ai - numbers[j])
    return 2.0 / n * total


print(task_func())

# Clone cot gpt-oss:latest-minimal 1 nfr0
def task_func(numbers=None):
    if numbers is None:
        numbers = list(range(1, 11))
    n = len(numbers)
    if n <= 1:
        return 0.0
    total = 0
    for i in range(n):
        for j in range(i + 1, n):
            total += abs(numbers[i] - numbers[j])
    return 2 * total / n


print(task_func())

# Clone few-shot gpt-oss:20b-minimal 1 nfr0
def task_func(numbers=None):
    if numbers is None:
        numbers = list(range(1, 11))
    n = len(numbers)
    if n <= 1:
        return 0.0
    total_diff = 0
    for i in range(n):
        ai = numbers[i]
        for j in range(i + 1, n):
            total_diff += abs(ai - numbers[j])
    return 2.0 / n * total_diff

# Clone few-shot gpt-oss:20b-minimal 1 nfr1
def task_func(numbers=None):
    if numbers is None:
        numbers = list(range(1, 11))
    n = len(numbers)
    if n <= 1:
        return 0.0
    total_abs_diff = 0
    for i in range(n):
        for j in range(i + 1, n):
            total_abs_diff += abs(numbers[i] - numbers[j])
    return 2.0 * total_abs_diff / n

# Clone few-shot gpt-oss:20b-minimal 1 nfr3
def task_func(numbers: list=None) ->float:
    if numbers is None:
        numbers = list(range(1, 11))
    n = len(numbers)
    if n <= 1:
        return 0.0
    total_abs_diff = 0
    for i, a in enumerate(numbers):
        for b in numbers[i + 1:]:
            total_abs_diff += abs(a - b)
    return 2.0 / n * total_abs_diff

# Clone cot gpt-oss:20b-minimal 1 nfr4
def task_func(numbers=None):
    """
    Calculates the average of the sums of absolute differences between each pair
    of consecutive numbers for all permutations of a given list.

    Parameters
    ----------
    numbers : list, optional
        A list of numbers. If None, defaults to numbers from 1 to 10.

    Returns
    -------
    float
        The average of the sums of absolute differences for each shuffled permutation
        of the list.
    """
    if numbers is None:
        numbers = list(range(1, 11))
    n = len(numbers)
    if n <= 1:
        return 0.0
    pair_sum = 0
    for i in range(n):
        ai = numbers[i]
        for j in range(i + 1, n):
            pair_sum += abs(ai - numbers[j])
    return float(2 * pair_sum / n)

