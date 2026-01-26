# Clone cot gpt-oss:20b-code 1 ['refac_3', 'refac_5', 'refac_7']
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

# Clone cot gpt-oss:20b-test 1 ['refac_1', 'refac_3', 'refac_7']
import pandas as pd
import numpy as np
import matplotlib.pyplot as plt


def task_func(df, group_col, value_col):
    df_clean = df.dropna(subset=[group_col, value_col])
    if not pd.api.types.is_numeric_dtype(df_clean[value_col]):
        raise TypeError('Value column must be numeric')
    groups = {}
    for _, row in df_clean.iterrows():
        key = row[group_col]
        val = row[value_col]
        if key in groups:
            groups[key].append(val)
        else:
            groups[key] = [val]
    means = {}
    stds = {}
    for key, vals in groups.items():
        means[key] = np.mean(vals)
        stds[key] = np.std(vals, ddof=1) if len(vals) > 1 else 0
    fig, ax = plt.subplots()
    x = np.arange(len(means))
    bar_width = 0.8
    ax.bar(x, list(means.values()), bar_width, yerr=list(stds.values()),
        capsize=5, color='b')
    ax.set_xlabel(group_col)
    ax.set_ylabel(value_col)
    ax.set_xticks(x)
    ax.set_xticklabels(list(means.keys()))
    ax.set_title(f'Bar chart of {value_col} by {group_col}')
    return ax

