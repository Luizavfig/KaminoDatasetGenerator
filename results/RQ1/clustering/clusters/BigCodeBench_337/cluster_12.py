# Clone zero-shot deepseek-r1:14b-test 1 ['refac_2', 'refac_6', 'refac_7']
import pandas as pd
import numpy as np
import matplotlib.pyplot as plt
from collections import defaultdict


def task_func(df: pd.DataFrame, group_col: str, value_col: str) ->plt.Axes:
    grouped_data = df.groupby(group_col)
    means = grouped_data[value_col].mean()
    std_devs = grouped_data[value_col].std()
    fig, ax = plt.subplots()
    bars = ax.bar(means.index, means.values, color='b')
    ax.errorbar(means.index, means.values, yerr=std_devs.values, fmt='none',
        capsize=5, capthick=2, ecolor='r')
    ax.set_xlabel(group_col)
    ax.set_ylabel(value_col)
    ax.set_title(f'Bar Chart of {value_col} by {group_col}')
    return ax

# Clone zero-shot deepseek-r1:14b-test 1 ['refac_2', 'refac_5', 'refac_6']
import pandas as pd
import numpy as np
import matplotlib.pyplot as plt
from collections import defaultdict


def task_func(df: pd.DataFrame, group_col: str, value_col: str) ->plt.Axes:
    grouped_data = df.groupby(group_col)
    means = grouped_data[value_col].mean()
    std_devs = grouped_data[value_col].std()
    fig, ax = plt.subplots()
    bars = ax.bar(means.index, means.values, color='b')
    ax.errorbar(means.index, means.values, yerr=std_devs.values, fmt='none',
        capsize=5, color='r')
    ax.set_xlabel(group_col)
    ax.set_ylabel(value_col)
    ax.set_title(f'Bar Chart of {value_col} by {group_col}')
    return ax

# Clone zero-shot deepseek-r1:14b-test 1 ['refac_1', 'refac_3', 'refac_7']
import matplotlib.pyplot as plt
import pandas as pd
import numpy as np


def task_func(df, group_col, value_col):
    fig, ax = plt.subplots()
    grouped_data = df.groupby(group_col)
    means = grouped_data[value_col].mean()
    std_devs = grouped_data[value_col].std()
    bars = ax.bar(means.index, means.values, color='b')
    ax.errorbar(means.index, means.values, yerr=std_devs.values, fmt='none',
        capsize=5)
    ax.set_title('Bar chart of Value by Group with Error Bars')
    ax.set_xlabel(group_col)
    ax.set_ylabel(value_col)
    ax.legend(['Mean Values'])
    return ax

