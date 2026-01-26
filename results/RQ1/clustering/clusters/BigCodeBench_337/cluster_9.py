# Clone zero-shot gemma3:latest-code 1 ['refac_3', 'refac_5', 'refac_7']
import numpy as np
import matplotlib.pyplot as plt
import pandas as pd


def task_func(df, group_col, value_col):
    groups = df[group_col].unique()
    group_means = {}
    group_stds = {}
    for group in groups:
        group_means[group] = df[df[group_col] == group][value_col].mean()
        group_stds[group] = df[df[group_col] == group][value_col].std()
    index = np.arange(len(groups))
    plt.bar(index, list(group_means.values()), yerr=list(group_stds.values(
        )), color=['r', 'g', 'b'][:len(groups)], capsize=4)
    plt.xlabel(group_col)
    plt.ylabel(value_col)
    plt.title(f'Bar chart of {value_col} by {group_col}')
    plt.xticks(index, groups)
    plt.legend()
    return plt.gca()

