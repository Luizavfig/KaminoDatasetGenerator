# Clone zero-shot gemma3:latest-code 1 ['refac_1', 'refac_4', 'refac_5']
import numpy as np
import matplotlib.pyplot as plt


def task_func(df, group_col, value_col):
    group_means = df.groupby(group_col)[value_col].mean()
    group_std_devs = df.groupby(group_col)[value_col].std()
    num_groups = len(group_means)
    x = np.arange(num_groups)
    plt.bar(x, list(group_means), yerr=list(group_std_devs), color=['r',
        'g', 'b'][0:num_groups], capsize=4)
    plt.xlabel(group_col)
    plt.ylabel(value_col)
    plt.title(f'Bar chart of {value_col} by {group_col}')
    plt.xticks(x, list(group_means.index))
    plt.legend()
    return plt.gca()

# Clone zero-shot gemma3:latest-complete 1 ['refac_1', 'refac_4', 'refac_5']
import numpy as np
import matplotlib.pyplot as plt
import pandas as pd
COLORS = ['r', 'g', 'b']


def task_func(df, group_col, value_col):
    group_mean = df.groupby(group_col)[value_col].mean()
    group_std = df.groupby(group_col)[value_col].std()
    num_groups = len(group_mean)
    index = np.arange(num_groups)
    plt.figure()
    plt.bar(index, group_mean, yerr=group_std, color=COLORS)
    plt.xlabel(group_col)
    plt.ylabel(value_col)
    plt.title(f'Bar chart of {value_col} by {group_col}')
    plt.xticks(index, group_mean.index)
    plt.legend(['Group 1', 'Group 2', 'Group 3'])
    plt.tight_layout()
    ax = plt.gca()
    plt.close()
    return ax

# Clone cot gemma3:latest-code 1 ['refac_1', 'refac_4', 'refac_5']
import pandas as pd
import matplotlib.pyplot as plt


def task_func(df, group_col, value_col):
    group_means = df.groupby(group_col)[value_col].mean()
    group_stds = df.groupby(group_col)[value_col].std()
    num_groups = len(group_means)
    x = range(num_groups)
    plt.bar(x, list(group_means), yerr=list(group_stds), capsize=4)
    plt.xlabel(group_col)
    plt.ylabel(value_col)
    plt.title(f'Bar chart of {value_col} by {group_col}')
    plt.xticks(x, list(group_means.index))
    plt.tight_layout()
    return plt.gca()

# Clone cot gemma3:latest-code 1 ['refac_1', 'refac_3', 'refac_4']
import numpy as np
import matplotlib.pyplot as plt


def task_func(df, group_col, value_col):
    group_mean = df.groupby(group_col)[value_col].mean()
    group_std = df.groupby(group_col)[value_col].std()
    x = np.arange(len(group_mean))
    plt.bar(x, list(group_mean), yerr=list(group_std), capsize=4)
    plt.xlabel(group_col)
    plt.ylabel(value_col)
    plt.title(f'Bar chart of {value_col} by {group_col}')
    plt.xticks(x, list(group_mean.index))
    plt.tight_layout()
    return plt.gca()

# Clone cot gemma3:latest-code 1 ['refac_2', 'refac_5', 'refac_6']
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

# Clone cot gemma3:latest-code 1 ['refac_1', 'refac_3', 'refac_7']
import numpy as np
import matplotlib.pyplot as plt


def task_func(df, group_col, value_col):
    group_mean = df.groupby(group_col)[value_col].mean()
    group_std = df.groupby(group_col)[value_col].std()
    x = np.arange(len(group_mean))
    plt.bar(x, list(group_mean), yerr=list(group_std), capsize=4)
    plt.xlabel(group_col)
    plt.ylabel(value_col)
    plt.title(f'Bar chart of {value_col} by {group_col}')
    plt.xticks(x, list(group_mean.index))
    plt.tight_layout()
    return plt.gca()

# Clone zero-shot llama3.1:latest-code 1 ['refac_1', 'refac_3', 'refac_7']
import matplotlib.pyplot as plt
import pandas as pd


def task_func(df, group_col, value_col):
    grouped = df.groupby(group_col)[value_col].agg(['mean', 'std'])
    grouped.columns = ['Mean', 'Std']
    fig, ax = plt.subplots()
    for i, (group, data) in enumerate(grouped.iterrows()):
        ax.bar(i, data['Mean'], yerr=data['Std'], label=group)
    ax.set_xlabel(group_col)
    ax.set_ylabel(value_col)
    ax.set_title(f'Bar chart of {value_col} by {group_col}')
    ax.legend()
    return ax

# Clone zero-shot llama3.1:latest-complete 1 ['refac_3', 'refac_5', 'refac_7']
import numpy as np
import matplotlib.pyplot as plt
from matplotlib import cm
import pandas as pd


def task_func(df, group_col, value_col):
    grouped = df.groupby(group_col)[value_col].agg(['mean', 'std'])
    num_groups = len(grouped)
    index = np.arange(num_groups)
    fig, ax = plt.subplots()
    for i, (mean, std) in enumerate(zip(grouped['mean'], grouped['std'])):
        ax.bar(index[i], mean, yerr=std, color=cm.rainbow(i / num_groups),
            capsize=4, label=f'Group {i + 1}')
    ax.set_xlabel(group_col)
    ax.set_ylabel(value_col)
    ax.set_title(f'Bar chart of {value_col} by {group_col}')
    ax.set_xticks(index)
    ax.set_xticklabels(grouped.index)
    ax.legend()
    return ax

# Clone zero-shot llama3.1:latest-ast 1 ['refac_1', 'refac_3', 'refac_7']
import pandas as pd
import matplotlib.pyplot as plt
import numpy as np


def task_func(df, group_col, value_col):
    grouped = df.groupby(group_col)[value_col].mean()
    stds = df.groupby(group_col)[value_col].std()
    fig, ax = plt.subplots(figsize=(10, 6))
    for i, (group, mean) in enumerate(zip(grouped.index, grouped.values)):
        ax.bar(i, mean, yerr=stds[group], color=plt.cm.tab20(i % len(stds)),
            capsize=4, label=f'Group {i + 1}')
    ax.set_xlabel(group_col)
    ax.set_ylabel(value_col)
    ax.set_title(f'Bar chart of {value_col} by {group_col}')
    ax.xaxis.set_ticks(np.arange(len(grouped)))
    ax.xaxis.set_ticklabels(grouped.index)
    plt.legend()
    return ax

# Clone cot llama3.1:latest-code 1 ['refac_1', 'refac_3', 'refac_4']
import matplotlib.pyplot as plt
import pandas as pd


def task_func(df, group_col, value_col):
    grouped_df = df.groupby(group_col)[value_col].agg(['mean', 'std'])
    grouped_df.plot(kind='bar', y='mean', yerr=grouped_df['std'], capsize=4)
    plt.xlabel(group_col)
    plt.ylabel(value_col)
    plt.title(f'Bar chart of {value_col} by {group_col}')
    plt.xticks(rotation=90)
    return plt.gca()

# Clone cot llama3.1:latest-code 1 ['refac_3', 'refac_5', 'refac_7']
import matplotlib.pyplot as plt
import pandas as pd


def task_func(df, group_col, value_col):
    grouped_df = df.groupby(group_col)[value_col].agg(['mean', 'std'])
    grouped_df.columns = ['Mean', 'Std']
    fig, ax = plt.subplots()
    for i, (col_name, series) in enumerate(grouped_df.iterrows()):
        ax.bar(i, series['Mean'], yerr=series['Std'], label=f'Group {i + 1}')
    ax.set_xlabel(group_col)
    ax.set_ylabel(value_col)
    ax.set_title(f'Bar chart of {value_col} by {group_col}')
    ax.legend()
    return ax

# Clone cot llama3.1:latest-complete 1 ['refac_1', 'refac_4', 'refac_5']
import matplotlib.pyplot as plt
import pandas as pd
import numpy as np


def task_func(df, group_col, value_col):
    """
    Create a bar chart of data in multiple groups with error bars.

    Parameters:
        df (pd.DataFrame): DataFrame containing the data.
        group_col (str): Column name for grouping.
        value_col (str): Column name for values to plot.

    Returns:
        ax: The axes object of the created plot.
    """
    if not pd.api.types.is_numeric_dtype(df[value_col]):
        raise TypeError("The 'Value' column must be numeric")
    grouped = df.groupby(group_col)[value_col].agg(['mean', 'std'])
    fig, ax = plt.subplots()
    grouped['mean'].plot(kind='bar', yerr=grouped['std'], ax=ax)
    ax.set_xlabel(group_col)
    ax.set_ylabel(value_col)
    ax.set_title(f'Bar chart of {value_col} by {group_col}')
    return ax

# Clone cot llama3.1:latest-complete 1 ['refac_1', 'refac_3', 'refac_7']
import matplotlib.pyplot as plt
from pandas import DataFrame, Series
import numpy as np


def task_func(df: DataFrame, group_col: str, value_col: str) ->plt.Axes:
    grouped = df.groupby(group_col)[value_col]
    num_groups = len(grouped)
    index = np.arange(num_groups)
    fig, ax = plt.subplots()
    for i, (mean, std) in enumerate(zip(grouped.mean(), grouped.std())):
        ax.bar(index[i], mean, yerr=std, color=plt.cm.tab10(i % len(plt.cm.
            tab10.colors)), capsize=4, label=f'Group {i + 1}')
    ax.set_xlabel(group_col)
    ax.set_ylabel(value_col)
    ax.set_title(f'Bar chart of {value_col} by {group_col}')
    ax.set_xticks(index)
    ax.legend()
    return ax

# Clone cot llama3.1:latest-ast 1 ['refac_1', 'refac_3', 'refac_7']
import pandas as pd
import matplotlib.pyplot as plt


def task_func(df, group_col, value_col):
    grouped = df.groupby(group_col)[value_col].mean()
    stds = df.groupby(group_col)[value_col].std()
    fig, ax = plt.subplots()
    for i, (group, mean) in enumerate(zip(grouped.index, grouped.values)):
        ax.bar(i, mean, yerr=stds[group], color=plt.cm.tab10(i % len(stds)),
            capsize=4, label=f'Group {i + 1}')
    ax.set_xlabel(group_col)
    ax.set_ylabel(value_col)
    ax.set_title(f'Bar chart of {value_col} by {group_col}')
    ax.set_xticks(range(len(grouped)))
    ax.set_xticklabels(grouped.index)
    plt.legend()
    return ax

# Clone zero-shot gpt-oss:20b-ast 1 ['refac_1', 'refac_3', 'refac_4']
import numpy as np
import matplotlib.pyplot as plt
from itertools import cycle


def task_func(df, group_col, value_col):
    """Create a bar chart with error bars for grouped data."""
    stats = df.groupby(group_col)[value_col].agg(['mean', 'std'])
    groups = stats.index.tolist()
    means = stats['mean'].values
    stds = stats['std'].values
    x = np.arange(len(groups))
    color_cycle = cycle(['#1f77b4', '#ff7f0e', '#2ca02c', '#d62728', '#9467bd']
        )
    colors = [next(color_cycle) for _ in groups]
    fig, ax = plt.subplots()
    ax.bar(x, means, yerr=stds, capsize=5, color=colors, edgecolor='black')
    ax.set_xticks(x)
    ax.set_xticklabels(groups)
    ax.set_xlabel(group_col)
    ax.set_ylabel(value_col)
    ax.set_title(f'Bar chart of {value_col} by {group_col}')
    ax.legend([f'Group {g}' for g in groups], loc='best')
    return ax

# Clone cot gpt-oss:20b-ast 1 ['refac_1', 'refac_4', 'refac_5']
import pandas as pd
import numpy as np
import matplotlib.pyplot as plt


def task_func(df, group_col, value_col):
    stats = df.groupby(group_col)[value_col].agg(['mean', 'std']).reset_index()
    positions = np.arange(len(stats))
    fig, ax = plt.subplots()
    ax.bar(positions, stats['mean'], yerr=stats['std'], capsize=4, color=
        'steelblue')
    ax.set_xticks(positions)
    ax.set_xticklabels(stats[group_col])
    ax.set_xlabel(group_col)
    ax.set_ylabel(value_col)
    ax.set_title(f'Bar chart of {value_col} by {group_col}')
    return ax

# Clone cot gpt-oss:20b-ast 1 ['refac_1', 'refac_3', 'refac_4']
import numpy as np
import matplotlib.pyplot as plt


def task_func(df, group_col, value_col):
    """
    Create a bar chart with error bars for grouped data.
    Returns a matplotlib Axes object.
    """
    grouped = df.groupby(group_col)[value_col]
    means = grouped.mean()
    stds = grouped.std()
    positions = np.arange(len(means))
    colors = {group: plt.cm.tab10(i % 10) for i, group in enumerate(means.
        index)}
    fig, ax = plt.subplots()
    ax.bar(positions, means, yerr=stds, color=[colors[g] for g in means.
        index], capsize=4)
    ax.set_xlabel(group_col)
    ax.set_ylabel(value_col)
    ax.set_title(f'Bar chart of {value_col} by {group_col}')
    ax.set_xticks(positions)
    ax.set_xticklabels(means.index, rotation=45, ha='right')
    ax.legend().remove()
    return ax

