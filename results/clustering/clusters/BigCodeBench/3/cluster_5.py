# Clone zero-shot llama3.1:latest-translation 1 nfr1
import random
import statistics


def task_func(letters):
    random_dict = {}
    for letter in letters:
        size = random.randint(1, 10)
        values = [random.uniform(0, 100) for _ in range(size)]
        random_dict[letter] = values
    mean_dict = {}
    for key, value in random_dict.items():
        mean_dict[key] = statistics.mean(value)
    return mean_dict

# Clone zero-shot llama3.1:latest-translation 1 nfr5
import random
from typing import List, Dict


def task_func(letters: List[str]) ->Dict[str, float]:
    random_dict = {}
    for letter in letters:
        size = random.randint(1, 10)
        values = [random.uniform(0, 100) for _ in range(size)]
        random_dict[letter] = values
    mean_dict = {key: (sum(values) / len(values)) for key, values in
        random_dict.items()}
    return mean_dict

# Clone zero-shot deepseek-r1-translation 1 nfr0
import random


def task_func(letters):
    random_dict = {}
    for letter in letters:
        size = random.randint(1, 10)
        values = [random.uniform(0, 100) for _ in range(size)]
        random_dict[letter] = values
    mean_dict = {}
    for key, value_list in random_dict.items():
        if len(value_list) > 0:
            mean_val = sum(value_list) / len(value_list)
            mean_dict[key] = round(mean_val, 1)
    return mean_dict

# Clone zero-shot deepseek-r1-translation 1 nfr1
import random


def task_func(letters):
    random_dict = {}
    for letter in letters:
        size = random.randint(1, 10)
        values = [random.uniform(0, 100) for _ in range(size)]
        random_dict[letter] = values
    mean_dict = {}
    for key, value_list in random_dict.items():
        if len(value_list) > 0:
            mean = sum(value_list) / len(value_list)
            mean_dict[key] = round(mean, 2)
    return mean_dict

# Clone zero-shot deepseek-r1-translation 1 nfr2
import random
from typing import List, Dict


def task_func(letters: List[str]) ->Dict[str, float]:
    random_dict = {}
    for letter in letters:
        size = random.randint(1, 10)
        values = [random.uniform(0, 100) for _ in range(size)]
        random_dict[letter] = values
    mean_dict = {}
    for key, value_list in random_dict.items():
        if len(value_list) > 0:
            mean = sum(value_list) / len(value_list)
            mean_dict[key] = round(mean, 2)
    return mean_dict

# Clone zero-shot deepseek-r1-translation 1 nfr3
import random


def task_func(letters):
    random_dict = {}
    for letter in letters:
        size = random.randint(1, 10)
        values = [random.uniform(0, 100) for _ in range(size)]
        random_dict[letter] = values
    mean_dict = {}
    for key, value_list in random_dict.items():
        if len(value_list) > 0:
            mean = sum(value_list) / len(value_list)
            mean_dict[key] = round(mean, 2)
    return mean_dict

# Clone zero-shot deepseek-r1-translation 1 nfr4
import random


def task_func(letters):
    random_dict = {}
    for letter in letters:
        size = random.randint(1, 10)
        values = [random.uniform(0, 100) for _ in range(size)]
        random_dict[letter] = values
    mean_dict = {}
    for key, value_list in random_dict.items():
        if len(value_list) > 0:
            mean = sum(value_list) / len(value_list)
            mean_dict[key] = round(mean, 2)
    return mean_dict

# Clone zero-shot deepseek-r1-translation 1 nfr5
import random


def task_func(letters):
    random_dict = {}
    for letter in letters:
        size = random.randint(1, 10)
        values = [random.uniform(0, 100) for _ in range(size)]
        random_dict[letter] = values
    mean_dict = {}
    for key, value_list in random_dict.items():
        if len(value_list) > 0:
            mean = sum(value_list) / len(value_list)
            mean_dict[key] = round(mean, 2)
    return mean_dict

# Clone zero-shot llama4:latest-translation 1 nfr0
import random
from typing import Dict, List


def task_func(letters: List[str]) ->Dict[str, float]:
    random_dict = {}
    for letter in letters:
        size = random.randint(1, 10)
        values = [random.uniform(0, 100) for _ in range(size)]
        random_dict[letter] = values
    mean_dict = {key: (sum(values) / len(values)) for key, values in
        random_dict.items()}
    return mean_dict


print(task_func(['a', 'b', 'c']))

# Clone zero-shot llama4:latest-translation 1 nfr1
import random


def task_func(LETTERS):
    random_dict = {}
    for letter in LETTERS:
        size = random.randint(1, 10)
        values = [random.uniform(0, 100) for _ in range(size)]
        random_dict[letter] = sum(values) / len(values)
    return random_dict

# Clone zero-shot llama4:latest-translation 1 nfr3
import random
from typing import Dict, List


def task_func(letters: List[str]) ->Dict[str, float]:
    random_dict: Dict[str, list[float]] = {}
    for letter in letters:
        size = random.randint(1, 10)
        values = [random.uniform(0, 100) for _ in range(size)]
        random_dict[letter] = values
    mean_dict: Dict[str, float] = {}
    for letter, values in random_dict.items():
        mean_dict[letter] = sum(values) / len(values)
    return mean_dict


print(task_func(['a', 'b', 'c']))

# Clone zero-shot llama4:latest-translation 1 nfr4
import random
from typing import Dict, List


def task_func(letters: List[str]) ->Dict[str, float]:
    random_dict = {}
    for letter in letters:
        size = random.randint(1, 10)
        values = [random.uniform(0, 100) for _ in range(size)]
        random_dict[letter] = values
    mean_dict = {key: (sum(values) / len(values)) for key, values in
        random_dict.items()}
    return mean_dict


print(task_func(['a', 'b', 'c']))

# Clone zero-shot llama4:latest-translation 1 nfr5
import random
from typing import Dict, List


def task_func(letters: List[str]) ->Dict[str, float]:
    random_dict = {}
    for letter in letters:
        size = random.randint(1, 10)
        values = [random.uniform(0, 100) for _ in range(size)]
        random_dict[letter] = values
    mean_dict = {key: (sum(values) / len(values)) for key, values in
        random_dict.items()}
    return mean_dict


print(task_func(['a', 'b', 'c']))

# Clone cot llama3.1:latest-translation 1 nfr3
import random
from typing import List, Dict


def task_func(letters: List[str]) ->Dict[str, float]:
    random_dict = {}
    for letter in letters:
        size = random.randint(1, 10)
        values = [random.uniform(0, 100) for _ in range(size)]
        random_dict[letter] = values
    mean_dict = {}
    for key, values in random_dict.items():
        mean_dict[key] = sum(values) / len(values)
    return mean_dict

# Clone cot llama3.1:latest-translation 1 nfr4
import random
from typing import List, Dict


def task_func(letters: List[str]) ->Dict[str, float]:
    random_dict = {}
    for letter in letters:
        size = random.randint(1, 10)
        values = [random.uniform(0, 100) for _ in range(size)]
        random_dict[letter] = values
    mean_dict = {}
    for key, values in random_dict.items():
        mean_dict[key] = sum(values) / len(values)
    return mean_dict

# Clone cot llama3.1:latest-translation 1 nfr5
import random
from typing import List, Dict


def task_func(letters: List[str]) ->Dict[str, float]:
    random_dict = {}
    for letter in letters:
        size = random.randint(1, 10)
        values = [random.uniform(0, 100) for _ in range(size)]
        random_dict[letter] = values
    mean_dict = {}
    for key, values in random_dict.items():
        mean_dict[key] = sum(values) / len(values)
    return mean_dict

# Clone few-shot deepseek-r1-translation 1 nfr0
import random


def task_func(letters):
    random_dict = {}
    for letter in letters:
        size = random.randint(1, 10)
        values = [random.uniform(0, 100) for _ in range(size)]
        random_dict[letter] = values
    mean_dict = {}
    for key, value_list in random_dict.items():
        if len(value_list) == 0:
            mean = 0.0
        else:
            mean = sum(value_list) / len(value_list)
        mean_dict[key] = round(mean, 10)
    return mean_dict

# Clone few-shot deepseek-r1-translation 1 nfr1
import random


def task_func(letters):
    random_dict = {}
    for letter in letters:
        size = random.randint(1, 10)
        values = [random.uniform(0, 100) for _ in range(size)]
        random_dict[letter] = values
    mean_dict = {}
    for key, value_list in random_dict.items():
        if len(value_list) == 0:
            mean = 0.0
        else:
            mean = sum(value_list) / len(value_list)
        mean_dict[key] = round(mean, 10)
    return mean_dict

# Clone few-shot deepseek-r1-translation 1 nfr2
import random
from typing import List, Dict


def task_func(letters: List[str]) ->Dict[str, float]:
    random_dict = {}
    for letter in letters:
        size = random.randint(1, 10)
        values = [random.uniform(0, 100) for _ in range(size)]
        random_dict[letter] = values
    mean_dict = {}
    for key, value_list in random_dict.items():
        if value_list:
            mean = sum(value_list) / len(value_list)
            mean_dict[key] = round(mean, 10)
    return mean_dict

# Clone few-shot deepseek-r1-translation 1 nfr3
import random


def task_func(letters: list[str]) ->dict[str, float]:
    random_dict = {}
    for letter in letters:
        size = random.randint(1, 10)
        values = [random.uniform(0.0, 100.0) for _ in range(size)]
        random_dict[letter] = values
    mean_dict = {}
    for key, value_list in random_dict.items():
        if len(value_list) == 0:
            continue
        mean_value = sum(value_list) / len(value_list)
        mean_dict[key] = round(mean_value, 10)
    return mean_dict

# Clone few-shot deepseek-r1-translation 1 nfr5
import random


def task_func(letters: list[str]) ->dict[str, float]:
    random_dict = {}
    for letter in letters:
        size = random.randint(1, 10)
        values = [random.uniform(0.0, 100.0) for _ in range(size)]
        random_dict[letter] = values
    mean_dict = {}
    for key, value_list in random_dict.items():
        if len(value_list) == 0:
            mean = 0.0
        else:
            mean = sum(value_list) / len(value_list)
        mean_dict[key] = round(mean, 10)
    return mean_dict

# Clone cot deepseek-r1-translation 1 nfr0
import random


def task_func(letters):
    random_dict = {}
    for letter in letters:
        size = random.randint(1, 10)
        values = [random.uniform(0, 100) for _ in range(size)]
        random_dict[letter] = values
    mean_dict = {}
    for key, value_list in random_dict.items():
        if len(value_list) > 0:
            mean_dict[key] = sum(value_list) / len(value_list)
    return mean_dict

# Clone cot deepseek-r1-translation 1 nfr1
import random


def task_func(letters):
    random_dict = {}
    for letter in letters:
        size = random.randint(1, 10)
        values = [random.uniform(0, 100) for _ in range(size)]
        random_dict[letter] = values
    mean_dict = {}
    for key, value_list in random_dict.items():
        if len(value_list) > 0:
            mean_dict[key] = sum(value_list) / len(value_list)
    return mean_dict

# Clone cot deepseek-r1-translation 1 nfr2
import random
from typing import List, Dict


def task_func(letters: List[str]) ->Dict[str, float]:
    random_dict = {}
    for letter in letters:
        size = random.randint(1, 10)
        values = [random.uniform(0, 100) for _ in range(size)]
        random_dict[letter] = values
    mean_dict = {}
    for key, value_list in random_dict.items():
        if len(value_list) > 0:
            mean_dict[key] = sum(value_list) / len(value_list)
        else:
            mean_dict[key] = 0.0
    return mean_dict

# Clone cot deepseek-r1-translation 1 nfr3
import random


def task_func(letters):
    random_dict = {}
    for letter in letters:
        size = random.randint(1, 10)
        values = [random.uniform(0, 100) for _ in range(size)]
        random_dict[letter] = values
    mean_dict = {}
    for key, values in random_dict.items():
        if len(values) > 0:
            mean_value = sum(values) / len(values)
            mean_dict[key] = round(mean_value, 10)
        else:
            mean_dict[key] = 0.0
    return mean_dict

# Clone cot deepseek-r1-translation 1 nfr4
import random


def task_func(letters):
    random_dict = {}
    for letter in letters:
        size = random.randint(1, 10)
        values = [random.uniform(0, 100) for _ in range(size)]
        random_dict[letter] = values
    mean_dict = {}
    for key, value_list in random_dict.items():
        if len(value_list) > 0:
            mean_value = sum(value_list) / len(value_list)
            mean_dict[key] = round(mean_value, 2)
    return mean_dict

# Clone cot deepseek-r1-translation 1 nfr5
import random


def task_func(letters):
    random_dict = {}
    for letter in letters:
        size = random.randint(1, 10)
        values = [random.uniform(0, 100) for _ in range(size)]
        random_dict[letter] = values
    mean_dict = {}
    for key, value_list in random_dict.items():
        if len(value_list) > 0:
            mean = sum(value_list) / len(value_list)
            mean_dict[key] = round(mean, 2)
    return mean_dict

# Clone few-shot llama4:latest-translation 1 nfr0
import random


def task_func(LETTERS):
    random_dict = {}
    for letter in LETTERS:
        size = random.randint(1, 10)
        values = [random.uniform(0, 100) for _ in range(size)]
        random_dict[letter] = sum(values) / len(values)
    return random_dict

# Clone few-shot llama4:latest-translation 1 nfr1
import random


def task_func(LETTERS):
    random_dict = {}
    for letter in LETTERS:
        size = random.randint(1, 10)
        values = [random.uniform(0, 100) for _ in range(size)]
        random_dict[letter] = sum(values) / len(values)
    return random_dict

# Clone few-shot llama4:latest-translation 1 nfr3
import random
from typing import Dict, List


def task_func(letters: List[str]) ->Dict[str, float]:
    random_dict = {}
    for letter in letters:
        size = random.randint(1, 10)
        values = [random.uniform(0, 100) for _ in range(size)]
        random_dict[letter] = sum(values) / len(values)
    return random_dict


print(task_func(['a', 'b', 'c']))

# Clone few-shot llama4:latest-translation 1 nfr4
import random
from typing import Dict, List


def task_func(letters: List[str]) ->Dict[str, float]:
    random_dict = {}
    for letter in letters:
        size = random.randint(1, 10)
        values = [random.uniform(0, 100) for _ in range(size)]
        random_dict[letter] = sum(values) / len(values)
    return random_dict


print(task_func(['a', 'b', 'c']))

# Clone few-shot llama4:latest-translation 1 nfr5
import random
from typing import Dict, List


def task_func(letters: List[str]) ->Dict[str, float]:
    random_dict = {}
    for letter in letters:
        size = random.randint(1, 10)
        values = [random.uniform(0, 100) for _ in range(size)]
        random_dict[letter] = values
    mean_dict = {}
    for letter, values in random_dict.items():
        mean_dict[letter] = sum(values) / len(values)
    return mean_dict

# Clone cot llama4:latest-translation 1 nfr0
import random
from typing import Dict, List


def task_func(LETTERS: List[str]) ->Dict[str, float]:
    random_dict = {}
    for letter in LETTERS:
        size = random.randint(1, 10)
        values = [random.uniform(0, 100) for _ in range(size)]
        random_dict[letter] = values
    mean_dict = {}
    for letter, values in random_dict.items():
        mean_dict[letter] = sum(values) / len(values)
    return mean_dict

# Clone cot llama4:latest-translation 1 nfr1
import random


def task_func(LETTERS):
    random_dict = {}
    for letter in LETTERS:
        size = random.randint(1, 10)
        values = [random.uniform(0, 100) for _ in range(size)]
        random_dict[letter] = sum(values) / len(values)
    return random_dict

# Clone cot llama4:latest-translation 1 nfr3
import random
from typing import Dict, List


def task_func(letters: List[str]) ->Dict[str, float]:
    random_dict: Dict[str, list[float]] = {}
    for letter in letters:
        size = random.randint(1, 10)
        values = [random.uniform(0, 100) for _ in range(size)]
        random_dict[letter] = values
    mean_dict: Dict[str, float] = {}
    for letter, values in random_dict.items():
        mean_dict[letter] = sum(values) / len(values)
    return mean_dict

# Clone cot llama4:latest-translation 1 nfr4
import random
from typing import Dict, List


def task_func(letters: List[str]) ->Dict[str, float]:
    random_dict = {}
    for letter in letters:
        size = random.randint(1, 10)
        values = [random.uniform(0, 100) for _ in range(size)]
        random_dict[letter] = sum(values) / len(values)
    return random_dict

# Clone cot llama4:latest-translation 1 nfr5
import random
from typing import Dict, List


def task_func(letters: List[str]) ->Dict[str, float]:
    random_dict: Dict[str, list[float]] = {}
    for letter in letters:
        size = random.randint(1, 10)
        values = [random.uniform(0, 100) for _ in range(size)]
        random_dict[letter] = values
    mean_dict: Dict[str, float] = {}
    for letter, values in random_dict.items():
        mean_dict[letter] = sum(values) / len(values)
    return mean_dict

# Clone zero-shot gemma3:latest-translation 1 nfr0
import random


def task_func(LETTERS):
    random_dict = {}
    for letter in LETTERS:
        size = random.randint(1, 10)
        values = [random.uniform(0, 100) for _ in range(size)]
        random_dict[letter] = values
    mean_dict = {}
    for letter, values in random_dict.items():
        mean_dict[letter] = sum(values) / len(values)
    return mean_dict

# Clone zero-shot gemma3:latest-translation 1 nfr1
import random


def task_func(LETTERS):
    random_dict = {}
    for letter in LETTERS:
        size = random.randint(1, 10)
        values = [random.uniform(0, 100) for _ in range(size)]
        random_dict[letter] = values
    mean_dict = {}
    for letter, values in random_dict.items():
        mean_dict[letter] = sum(values) / len(values)
    return mean_dict

# Clone zero-shot gemma3:latest-translation 1 nfr3
import random


def task_func(LETTERS):
    random_dict = {}
    for letter in LETTERS:
        size = random.randint(1, 10)
        values = [random.uniform(0, 100) for _ in range(size)]
        random_dict[letter] = values
    mean_dict = {}
    for letter, values in random_dict.items():
        mean_dict[letter] = sum(values) / len(values)
    return mean_dict

# Clone zero-shot gemma3:latest-translation 1 nfr4
import random


def task_func(LETTERS):
    random_dict = {}
    for letter in LETTERS:
        size = random.randint(1, 10)
        values = [random.uniform(0, 100) for _ in range(size)]
        random_dict[letter] = values
    mean_dict = {}
    for letter, values in random_dict.items():
        mean_dict[letter] = sum(values) / len(values)
    return mean_dict

# Clone zero-shot gemma3:latest-translation 1 nfr5
import random


def task_func(LETTERS):
    random_dict = {}
    for letter in LETTERS:
        size = random.randint(1, 10)
        values = [random.uniform(0, 100) for _ in range(size)]
        random_dict[letter] = values
    mean_dict = {}
    for letter, values in random_dict.items():
        mean_dict[letter] = sum(values) / len(values)
    return mean_dict

# Clone few-shot gemma3:latest-translation 1 nfr0
import random
import numpy as np


def task_func(LETTERS):
    randomDict = {}
    for letter in LETTERS:
        size = random.randint(1, 10)
        values = [random.uniform(0, 100) for _ in range(size)]
        randomDict[letter] = values
    meanDict = {}
    for letter, values in randomDict.items():
        meanDict[letter] = np.mean(values)
    return meanDict

# Clone few-shot gemma3:latest-translation 1 nfr1
def task_func(LETTERS):
    randomDict = {}
    for letter in LETTERS:
        size = random.randint(1, 10)
        values = [random.uniform(0, 100) for _ in range(size)]
        randomDict[letter] = values
    meanDict = {}
    for letter, values in randomDict.items():
        meanDict[letter] = sum(values) / len(values)
    return meanDict


import random

# Clone few-shot gemma3:latest-translation 1 nfr3
import random


def task_func(LETTERS):
    randomDict = {}
    for letter in LETTERS:
        size = random.randint(1, 10)
        values = [random.uniform(0, 100) for _ in range(size)]
        randomDict[letter] = values
    meanDict = {}
    for letter, values in randomDict.items():
        meanDict[letter] = sum(values) / len(values)
    return meanDict

# Clone few-shot gemma3:latest-translation 1 nfr4
import random


def task_func(LETTERS):
    randomDict = {}
    for letter in LETTERS:
        size = random.randint(1, 10)
        values = [random.uniform(0, 100) for _ in range(size)]
        randomDict[letter] = values
    meanDict = {}
    for letter, values in randomDict.items():
        meanDict[letter] = sum(values) / len(values)
    return meanDict

# Clone few-shot gemma3:latest-translation 1 nfr5
import random
from typing import List, Dict


def task_func(letters: List[str]) ->Dict[str, float]:
    """
    Generates a dictionary where each key is a letter from the input list
    and the value is the mean of a randomly generated list of integers
    (with each list having 1 to 10 integers ranging from 0 to 100).
    """
    random_dict = {}
    for letter in letters:
        size = random.randint(1, 10)
        values = [random.uniform(0, 100) for _ in range(size)]
        random_dict[letter] = values
    mean_dict = {}
    for letter, values in random_dict.items():
        mean_dict[letter] = sum(values) / len(values)
    return mean_dict

# Clone cot gemma3:latest-translation 1 nfr0
import random


def task_func(letters):
    random_dict = {}
    for letter in letters:
        size = random.randint(1, 10)
        values = [random.uniform(0, 100) for _ in range(size)]
        random_dict[letter] = values
    mean_dict = {}
    for letter, values in random_dict.items():
        mean_dict[letter] = sum(values) / len(values)
    return mean_dict

# Clone cot gemma3:latest-translation 1 nfr1
import random


def task_func(LETTERS):
    randomDict = {}
    for letter in LETTERS:
        size = random.randint(1, 10)
        values = [random.uniform(0, 100) for _ in range(size)]
        randomDict[letter] = values
    meanDict = {}
    for letter, values in randomDict.items():
        meanDict[letter] = sum(values) / len(values)
    return meanDict

# Clone cot gemma3:latest-translation 1 nfr2
import random
import numpy as np


def task_func(LETTERS):
    meanDict = {}
    for letter in LETTERS:
        size = random.randint(1, 10)
        values = [random.uniform(0, 100) for _ in range(size)]
        meanDict[letter] = np.mean(values)
    return meanDict

# Clone cot gemma3:latest-translation 1 nfr3
import random
import numpy as np


def task_func(LETTERS):
    randomDict = {}
    for letter in LETTERS:
        size = random.randint(1, 10)
        values = [random.uniform(0, 100) for _ in range(size)]
        randomDict[letter] = values
    meanDict = {}
    for letter, values in randomDict.items():
        meanDict[letter] = np.mean(values)
    return meanDict

# Clone cot gemma3:latest-translation 1 nfr4
import random


def task_func(LETTERS):
    randomDict = {}
    for letter in LETTERS:
        size = random.randint(1, 10)
        values = [random.uniform(0, 100) for _ in range(size)]
        randomDict[letter] = values
    meanDict = {}
    for letter, values in randomDict.items():
        meanDict[letter] = sum(values) / len(values)
    return meanDict

# Clone cot gemma3:latest-translation 1 nfr5
import random


def task_func(LETTERS):
    randomDict = {}
    for letter in LETTERS:
        size = random.randint(1, 10)
        values = [random.uniform(0, 100) for _ in range(size)]
        randomDict[letter] = values
    meanDict = {}
    for letter, values in randomDict.items():
        meanDict[letter] = sum(values) / len(values)
    return meanDict

# Clone zero-shot gpt-oss:latest-translation 1 nfr5
import random
from typing import List, Dict


def task_func(LETTERS: List[str]) ->Dict[str, float]:
    random_dict: Dict[str, List[int]] = {}
    for letter in LETTERS:
        size = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(size)]
        random_dict[letter] = values
    mean_dict: Dict[str, float] = {}
    for letter, values in random_dict.items():
        mean = sum(values) / len(values) if values else 0.0
        mean_dict[letter] = mean
    return mean_dict


print(task_func(['a', 'b', 'c']))

# Clone cot gpt-oss:latest-translation 1 nfr0
import random


def task_func(LETTERS):
    random_dict = {}
    for letter in LETTERS:
        size = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(size)]
        random_dict[letter] = values
    mean_dict = {}
    for letter, values in random_dict.items():
        mean_dict[letter] = sum(values) / len(values) if values else 0.0
    return mean_dict


print(task_func(['a', 'b', 'c']))

# Clone cot gpt-oss:latest-translation 1 nfr4
import random


def task_func(letters):
    random_dict = {}
    for letter in letters:
        size = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(size)]
        random_dict[letter] = values
    mean_dict = {k: (sum(v) / len(v) if v else 0.0) for k, v in random_dict
        .items()}
    return mean_dict


print(task_func([]))

# Clone few-shot gpt-oss:20b-ast 1 nfr4
import random


def task_func(LETTERS):
    data = {}
    for letter in LETTERS:
        count = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(count)]
        data[letter] = values
    result = {}
    for letter, values in data.items():
        result[letter] = sum(values) / len(values)
    return result

# Clone cot gpt-oss:20b-ast 1 nfr5
import random


def task_func(LETTERS):
    random_dict = {}
    for key in LETTERS:
        length = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(length)]
        random_dict[key] = values
    mean_dict = {}
    for key, values in random_dict.items():
        mean_dict[key] = sum(values) / len(values)
    return mean_dict

