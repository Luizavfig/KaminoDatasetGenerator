# Clone zero-shot deepseek-r1:14b-ast 1 ['refac_1', 'refac_3', 'refac_4']
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

