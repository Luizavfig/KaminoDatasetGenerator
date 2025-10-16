# Clone zero-shot deepseek-r1:14b-code 1 ['refac_2', 'refac_6', 'refac_7']
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

