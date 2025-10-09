# Clone zero-shot llama3.1:latest-minimal 1 nfr0
import itertools
import numpy as np


def task_func(numbers=None):
    if numbers is None:
        numbers = list(range(1, 11))
    total_sum = 0
    for perm in itertools.permutations(numbers):
        shuffled_perm = np.random.permutation(perm)
        current_sum = 0
        for i in range(len(shuffled_perm) - 1):
            current_sum += abs(shuffled_perm[i] - shuffled_perm[i + 1])
        total_sum += current_sum
    return total_sum / len(list(itertools.permutations(numbers)))

# Clone zero-shot llama3.1:latest-minimal 1 nfr2
import itertools
import numpy as np


def task_func(numbers=None):
    if numbers is None:
        numbers = list(range(1, 11))

    def calculate_permutations(numbers):
        return [list(p) for p in itertools.permutations(numbers)]

    def calculate_absolute_differences(permutation):
        return sum(abs(permutation[i] - permutation[i - 1]) for i in range(
            1, len(permutation)))
    permutations = calculate_permutations(numbers)
    absolute_differences = [calculate_absolute_differences(p) for p in
        permutations]
    average = np.mean(absolute_differences)
    return float(average)

# Clone zero-shot llama3.1:latest-minimal 1 nfr3
import itertools
import numpy as np


def task_func(numbers=None):
    if numbers is None:
        numbers = list(range(1, 11))
    total_sum = 0
    count = 0
    for perm in itertools.permutations(numbers):
        shuffled_perm = np.random.permutation(perm)
        total_diff = 0
        for i in range(len(shuffled_perm) - 1):
            total_diff += abs(shuffled_perm[i] - shuffled_perm[i + 1])
        total_sum += total_diff
        count += 1
    return total_sum / count

# Clone zero-shot llama3.1:latest-minimal 1 nfr5
import itertools
import numpy as np


def task_func(numbers=None):
    if numbers is None:
        numbers = list(range(1, 11))
    total_sum = 0
    for perm in itertools.permutations(numbers):
        shuffled_perm = np.random.permutation(perm)
        total_sum += sum(abs(shuffled_perm[i] - shuffled_perm[i - 1]) for i in
            range(1, len(shuffled_perm)))
    return total_sum / len(list(itertools.permutations(numbers)))

# Clone zero-shot deepseek-r1-minimal 1 nfr0
import itertools
import math


def task_func(numbers=None):
    if numbers is None:
        numbers = list(range(1, 11))
    n = len(numbers)
    total_permutations = math.factorial(n)
    if n == 1:
        return 0.0
    all_permutations = itertools.permutations(numbers)
    sum_of_abs_diffs = 0
    for perm in all_permutations:
        s = 0
        for i in range(1, n):
            s += abs(perm[i] - perm[i - 1])
        sum_of_abs_diffs += s
    average = sum_of_abs_diffs / total_permutations
    return average

# Clone zero-shot deepseek-r1-minimal 1 nfr1
import itertools
import math


def task_func(numbers=None):
    if numbers is None:
        numbers = list(range(1, 11))
    n = len(numbers)
    total_permutations = math.factorial(n)
    if total_permutations == 0:
        return 0.0
    sums_of_differences = []
    for perm in itertools.permutations(numbers):
        current_sum = 0
        for i in range(1, n):
            diff = abs(perm[i] - perm[i - 1])
            current_sum += diff
        sums_of_differences.append(current_sum)
    average = sum(sums_of_differences) / total_permutations
    return average

# Clone zero-shot deepseek-r1-minimal 1 nfr3
import itertools
import math


def task_func(numbers=None):
    if numbers is None:
        numbers = list(range(1, 11))
    else:
        numbers = [float(x) for x in numbers]
    n = len(numbers)
    total_permutations = math.factorial(n)
    if n < 2:
        return 0.0
    total_sum = 0
    for perm in itertools.permutations(numbers):
        s = 0
        for i in range(1, n):
            s += abs(perm[i] - perm[i - 1])
        total_sum += s
    average = total_sum / float(total_permutations)
    return average

# Clone zero-shot deepseek-r1-ast 1 nfr0
import random
from itertools import permutations


def task_func(numbers=None):
    if numbers is None:
        numbers = list(range(1, 11))
    else:
        numbers = list(numbers)
    total_sum = 0
    count = 0
    for perm in permutations(numbers):
        perm_list = list(perm)
        random.shuffle(perm_list)
        diffs = [abs(perm_list[i] - perm_list[i + 1]) for i in range(len(
            perm_list) - 1)]
        total_sum += sum(diffs)
        count += 1
    return total_sum / count

# Clone zero-shot deepseek-r1-ast 1 nfr1
import itertools
import random


def task_func(numbers=None):
    if numbers is None:
        numbers = list(range(1, 11))
    total_sum = 0
    count = 0
    for perm in itertools.permutations(numbers):
        perm_list = list(perm)
        random.shuffle(perm_list)
        diffs = [abs(perm_list[i] - perm_list[i + 1]) for i in range(len(
            perm_list) - 1)]
        total_sum += sum(diffs)
        count += 1
    return total_sum / count

# Clone zero-shot deepseek-r1-ast 1 nfr2
import numpy as np
from itertools import permutations
import random


def task_func(numbers=None):
    if numbers is None:
        numbers = list(range(1, 11))
    perms = list(permutations(numbers))
    total_sum = 0.0
    for perm in perms:
        random.shuffle(list(perm))
        diffs = [abs(perm[i] - perm[i + 1]) for i in range(len(perm) - 1)]
        total_sum += sum(diffs)
    avg_sum_diffs = total_sum / len(perms)
    return avg_sum_diffs

# Clone zero-shot deepseek-r1-ast 1 nfr4
import random
from itertools import permutations


def task_func(numbers=None):
    if numbers is None:
        numbers = list(range(1, 11))
    total_sum = 0
    count = 0
    for perm in permutations(numbers):
        perm_list = list(perm)
        random.shuffle(perm_list)
        diffs = [abs(perm_list[i] - perm_list[i + 1]) for i in range(len(
            perm_list) - 1)]
        total_sum += sum(diffs)
        count += 1
    return total_sum / count

# Clone zero-shot deepseek-r1-ast 1 nfr5
import random
from itertools import permutations


def task_func(numbers=None):
    if numbers is None:
        numbers = list(range(1, 11))
    total_sum = 0
    count = 0
    for perm in permutations(numbers):
        shuffled_perm = list(perm)
        random.shuffle(shuffled_perm)
        diffs = [abs(shuffled_perm[i] - shuffled_perm[i + 1]) for i in
            range(len(shuffled_perm) - 1)]
        total_sum += sum(diffs)
        count += 1
    if count == 0:
        return 0.0
    average = total_sum / count
    return average

# Clone zero-shot llama4:latest-minimal 1 nfr1
import itertools
import random


def task_func(numbers=None):
    if numbers is None:
        numbers = list(range(1, 11))
    total_sum = 0
    permutations = list(itertools.permutations(numbers))
    for permutation in permutations:
        shuffled_permutation = list(permutation)
        random.shuffle(shuffled_permutation)
        differences = [abs(shuffled_permutation[i] - shuffled_permutation[i -
            1]) for i in range(1, len(shuffled_permutation))]
        total_sum += sum(differences)
    return total_sum / len(permutations)

# Clone zero-shot llama4:latest-minimal 1 nfr2
import numpy as np
import itertools
import random
from typing import List


def task_func(numbers: List[float]=list(range(1, 11))) ->float:
    total_sum = 0
    permutations = list(itertools.permutations(numbers))
    for permutation in permutations:
        shuffled_permutation = list(permutation)
        random.shuffle(shuffled_permutation)
        differences = [abs(shuffled_permutation[i] - shuffled_permutation[i -
            1]) for i in range(1, len(shuffled_permutation))]
        total_sum += sum(differences)
    return total_sum / len(permutations)

# Clone zero-shot llama4:latest-minimal 1 nfr3
import numpy as np
import itertools


def task_func(numbers=None):
    if numbers is None:
        numbers = list(range(1, 11))
    total_permutations = 0
    total_sum = 0
    permutations = list(itertools.permutations(numbers))
    for permutation in permutations:
        total_sum += sum(abs(permutation[i] - permutation[i + 1]) for i in
            range(len(permutation) - 1))
        total_permutations += 1
    return total_sum / total_permutations

# Clone zero-shot llama4:latest-minimal 1 nfr4
import itertools
import random
import math


def task_func(numbers=None):
    if numbers is None:
        numbers = list(range(1, 11))
    total_sum = 0
    permutations = list(itertools.permutations(numbers))
    for permutation in permutations:
        shuffled_permutation = list(permutation)
        random.shuffle(shuffled_permutation)
        differences_sum = 0
        for i in range(len(shuffled_permutation) - 1):
            differences_sum += abs(shuffled_permutation[i] -
                shuffled_permutation[i + 1])
        total_sum += differences_sum
    average = total_sum / len(permutations)
    return average


print(task_func())

# Clone zero-shot llama4:latest-minimal 1 nfr5
import itertools
import random
import math


def task_func(numbers=None):
    if numbers is None:
        numbers = list(range(1, 11))
    total_sum = 0
    permutations = list(itertools.permutations(numbers))
    for permutation in permutations:
        shuffled_permutation = list(permutation)
        random.shuffle(shuffled_permutation)
        differences_sum = 0
        for i in range(len(shuffled_permutation) - 1):
            differences_sum += abs(shuffled_permutation[i] -
                shuffled_permutation[i + 1])
        total_sum += differences_sum
    average = total_sum / len(permutations)
    return average

# Clone cot llama3.1:latest-minimal 1 nfr0
import itertools
import numpy as np


def task_func(numbers=None):
    if numbers is None:
        numbers = list(range(1, 11))
    result = []
    for p in itertools.permutations(numbers):
        shuffled_p = np.random.permutation(p)
        diff_sum = sum(abs(shuffled_p[i] - shuffled_p[i - 1]) for i in
            range(1, len(shuffled_p)))
        result.append(diff_sum)
    return np.mean(result)

# Clone cot llama3.1:latest-minimal 1 nfr2
import itertools
import numpy as np


def task_func(numbers=None):
    if numbers is None:
        numbers = list(range(1, 11))
    permutations = list(itertools.permutations(numbers))
    results = []
    for p in permutations:
        shuffled_p = np.random.permutation(p)
        differences = [abs(shuffled_p[i] - shuffled_p[i - 1]) for i in
            range(1, len(shuffled_p))]
        results.append(sum(differences))
    return np.mean(results)

# Clone cot llama3.1:latest-minimal 1 nfr4
import itertools
import numpy as np


def task_func(numbers=None):
    if numbers is None:
        numbers = list(range(1, 11))
    permutations = list(itertools.permutations(numbers))
    results = []
    for p in permutations:
        shuffled_p = np.random.permutation(p)
        differences = [abs(shuffled_p[i] - shuffled_p[i - 1]) for i in
            range(1, len(shuffled_p))]
        results.append(sum(differences))
    return np.mean(results)

# Clone cot llama3.1:latest-minimal 1 nfr5
import itertools
import numpy as np


def task_func(numbers=None):
    if numbers is None:
        numbers = list(range(1, 11))
    permutations = list(itertools.permutations(numbers))
    total_sum = 0
    for p in permutations:
        shuffled_p = np.random.permutation(p)
        total_sum += sum(np.abs(np.diff(shuffled_p)))
    return total_sum / len(permutations)

# Clone few-shot deepseek-r1-minimal 1 nfr0
import itertools


def task_func(numbers=None):
    if numbers is None:
        numbers = list(range(1, 11))
    total_permutations = 0
    total_sum = 0.0
    for perm in itertools.permutations(numbers):
        total_permutations += 1
        current_sum = 0
        for i in range(len(perm) - 1):
            current_sum += abs(perm[i] - perm[i + 1])
        total_sum += current_sum
    if total_permutations == 0:
        return 0.0
    average = total_sum / total_permutations
    return average

# Clone few-shot deepseek-r1-minimal 1 nfr1
import itertools


def task_func(numbers=None):
    if numbers is None:
        numbers = list(range(1, 11))
    total_permutations = 0
    total_sum = 0.0
    for perm in itertools.permutations(numbers):
        total_permutations += 1
        current_sum = 0
        for i in range(len(perm) - 1):
            current_sum += abs(perm[i] - perm[i + 1])
        total_sum += current_sum
    if total_permutations == 0:
        return 0.0
    average = total_sum / total_permutations
    return average

# Clone few-shot deepseek-r1-minimal 1 nfr2
import itertools
import numpy as np
from typing import List


def task_func(numbers: List[int]=None) ->float:
    if numbers is None:
        numbers = list(range(1, 11))
    perms = itertools.permutations(numbers)
    sums_diff = []
    for perm in perms:
        diff_sum = 0
        for i in range(len(perm) - 1):
            diff_sum += abs(perm[i] - perm[i + 1])
        sums_diff.append(diff_sum)
    avg = np.mean(sums_diff)
    return avg

# Clone few-shot deepseek-r1-minimal 1 nfr3
import itertools
import math


def task_func(numbers=None):
    if numbers is None:
        numbers = list(range(1, 11))
    n = len(numbers)
    total_permutations = math.factorial(n)
    if total_permutations == 0:
        return 0.0
    total_sum = 0
    for perm in itertools.permutations(numbers):
        s = 0
        for i in range(1, n):
            s += abs(perm[i] - perm[i - 1])
        total_sum += s
    average = total_sum / total_permutations
    return average

# Clone few-shot deepseek-r1-ast 1 nfr3
import random
from itertools import permutations


def task_func(numbers=None):
    if numbers is None:
        numbers = list(range(1, 11))
    total_permutations = len(list(permutations(numbers)))
    all_sums = []
    for perm in permutations(numbers):
        perm_list = list(perm)
        random.shuffle(perm_list)
        diffs = [abs(perm_list[i] - perm_list[i + 1]) for i in range(len(
            perm_list) - 1)]
        all_sums.append(sum(diffs))
    avg_sum_diffs = sum(all_sums) / total_permutations
    return avg_sum_diffs

# Clone few-shot deepseek-r1-ast 1 nfr4
import random
from itertools import permutations


def task_func(numbers=None):
    if numbers is None:
        numbers = list(range(1, 11))
    total_sum = 0.0
    count = 0
    for perm in permutations(numbers):
        shuffled_perm = list(perm)
        random.shuffle(shuffled_perm)
        diffs = [abs(shuffled_perm[i] - shuffled_perm[i + 1]) for i in
            range(len(shuffled_perm) - 1)]
        total_sum += sum(diffs)
        count += 1
    if count == 0:
        return 0.0
    average = total_sum / count
    return average

# Clone few-shot deepseek-r1-ast 1 nfr5
import random
from itertools import permutations


def task_func(numbers=None):
    if numbers is None:
        numbers = list(range(1, 11))
    total_sum = 0
    count = 0
    for perm in permutations(numbers):
        lst = list(perm)
        random.shuffle(lst)
        diffs = []
        for i in range(len(lst) - 1):
            diffs.append(abs(lst[i] - lst[i + 1]))
        total_sum += sum(diffs)
        count += 1
    return total_sum / count

# Clone cot deepseek-r1-minimal 1 nfr0
import itertools
import math


def task_func(numbers=None):
    if numbers is None:
        numbers = list(range(1, 11))
    total_permutations = 0
    total_sum = 0.0
    for perm in itertools.permutations(numbers):
        total_permutations += 1
        current_sum = 0
        for i in range(len(perm) - 1):
            current_sum += abs(perm[i] - perm[i + 1])
        total_sum += current_sum
    if total_permutations == 0:
        return 0.0
    average = total_sum / total_permutations
    return average

# Clone cot deepseek-r1-minimal 1 nfr1
import itertools
import math


def task_func(numbers=None):
    if numbers is None:
        numbers = list(range(1, 11))
    total_permutations = math.factorial(len(numbers))
    total_sum = 0
    for perm in itertools.permutations(numbers):
        current_sum = 0
        for i in range(1, len(perm)):
            current_sum += abs(perm[i] - perm[i - 1])
        total_sum += current_sum
    return total_sum / total_permutations

# Clone cot deepseek-r1-minimal 1 nfr2
import itertools
import numpy as np


def task_func(numbers=None):
    if numbers is None:
        numbers = list(range(1, 11))
    total_permutations = len(numbers)
    sums_of_differences = []
    for perm in itertools.permutations(numbers):
        consecutive_differences = [abs(perm[i] - perm[i - 1]) for i in
            range(1, len(perm))]
        sum_diff = sum(consecutive_differences)
        sums_of_differences.append(sum_diff)
    average = np.mean(sums_of_differences)
    return average

# Clone cot deepseek-r1-minimal 1 nfr3
import itertools
import math


def task_func(numbers=None):
    if numbers is None:
        numbers = list(range(1, 11))
    n = len(numbers)
    total_permutations = math.factorial(n)
    if total_permutations == 0:
        return 0.0
    total_sum = 0
    for perm in itertools.permutations(numbers):
        current_sum = 0
        for i in range(1, n):
            diff = abs(perm[i] - perm[i - 1])
            current_sum += diff
        total_sum += current_sum
    return total_sum / total_permutations

# Clone cot deepseek-r1-minimal 1 nfr4
import itertools
import math


def task_func(numbers=None):
    if numbers is None:
        numbers = list(range(1, 11))
    total_permutations = math.factorial(len(numbers))
    if total_permutations == 0:
        return 0.0
    sum_of_differences = 0.0
    for perm in itertools.permutations(numbers):
        diff_sum = 0.0
        for i in range(len(perm) - 1):
            diff_sum += abs(perm[i] - perm[i + 1])
        sum_of_differences += diff_sum
    average = sum_of_differences / total_permutations
    return average

# Clone cot deepseek-r1-minimal 1 nfr5
import itertools
import math


def task_func(numbers=None):
    if numbers is None:
        numbers = list(range(1, 11))
    perms = itertools.permutations(numbers)
    total_sum = 0.0
    count = 0
    for perm in perms:
        s = 0.0
        for i in range(len(perm) - 1):
            diff = abs(perm[i] - perm[i + 1])
            s += diff
        total_sum += s
        count += 1
    if count == 0:
        return 0.0
    average = total_sum / count
    return average

# Clone cot deepseek-r1-ast 1 nfr2
import random
from itertools import permutations


def task_func(numbers=None):
    if numbers is None:
        numbers = list(range(1, 11))
    total_sum = 0
    count = 0
    for perm in permutations(numbers):
        perm_list = list(perm)
        random.shuffle(perm_list)
        diffs = [abs(perm_list[i] - perm_list[i + 1]) for i in range(len(
            perm_list) - 1)]
        total_sum += sum(diffs)
        count += 1
    return total_sum / count

# Clone cot deepseek-r1-ast 1 nfr4
import random
from itertools import permutations


def task_func(numbers=None):
    if numbers is None:
        numbers = list(range(1, 11))
    total_sum = 0
    count = 0
    for num_list in permutations(numbers):
        diffs = [abs(num_list[i] - num_list[i + 1]) for i in range(len(
            num_list) - 1)]
        total_sum += sum(diffs)
        count += 1
    return total_sum / count

# Clone cot deepseek-r1-ast 1 nfr5
import random
from itertools import permutations


def task_func(numbers=None):
    if numbers is None:
        numbers = list(range(1, 11))
    total_sum = 0
    count = 0
    for perm in permutations(numbers):
        shuffled_perm = list(perm)
        random.shuffle(shuffled_perm)
        diffs = []
        for i in range(len(shuffled_perm) - 1):
            diffs.append(abs(shuffled_perm[i] - shuffled_perm[i + 1]))
        total_sum += sum(diffs)
        count += 1
    if count == 0:
        return 0.0
    average = total_sum / count
    return average

# Clone few-shot llama4:latest-minimal 1 nfr0
import itertools
import random


def task_func(numbers=None):
    if numbers is None:
        numbers = list(range(1, 11))
    total_diff = 0
    permutations = list(itertools.permutations(numbers))
    for p in permutations:
        diff = 0
        for i in range(len(p) - 1):
            diff += abs(p[i] - p[i + 1])
        total_diff += diff
    return total_diff / len(permutations)

# Clone few-shot llama4:latest-minimal 1 nfr2
import numpy as np
import itertools


def task_func(numbers=None):
    if numbers is None:
        numbers = list(range(1, 11))
    total_diff = 0
    permutations = list(itertools.permutations(numbers))
    for p in permutations:
        diff = sum(abs(p[i] - p[i + 1]) for i in range(len(p) - 1))
        total_diff += diff
    return total_diff / len(permutations)

# Clone few-shot llama4:latest-minimal 1 nfr3
import numpy as np
import itertools


def task_func(numbers=None):
    if numbers is None:
        numbers = list(range(1, 11))
    total_diff = 0
    permutations = list(itertools.permutations(numbers))
    for p in permutations:
        diff = sum(abs(p[i] - p[i + 1]) for i in range(len(p) - 1))
        total_diff += diff
    return total_diff / len(permutations)

# Clone few-shot llama4:latest-minimal 1 nfr4
import itertools
import random
import math


def task_func(numbers=None):
    if numbers is None:
        numbers = list(range(1, 11))
    total_diff = 0
    permutations = list(itertools.permutations(numbers))
    for p in permutations:
        diff = 0
        for i in range(len(p) - 1):
            diff += abs(p[i] - p[i + 1])
        total_diff += diff
    return total_diff / len(permutations)

# Clone few-shot llama4:latest-minimal 1 nfr5
import itertools
import random
import math


def task_func(numbers=None):
    if numbers is None:
        numbers = list(range(1, 11))
    total_diff = 0
    permutations = list(itertools.permutations(numbers))
    for permutation in permutations:
        shuffled_permutation = list(permutation)
        random.shuffle(shuffled_permutation)
        diff = sum(abs(shuffled_permutation[i] - shuffled_permutation[i + 1
            ]) for i in range(len(shuffled_permutation) - 1))
        total_diff += diff
    return total_diff / len(permutations)

# Clone cot llama4:latest-minimal 1 nfr0
import itertools
import random


def task_func(numbers=None):
    if numbers is None:
        numbers = list(range(1, 11))
    total_diff = 0
    permutations = list(itertools.permutations(numbers))
    for p in permutations:
        diff = 0
        for i in range(len(p) - 1):
            diff += abs(p[i] - p[i + 1])
        total_diff += diff
    return total_diff / len(permutations)

# Clone cot llama4:latest-minimal 1 nfr1
import itertools
import random


def task_func(numbers=None):
    if numbers is None:
        numbers = list(range(1, 11))
    total_diff = 0
    permutations = list(itertools.permutations(numbers))
    for p in permutations:
        diff = 0
        for i in range(len(p) - 1):
            diff += abs(p[i] - p[i + 1])
        total_diff += diff
    return total_diff / len(permutations)

# Clone cot llama4:latest-minimal 1 nfr2
import numpy as np
import itertools


def task_func(numbers=None):
    if numbers is None:
        numbers = list(range(1, 11))
    total_diff = 0
    permutations = list(itertools.permutations(numbers))
    for p in permutations:
        diff = sum(abs(p[i] - p[i + 1]) for i in range(len(p) - 1))
        total_diff += diff
    return total_diff / len(permutations)

# Clone cot llama4:latest-minimal 1 nfr3
import itertools
import random


def task_func(numbers=None):
    if numbers is None:
        numbers = list(range(1, 11))
    total_diff = 0
    permutations = list(itertools.permutations(numbers))
    for p in permutations:
        diff = 0
        for i in range(len(p) - 1):
            diff += abs(p[i] - p[i + 1])
        total_diff += diff
    return total_diff / len(permutations)

# Clone cot llama4:latest-minimal 1 nfr4
import itertools
import random


def task_func(numbers=None):
    if numbers is None:
        numbers = list(range(1, 11))
    total_diff = 0
    permutations = list(itertools.permutations(numbers))
    for p in permutations:
        diff = 0
        for i in range(len(p) - 1):
            diff += abs(p[i] - p[i + 1])
        total_diff += diff
    return total_diff / len(permutations)

# Clone cot llama4:latest-minimal 1 nfr5
import itertools
import random


def task_func(numbers=None):
    if numbers is None:
        numbers = list(range(1, 11))
    total_diff = 0
    permutations = list(itertools.permutations(numbers))
    for p in permutations:
        diff = 0
        for i in range(len(p) - 1):
            diff += abs(p[i] - p[i + 1])
        total_diff += diff
    return total_diff / len(permutations)

# Clone zero-shot gemma3:latest-minimal 1 nfr3
import itertools
import random


def task_func(numbers=None):
    if numbers is None:
        numbers = list(range(1, 11))
    if not numbers:
        return 0.0
    permutations = list(itertools.permutations(numbers))
    sum_of_abs_diffs = 0
    for perm in permutations:
        abs_diff_sum = 0
        for i in range(len(perm) - 1):
            abs_diff_sum += abs(perm[i] - perm[i + 1])
        sum_of_abs_diffs += abs_diff_sum
    return float(sum_of_abs_diffs / len(permutations))

# Clone zero-shot gemma3:latest-minimal 1 nfr4
import itertools
import random


def task_func(numbers=None):
    if numbers is None:
        numbers = list(range(1, 11))
    if not numbers:
        return 0.0
    total_sum = 0
    num_permutations = 0
    for permutation in itertools.permutations(numbers):
        permutation = list(permutation)
        num_permutations += 1
        current_sum = 0
        for i in range(len(permutation) - 1):
            current_sum += abs(permutation[i] - permutation[i + 1])
        total_sum += current_sum
    return float(total_sum) / num_permutations

# Clone zero-shot gemma3:latest-minimal 1 nfr5
import itertools
import random


def task_func(numbers=None):
    if numbers is None:
        numbers = list(range(1, 11))
    if not numbers:
        return 0.0
    n = len(numbers)
    total_sum = 0.0
    for permutation in itertools.permutations(numbers):
        permutation_sum = 0
        for i in range(n - 1):
            permutation_sum += abs(permutation[i] - permutation[i + 1])
        total_sum += permutation_sum
    return float(total_sum) / len(list(itertools.permutations(numbers)))

# Clone few-shot gemma3:latest-minimal 1 nfr1
import itertools
import random


def task_func(numbers=None):
    if numbers is None:
        numbers = list(range(1, 11))
    else:
        numbers = list(numbers)
    if not numbers:
        return 0.0
    sums = []
    for permutation in itertools.permutations(numbers):
        perm_sum = 0
        for i in range(len(permutation) - 1):
            perm_sum += abs(permutation[i] - permutation[i + 1])
        sums.append(perm_sum)
    return sum(sums) / len(sums)

# Clone few-shot gemma3:latest-minimal 1 nfr3
import itertools
import numpy as np


def task_func(numbers=None):
    if numbers is None:
        numbers = list(range(1, 11))
    if not numbers:
        return 0.0
    sums = []
    for permutation in itertools.permutations(numbers):
        perm_list = list(permutation)
        sum_abs_diff = 0
        for i in range(len(perm_list) - 1):
            sum_abs_diff += abs(perm_list[i] - perm_list[i + 1])
        sums.append(sum_abs_diff)
    return float(np.mean(sums))

# Clone cot gemma3:latest-minimal 1 nfr0
import itertools
import numpy as np


def task_func(numbers=None):
    if numbers is None:
        numbers = list(range(1, 11))
    if not numbers:
        return 0.0
    perms = list(itertools.permutations(numbers))
    sums = []
    for perm in perms:
        perm_list = list(perm)
        sum_diff = 0
        for i in range(len(perm_list) - 1):
            sum_diff += abs(perm_list[i] - perm_list[i + 1])
        sums.append(sum_diff)
    return float(np.mean(sums))

# Clone cot gemma3:latest-minimal 1 nfr1
def task_func(numbers=None):
    import itertools
    if numbers is None:
        numbers = list(range(1, 11))
    if not numbers:
        return 0.0
    sums = []
    for permutation in itertools.permutations(numbers):
        perm_sum = 0
        for i in range(len(permutation) - 1):
            perm_sum += abs(permutation[i] - permutation[i + 1])
        sums.append(perm_sum)
    return sum(sums) / len(sums)

# Clone cot gemma3:latest-minimal 1 nfr2
import itertools
import numpy as np


def task_func(numbers=None):
    if numbers is None:
        numbers = list(range(1, 11))
    if not numbers:
        return 0.0
    permutations = list(itertools.permutations(numbers))
    sums = []
    for perm in permutations:
        perm_list = list(perm)
        sum_diff = 0
        for i in range(len(perm_list) - 1):
            sum_diff += abs(perm_list[i] - perm_list[i + 1])
        sums.append(sum_diff)
    return float(np.mean(sums))

# Clone cot gemma3:latest-minimal 1 nfr3
import itertools
import random


def task_func(numbers=None):
    if numbers is None:
        numbers = list(range(1, 11))
    if not numbers:
        return 0.0
    total_sum = 0
    num_permutations = 0
    for permutation in itertools.permutations(numbers):
        permutation_sum = 0
        for i in range(len(permutation) - 1):
            permutation_sum += abs(permutation[i] - permutation[i + 1])
        total_sum += permutation_sum
        num_permutations += 1
    return float(total_sum) / num_permutations

# Clone cot gemma3:latest-minimal 1 nfr4
import itertools
import random


def task_func(numbers=None):
    if numbers is None:
        numbers = list(range(1, 11))
    if not numbers:
        return 0.0
    total_sum = 0
    num_permutations = 0
    for permutation in itertools.permutations(numbers):
        permutation_sum = 0
        for i in range(len(permutation) - 1):
            permutation_sum += abs(permutation[i] - permutation[i + 1])
        total_sum += permutation_sum
        num_permutations += 1
    return float(total_sum) / num_permutations

# Clone zero-shot gpt-oss:latest-minimal 1 nfr1
import itertools


def task_func(numbers=None):
    if numbers is None:
        numbers = list(range(1, 11))
    if not numbers:
        return 0.0
    total = 0
    count = 0
    for perm in itertools.permutations(numbers):
        s = 0
        for i in range(len(perm) - 1):
            s += abs(perm[i] - perm[i + 1])
        total += s
        count += 1
    return total / count


print(task_func())

# Clone few-shot gpt-oss:latest-minimal 1 nfr1
import itertools


def task_func(numbers=None):
    if numbers is None:
        numbers = list(range(1, 11))
    n = len(numbers)
    if n <= 1:
        return 0.0
    total = 0
    count = 0
    for perm in itertools.permutations(numbers):
        s = 0
        for i in range(n - 1):
            s += abs(perm[i] - perm[i + 1])
        total += s
        count += 1
    return total / count


print(task_func())

# Clone few-shot gpt-oss:latest-ast 1 nfr0
import itertools as it
import random


def task_func(numbers=None):
    if numbers is None:
        numbers = list(range(1, 11))
    total = 0
    cnt = 0
    for perm in it.permutations(numbers):
        perm_list = list(perm)
        random.shuffle(perm_list)
        diff_sum = 0
        for i in range(len(perm_list) - 1):
            diff_sum += abs(perm_list[i + 1] - perm_list[i])
        total += diff_sum
        cnt += 1
    return total / cnt if cnt else 0


print(task_func())

# Clone few-shot gpt-oss:latest-ast 1 nfr4
from itertools import permutations as perm_iter
import random as rnd


def task_func(numbers=None):
    if numbers is None:
        numbers = list(range(1, 11))
    total = 0
    count = 0
    for p in perm_iter(numbers):
        lst = list(p)
        rnd.shuffle(lst)
        diff_sum = sum(abs(lst[i] - lst[i + 1]) for i in range(len(lst) - 1))
        total += diff_sum
        count += 1
    return total / count if count else 0.0


print(task_func())

# Clone cot gpt-oss:latest-ast 1 nfr4
import random
from itertools import permutations


def task_func(numbers=None):
    if numbers is None:
        numbers = list(range(1, 11))
    total_sum = 0.0
    count = 0
    for perm in permutations(numbers):
        perm_list = list(perm)
        random.shuffle(perm_list)
        diff_sum = 0.0
        for i in range(len(perm_list) - 1):
            diff_sum += abs(perm_list[i + 1] - perm_list[i])
        total_sum += diff_sum
        count += 1
    return total_sum / count if count else 0.0


print(task_func())

# Clone cot gpt-oss:latest-ast 1 nfr5
import itertools
import random
import math


def task_func(numbers=None):
    if numbers is None:
        numbers = list(range(1, 11))
    n = len(numbers)
    total = 0
    for perm in itertools.permutations(numbers):
        shuffled = random.sample(perm, n)
        diff_sum = sum(abs(shuffled[i] - shuffled[i + 1]) for i in range(n - 1)
            )
        total += diff_sum
    avg = total / math.factorial(n)
    return float(avg)


print(task_func())

# Clone zero-shot gpt-oss:20b-complete 1 nfr0
import itertools
from random import shuffle


def task_func(numbers=None):
    if numbers is None:
        numbers = list(range(1, 11))
    perms = list(itertools.permutations(numbers))
    total = 0.0
    for p in perms:
        perm_list = list(p)
        shuffle(perm_list)
        diff_sum = 0.0
        for i in range(len(perm_list) - 1):
            diff_sum += abs(perm_list[i] - perm_list[i + 1])
        total += diff_sum
    return total / len(perms) if perms else 0.0

# Clone zero-shot gpt-oss:20b-minimal 1 nfr0
import itertools


def task_func(numbers=None):
    if numbers is None:
        numbers = list(range(1, 11))
    n = len(numbers)
    if n == 0:
        return 0.0
    total = 0
    count = 0
    for perm in itertools.permutations(numbers):
        diff_sum = 0
        for i in range(n - 1):
            diff_sum += abs(perm[i] - perm[i + 1])
        total += diff_sum
        count += 1
    return total / count

# Clone zero-shot gpt-oss:20b-minimal 1 nfr1
import itertools
import math


def task_func(numbers=None):
    if numbers is None:
        numbers = list(range(1, 11))
    n = len(numbers)
    if n <= 1:
        return 0.0
    total = 0
    for perm in itertools.permutations(numbers):
        s = 0
        for a, b in zip(perm, perm[1:]):
            s += abs(a - b)
        total += s
    avg = total / math.factorial(n)
    return float(avg)

# Clone zero-shot gpt-oss:20b-ast 1 nfr1
import itertools
import random


def task_func(numbers=None):
    if numbers is None:
        numbers = list(range(1, 11))
    total = 0.0
    count = 0
    for perm in itertools.permutations(numbers):
        lst = list(perm)
        random.shuffle(lst)
        s = 0
        for i in range(len(lst) - 1):
            s += abs(lst[i + 1] - lst[i])
        total += s
        count += 1
    return total / count

# Clone zero-shot gpt-oss:20b-ast 1 nfr4
import itertools as it
from random import shuffle
import math


def task_func(numbers=None):
    if numbers is None:
        numbers = list(range(1, 11))
    n = len(numbers)
    total_sum = 0.0
    count = 0
    for perm in it.permutations(numbers):
        perm_list = list(perm)
        shuffle(perm_list)
        diff_sum = sum(abs(a - b) for a, b in zip(perm_list, perm_list[1:]))
        total_sum += diff_sum
        count += 1
    avg = total_sum / count if count else 0.0
    return avg

# Clone zero-shot gpt-oss:20b-ast 1 nfr5
import itertools
import random


def task_func(numbers=None):
    if numbers is None:
        numbers = list(range(1, 11))
    total = 0.0
    count = 0
    for perm in itertools.permutations(numbers):
        shuffled = list(perm)
        random.shuffle(shuffled)
        diff_sum = sum(abs(shuffled[i] - shuffled[i + 1]) for i in range(
            len(shuffled) - 1))
        total += diff_sum
        count += 1
    return total / count if count else 0.0

# Clone few-shot gpt-oss:20b-minimal 1 nfr5
import itertools


def task_func(numbers=None):
    """
    Calculates the average of the sums of absolute differences between each pair of
    consecutive numbers for all permutations of the given list.

    Args:
        numbers (list, optional): A list of numbers. Defaults to [1, 2, ..., 10].

    Returns:
        float: The average sum of absolute differences across all permutations.
    """
    if numbers is None:
        numbers = list(range(1, 11))
    n = len(numbers)
    if n <= 1:
        return 0.0
    total = 0.0
    count = 0
    for perm in itertools.permutations(numbers):
        diff_sum = sum(abs(perm[i] - perm[i + 1]) for i in range(n - 1))
        total += diff_sum
        count += 1
    return total / count

# Clone few-shot gpt-oss:20b-ast 1 nfr1
import itertools
import math


def task_func(numbers=None):
    if numbers is None:
        numbers = list(range(1, 11))
    n = len(numbers)
    total = 0
    for perm in itertools.permutations(numbers):
        s = 0
        for i in range(n - 1):
            s += abs(perm[i + 1] - perm[i])
        total += s
    avg = total / math.factorial(n)
    return float(avg)

# Clone cot gpt-oss:20b-minimal 1 nfr0
import itertools
from math import factorial


def task_func(numbers=None):
    if numbers is None:
        numbers = list(range(1, 11))
    n = len(numbers)
    if n <= 1:
        return 0.0
    total = 0
    for perm in itertools.permutations(numbers):
        total += sum(abs(perm[i] - perm[i + 1]) for i in range(n - 1))
    return float(total / factorial(n))

# Clone cot gpt-oss:20b-minimal 1 nfr1
import itertools


def task_func(numbers=None):
    if numbers is None:
        numbers = list(range(1, 11))
    total = 0
    count = 0
    for perm in itertools.permutations(numbers):
        diff_sum = 0
        for i in range(1, len(perm)):
            diff_sum += abs(perm[i] - perm[i - 1])
        total += diff_sum
        count += 1
    return float(total / count) if count else 0.0

# Clone cot gpt-oss:20b-minimal 1 nfr5
import math
import itertools
from typing import List, Optional


def task_func(numbers: Optional[List[float]]=None) ->float:
    if numbers is None:
        numbers = list(range(1, 11))
    n = len(numbers)
    if n <= 1:
        return 0.0
    total = 0
    for perm in itertools.permutations(numbers):
        perm_sum = sum(abs(perm[i] - perm[i + 1]) for i in range(n - 1))
        total += perm_sum
    average = total / math.factorial(n)
    return float(average)

