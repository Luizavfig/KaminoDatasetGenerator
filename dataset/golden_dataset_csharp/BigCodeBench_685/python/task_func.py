from collections import Counter
from itertools import chain

def task_func(list_of_lists):
    merged_list = list(chain.from_iterable(list_of_lists))
    return Counter(merged_list)
