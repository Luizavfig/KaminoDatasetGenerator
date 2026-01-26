# Clone zero-shot deepseek-r1:14b-test 1 ['refac_1', 'refac_3', 'refac_4']
def task_func(df, group_col, value_col):
    """Create a bar chart of data grouped by specified columns with error bars."""
    import matplotlib.pyplot as plt
    grouped = df.groupby(group_col)
    means = grouped[value_col].mean()
    std_devs = grouped[value_col].std()
    fig, ax = plt.subplots()
    bars = ax.bar(means.index, means.values, color=COLORS[0])
    for i in range(len(bars)):
        ax.errorbar(means.index[i], means.values[i], yerr=std_devs.values[i
            ], fmt='none', capsize=5, color='black')
    ax.set_xlabel(group_col)
    ax.set_ylabel(value_col)
    ax.set_title(f'Bar chart of {value_col} by {group_col}')
    return ax

# Clone zero-shot deepseek-r1:14b-complete 1 ['refac_1', 'refac_3', 'refac_7']
import numpy as np
import matplotlib.pyplot as plt
import pandas as pd


def task_func(df, group_col, value_col):
    grouped = df.groupby(group_col)
    means = grouped[value_col].mean()
    stds = grouped[value_col].std()
    groups = list(means.index)
    num_groups = len(groups)
    x_positions = np.arange(num_groups)
    fig, ax = plt.subplots(figsize=(10, 6))
    for i in range(num_groups):
        color = COLORS[i % len(COLORS)]
        bar_height = means.iloc[i]
        error_height = stds.iloc[i]
        plt.bar(x_positions[i], bar_height, yerr=error_height, color=color,
            capsize=4)
    ax.set_xlabel(group_col)
    ax.set_ylabel(value_col)
    ax.set_title(f'Bar chart of {value_col} by {group_col}')
    ax.set_xticks(x_positions)
    ax.set_xticklabels(groups)
    ax.legend([f'Group {i + 1}' for i in range(num_groups)])
    return ax

# Clone cot deepseek-r1:14b-test 1 ['refac_3', 'refac_5', 'refac_7']
import matplotlib.pyplot as plt


def task_func(df, group_col, value_col):
    grouped = df.groupby(group_col)
    means = grouped[value_col].mean()
    std_devs = grouped[value_col].std()
    fig, ax = plt.subplots()
    bars = ax.bar(means.index, means.values, color=COLORS)
    for i in range(len(bars)):
        bar = bars[i]
        mean_val = means.values[i]
        std_dev = std_devs.values[i]
        ax.errorbar(bar.get_x() + bar.get_width() / 2.0, mean_val, yerr=
            std_dev, fmt='none', capsize=5)
    ax.set_xlabel(group_col)
    ax.set_ylabel(value_col)
    ax.set_title(f'Bar chart of {value_col} by {group_col}')
    return ax

# Clone cot deepseek-r1:14b-complete 1 ['refac_3', 'refac_5', 'refac_7']
import numpy as np
import matplotlib.pyplot as plt


def task_func(df, group_col, value_col):
    grouped_data = df.groupby(group_col)
    means = grouped_data[value_col].mean()
    stds = grouped_data[value_col].std()
    num_groups = len(means)
    index = np.arange(num_groups)
    fig, ax = plt.subplots(figsize=(10, 6))
    for i, (group_name, mean_val) in enumerate(means.items()):
        color = COLORS[i % len(COLORS)]
        yerr = stds[group_name]
        ax.bar(index[i], mean_val, yerr=yerr, capsize=4, color=color, label
            =f'{group_name}')
    ax.set_xlabel(group_col)
    ax.set_ylabel(value_col)
    ax.set_title(f'Bar chart of {value_col} by {group_col}')
    ax.set_xticks(index)
    ax.set_xticklabels(means.index)
    ax.legend()
    return ax

# Clone cot deepseek-r1:14b-complete 1 ['refac_1', 'refac_3', 'refac_7']
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

