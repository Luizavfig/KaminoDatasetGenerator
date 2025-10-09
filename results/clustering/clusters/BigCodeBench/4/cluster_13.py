# Clone cot gpt-oss:20b-minimal 1 nfr2
def task_func(d):
    from collections import Counter
    from itertools import chain
    return dict(Counter(chain.from_iterable(d.values())))

# Clone cot gpt-oss:20b-minimal 1 nfr3
def task_func(d):
    from collections import Counter
    counts = Counter()
    for v in d.values():
        if isinstance(v, list):
            counts.update(v)
    return dict(counts)

