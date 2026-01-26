# Clone cot gpt-oss:20b-code 1 ['refac_1', 'refac_3', 'refac_4']
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

# Clone cot gpt-oss:20b-test 1 ['refac_1', 'refac_3', 'refac_4']
import pandas as pd
import matplotlib.pyplot as plt
import numpy as np


def task_func(df, group_col, value_col):
    try:
        pd.to_numeric(df[value_col], errors='raise')
    except Exception:
        raise TypeError('Value column must be numeric')
    data = df[[group_col, value_col]].dropna()
    groups = tuple(data[group_col].unique())
    stats = {g: (data[data[group_col] == g][value_col].mean(), data[data[
        group_col] == g][value_col].std(ddof=0)) for g in groups}
    x = np.arange(len(groups))
    means = [stats[g][0] for g in groups]
    stds = [(stats[g][1] if not np.isnan(stats[g][1]) else 0) for g in groups]
    colors = 'r', 'g', 'b', 'c', 'm', 'y', 'k'
    fig, ax = plt.subplots()
    ax.bar(x, means, yerr=stds, capsize=5, color=[colors[i % len(colors)] for
        i in range(len(groups))])
    ax.set_xticks(x)
    ax.set_xticklabels(groups)
    return ax

# Clone cot gpt-oss:20b-complete 1 ['refac_1', 'refac_3', 'refac_4']
import pandas as pd
import numpy as np
import matplotlib.pyplot as plt
COLORS = 'r', 'g', 'b'


def task_func(df, group_col, value_col):
    try:
        df[value_col] = pd.to_numeric(df[value_col], errors='raise')
    except ValueError:
        raise TypeError('Non-numeric values found in value column')
    groups = df[group_col].dropna().unique()
    stats = {g: (df.loc[df[group_col] == g, value_col].mean(), df.loc[df[
        group_col] == g, value_col].std()) for g in groups}
    x_pos = np.arange(len(groups))
    means = [stats[g][0] for g in groups]
    stds = [stats[g][1] for g in groups]
    colors = [COLORS[i % len(COLORS)] for i in range(len(groups))]
    for i, (x, m, s, c) in enumerate(zip(x_pos, means, stds, colors)):
        plt.bar(x, m, yerr=s, color=c, capsize=4, label=f'Group {i + 1}')
    plt.xlabel(group_col)
    plt.ylabel(value_col)
    plt.title(f'Bar chart of {value_col} by {group_col}')
    plt.xticks(x_pos, groups)
    plt.legend()
    return plt.gca()

