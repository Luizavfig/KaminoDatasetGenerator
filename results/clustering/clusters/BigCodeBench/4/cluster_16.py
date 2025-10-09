# Clone zero-shot gpt-oss:20b-requirements 1 nfr5
def task_func(d):
    from collections import Counter
    counter = Counter()
    for iterable in d.values():
        for item in iterable:
            counter[item] += 1
    return dict(counter)

