# Clone cot gpt-oss:20b-complete 1 nfr5
import collections


def task_func(d):
    all_vals = []
    for lst in d.values():
        for val in lst:
            if not isinstance(val, int):
                raise TypeError(f'Non-integer value encountered: {val!r}')
            all_vals.append(val)
    return dict(collections.Counter(all_vals))

