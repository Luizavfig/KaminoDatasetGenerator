# Clone zero-shot deepseek-r1:14b-test 1 ['refac_2', 'refac_6', 'refac_7']
import numpy as np
import matplotlib.pyplot as plt
import pandas as pd


def task_func(data):
    df = pd.DataFrame(data)
    df['Average'] = df.mean(axis=1)
    fig, ax = plt.subplots()
    ax.plot(df['Average'])
    return df, ax

# Clone zero-shot deepseek-r1:14b-test 1 ['refac_2', 'refac_4', 'refac_6']
import numpy as np
import matplotlib.pyplot as plt
import pandas as pd


def task_func(data):
    df = pd.DataFrame(data)
    df['Average'] = df.mean(axis=1)
    fig, ax = plt.subplots()
    ax.plot(df['Average'])
    return df, ax

# Clone zero-shot deepseek-r1:14b-test 1 ['refac_1', 'refac_3', 'refac_7']
import pandas as pd
import numpy as np
import matplotlib.pyplot as plt


def task_func(data):
    df = pd.DataFrame(data)
    denom = df.max() - df.min()
    denom[denom == 0] = 1
    normalized_df = (df - df.min()) / denom
    averages = normalized_df.mean(axis=1)
    df['Average'] = averages
    plt.figure(figsize=(10, 6))
    ax = plt.gca()
    ax.plot(averages, label='Average Values')
    return df, ax

# Clone cot deepseek-r1:14b-test 1 ['refac_1', 'refac_3', 'refac_7']
import pandas as pd
import matplotlib.pyplot as plt


def task_func(data):
    df = pd.DataFrame(data)
    avg = df.mean(axis=1)
    df['Average'] = avg
    fig, ax = plt.subplots()
    ax.plot(avg.values, marker='o')
    return df, ax

# Clone zero-shot deepseek-r1:14b-test 1 [1, ('refac_1', 'refac_4', 'refac_5')]
import pandas as pd
import numpy as np
import matplotlib.pyplot as plt


def task_func(data):
    min_vals = np.min(data, axis=0)
    max_vals = np.max(data, axis=0)
    denom = max_vals - min_vals
    denom_safe = np.where(denom == 0, 1, denom)
    normalized_data = (data - min_vals) / denom_safe
    df = pd.DataFrame(normalized_data)
    df['Average'] = df.mean(axis=1)
    fig, ax = plt.subplots()
    ax.plot(df['Average'])
    return df, ax

# Clone zero-shot deepseek-r1:14b-test 1 [4, ('refac_2', 'refac_5', 'refac_6')]
import pandas as pd
import numpy as np
import matplotlib.pyplot as plt


def task_func(data):
    min_vals = np.min(data, axis=1, keepdims=True)
    max_vals = np.max(data, axis=1, keepdims=True)
    denom = max_vals - min_vals
    normalized_data = np.where(denom == 0, 0, (data - min_vals) / denom)
    df = pd.DataFrame(normalized_data)
    df['Average'] = df.mean(axis=1)
    fig, ax = plt.subplots()
    ax.plot(df['Average'])
    return df, ax

# Clone zero-shot deepseek-r1:14b-test 1 [5, ('refac_3', 'refac_5', 'refac_7')]
import numpy as np
import matplotlib.pyplot as plt
import pandas as pd


def task_func(data):
    df = pd.DataFrame(data)
    df['Average'] = df.mean(axis=1)
    fig, ax = plt.subplots()
    ax.plot(df['Average'])
    return df, ax

# Clone zero-shot deepseek-r1:14b-test 1 [7, ('refac_1', 'refac_3', 'refac_7')]
import pandas as pd
import numpy as np
import matplotlib.pyplot as plt


def task_func(data):
    df = pd.DataFrame(data)
    df['Average'] = df.mean(axis=1)
    fig, ax = plt.subplots()
    ax.plot(df['Average'])
    return df, ax

# Clone cot deepseek-r1:14b-test 1 [3, ('refac_1', 'refac_3', 'refac_4')]
import pandas as pd
import numpy as np
import matplotlib.pyplot as plt


def task_func(data):
    mins = np.min(data, axis=0)
    maxs = np.max(data, axis=0)
    denom = maxs - mins
    denom_safe = np.where(denom == 0, 1, denom)
    normalized_data = (data - mins) / denom_safe
    averages = np.mean(normalized_data, axis=1)
    df = pd.DataFrame(data)
    df['Average'] = averages
    fig, ax = plt.subplots()
    ax.plot(averages)
    return df, ax

# Clone cot deepseek-r1:14b-test 1 [4, ('refac_2', 'refac_5', 'refac_6')]
import numpy as np
import matplotlib.pyplot as plt
import pandas as pd


def task_func(data):
    df = pd.DataFrame(data)
    df['Average'] = df.mean(axis=1)
    fig, ax = plt.subplots()
    ax.plot(df['Average'])
    return df, ax

# Clone cot deepseek-r1:14b-test 1 [5, ('refac_3', 'refac_5', 'refac_7')]
import pandas as pd
import numpy as np
import matplotlib.pyplot as plt


def task_func(data):
    min_vals = np.min(data, axis=0)
    max_vals = np.max(data, axis=0)
    denom = max_vals - min_vals
    denom = np.where(denom == 0, 1, denom)
    normalized_data = (data - min_vals) / denom
    averages = np.mean(normalized_data, axis=1)
    df = pd.DataFrame(data)
    df['Average'] = averages
    fig, ax = plt.subplots()
    ax.plot(averages)
    return df, ax

# Clone cot deepseek-r1:14b-test 1 [6, ('refac_2', 'refac_4', 'refac_6')]
import numpy as np
import matplotlib.pyplot as plt
import pandas as pd


def task_func(data):
    df = pd.DataFrame(data)
    df['Average'] = df.mean(axis=1)
    fig, ax = plt.subplots()
    ax.plot(df['Average'])
    return df, ax

# Clone cot deepseek-r1:14b-test 1 [7, ('refac_1', 'refac_3', 'refac_7')]
import pandas as pd
import matplotlib.pyplot as plt
import numpy as np


def task_func(data):
    min_vals = np.min(data, axis=0)
    max_vals = np.max(data, axis=0)
    denom = max_vals - min_vals
    denom[denom == 0] = 1
    normalized_data = (data - min_vals) / denom
    averages = np.mean(normalized_data, axis=1)
    df = pd.DataFrame(data)
    df['Average'] = averages
    fig, ax = plt.subplots()
    ax.plot(averages)
    return df, ax

