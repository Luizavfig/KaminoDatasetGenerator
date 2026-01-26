# Clone zero-shot deepseek-r1:14b-ast 1 ['refac_3', 'refac_5', 'refac_7']
import numpy as np
import matplotlib.pyplot as plt


def task_func(df, group_col, value_col):
    grouped_data = df.groupby(group_col)[value_col]
    means = grouped_data.mean()
    stds = grouped_data.std()
    x_positions = np.arange(len(means))
    fig, ax = plt.subplots()
    for i, (mean, std) in enumerate(zip(means, stds)):
        color = COLORS[i % len(COLORS)]
        ax.bar(x_positions[i], mean, yerr=std, color=color, capsize=4)
    ax.set_xlabel(group_col)
    ax.set_ylabel(value_col)
    ax.set_title(f'Bar chart of {value_col} by {group_col}')
    ax.set_xticks(x_positions)
    ax.set_xticklabels(means.index)
    ax.legend()
    return plt.gca()

# Clone zero-shot deepseek-r1:14b-ast 1 ['refac_1', 'refac_3', 'refac_7']
import numpy as np
import matplotlib.pyplot as plt


def task_func(df, group_col, value_col):
    grouped_data = df.groupby(group_col)[value_col]
    group_stats = {'mean': grouped_data.mean(), 'std': grouped_data.std()}
    num_groups = len(group_stats['mean'])
    index = np.arange(num_groups)
    fig, ax = plt.subplots()
    for i in range(num_groups):
        mean_val = group_stats['mean'].iloc[i]
        std_val = group_stats['std'].iloc[i]
        plt.bar(x=index[i], height=mean_val, yerr=std_val, color='r' if i %
            3 == 0 else 'g' if i % 3 == 1 else 'b', capsize=4, label=
            f'Group {i + 1}')
    plt.xlabel(group_col)
    plt.ylabel(value_col)
    plt.title(f'Bar chart of {value_col} by {group_col}')
    plt.xticks(index, group_stats['mean'].index)
    plt.legend()
    return plt.gca()

# Clone cot deepseek-r1:14b-code 1 ['refac_1', 'refac_3', 'refac_4']
import numpy as np
import matplotlib.pyplot as plt


def task_func(df, group_col, value_col):
    grouped_data = df.groupby(group_col)[value_col]
    means = grouped_data.mean()
    stds = grouped_data.std()
    num_groups = len(means)
    index = np.arange(num_groups)
    [plt.bar(index[i], means.iloc[i], yerr=stds.iloc[i], color=['r', 'g',
        'b'][i % 3], capsize=4, label=f'Group {i + 1}') for i in range(
        num_groups)]
    plt.xlabel(group_col)
    plt.ylabel(value_col)
    plt.title(f'{value_col} by {group_col}')
    plt.xticks(index, means.index)
    plt.legend()
    return plt.gca()

# Clone cot deepseek-r1:14b-complete 1 ['refac_1', 'refac_4', 'refac_5']
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

# Clone cot deepseek-r1:14b-ast 1 ['refac_3', 'refac_5', 'refac_7']
import numpy as np
import matplotlib.pyplot as plt


def task_func(df, group_col, value_col):
    group_data = df.groupby(group_col)[value_col]
    group_stats = group_data.agg(['mean', 'std'])
    groups = list(group_stats.index)
    num_groups = len(groups)
    index = np.arange(num_groups)
    fig, ax = plt.subplots()
    for i in range(num_groups):
        mean = group_stats['mean'][i]
        std = group_stats['std'][i]
        color = COLORS[i % len(COLORS)]
        ax.bar(x=index[i], height=mean, yerr=std, color=color, capsize=4,
            label=f'Group {i + 1}')
    plt.xlabel(group_col)
    plt.ylabel(value_col)
    plt.title(f'Bar chart of {value_col} by {group_col}')
    plt.xticks(index, groups)
    plt.legend()
    return plt.gca()

