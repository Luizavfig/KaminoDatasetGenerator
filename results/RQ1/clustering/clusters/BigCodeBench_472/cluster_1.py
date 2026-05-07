# Clone zero-shot deepseek-r1:14b-complete 1 ['refac_3', 'refac_5', 'refac_7']
import matplotlib.pyplot as plt
from sklearn.cluster import KMeans


def task_func(myList, n_clusters):
    if not isinstance(myList, list) or len(myList) == 0:
        raise ValueError('Invalid inputs')
    if not isinstance(n_clusters, int) or n_clusters <= 0:
        raise ValueError('Invalid number of clusters')
    if n_clusters > len(myList):
        raise ValueError('Too many clusters for the given data')
    points = [tuple(point) for point in myList]
    kmeans = KMeans(n_clusters=n_clusters, random_state=42, n_init=10)
    kmeans.fit(points)
    fig = plt.figure()
    ax = fig.add_subplot(111)
    scatter = ax.scatter(*zip(*myList), c=kmeans.labels_)
    centers = kmeans.cluster_centers_
    ax.scatter(*zip(*centers), marker='x', color='red')
    return ax

# Clone zero-shot deepseek-r1:14b-complete 1 ['refac_1', 'refac_3', 'refac_7']
import matplotlib.pyplot as plt
from sklearn.cluster import KMeans


def task_func(myList, n_clusters):
    if not isinstance(myList, list) or len(myList) == 0:
        raise ValueError('Invalid inputs')
    if not isinstance(n_clusters, int) or n_clusters <= 0:
        raise ValueError('Invalid number of clusters')
    if n_clusters > len(myList):
        raise ValueError('Too many clusters for the given data')
    X = [point for point in myList]
    y = KMeans(n_clusters=n_clusters, random_state=42, n_init=10).fit_predict(X
        )
    fig = plt.figure()
    ax = fig.add_subplot(111)
    scatter = ax.scatter(*zip(*X), c=y)
    centers = KMeans(n_clusters=n_clusters).fit(X).cluster_centers_
    ax.scatter(*zip(*centers), marker='x', color='red')
    return ax

# Clone cot deepseek-r1:14b-complete 1 ['refac_3', 'refac_5', 'refac_7']
import matplotlib.pyplot as plt
from sklearn.cluster import KMeans


def task_func(myList, n_clusters):
    if not isinstance(myList, list) or len(myList) == 0:
        raise ValueError('Invalid inputs')
    if not isinstance(n_clusters, int) or n_clusters <= 0:
        raise ValueError('Invalid number of clusters')
    if n_clusters > len(myList):
        raise ValueError('Too many clusters for the given data')
    points = [tuple(point) for point in myList]
    kmeans = KMeans(n_clusters=n_clusters, random_state=42, n_init=10)
    kmeans.fit(points)
    fig = plt.figure()
    ax = fig.add_subplot(111)
    scatter = ax.scatter(*zip(*myList), c=kmeans.labels_)
    centers = kmeans.cluster_centers_
    ax.scatter(*zip(*centers), marker='x', color='red')
    return ax

