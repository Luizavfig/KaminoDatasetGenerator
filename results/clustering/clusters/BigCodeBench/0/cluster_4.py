# Clone zero-shot gpt-oss:20b-ast 1 nfr0
def task_func(numbers=None):
    if numbers is None:
        numbers = [i for i in range(1, 11)]
    import itertools
    import random
    import math
    total = 0.0
    n = len(numbers)
    perm_count = math.factorial(n)
    for perm in itertools.permutations(numbers):
        arr = list(perm)
        random.shuffle(arr)
        total += sum(abs(a - b) for a, b in zip(arr, arr[1:]))
    return total / perm_count

