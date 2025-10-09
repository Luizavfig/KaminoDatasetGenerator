# Clone cot deepseek-r1-requirements 1 nfr1
import random
import statistics


def task_func(LETTERS):
    if not hasattr(random, 'random'):
        raise ImportError('random module is required')
    if not hasattr(statistics, 'mean'):
        raise ImportError('statistics module is required')
    result_dict = {}
    for letter in LETTERS:
        if letter in result_dict:
            raise ValueError('Duplicate keys are not allowed')
        length = random.randint(1, 10)
        num_list = [random.randint(-100, 100) for _ in range(length)]
        result_dict[letter] = num_list
    sorted_dict = {}
    while result_dict:
        key_with_max_mean = None
        max_mean = -float('inf')
        for key, value in result_dict.items():
            current_mean = statistics.mean(value)
            if current_mean > max_mean:
                max_mean = current_mean
                key_with_max_mean = key
        if key_with_max_mean is not None:
            sorted_dict[key_with_max_mean] = result_dict.pop(key_with_max_mean)
    return sorted_dict

