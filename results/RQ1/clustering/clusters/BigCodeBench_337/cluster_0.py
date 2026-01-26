# Clone cot llama3.1:latest-test 1 ['refac_1', 'refac_4', 'refac_5']
import matplotlib.pyplot as plt
from pandas import DataFrame


def task_func(df, group_col, value_col):
    grouped_df = df.groupby(group_col)[value_col].mean().reset_index()
    fig, ax = plt.subplots()
    ax.bar(grouped_df[group_col], grouped_df[value_col], yerr=grouped_df[
        value_col].std())
    ax.set_title('Bar chart of Value by Group')
    ax.set_xlabel(group_col)
    ax.set_ylabel(value_col)
    ax.legend([f'Group {i}' for i in range(1, len(grouped_df[group_col]) + 1)])
    return ax

# Clone cot llama3.1:latest-test 1 ['refac_1', 'refac_3', 'refac_4']
import matplotlib.pyplot as plt
from pandas import DataFrame


def task_func(df, group_col, value_col):
    df_grouped = df.groupby(group_col)[value_col].mean().reset_index()
    ax = df_grouped.plot(kind='bar', x=group_col, y=value_col, figsize=(10,
        6), rot=0)
    plt.title('Bar chart of Value by Group')
    plt.xlabel(group_col)
    plt.ylabel(value_col)
    plt.legend(title='Group')
    return ax

# Clone cot llama3.1:latest-test 1 ['refac_3', 'refac_5', 'refac_7']
import matplotlib.pyplot as plt
from pandas import DataFrame


def task_func(df, group_col, value_col):
    fig, ax = plt.subplots()
    df_grouped = df.groupby(group_col)[value_col].mean().plot(kind='bar',
        yerr=df.groupby(group_col)[value_col].std(), ax=ax)
    return ax

# Clone cot llama3.1:latest-test 1 ['refac_1', 'refac_3', 'refac_7']
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

