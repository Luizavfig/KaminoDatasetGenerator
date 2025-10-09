# Clone cot deepseek-r1-complete 1 nfr2
import random
from collections import Counter as char_counts


def task_func(length=100):
    if length < 0:
        raise ValueError
    valid_chars = string.ascii_uppercase + string.ascii_lowercase
    return dict(char_counts(random.choices(valid_chars, k=length)))

