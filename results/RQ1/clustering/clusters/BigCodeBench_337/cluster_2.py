# Clone zero-shot deepseek-r1:14b-code 1 ['refac_3', 'refac_5', 'refac_7']
import numpy as np
import matplotlib.pyplot as plt
from collections import defaultdict


def task_func(df, group_col, value_col):
    grouped_data = df.groupby(group_col)

    def calculate_stats(group):
        return {'mean': group[value_col].mean(), 'std': group[value_col].std()}
    stats_dict = {col: calculate_stats(grp) for col, grp in grouped_data}
    x_positions = np.arange(len(stats_dict))
    colors = ['r', 'g', 'b']

    def plot_bars():
        for i, (group_name, stats) in enumerate(stats_dict.items()):
            plt.bar(x_positions[i], stats['mean'], yerr=stats['std'], color
                =colors[i % len(colors)], capsize=4, label=f'Group {i + 1}')
        plt.xlabel(group_col)
        plt.ylabel(value_col)
        plt.title(f'Bar chart of {value_col} by {group_col}')
        plt.xticks(x_positions, list(stats_dict.keys()))
        plt.legend()
    fig = plt.figure(figsize=(10, 6))
    plot_bars()
    return fig.gca()

