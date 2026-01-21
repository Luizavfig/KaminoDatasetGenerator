# Cluster 0 - Representative clone zero-shot deepseek-r1:14b-code 1 ['refac_3,refac_5,refac_7']
from collections import defaultdict
import matplotlib.pyplot as plt
import pandas as pd
import seaborn as sns


def task_func(list_of_menuitems):
    if not list_of_menuitems:
        return None
    flat_list = []
    for sublist in list_of_menuitems:
        if isinstance(sublist, list):
            for item in sublist:
                flat_list.append(item)
    if not flat_list:
        return None
    counter = defaultdict(int)
    for item in flat_list:
        counter[item] += 1
    df = pd.DataFrame.from_dict(counter, orient='index', columns=['Count']
        ).reset_index()
    df.columns = ['Item', 'Count']
    if df.empty:
        return None
    sns.set(style='darkgrid')
    ax = sns.barplot(y='Item', x='Count', data=df, palette='plasma')
    plt.tight_layout()
    return ax

# Cluster 1 - Representative clone zero-shot deepseek-r1:14b-test 1 ['refac_2,refac_6,refac_7']
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

# Cluster 2 - Representative clone cot gpt-oss:20b-code 1 ['refac_1,refac_3,refac_7']
import itertools
import collections
import pandas as pd
import seaborn as sns
import matplotlib.pyplot as plt


def task_func(list_of_menuitems):
    flat = list(itertools.chain.from_iterable(list_of_menuitems))
    if not flat:
        return None
    freq = collections.Counter(flat)
    df = pd.DataFrame(list(freq.items()), columns=['Item', 'Count'])
    if df.empty:
        return None
    sns.set_theme(style='whitegrid')
    ax = sns.barplot(data=df, x='Count', y='Item', palette='muted')
    plt.tight_layout()
    return ax

