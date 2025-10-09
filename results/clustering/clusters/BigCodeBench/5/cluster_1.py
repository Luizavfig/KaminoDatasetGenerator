# Clone cot llama3.1:latest-minimal 1 nfr2
import random
import numpy as np
from typing import List, Dict


def task_func(LETTERS: List[str]=list('abcdefghijklmnopqrstuvwxyz')):
    result_dict = {}
    for letter in LETTERS:
        num_list = [random.randint(0, 100) for _ in range(random.randint(1,
            10))]
        result_dict[letter] = np.std(num_list)
    return result_dict

# Clone zero-shot gpt-oss:latest-minimal 1 nfr4
import random
import string
import statistics
from typing import List, Dict, Optional


def task_func(LETTERS: Optional[List[str]]=None) ->Dict[str, float]:
    if LETTERS is None:
        LETTERS = list(string.ascii_lowercase)
    result = {}
    for letter in LETTERS:
        count = random.randint(1, 10)
        numbers = [random.randint(0, 100) for _ in range(count)]
        result[letter] = statistics.pstdev(numbers)
    return result


print(task_func())

# Clone few-shot gpt-oss:latest-ast 1 nfr0
import random
import string
import statistics


def task_func(LETTERS=None):
    if LETTERS is None:
        LETTERS = list(string.ascii_lowercase)
    random_dict = {}
    for key in LETTERS:
        length = random.randint(1, 10)
        random_dict[key] = [random.randint(0, 100) for _ in range(length)]
    sd_dict = {}
    for key, values in random_dict.items():
        sd_dict[key] = statistics.pstdev(values)
    return sd_dict


print(task_func())

# Clone few-shot gpt-oss:latest-ast 1 nfr4
import random
import string
import statistics


def task_func(LETTERS=None):
    if LETTERS is None:
        LETTERS = list(string.ascii_lowercase)
    result = {}
    for letter in LETTERS:
        count = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(count)]
        result[letter] = statistics.pstdev(values)
    return result


print(task_func())

# Clone few-shot gpt-oss:latest-ast 1 nfr5
import random
import string
import statistics


def task_func(LETTERS=None):
    if LETTERS is None:
        LETTERS = list(string.ascii_lowercase)
    random_dict = {}
    for letter in LETTERS:
        count = random.randint(1, 10)
        random_dict[letter] = [random.randint(0, 100) for _ in range(count)]
    sd_dict = {}
    for letter, values in random_dict.items():
        sd_dict[letter] = statistics.pstdev(values) if values else 0.0
    return sd_dict


print(task_func())

# Clone cot gpt-oss:latest-minimal 1 nfr3
import random
import statistics
import string


def task_func(LETTERS=None):
    if LETTERS is None:
        LETTERS = list(string.ascii_lowercase)
    result = {}
    for letter in LETTERS:
        length = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(length)]
        result[letter] = statistics.pstdev(values)
    return result


print(task_func())

# Clone cot gpt-oss:latest-requirements 1 nfr2
import random
import math
import statistics
import numpy as np
import pandas as pd


def task_func(LETTERS=None):
    if LETTERS is None:
        LETTERS = list('abcdefghijklmnopqrstuvwxyz')
    result = {}
    for letter in LETTERS:
        length = random.randint(1, 10)
        numbers = [random.randint(0, 100) for _ in range(length)]
        sd = statistics.pstdev(numbers)
        result[letter] = sd
    return result


print(task_func())

# Clone cot gpt-oss:latest-ast 1 nfr5
import random
import math
import string


def task_func(LETTERS=None):
    if LETTERS is None:
        LETTERS = list(string.ascii_lowercase)
    random_dict = {}
    for letter in LETTERS:
        length = random.randint(1, 10)
        random_dict[letter] = [random.randint(0, 100) for _ in range(length)]
    sd_dict = {}
    for letter, values in random_dict.items():
        mean = sum(values) / len(values)
        variance = sum((x - mean) ** 2 for x in values) / len(values)
        sd_dict[letter] = math.sqrt(variance)
    return sd_dict


print(task_func())

# Clone zero-shot gpt-oss:20b-minimal 1 nfr2
import random
import string
import numpy as np
import pandas as pd
import statistics


def task_func(LETTERS: (list[str] | None)=None) ->dict[str, float]:
    if LETTERS is None:
        LETTERS = list(string.ascii_lowercase)
    result: dict[str, float] = {}
    for letter in LETTERS:
        count = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(count)]
        std_dev = float(pd.Series(values).std(ddof=0))
        result[letter] = std_dev
    return result

# Clone zero-shot gpt-oss:20b-minimal 1 nfr5
import string
import random
import statistics


def task_func(LETTERS=None):
    if LETTERS is None:
        LETTERS = list(string.ascii_lowercase)
    std_dict = {}
    for letter in LETTERS:
        count = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(count)]
        std_dict[letter] = statistics.pstdev(values)
    return std_dict

# Clone zero-shot gpt-oss:20b-ast 1 nfr2
import random
import string
import numpy as np
import pandas as pd
import statistics


def task_func(LETTERS: (list[str] | None)=None) ->dict[str, float]:
    if LETTERS is None:
        LETTERS = list(string.ascii_lowercase)
    random_data = {}
    for letter in LETTERS:
        n = random.randint(1, 10)
        random_data[letter] = [random.randint(0, 100) for _ in range(n)]
    std_dict = {k: statistics.pstdev(v) for k, v in random_data.items()}
    return std_dict

# Clone zero-shot gpt-oss:20b-ast 1 nfr3
import random
import statistics
import string


def task_func(LETTERS=None):
    if LETTERS is None:
        LETTERS = list(string.ascii_lowercase)
    result = {}
    for key in LETTERS:
        n = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(n)]
        result[key] = statistics.pstdev(values)
    return result

# Clone zero-shot gpt-oss:20b-ast 1 nfr4
import random
import string
import statistics


def task_func(LETTERS=None):
    if LETTERS is None:
        LETTERS = list(string.ascii_lowercase)
    result = {}
    for key in LETTERS:
        length = random.randint(1, 10)
        numbers = [random.randint(0, 100) for _ in range(length)]
        result[key] = statistics.pstdev(numbers)
    return result

# Clone zero-shot gpt-oss:20b-ast 1 nfr5
import random
import math
import string


def task_func(LETTERS: (list[str] | None)=None) ->dict[str, float]:
    if LETTERS is None:
        LETTERS = list(string.ascii_lowercase)
    random_dict = {}
    for letter in LETTERS:
        count = random.randint(1, 10)
        random_dict[letter] = [random.randint(0, 100) for _ in range(count)]
    sd_dict = {}
    for letter, values in random_dict.items():
        mean = sum(values) / len(values)
        variance = sum((x - mean) ** 2 for x in values) / len(values)
        sd_dict[letter] = math.sqrt(variance)
    return sd_dict

# Clone zero-shot gpt-oss:20b-translation 1 nfr2
import random
import math
import statistics
import string
import itertools
import collections


def task_func(LETTERS=None):
    if LETTERS is None:
        LETTERS = list(string.ascii_lowercase)
    result = {}
    for letter in LETTERS:
        size = random.randint(1, 11)
        values = [random.randint(0, 100) for _ in range(size)]
        sd = statistics.pstdev(values)
        result[letter] = sd
    return result

# Clone few-shot gpt-oss:20b-minimal 1 nfr2
import random
import string
import statistics
import numpy as np
import pandas as pd
from collections import defaultdict
from typing import List, Dict


def task_func(LETTERS: List[str]=None) ->Dict[str, float]:
    if LETTERS is None:
        LETTERS = list(string.ascii_lowercase)
    result = {}
    for letter in LETTERS:
        count = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(count)]
        std_pstdev = statistics.pstdev(values)
        std_numpy = np.std(values, ddof=0)
        std_pandas = pd.Series(values).std(ddof=0)
        result[letter] = std_pstdev
    return result

# Clone few-shot gpt-oss:20b-requirements 1 nfr2
import random
import math
import string
import statistics
import numpy as np
import pandas as pd
import itertools
import collections
import functools
import operator
import re
import json
import datetime
import sys
import os
import typing


def task_func(LETTERS: typing.List[str]=None):
    if LETTERS is None:
        LETTERS = list(string.ascii_lowercase)
    result = {}
    for letter in LETTERS:
        length = random.randint(1, 10)
        numbers = [random.randint(0, 100) for _ in range(length)]
        sd = statistics.pstdev(numbers)
        result[letter] = sd
    return result

# Clone few-shot gpt-oss:20b-ast 1 nfr3
import random
import math
import string


def task_func(LETTERS=None):
    if LETTERS is None:
        LETTERS = list(string.ascii_lowercase)
    random_dict = {}
    for letter in LETTERS:
        count = random.randint(1, 10)
        random_dict[letter] = [random.randint(0, 100) for _ in range(count)]
    sd_dict = {}
    for letter, values in random_dict.items():
        n = len(values)
        mean = sum(values) / n
        var = sum((x - mean) ** 2 for x in values) / n
        sd_dict[letter] = math.sqrt(var)
    return sd_dict

# Clone few-shot gpt-oss:20b-translation 1 nfr2
import random
import string
import statistics


def task_func(LETTERS=None):
    if LETTERS is None:
        LETTERS = list(string.ascii_lowercase)
    result = {}
    for letter in LETTERS:
        size = random.randint(1, 11)
        values = [random.randint(0, 100) for _ in range(size)]
        result[letter] = statistics.pstdev(values)
    return result

# Clone cot gpt-oss:20b-ast 1 nfr1
import random


def task_func(LETTERS=None):
    if LETTERS is None:
        LETTERS = list('abcdefghijklmnopqrstuvwxyz')
    random_dict = {}
    for letter in LETTERS:
        count = random.randint(1, 10)
        random_dict[letter] = [random.randint(0, 100) for _ in range(count)]
    sd_dict = {}
    for letter, values in random_dict.items():
        n = len(values)
        mean = sum(values) / n
        variance = sum((x - mean) ** 2 for x in values) / n
        sd_dict[letter] = variance ** 0.5
    return sd_dict

# Clone cot gpt-oss:20b-ast 1 nfr2
import random
import statistics
import numpy as np
import math
import string
import itertools
import collections


def task_func(LETTERS=None):
    if LETTERS is None:
        LETTERS = list(string.ascii_lowercase)
    random_dict = {}
    for letter in LETTERS:
        count = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(count)]
        random_dict[letter] = values
    std_dict = {}
    for letter, values in random_dict.items():
        std_val = float(np.std(values, ddof=0))
        std_dict[letter] = std_val
    return std_dict

# Clone cot gpt-oss:20b-translation 1 nfr2
import random
import math
import statistics
import numpy as np
import string
from typing import List, Dict


def task_func(LETTERS: List[str]=None) ->Dict[str, float]:
    if LETTERS is None:
        LETTERS = list(string.ascii_lowercase)
    random_dict = {letter: [random.randint(0, 100) for _ in range(random.
        randint(1, 11))] for letter in LETTERS}
    sd_dict = {letter: float(np.std(values, ddof=0)) for letter, values in
        random_dict.items()}
    return sd_dict

