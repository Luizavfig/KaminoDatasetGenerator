# Clone cot gpt-oss:20b-code 1 ['refac_1,refac_3,refac_7']
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

