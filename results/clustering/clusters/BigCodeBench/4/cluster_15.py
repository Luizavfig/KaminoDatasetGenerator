# Clone zero-shot deepseek-r1-ast 1 nfr3
def task_func(d):
    from collections import Counter
    flat_list = []
    for sublist in d.values():
        flat_list.extend(sublist)
    return dict(Counter(flat_list))

# Clone zero-shot deepseek-r1-ast 1 nfr4
def task_func(d):
    flat_list = []
    for sublist in d.values():
        flat_list.extend(sublist)
    from collections import Counter
    count_dict = Counter(flat_list)
    return dict(count_dict)

# Clone zero-shot deepseek-r1-ast 1 nfr5
def task_func(d):
    flat_list = []
    for sublist in d.values():
        flat_list.extend(sublist)
    from collections import Counter
    count_dict = Counter(flat_list)
    return dict(count_dict)

# Clone few-shot deepseek-r1-ast 1 nfr5
def task_func(d):
    flat_list = []
    for sublist in d.values():
        flat_list.extend(sublist)
    from collections import Counter
    count_dict = Counter(flat_list)
    return dict(count_dict)

# Clone cot gpt-oss:latest-requirements 1 nfr3
from collections import Counter


def task_func(d):
    counter = Counter()
    for iterable in d.values():
        counter.update(iterable)
    return dict(counter)


print(task_func({'a': [1, 2, 3], 'b': [2, 3, 4]}))

# Clone zero-shot gpt-oss:20b-minimal 1 nfr3
def task_func(d: dict) ->dict:
    from collections import Counter
    counter = Counter()
    for lst in d.values():
        counter.update(lst)
    return dict(counter)

# Clone zero-shot gpt-oss:20b-minimal 1 nfr5
def task_func(d: dict) ->dict:
    from collections import Counter
    counts = Counter()
    for lst in d.values():
        counts.update(lst)
    return dict(counts)

# Clone cot gpt-oss:20b-minimal 1 nfr5
from collections import Counter


def task_func(d):
    counter = Counter()
    for lst in d.values():
        counter.update(lst)
    return dict(counter)

# Clone cot gpt-oss:20b-translation 1 nfr0
from collections import Counter


def task_func(d):
    counter = Counter()
    for lst in d.values():
        counter.update(lst)
    return dict(counter)

# Clone cot gpt-oss:20b-translation 1 nfr3
from collections import Counter


def task_func(d):
    """
    Count occurrences of integers across all lists in the input dictionary.

    Parameters
    ----------
    d : dict[str, list[int]]
        Mapping from strings to lists of integers.

    Returns
    -------
    dict[int, int]
        Dictionary mapping each integer to the total count of its appearances.
    """
    total_counts = Counter()
    for lst in d.values():
        total_counts.update(lst)
    return dict(total_counts)

