# Clone cot gpt-oss:20b-complete 1 nfr0
import random
import statistics


def task_func(LETTERS):
    rand_dict = {k: random.choices(range(101), k=random.randint(1, 10)) for
        k in LETTERS}
    sorted_keys = sorted(rand_dict, key=lambda k: statistics.mean(rand_dict
        [k]), reverse=True)
    return {k: rand_dict[k] for k in sorted_keys}

