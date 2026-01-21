# Clone zero-shot deepseek-r1:14b-code 1 ['refac_3,refac_5,refac_7']
from collections import defaultdict
import matplotlib.pyplot as plt
import pandas as pd
import seaborn as sns


def task_func(list_of_menuitems):
    if not list_of_menuitems:
        return None
    flat_list = []
    for sublist in list_of_menuitems:
        if isinstance(sublist, list):
            for item in sublist:
                flat_list.append(item)
    if not flat_list:
        return None
    counter = defaultdict(int)
    for item in flat_list:
        counter[item] += 1
    df = pd.DataFrame.from_dict(counter, orient='index', columns=['Count']
        ).reset_index()
    df.columns = ['Item', 'Count']
    if df.empty:
        return None
    sns.set(style='darkgrid')
    ax = sns.barplot(y='Item', x='Count', data=df, palette='plasma')
    plt.tight_layout()
    return ax

# Clone zero-shot deepseek-r1:14b-code 1 ['refac_2,refac_5,refac_6']
from collections import defaultdict
import matplotlib.pyplot as plt
import pandas as pd
import seaborn as sns


def task_func(list_of_menuitems):
    if not list_of_menuitems:
        return None
    flat_list = []
    for sublist in list_of_menuitems:
        if isinstance(sublist, list):
            for item in sublist:
                flat_list.append(item)
    if not flat_list:
        return None
    counter = defaultdict(int)
    for item in flat_list:
        counter[item] += 1
    df = pd.DataFrame.from_dict(counter, orient='index', columns=['Count']
        ).reset_index()
    df.columns = ['Item', 'Count']
    if df.empty:
        return None
    sns.set(style='darkgrid')
    ax = sns.barplot(y='Item', x='Count', data=df, palette='plasma')
    plt.tight_layout()
    return ax

# Clone zero-shot deepseek-r1:14b-code 1 ['refac_2,refac_6,refac_7']
from collections import defaultdict
import matplotlib.pyplot as plt
import pandas as pd
import seaborn as sns


def task_func(list_of_menuitems):
    if not list_of_menuitems:
        return None
    flat_list = []
    for sublist in list_of_menuitems:
        if sublist:
            flat_list.extend(sublist)
    if not flat_list:
        return None
    counter = defaultdict(int)
    for item in flat_list:
        counter[item] += 1
    df = pd.DataFrame(counter.items(), columns=['Item', 'Count'])
    if df.empty:
        return None
    sns.set(style='darkgrid')
    ax = sns.barplot(x='Count', y='Item', data=df, palette='plasma')
    plt.tight_layout()
    return ax

# Clone zero-shot deepseek-r1:14b-code 1 ['refac_1,refac_4,refac_5']
from collections import defaultdict
import matplotlib.pyplot as plt
import pandas as pd
import seaborn as sns


def task_func(list_of_menuitems):
    if not list_of_menuitems:
        return None
    flat_list = []
    for sublist in list_of_menuitems:
        if isinstance(sublist, list):
            for item in sublist:
                flat_list.append(item)
    if not flat_list:
        return None
    counter = defaultdict(int)
    for item in flat_list:
        counter[item] += 1
    df = pd.DataFrame.from_dict(counter, orient='index', columns=['Count']
        ).reset_index()
    df.columns = ['Item', 'Count']
    if df.empty:
        return None
    sns.set(style='whitegrid')
    fig, ax = plt.subplots(figsize=(10, 6))
    sns.barplot(x='Count', y='Item', data=df, palette='viridis', ax=ax)
    plt.tight_layout()
    return ax

# Clone zero-shot deepseek-r1:14b-code 1 ['refac_1,refac_3,refac_4']
from collections import defaultdict
import matplotlib.pyplot as plt
import pandas as pd
import seaborn as sns


def task_func(list_of_menuitems):
    if not list_of_menuitems:
        return None
    flat_list = []
    for sublist in list_of_menuitems:
        if sublist:
            flat_list.extend(sublist)
    if not flat_list:
        return None
    counter = defaultdict(int)
    for item in flat_list:
        counter[item] += 1
    df = pd.DataFrame(counter.items(), columns=['Item', 'Count'])
    if df.empty:
        return None
    sns.set(style='darkgrid')
    ax = sns.barplot(x='Count', y='Item', data=df, palette='plasma')
    plt.tight_layout()
    return ax

