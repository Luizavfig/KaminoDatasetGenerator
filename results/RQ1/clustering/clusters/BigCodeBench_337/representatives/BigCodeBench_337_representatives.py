# Cluster 0 - Representative clone cot llama3.1:latest-test 1 ['refac_1', 'refac_3', 'refac_7']
import matplotlib.pyplot as plt
from pandas import DataFrame


def task_func(df, group_col, value_col):
    df_grouped = df.groupby(group_col)[value_col].mean().reset_index()
    ax = df_grouped.plot(kind='bar', x=group_col, y=value_col, figsize=(10,
        6), rot=0)
    plt.title('Bar chart of Value by Group')
    plt.xlabel(group_col)
    plt.ylabel(value_col)
    plt.legend(['Group 1', 'Group 2', 'Group 3'])
    return ax

# Cluster 1 - Representative clone zero-shot llama3.1:latest-test 1 ['refac_3', 'refac_5', 'refac_7']
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

# Cluster 2 - Representative clone zero-shot deepseek-r1:14b-code 1 ['refac_3', 'refac_5', 'refac_7']
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

# Cluster 3 - Representative clone zero-shot deepseek-r1:14b-code 1 ['refac_1', 'refac_3', 'refac_7']
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

# Cluster 4 - Representative clone zero-shot llama3.1:latest-ast 1 ['refac_1', 'refac_4', 'refac_5']
import pandas as pd
import matplotlib.pyplot as plt
import numpy as np


def task_func(df, group_col, value_col):
    """
    Create a bar chart of data in multiple groups with error bars.

    Parameters:
    df (DataFrame): The input DataFrame containing the data.
    group_col (str): The name of the column to group the data by.
    value_col (str): The name of the column containing the values to plot.

    Returns:
    Axes: A matplotlib axes object with the bar chart.
    """
    grouped = df.groupby(group_col)[value_col].agg(['mean', 'std'])
    fig, ax = plt.subplots()
    for i, (group, values) in enumerate(grouped.iterrows()):
        ax.bar(i, values['mean'], yerr=values['std'], color=plt.cm.tab10(i %
            10), label=f'Group {i + 1}')
    ax.set_xlabel(group_col)
    ax.set_ylabel(value_col)
    ax.set_title(f'Bar chart of {value_col} by {group_col}')
    ax.legend()
    return ax

# Cluster 5 - Representative clone cot gemma3:latest-code 1 ['refac_2', 'refac_5', 'refac_6']
import pandas as pd
import matplotlib.pyplot as plt


def task_func(df, group_col, value_col):
    group_means = df.groupby(group_col)[value_col].mean()
    group_stds = df.groupby(group_col)[value_col].std()
    fig, ax = plt.subplots()
    ax.bar(group_means.index, group_means.values, yerr=group_stds.values,
        capsize=4)
    ax.set_xlabel(group_col)
    ax.set_ylabel(value_col)
    ax.set_title(f'Bar chart of {value_col} by {group_col}')
    ax.set_xticks(group_means.index)
    plt.tight_layout()
    return ax

# Cluster 6 - Representative clone cot gpt-oss:20b-code 1 ['refac_1', 'refac_3', 'refac_4']
import pandas as pd
import matplotlib.pyplot as plt
import numpy as np


def task_func(df, group_col, value_col):
    stats = {g: (df.loc[df[group_col] == g, value_col].mean(), df.loc[df[
        group_col] == g, value_col].std()) for g in df[group_col].unique()}
    groups = list(stats.keys())
    means = [stats[g][0] for g in groups]
    stds = [stats[g][1] for g in groups]
    positions = tuple(range(len(groups)))
    fig, ax = plt.subplots()
    ax.bar(positions, means, yerr=stds, capsize=4, color='steelblue')
    ax.set_xticks(positions)
    ax.set_xticklabels(groups)
    ax.set_xlabel(group_col)
    ax.set_ylabel(value_col)
    ax.set_title(f'Bar chart of {value_col} by {group_col}')
    return ax

# Cluster 7 - Representative clone zero-shot gemma3:latest-complete 1 ['refac_2', 'refac_6', 'refac_7']
import numpy as np
import matplotlib.pyplot as plt
import pandas as pd
import seaborn as sns
import warnings


def task_func(df, group_col, value_col):
    try:
        df[value_col] = pd.to_numeric(df[value_col])
    except ValueError:
        raise TypeError('Value column must contain numeric values.')
    plt.figure(figsize=(10, 6))
    sns.barplot(x=group_col, y=value_col, data=df, palette='viridis')
    plt.title(f'Bar chart of {value_col} by {group_col}')
    plt.xlabel(group_col)
    plt.ylabel(value_col)
    plt.xticks(rotation=45, ha='right')
    plt.tight_layout()
    plt.show()
    return plt.gca()

# Cluster 8 - Representative clone cot deepseek-r1:14b-complete 1 ['refac_1', 'refac_4', 'refac_5']
import numpy as np
import matplotlib.pyplot as plt


def task_func(df, group_col, value_col):
    grouped_data = df.groupby(group_col)[value_col]
    means = grouped_data.mean()
    stds = grouped_data.std()
    num_groups = len(means)
    x_positions = np.arange(num_groups)
    [plt.bar(x, mean, yerr=std, color=COLORS[i % len(COLORS)], capsize=4,
        label=f'Group {i + 1}') for i, (x, mean, std) in enumerate(zip(
        x_positions, means, stds))]
    plt.xlabel(group_col)
    plt.ylabel(value_col)
    plt.title(f'Bar chart of {value_col} by {group_col}')
    plt.xticks(x_positions, means.index)
    plt.legend()
    return plt.gca()

# Cluster 9 - Representative clone zero-shot gemma3:latest-code 1 ['refac_3', 'refac_5', 'refac_7']
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

# Cluster 10 - Representative clone cot deepseek-r1:14b-test 1 ['refac_2', 'refac_5', 'refac_6']
import matplotlib.pyplot as plt
import pandas as pd
import numpy as np


def task_func(df, group_col, value_col):
    grouped_data = df.groupby(group_col)[value_col].agg(['mean', 'std'])
    fig, ax = plt.subplots()
    colors = COLORS[:len(grouped_data)]
    bars = ax.bar(grouped_data.index, grouped_data['mean'], color=colors)
    for i, bar in enumerate(bars):
        mean_val = grouped_data['mean'][i]
        std_val = grouped_data['std'][i]
        ax.errorbar(bar.get_x() + bar.get_width() / 2.0, mean_val, yerr=
            std_val, fmt='none', color='black', capsize=5)
    ax.set_xlabel(group_col)
    ax.set_ylabel(value_col)
    ax.set_title(f'Bar chart of {value_col} by {group_col}')
    ax.legend()
    return ax

# Cluster 11 - Representative clone cot deepseek-r1:14b-complete 1 ['refac_1', 'refac_3', 'refac_7']
import numpy as np
import matplotlib.pyplot as plt


def task_func(df, group_col, value_col):
    grouped = df.groupby(group_col)
    means = grouped[value_col].mean()
    stds = grouped[value_col].std()
    groups = list(means.index)
    num_groups = len(groups)
    x_positions = np.arange(num_groups)
    fig, ax = plt.subplots(figsize=(10, 6))
    for i in range(num_groups):
        mean_val = means.iloc[i]
        std_val = stds.iloc[i]
        bar_color = COLORS[i % len(COLORS)]
        plt.bar(x_positions[i], mean_val, yerr=std_val, color=bar_color,
            capsize=4)
    ax.set_xlabel(group_col)
    ax.set_ylabel(value_col)
    ax.set_title(f'Bar chart of {value_col} by {group_col}')
    ax.set_xticks(x_positions)
    ax.set_xticklabels(groups)
    ax.legend()
    return ax

# Cluster 12 - Representative clone zero-shot deepseek-r1:14b-test 1 ['refac_2', 'refac_5', 'refac_6']
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

# Cluster 13 - Representative clone cot gpt-oss:20b-code 1 ['refac_3', 'refac_5', 'refac_7']
import pandas as pd
import numpy as np
import matplotlib.pyplot as plt


def task_func(df, group_col, value_col):
    groups = set(df[group_col])
    stats = {}
    for g in groups:
        vals = df.loc[df[group_col] == g, value_col].values
        stats[g] = np.mean(vals), np.std(vals)
    pos = tuple(range(len(stats)))
    colors = '#1f77b4', '#ff7f0e', '#2ca02c', '#d62728'
    fig, ax = plt.subplots()
    for i, (g, (m, s)) in enumerate(stats.items()):
        ax.bar(pos[i], m, color=colors[i % len(colors)], width=0.6)
    for i, (g, (m, s)) in enumerate(stats.items()):
        ax.errorbar(pos[i], m, yerr=s, fmt='none', ecolor='black', capsize=5)
    ax.set_xticks(pos)
    ax.set_xticklabels(stats.keys())
    ax.set_xlabel(group_col)
    ax.set_ylabel(value_col)
    ax.set_title(f'Bar chart of {value_col} by {group_col}')
    return ax

# Cluster 14 - Representative clone zero-shot gpt-oss:20b-code 1 ['refac_1', 'refac_3', 'refac_4']
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

# Cluster 15 - Representative clone zero-shot deepseek-r1:14b-ast 1 ['refac_1', 'refac_3', 'refac_4']
def task_func(df, group_col, value_col):
    """Create a bar chart of data grouped by specified columns with error bars."""
    group_data = df.groupby(group_col)[value_col]
    group_mean = group_data.mean()
    group_std = group_data.std()
    num_groups = len(group_mean)
    x_positions = np.arange(num_groups)
    fig, axes = plt.subplots(figsize=(10, 6))
    for i, (mean_val, std_val) in enumerate(zip(group_mean, group_std)):
        color = COLORS[i % len(COLORS)]
        axes.bar(x_positions[i], mean_val, yerr=std_val, capsize=4, color=
            color, label=f'Group {i + 1}')
    axes.set_xlabel(group_col)
    axes.set_ylabel(value_col)
    axes.set_title(f'Bar Chart of {value_col} by {group_col}')
    axes.set_xticks(x_positions)
    axes.set_xticklabels(group_mean.index)
    axes.legend()
    return axes.get_children()[0].axes

# Cluster 16 - Representative clone zero-shot gpt-oss:20b-test 1 ['refac_2', 'refac_5', 'refac_6']
import pandas as pd
import seaborn as sns
import logging
logger = logging.getLogger(__name__)


def task_func(df, group_col, value_col):
    if not isinstance(df, pd.DataFrame):
        raise TypeError('df must be a pandas DataFrame')
    if group_col not in df.columns:
        raise KeyError(f"'{group_col}' not found in DataFrame columns")
    if value_col not in df.columns:
        raise KeyError(f"'{value_col}' not found in DataFrame columns")
    if not pd.api.types.is_numeric_dtype(df[value_col]):
        raise TypeError(f"'{value_col}' must contain numeric values")
    df_clean = df.dropna(subset=[group_col, value_col])
    agg = df_clean.groupby(group_col)[value_col].agg(['mean', 'std']
        ).reset_index()
    ax = sns.barplot(x=group_col, y='mean', data=agg, ci=None, palette=
        'colorblind')
    ax.errorbar(x=range(len(agg)), y=agg['mean'], yerr=agg['std'], fmt=
        'none', c='black', capsize=5)
    return ax

