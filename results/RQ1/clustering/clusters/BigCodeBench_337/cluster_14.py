# Clone zero-shot gpt-oss:20b-code 1 ['refac_1', 'refac_3', 'refac_4']
import pandas as pd
import matplotlib.pyplot as plt


def task_func(df, group_col, value_col):
    """Create a grouped bar chart with error bars."""
    stats = df.groupby(group_col)[value_col].agg(['mean', 'std']).to_dict(
        orient='index')
    groups = list(stats.keys())
    means = [stats[g]['mean'] for g in groups]
    stds = [stats[g]['std'] for g in groups]
    fig, ax = plt.subplots()
    positions = {g: i for i, g in enumerate(groups)}
    colors = ['#1f77b4', '#ff7f0e', '#2ca02c', '#d62728', '#9467bd']
    for g, pos in positions.items():
        ax.bar(pos, stats[g]['mean'], yerr=stats[g]['std'], color=colors[
            pos % len(colors)], capsize=5, label=str(g))
    ax.set_xlabel(group_col)
    ax.set_ylabel(value_col)
    ax.set_title(f'{value_col} by {group_col}')
    ax.set_xticks(list(positions.values()))
    ax.set_xticklabels(groups)
    ax.legend()
    return ax

