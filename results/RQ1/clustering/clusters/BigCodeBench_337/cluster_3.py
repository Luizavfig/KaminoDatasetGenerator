# Clone zero-shot deepseek-r1:14b-code 1 ['refac_1', 'refac_3', 'refac_7']
import numpy as np
import matplotlib.pyplot as plt
from pandas import DataFrame


def task_func(df: DataFrame, group_col: str, value_col: str) ->plt.Axes:
    grouped_data = df.groupby(group_col)[value_col]
    means = grouped_data.mean()
    stds = grouped_data.std()
    groups = list(means.index)
    num_groups = len(groups)
    x_positions = np.arange(num_groups)
    fig, ax = plt.subplots(figsize=(10, 6))
    colors = ['r', 'g', 'b']
    for i in range(num_groups):
        mean_val = means[groups[i]]
        std_val = stds[groups[i]]
        bar = plt.bar(x_positions[i], mean_val, yerr=std_val, capsize=4,
            color=colors[i % len(colors)])
    ax.set_xlabel(group_col)
    ax.set_ylabel(value_col)
    ax.set_title(f'Bar Chart of {value_col} by {group_col}')
    ax.set_xticks(x_positions)
    ax.set_xticklabels(groups)
    ax.legend([plt.Rectangle((0, 0), 1, 1, fc='r'), plt.Rectangle((0, 0), 1,
        1, fc='g'), plt.Rectangle((0, 0), 1, 1, fc='b')], ['Group 1',
        'Group 2', 'Group 3'])
    return ax

