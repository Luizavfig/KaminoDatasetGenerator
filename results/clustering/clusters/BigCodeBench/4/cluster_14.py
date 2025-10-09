# Clone few-shot llama3.1:latest-minimal 1 nfr3
from collections import Counter


def task_func(d):
    counts = Counter()
    for key in d:
        counts.update(d[key])
    return dict(counts)

# Clone zero-shot gemma3:latest-requirements 1 nfr2
from collections import Counter


def task_func(d):
    """
    Generates a dictionary where the keys are unique elements from the input dictionary's values
    and the values are their respective counts.
    """
    if not d:
        return {}
    all_values = []
    for key in d:
        all_values.extend(d[key])
    counts = Counter(all_values)
    return dict(counts)

