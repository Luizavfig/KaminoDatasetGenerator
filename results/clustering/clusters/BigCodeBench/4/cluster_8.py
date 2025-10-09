# Clone cot llama4:latest-complete 1 nfr1
def task_func(d):
    result = {}
    for v in d.values():
        for i in v:
            if isinstance(i, int):
                result[i] = result.get(i, 0) + 1
            else:
                raise TypeError('Non-integer value encountered')
    return result

