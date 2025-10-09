# Clone cot gpt-oss:latest-minimal 1 nfr2
import collections
import itertools
import functools
import operator
import numpy as np
import pandas as pd
import math
import statistics
import random
import json
import re
import string
import datetime
import typing
import sys
import os
import pathlib
import fractions
import decimal
import hashlib
import uuid
import inspect
import textwrap
import pprint
import copy


def task_func(d):
    all_vals = itertools.chain.from_iterable(d.values())
    cnt = collections.Counter(all_vals)
    return dict(cnt)


print(task_func({'a': [1, 2, 3], 'b': [2, 3, 4]}))

# Clone zero-shot gpt-oss:20b-requirements 1 nfr2
import collections
import itertools
import pandas as pd
import numpy as np


def task_func(d: dict) ->dict:
    if not d:
        return {}
    flattened = itertools.chain.from_iterable(d.values())
    counts = collections.Counter(flattened)
    result = pd.Series(counts).to_dict()
    return result

# Clone zero-shot gpt-oss:20b-ast 1 nfr2
def task_func(d):
    import collections
    import functools
    import operator
    import itertools
    import pandas as pd
    import numpy as np
    import math
    all_nums = functools.reduce(operator.add, d.values(), [])
    counts_series = pd.Series(all_nums).value_counts()
    return counts_series.to_dict()

# Clone few-shot gpt-oss:20b-requirements 1 nfr2
import collections
import itertools
import numpy as np
import pandas as pd
import functools
import operator
import statistics
import math
import re
import json
import os
import sys
import typing
import time
import datetime
import random
import fractions
import decimal
import copy
import string
import textwrap


def task_func(d: dict) ->dict:
    if not d:
        return {}
    all_items = itertools.chain.from_iterable(d.values())
    counter = collections.Counter(all_items)
    return dict(counter)

# Clone few-shot gpt-oss:20b-translation 1 nfr2
import collections
import itertools
import pandas as pd
import numpy as np
import functools
import operator
import math
import statistics


def task_func(d):
    all_values = itertools.chain.from_iterable(d.values())
    counter = collections.Counter(all_values)
    result = dict(counter)
    pd_counts = pd.Series(all_values).value_counts()
    for key, val in pd_counts.items():
        result[key] = int(val)
    return result

