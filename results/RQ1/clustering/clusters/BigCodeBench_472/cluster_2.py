# Clone zero-shot deepseek-r1:14b-test 1 ['refac_3', 'refac_5', 'refac_7']
import numpy as np
from sklearn.cluster import KMeans
import matplotlib.pyplot as plt


def task_func(myList, n_clusters):
    if not myList or n_clusters <= 0:
        raise ValueError('Invalid input parameters')
    points = np.array(myList)
    if len(points) < n_clusters:
        raise ValueError('Number of clusters exceeds the number of points')
    kmeans = KMeans(n_clusters=n_clusters, random_state=42).fit(points)
    labels = kmeans.labels_
    plt.figure(figsize=(10, 8))
    ax = plt.gca()
    scatter = ax.scatter(points[:, 0], points[:, 1], c=labels, cmap='viridis')
    centers = kmeans.cluster_centers_
    ax.scatter(centers[:, 0], centers[:, 1], marker='x', color='red', s=100)
    return ax

# Clone zero-shot deepseek-r1:14b-ast 1 ['refac_2', 'refac_6', 'refac_7']
import numpy as np
from sklearn.cluster import KMeans
import matplotlib.pyplot as plt


def task_func(myList, n_clusters):
    if not isinstance(myList, list) or len(myList) == 0:
        raise ValueError(
            'Invalid input: myList must be a non-empty list of points')
    try:
        X = np.array(myList)
        kmeans = KMeans(n_clusters=n_clusters, random_state=42, n_init=10)
        kmeans.fit(X)
        fig, ax = plt.subplots()
        colors = kmeans.labels_
        centers = kmeans.cluster_centers_
        ax.scatter(*zip(*myList), c=colors)
        ax.scatter(*zip(*centers), marker='x', color='red')
        plt.show()
        return ax
    except Exception as e:
        raise ValueError(f'Error during clustering: {e}')

# Clone cot deepseek-r1:14b-test 1 ['refac_2', 'refac_5', 'refac_6']
import numpy as np
from sklearn.cluster import KMeans
import matplotlib.pyplot as plt


def task_func(myList, n_clusters):
    if not myList or n_clusters <= 0:
        raise ValueError('Invalid input parameters')
    points = np.array(myList)
    kmeans = KMeans(n_clusters=n_clusters, random_state=42).fit(points)
    labels = kmeans.labels_
    plt.figure(figsize=(10, 8))
    ax = plt.gca()
    scatter = ax.scatter(points[:, 0], points[:, 1], c=labels, cmap='viridis')
    centers = kmeans.cluster_centers_
    ax.scatter(centers[:, 0], centers[:, 1], marker='x', color='red',
        linewidths=2)
    return ax

# Clone zero-shot gemma3:latest-complete 1 ['refac_2', 'refac_6', 'refac_7']
import matplotlib.pyplot as plt
from sklearn.cluster import KMeans
import numpy as np


def task_func(myList, n_clusters):
    if not isinstance(myList, list):
        raise TypeError('Input must be a list')
    if not all(isinstance(point, list) and len(point) == 2 for point in myList
        ):
        raise ValueError('Each point must be a list of two numbers')
    if n_clusters <= 0:
        raise ValueError('Number of clusters must be positive')
    try:
        points = np.array(myList)
        kmeans = KMeans(n_clusters=n_clusters, random_state=42, n_init=10)
        kmeans.fit(points)
        labels = kmeans.labels_
        centers = kmeans.cluster_centers_
        fig, ax = plt.subplots()
        ax.scatter(points[:, 0], points[:, 1], c=labels, s=50)
        ax.scatter(centers[:, 0], centers[:, 1], marker='x', color='red', s=100
            )
        ax.set_title('KMeans Clustering')
        plt.show()
        return ax
    except Exception as e:
        raise ValueError(f'An error occurred: {e}')

