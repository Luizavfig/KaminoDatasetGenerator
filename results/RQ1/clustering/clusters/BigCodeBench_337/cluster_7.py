# Clone zero-shot gemma3:latest-complete 1 ['refac_2', 'refac_6', 'refac_7']
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

