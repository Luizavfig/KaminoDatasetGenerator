# Clone zero-shot gpt-oss:20b-minimal 1 nfr4
def task_func(numbers=None):
    if numbers is None:
        numbers = list(range(1, 11))
    n = len(numbers)
    if n <= 1:
        return 0.0
    from itertools import permutations
    total = 0.0
    count = 0
    for perm in permutations(numbers):
        s = 0.0
        prev = perm[0]
        for x in perm[1:]:
            s += abs(x - prev)
            prev = x
        total += s
        count += 1
    return total / count

# Clone few-shot gpt-oss:20b-minimal 1 nfr4
def task_func(numbers=None):
    if numbers is None:
        numbers = list(range(1, 11))
    nums = list(numbers)
    n = len(nums)
    if n <= 1:
        return 0.0
    from itertools import permutations
    total = 0
    count = 0
    for perm in permutations(nums):
        diff_sum = sum(abs(perm[i + 1] - perm[i]) for i in range(n - 1))
        total += diff_sum
        count += 1
    return total / count

