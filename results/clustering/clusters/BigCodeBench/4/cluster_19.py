# Clone zero-shot llama3.1:latest-translation 1 nfr0
from typing import Dict, List


def task_func(d: Dict[str, List[int]]) ->Dict[int, int]:
    count_dict = {}
    for list_ in d.values():
        for s in list_:
            count_dict[s] = count_dict.get(s, 0) + 1
    return {k: v for k, v in count_dict.items()}

# Clone zero-shot llama3.1:latest-translation 1 nfr2
from typing import Dict, List
from collections import defaultdict


def task_func(d: Dict[str, List[int]]) ->Dict[int, int]:
    count_dict = defaultdict(int)
    for list_ in d.values():
        for num in list_:
            count_dict[num] += 1
    return dict(count_dict)

# Clone zero-shot llama3.1:latest-translation 1 nfr4
from typing import Dict, List


def task_func(d: Dict[str, List[int]]) ->Dict[int, int]:
    count_dict = {}
    for key, value in d.items():
        for num in value:
            count_dict[num] = count_dict.get(num, 0) + 1
    return {key: value for key, value in count_dict.items()}

# Clone zero-shot llama3.1:latest-translation 1 nfr5
from typing import Dict, List


def task_func(d: Dict[str, List[int]]) ->Dict[int, int]:
    count_dict = {}
    for key, value in d.items():
        for num in value:
            count_dict[num] = count_dict.get(num, 0) + 1
    return count_dict

# Clone zero-shot deepseek-r1-ast 1 nfr2
import sys
from collections import defaultdict
import json
import re
from typing import Dict, List, Any


def task_func(d: Dict[str, List[int]]) ->Dict[Any, int]:
    count_dict = defaultdict(int)
    for key in d:
        for num in d[key]:
            count_dict[num] += 1
    return dict(count_dict)


if __name__ == '__main__':
    import doctest
    doctest.testmod()

# Clone zero-shot deepseek-r1-translation 1 nfr2
from collections import defaultdict, Counter
from typing import Dict, List, Mapping, Any


def task_func(d: Dict[str, List[int]]) ->Dict[int, int]:
    count_dict = defaultdict(int)
    for sublist in d.values():
        for num in sublist:
            count_dict[num] += 1
    return {k: v for k, v in count_dict.items()}

# Clone zero-shot llama4:latest-minimal 1 nfr2
from collections import defaultdict
from typing import Dict, List


def task_func(d: Dict[str, List[int]]) ->Dict[int, int]:
    count_dict = defaultdict(int)
    for value in d.values():
        for num in value:
            count_dict[num] += 1
    return dict(count_dict)

# Clone zero-shot llama4:latest-requirements 1 nfr2
from collections import defaultdict
from typing import Dict, List


def task_func(d: Dict[str, List[int]]) ->Dict[int, int]:
    result = defaultdict(int)
    for value in d.values():
        for num in value:
            result[num] += 1
    return dict(result)

# Clone zero-shot llama4:latest-translation 1 nfr2
from collections import defaultdict
from typing import Dict, List


def task_func(d: Dict[str, List[int]]) ->Dict[int, int]:
    count_dict: Dict[int, int] = defaultdict(int)
    for lst in d.values():
        for num in lst:
            count_dict[num] += 1
    return dict(count_dict)

# Clone zero-shot llama4:latest-translation 1 nfr5
from typing import Dict, List


def task_func(d: Dict[str, List[int]]) ->Dict[int, int]:
    count_dict: Dict[int, int] = {}
    for value in d.values():
        for item in value:
            count_dict[item] = count_dict.get(item, 0) + 1
    return count_dict

# Clone few-shot llama3.1:latest-translation 1 nfr0
from typing import Dict, List


def task_func(d: Dict[str, List[int]]) ->Dict[int, int]:
    count_dict = {}
    for key in d:
        for value in d[key]:
            if value not in count_dict:
                count_dict[value] = 1
            else:
                count_dict[value] += 1
    return count_dict

# Clone few-shot llama3.1:latest-translation 1 nfr1
from typing import Dict, List


def task_func(d: Dict[str, List[int]]) ->Dict[int, int]:
    count_dict = {}
    for list_ in d.values():
        for s in list_:
            count_dict[s] = count_dict.get(s, 0) + 1
    return {int(k): v for k, v in count_dict.items()}

# Clone few-shot llama3.1:latest-translation 1 nfr2
from typing import Dict, List
from collections import defaultdict


def task_func(d: Dict[str, List[int]]) ->Dict[int, int]:
    count_dict = defaultdict(int)
    for lst in d.values():
        for num in lst:
            count_dict[num] += 1
    return dict(count_dict)

# Clone few-shot llama3.1:latest-translation 1 nfr4
from typing import Dict, List


def task_func(d: Dict[str, List[int]]) ->Dict[int, int]:
    count_dict = {}
    for key, value in d.items():
        for num in value:
            count_dict[num] = count_dict.get(num, 0) + 1
    return {int(key): value for key, value in count_dict.items()}

# Clone few-shot llama3.1:latest-translation 1 nfr5
from typing import Dict, List


def task_func(d: Dict[str, List[int]]) ->Dict[int, int]:
    count_dict = {}
    for key, value in d.items():
        for num in value:
            count_dict[num] = count_dict.get(num, 0) + 1
    return {int(key): value for key, value in count_dict.items()}

# Clone cot llama3.1:latest-translation 1 nfr2
from typing import Dict, List
from collections import defaultdict


def task_func(d: Dict[str, List[int]]) ->Dict[int, int]:
    count_dict = defaultdict(int)
    for list_ in d.values():
        for s in list_:
            count_dict[s] += 1
    return dict(count_dict)

# Clone cot llama3.1:latest-translation 1 nfr5
from typing import Dict, List


def task_func(d: Dict[str, List[int]]) ->Dict[int, int]:
    count_dict = {}
    for list_ in d.values():
        for s in list_:
            count_dict[s] = count_dict.get(s, 0) + 1
    return {int(k): v for k, v in count_dict.items()}

# Clone few-shot deepseek-r1-translation 1 nfr2
from collections import defaultdict, Counter
from typing import Dict, List, Union


def task_func(d: Dict[str, List[int]]) ->Dict[Union[int, str], int]:
    count_dict = defaultdict(int)
    for sublist in d.values():
        for num in sublist:
            count_dict[num] += 1
    return {k: v for k, v in count_dict.items()}

# Clone cot deepseek-r1-translation 1 nfr2
from collections import defaultdict, Counter
from typing import Dict, List, Union


def task_func(d: Dict[str, List[int]]) ->Dict[Union[int, str], int]:
    count_dict = defaultdict(int)
    for inner_list in d.values():
        for num in inner_list:
            count_dict[num] += 1
    return dict(count_dict)

# Clone cot deepseek-r1-translation 1 nfr5
from collections import defaultdict
from typing import Dict, List


def task_func(d: Dict[str, List[int]]) ->Dict[int, int]:
    count_dict = defaultdict(int)
    for sublist in d.values():
        for num in sublist:
            count_dict[num] += 1
    return dict(count_dict)

# Clone few-shot llama4:latest-minimal 1 nfr2
from collections import defaultdict
from typing import Dict, List


def task_func(d: Dict[str, List[int]]) ->Dict[int, int]:
    count_dict = defaultdict(int)
    for value in d.values():
        for num in value:
            count_dict[num] += 1
    return dict(count_dict)

# Clone cot llama4:latest-minimal 1 nfr2
from collections import defaultdict
from typing import Dict, List


def task_func(d: Dict[str, List[int]]) ->Dict[int, int]:
    count_dict = defaultdict(int)
    for value in d.values():
        for num in value:
            count_dict[num] += 1
    return dict(count_dict)

# Clone cot llama4:latest-requirements 1 nfr2
from collections import defaultdict
from typing import Dict, List


def task_func(d: Dict[str, List[int]]) ->Dict[int, int]:
    count_dict = defaultdict(int)
    for value in d.values():
        for num in value:
            count_dict[num] += 1
    return dict(count_dict)

# Clone cot llama4:latest-ast 1 nfr5
from typing import Dict, List


def task_func(d: Dict[str, List[int]]) ->Dict[int, int]:
    count_dict = {}
    for value in d.values():
        for integer in value:
            if integer in count_dict:
                count_dict[integer] += 1
            else:
                count_dict[integer] = 1
    return count_dict

# Clone zero-shot gpt-oss:20b-uml 1 nfr5
import collections
import itertools
from typing import Dict, List


def task_func(d: Dict[str, List[int]]) ->Dict[int, int]:
    count_dict = collections.Counter(itertools.chain.from_iterable(d.values()))
    return dict(count_dict)

# Clone few-shot gpt-oss:20b-uml 1 nfr2
import collections
import itertools
from typing import Dict, List


def task_func(d: Dict[str, List[int]]) ->Dict[int, int]:
    count_dict = collections.Counter(itertools.chain.from_iterable(d.values()))
    return dict(count_dict)

