# Cluster 0 - Representative clone cot deepseek-r1:14b-test 1 [2, ('refac_2', 'refac_6', 'refac_7')]
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

# Cluster 1 - Representative clone zero-shot deepseek-r1:14b-test 1 ['refac_2', 'refac_6', 'refac_7']
import numpy as np
import matplotlib.pyplot as plt
import pandas as pd


def task_func(data):
    df = pd.DataFrame(data)
    df['Average'] = df.mean(axis=1)
    fig, ax = plt.subplots()
    ax.plot(df['Average'])
    return df, ax

# Cluster 2 - Representative clone zero-shot deepseek-r1:14b-code 1 ['refac_2', 'refac_6', 'refac_7']
import numpy as np
from sklearn.preprocessing import MinMaxScaler
import matplotlib.pyplot as plt
import pandas as pd


def task_func(data):
    df = pd.DataFrame(data)
    if not df.empty:
        scaler = MinMaxScaler()
        normalized_data = scaler.fit_transform(df)
        df_normalized = pd.DataFrame(normalized_data, columns=df.columns)
        df_normalized['Average'] = df_normalized.mean(axis=1)
        plt.figure(figsize=(10, 6))
        df_normalized['Average'].plot(kind='line', marker='o')
        plt.title('Average Values Visualization')
        plt.xlabel('Row Index')
        plt.ylabel('Average Value')
        plt.grid(True)
        return df_normalized, plt.gca()
    else:
        raise ValueError('Input data is empty or not properly formatted.')

