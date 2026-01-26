# Clone cot deepseek-r1:14b-test 1 ['refac_2', 'refac_5', 'refac_6']
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

# Clone cot deepseek-r1:14b-test 1 ['refac_1', 'refac_3', 'refac_7']
import matplotlib.pyplot as plt
import pandas as pd
import numpy as np


def task_func(df, group_col, value_col):
    grouped_data = df.groupby(group_col)[value_col].agg(['mean', 'std']
        ).reset_index()
    fig, ax = plt.subplots(figsize=(10, 6))
    colors = COLORS[:len(grouped_data[group_col])]
    bars = ax.bar(grouped_data[group_col], grouped_data['mean'], color=colors)
    for i, bar in enumerate(bars):
        std = grouped_data.iloc[i]['std']
        ax.errorbar(bar.get_x() + bar.get_width() / 2.0, grouped_data.iloc[
            i]['mean'], yerr=std, fmt='none', color='black', capsize=5)
    ax.set_title('Bar chart of Value by Group')
    ax.set_xlabel(group_col)
    ax.set_ylabel(value_col)
    ax.legend([bars[0]], ['Value'])
    return ax

