# Clone zero-shot gpt-oss:20b-test 1 ['refac_2', 'refac_5', 'refac_6']
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

