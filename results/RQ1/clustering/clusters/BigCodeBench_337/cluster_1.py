# Clone zero-shot llama3.1:latest-test 1 ['refac_3', 'refac_5', 'refac_7']
import matplotlib.pyplot as plt
from pandas import DataFrame
import numpy as np


def task_func(df: DataFrame, group_col: str, value_col: str) ->object:
    grouped = df.groupby(group_col)[value_col]
    for name, group in grouped:
        plt.bar(name, group.count(), color='b', label=name)
        plt.errorbar(name, group.mean(), yerr=group.std(), fmt='o')
    ax = plt.gca()
    ax.set_title('Bar chart of Value by Group')
    ax.set_xlabel(group_col)
    ax.set_ylabel(value_col)
    ax.legend()
    return ax

