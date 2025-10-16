# Clone zero-shot deepseek-r1:14b-test 1 ['refac_1', 'refac_4', 'refac_5']
import pandas as pd
import numpy as np
import matplotlib.pyplot as plt


def task_func(data):

    def minmax_scale(col):
        min_val = col.min()
        max_val = col.max()
        if max_val == min_val:
            return pd.Series(0.0, index=col.index)
        return (col - min_val) / (max_val - min_val)
    df = pd.DataFrame(data)
    scaled_df = df.apply(minmax_scale, axis=0)
    averages = scaled_df.mean(axis=1)
    df['Average'] = averages
    fig, ax = plt.subplots()
    ax.plot(averages, label='Scaled Average')
    ax.set_title('Average Values Visualization')
    ax.set_xlabel('Index')
    ax.set_ylabel('Average Value')
    ax.legend()
    return df, ax

# Clone cot deepseek-r1:14b-test 1 ['refac_2', 'refac_6', 'refac_7']
import pandas as pd
import matplotlib.pyplot as plt


def task_func(data):
    normalized_data = []
    for row in data.T:
        min_val = np.min(row)
        max_val = np.max(row)
        if max_val == min_val:
            scaled_row = np.zeros_like(row)
        else:
            scaled_row = (row - min_val) / (max_val - min_val)
        normalized_data.append(scaled_row)
    normalized_data = np.array(normalized_data).T
    averages = []
    for row in normalized_data:
        avg = np.mean(row)
        averages.append(avg)
    df = pd.DataFrame(normalized_data, columns=[f'Column_{i + 1}' for i in
        range(normalized_data.shape[1])])
    df['Average'] = averages
    fig, ax = plt.subplots()
    ax.plot(averages)
    ax.set_title('Average Values')
    ax.set_xlabel('Index')
    ax.set_ylabel('Average')
    return df, ax

# Clone cot deepseek-r1:14b-test 1 [1, ('refac_1', 'refac_4', 'refac_5')]
import pandas as pd
import numpy as np
import matplotlib.pyplot as plt


def task_func(data):
    normalized_data = []
    for row in data.T:
        min_val = np.min(row)
        max_val = np.max(row)
        if max_val == 0 and min_val == 0:
            scaled_row = np.zeros_like(row)
        else:
            scaled_row = (row - min_val) / (max_val - min_val)
        normalized_data.append(scaled_row)
    normalized_data = np.array(normalized_data).T
    df = pd.DataFrame(normalized_data)
    averages = [np.mean(row) for row in data]
    df['Average'] = averages
    plt.figure(figsize=(10, 6))
    ax = plt.gca()
    line = ax.plot(df.index, df['Average'], 'b-', label='Average')
    return df, ax

# Clone cot deepseek-r1:14b-test 1 [2, ('refac_2', 'refac_6', 'refac_7')]
import pandas as pd
import numpy as np
import matplotlib.pyplot as plt


def task_func(data):
    normalized_data = []
    for row in data.T:
        min_val = np.min(row)
        max_val = np.max(row)
        if max_val == 0 and min_val == 0:
            scaled_row = np.zeros_like(row)
        else:
            scaled_row = (row - min_val) / (max_val - min_val)
        normalized_data.append(scaled_row)
    normalized_data = np.array(normalized_data).T
    df = pd.DataFrame(normalized_data)
    averages = [np.mean(row) for row in data]
    df['Average'] = averages
    plt.figure()
    ax = plt.gca()
    ax.plot(averages, label='Average')
    ax.set_xlabel('Index')
    ax.set_ylabel('Value')
    ax.legend()
    return df, ax

