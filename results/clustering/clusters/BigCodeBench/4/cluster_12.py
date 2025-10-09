# Clone zero-shot llama3.1:latest-requirements 1 nfr2
from collections import Counter
from typing import Dict


def task_func(d: Dict[str, list]) ->Dict[int, int]:
    flat_list = [item for sublist in d.values() for item in sublist]
    return dict(Counter(flat_list))

# Clone few-shot llama3.1:latest-requirements 1 nfr0
from collections import Counter


def task_func(d):
    flat_list = [item for sublist in d.values() for item in sublist]
    return dict(Counter(flat_list))

# Clone few-shot llama3.1:latest-requirements 1 nfr3
from collections import Counter


def task_func(d):
    flat_list = [item for sublist in d.values() for item in sublist]
    return dict(Counter(flat_list))

# Clone few-shot llama3.1:latest-requirements 1 nfr4
from collections import Counter


def task_func(d):
    flat_list = [item for sublist in d.values() for item in sublist]
    return dict(Counter(flat_list))

# Clone few-shot llama3.1:latest-requirements 1 nfr5
from collections import Counter


def task_func(d):
    flat_list = [item for sublist in d.values() for item in sublist]
    return dict(Counter(flat_list))

# Clone cot llama3.1:latest-minimal 1 nfr2
from collections import Counter
from typing import Dict


def task_func(d: Dict[str, list[int]]) ->Dict[int, int]:
    flat_list = [item for sublist in d.values() for item in sublist]
    return dict(Counter(flat_list))

# Clone cot llama3.1:latest-requirements 1 nfr5
from collections import Counter


def task_func(d):
    flat_list = [item for sublist in d.values() for item in sublist]
    return dict(Counter(flat_list))

# Clone cot gpt-oss:latest-translation 1 nfr4
from collections import Counter


def task_func(d):
    return dict(Counter(num for lst in d.values() for num in lst))


print(task_func({}))

