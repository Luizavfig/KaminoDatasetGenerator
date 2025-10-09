# Clone cot deepseek-r1-complete 1 nfr1
from collections import Counter
import itertools


def task_func(d):
    all_values = []
    for key in d:
        all_values.extend(d[key])
    count_dict = {}
    for num in all_values:
        count_dict[num] = count_dict.get(num, 0) + 1
    return count_dict

# Clone zero-shot gemma3:latest-ast 1 nfr3
def task_func(d):
    count_dict = {}
    for value_list in d.values():
        counts = {}
        for num in value_list:
            counts[num] = counts.get(num, 0) + 1
        for num, count in counts.items():
            count_dict[num] = count_dict.get(num, 0) + count
    return count_dict

