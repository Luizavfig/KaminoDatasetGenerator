# Clone zero-shot deepseek-r1:14b-test 1 ['refac_3,refac_5,refac_7']
import matplotlib.pyplot as plt
import seaborn as sns
from collections import Counter


def task_func(list_of_menuitems):
    if not list_of_menuitems:
        return None
    flat_list = [item for menu in list_of_menuitems for item in menu]
    counts = Counter(flat_list)
    fig, ax = plt.subplots()
    sns.barplot(x=counts.values(), y=counts.keys(), ax=ax)
    return ax

# Clone zero-shot deepseek-r1:14b-test 1 ['refac_2,refac_5,refac_6']
import matplotlib.pyplot as plt
import seaborn as sns
from collections import Counter


def task_func(list_of_menuitems):
    if not list_of_menuitems:
        return None
    all_items = [item for sublist in list_of_menuitems for item in sublist]
    counts = Counter(all_items)
    fig, ax = plt.subplots()
    sns.barplot(x=counts.keys(), y=counts.values(), ax=ax)
    return ax

# Clone zero-shot deepseek-r1:14b-test 1 ['refac_1,refac_4,refac_5']
import matplotlib.pyplot as plt
import seaborn as sns
from collections import defaultdict


def task_func(list_of_menuitems):
    if not list_of_menuitems:
        return None
    items = [item for menu in list_of_menuitems for item in menu]
    counts = defaultdict(int)
    for item in items:
        counts[item] += 1
    if not counts:
        return None
    fig, ax = plt.subplots()
    sns.barplot(x=list(counts.keys()), y=list(counts.values()), ax=ax)
    return ax

# Clone zero-shot deepseek-r1:14b-test 1 ['refac_2,refac_4,refac_6']
import matplotlib.pyplot as plt
import seaborn as sns
from collections import Counter


def task_func(list_of_menuitems):
    if not list_of_menuitems:
        return None
    flat_list = [item for menu in list_of_menuitems for item in menu]
    counts = Counter(flat_list)
    fig, ax = plt.subplots()
    sns.barplot(x=counts.keys(), y=counts.values(), ax=ax)
    return ax

# Clone zero-shot gpt-oss:20b-complete 1 ['refac_1,refac_3,refac_4']
import collections
import pandas as pd
import seaborn as sns
import matplotlib.pyplot as plt


def task_func(list_of_menuitems):
    if not list_of_menuitems:
        return None
    flat = [item for sub in list_of_menuitems for item in sub]
    if not flat:
        return None
    counts = collections.Counter(flat)
    df = pd.DataFrame(list(counts.items()), columns=['Item', 'Count'])
    if df.empty:
        return None
    sns.set_style('whitegrid')
    ax = sns.barplot(x='Count', y='Item', data=df, palette='viridis')
    plt.tight_layout()
    return ax

# Clone cot gpt-oss:20b-test 1 ['refac_1,refac_3,refac_4']
import seaborn as sns
import pandas as pd
from collections import Counter


def task_func(list_of_menuitems):
    flat = [item for sub in list_of_menuitems for item in sub]
    if not flat:
        return None
    counts = Counter(flat)
    df = pd.DataFrame(list(counts.items()), columns=['item', 'count'])
    ax = sns.barplot(x='item', y='count', data=df)
    return ax

# Clone zero-shot deepseek-r1:14b-test 1 ['refac_2,refac_6,refac_7']
import matplotlib.pyplot as plt
import seaborn as sns
from collections import Counter


def task_func(list_of_menuitems):
    if not list_of_menuitems:
        return None
    flat_list = [item for sublist in list_of_menuitems for item in sublist]
    counts = Counter(flat_list)
    fig, ax = plt.subplots()
    sns.barplot(x=counts.keys(), y=counts.values(), ax=ax)
    return ax

# Clone zero-shot deepseek-r1:14b-complete 1 ['refac_2,refac_6,refac_7']
from collections import defaultdict
import matplotlib.pyplot as plt
import seaborn as sns


def task_func(list_of_menuitems):
    if not list_of_menuitems:
        return None
    flat_list = [item for sublist in list_of_menuitems for item in sublist]
    if not flat_list:
        return None
    counts = defaultdict(int)
    for item in flat_list:
        counts[item] += 1
    df = {'Item': list(counts.keys()), 'Count': list(counts.values())}
    sns.set(style='whitegrid')
    ax = sns.barplot(x='Count', y='Item', data=df, palette='viridis')
    plt.tight_layout()
    return ax

# Clone zero-shot deepseek-r1:14b-test 1 ['refac_1,refac_3,refac_4']
import matplotlib.pyplot as plt
import seaborn as sns


def task_func(list_of_menuitems):
    if not list_of_menuitems:
        return None
    items = [item for menu in list_of_menuitems for item in menu]
    counts = {}
    for item in items:
        counts[item] = counts.get(item, 0) + 1
    if not counts:
        return None
    fig, ax = plt.subplots()
    sns.barplot(x=list(counts.keys()), y=list(counts.values()), ax=ax)
    return ax

# Clone zero-shot gpt-oss:20b-test 1 ['refac_1,refac_3,refac_4']
import seaborn as sns
import matplotlib.pyplot as plt
from collections import Counter


def task_func(list_of_menuitems):
    flat = [item for sublist in list_of_menuitems for item in sublist]
    if not flat:
        return None
    counts = Counter(flat)
    ax = sns.barplot(x=list(counts.keys()), y=list(counts.values()))
    return ax

# Clone zero-shot gpt-oss:20b-test 1 ['refac_1,refac_3,refac_7']
import matplotlib.pyplot as plt
import seaborn as sns
from collections import Counter


def task_func(list_of_menuitems):
    if not list_of_menuitems:
        return None
    flattened = [item for sublist in list_of_menuitems for item in sublist]
    if not flattened:
        return None
    counts = Counter(flattened)
    items = list(counts.keys())
    freq = list(counts.values())
    fig, ax = plt.subplots()
    sns.barplot(x=items, y=freq, ax=ax)
    return ax

# Clone cot deepseek-r1:14b-test 1 ['refac_2,refac_6,refac_7']
import matplotlib.pyplot as plt
import seaborn as sns
from collections import defaultdict


def task_func(list_of_menuitems):
    if not list_of_menuitems:
        return None
    items = [item for menu in list_of_menuitems for item in menu]
    counts = defaultdict(int)
    for item in items:
        counts[item] += 1
    if not counts:
        return None
    fig, ax = plt.subplots()
    sns.barplot(x=list(counts.keys()), y=list(counts.values()), ax=ax)
    return ax

# Clone cot deepseek-r1:14b-test 1 ['refac_3,refac_5,refac_7']
import matplotlib.pyplot as plt
import seaborn as sns
from collections import defaultdict


def task_func(list_of_menuitems):
    if not list_of_menuitems:
        return None
    items = [item for menu in list_of_menuitems for item in menu]
    counts = defaultdict(int)
    for item in items:
        counts[item] += 1
    if not counts:
        return None
    fig, ax = plt.subplots()
    sns.barplot(x=counts.keys(), y=counts.values(), ax=ax)
    return ax

# Clone cot deepseek-r1:14b-test 1 ['refac_2,refac_4,refac_6']
import matplotlib.pyplot as plt
import seaborn as sns
from collections import defaultdict


def task_func(list_of_menuitems):
    if not list_of_menuitems:
        return None
    items = [item for menu in list_of_menuitems for item in menu]
    counts = defaultdict(int)
    for item in items:
        counts[item] += 1
    if not counts:
        return None
    fig, ax = plt.subplots()
    sns.barplot(x=list(counts.keys()), y=list(counts.values()), ax=ax)
    return ax

# Clone zero-shot gemma3:latest-complete 1 ['refac_1,refac_4,refac_5']
import collections
import matplotlib.pyplot as plt
import seaborn as sns
import pandas as pd


def task_func(list_of_menuitems):
    if not list_of_menuitems or not any(list_of_menuitems):
        return None
    flat_list = [item for sublist in list_of_menuitems for item in sublist]
    if not flat_list:
        return None
    counter = collections.Counter(flat_list)
    df = pd.DataFrame(list(counter.items()), columns=['Item', 'Count'])
    if df.empty:
        return None
    sns.set(style='whitegrid')
    ax = sns.barplot(x='Count', y='Item', data=df, palette='viridis')
    plt.tight_layout()
    return ax

# Clone cot deepseek-r1:14b-test 1 ['refac_1,refac_4,refac_5']
import matplotlib.pyplot as plt
import seaborn as sns
from collections import defaultdict


def task_func(list_of_menuitems):
    if not list_of_menuitems:
        return None
    items = [item for menu in list_of_menuitems for item in menu]
    counts = defaultdict(int)
    for item in items:
        counts[item] += 1
    if not counts:
        return None
    fig, ax = plt.subplots()
    sns.barplot(x=list(counts.keys()), y=list(counts.values()), ax=ax)
    return ax

# Clone zero-shot deepseek-r1:14b-complete 1 ['refac_1,refac_3,refac_7']
from collections import defaultdict
import matplotlib.pyplot as plt
import seaborn as sns


def task_func(list_of_menuitems):
    if not list_of_menuitems:
        return None
    flat_list = [item for sublist in list_of_menuitems for item in sublist]
    if not flat_list:
        return None
    counts = defaultdict(int)
    for item in flat_list:
        counts[item] += 1
    df = {'Item': list(counts.keys()), 'Count': list(counts.values())}
    sns.set(style='whitegrid')
    ax = sns.barplot(x='Count', y='Item', data=df, palette='viridis')
    plt.tight_layout()
    return ax

# Clone cot gpt-oss:20b-test 1 ['refac_2,refac_6,refac_7']
import seaborn as sns
import matplotlib.pyplot as plt
from collections import Counter


def task_func(list_of_menuitems):
    flat = [item for sublist in list_of_menuitems for item in sublist]
    if not flat:
        return None
    counts = Counter(flat)
    ax = sns.barplot(x=list(counts.keys()), y=list(counts.values()))
    return ax

# Clone zero-shot deepseek-r1:14b-ast 1 ['refac_2,refac_5,refac_6']
import matplotlib.pyplot as plt
from collections import Counter
import pandas as pd
import seaborn as sns


def task_func(list_of_menuitems):
    if not list_of_menuitems and not any(list_of_menuitems):
        return None
    flat_list = [item for sublist in list_of_menuitems for item in sublist]
    if not flat_list:
        return None
    counter = Counter(flat_list)
    df = pd.DataFrame(counter.items(), columns=['Item', 'Count'])
    if df.empty:
        return None
    sns.set(style='whitegrid')
    ax = sns.barplot(x='Count', y='Item', data=df, palette='viridis')
    plt.tight_layout()
    return ax

# Clone cot gpt-oss:20b-complete 1 ['refac_1,refac_4,refac_5']
from collections import Counter
import matplotlib.pyplot as plt
import pandas as pd
import seaborn as sns


def task_func(list_of_menuitems):
    if not list_of_menuitems:
        return None
    flat = [item for sub in list_of_menuitems for item in sub]
    if not flat:
        return None
    counts = Counter(flat)
    df = pd.DataFrame(list(counts.items()), columns=['Item', 'Count'])
    ax = sns.barplot(x='Count', y='Item', data=df, palette='viridis')
    plt.tight_layout()
    return ax

# Clone zero-shot gemma3:latest-test 1 ['refac_1,refac_3,refac_4']
import matplotlib.pyplot as plt


def task_func(list_of_menuitems):
    if not list_of_menuitems:
        return None
    items = [item for menu in list_of_menuitems for item in menu]
    counts = {}
    for item in items:
        counts[item] = counts.get(item, 0) + 1
    if not counts:
        return None
    fig, ax = plt.subplots()
    bars = ax.bar(counts.keys(), counts.values())
    ax.set_title('Menu Item Frequencies')
    ax.set_xlabel('Item')
    ax.set_ylabel('Count')
    return ax

# Clone cot gpt-oss:20b-test 1 ['refac_1,refac_3,refac_7']
import seaborn as sns
import matplotlib.pyplot as plt
from collections import Counter
import pandas as pd


def task_func(list_of_menuitems):
    flattened = [item for sublist in list_of_menuitems for item in sublist]
    if not flattened:
        return None
    counts = Counter(flattened)
    df = pd.DataFrame(list(counts.items()), columns=['item', 'count'])
    ax = sns.barplot(data=df, x='item', y='count')
    return ax

# Clone cot gpt-oss:20b-complete 1 ['refac_2,refac_5,refac_6']
import collections
import pandas as pd
import seaborn as sns
import matplotlib.pyplot as plt


def task_func(list_of_menuitems):
    flat = [item for sub in list_of_menuitems for item in sub]
    if not flat:
        return None
    counts = collections.Counter(flat)
    df = pd.DataFrame(list(counts.items()), columns=['Item', 'Count'])
    if df.empty:
        return None
    sns.set_style('whitegrid')
    ax = sns.barplot(x='Count', y='Item', data=df, palette='viridis')
    plt.tight_layout()
    return ax

# Clone zero-shot gpt-oss:20b-test 1 ['refac_2,refac_5,refac_6']
import matplotlib.pyplot as plt
import seaborn as sns
from collections import Counter


def task_func(list_of_menuitems):
    if not list_of_menuitems:
        return None
    flat_items = [item for sublist in list_of_menuitems for item in sublist]
    if not flat_items:
        return None
    counts = Counter(flat_items)
    items, freq = zip(*counts.items())
    fig, ax = plt.subplots()
    sns.barplot(x=list(items), y=list(freq), ax=ax)
    return ax

# Clone cot gpt-oss:20b-test 1 ['refac_2,refac_4,refac_6']
import matplotlib.pyplot as plt
import seaborn as sns
import pandas as pd
from collections import Counter


def task_func(list_of_menuitems):
    items = [item for sublist in list_of_menuitems for item in sublist]
    if not items:
        return None
    counts = Counter(items)
    df = pd.DataFrame(list(counts.items()), columns=['item', 'count'])
    ax = sns.barplot(data=df, x='item', y='count')
    return ax

# Clone zero-shot llama3.1:latest-ast 1 ['refac_3,refac_5,refac_7']
import pandas as pd
import seaborn as sns
import matplotlib.pyplot as plt


def task_func(list_of_menuitems):
    flat_list = [item for sublist in list_of_menuitems for item in sublist]
    if not flat_list:
        return None
    counter = pd.Series(flat_list).value_counts()
    df = pd.DataFrame({'Item': counter.index, 'Count': counter.values})
    if df.empty:
        return None
    sns.set(style='whitegrid')
    ax = sns.barplot(x='Count', y='Item', data=df, palette='viridis')
    plt.tight_layout()
    return ax

# Clone cot llama3.1:latest-ast 1 ['refac_3,refac_5,refac_7']
import collections as c
import matplotlib.pyplot as plt
import pandas as pd
import seaborn as sns


def task_func(list_of_menuitems):
    flat_list = [item for sublist in list_of_menuitems for item in sublist]
    if not flat_list:
        return None
    counter = c.Counter(flat_list)
    df = pd.DataFrame(list(counter.items()), columns=['Item', 'Count'])
    if df.empty:
        return None
    sns.set(style='whitegrid')
    ax = sns.barplot(x='Count', y='Item', data=df, palette='viridis')
    plt.tight_layout()
    return ax

# Clone zero-shot llama3.1:latest-ast 1 ['refac_2,refac_4,refac_6']
import pandas as pd
import seaborn as sns
import matplotlib.pyplot as plt
from collections import Counter


def task_func(list_of_menuitems):
    flat_list = [item for sublist in list_of_menuitems for item in sublist]
    if not flat_list:
        return None
    counter = Counter(flat_list)
    df = pd.DataFrame(counter.items(), columns=['Item', 'Count'])
    if df.empty:
        return None
    sns.set(style='whitegrid')
    ax = sns.barplot(x='Count', y='Item', data=df, palette='viridis')
    plt.tight_layout()
    return ax

# Clone cot gpt-oss:20b-complete 1 ['refac_1,refac_3,refac_4']
import matplotlib.pyplot as plt
import seaborn as sns
import pandas as pd
from collections import Counter


def task_func(list_of_menuitems):
    if not list_of_menuitems or not any(list_of_menuitems):
        return None
    flat_list = [item for sublist in list_of_menuitems for item in sublist]
    if not flat_list:
        return None
    counts = Counter(flat_list)
    df = pd.DataFrame(list(counts.items()), columns=['Item', 'Count'])
    if df.empty:
        return None
    sns.set_style('whitegrid')
    ax = sns.barplot(x='Count', y='Item', data=df, palette='viridis')
    plt.tight_layout()
    return ax

