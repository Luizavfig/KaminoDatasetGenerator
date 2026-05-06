# Clone zero-shot deepseek-r1:14b-complete 1 ['refac_2', 'refac_4', 'refac_6']
import numpy as np
from sklearn.cluster import KMeans
import matplotlib.pyplot as plt


def task_func(myList, n_clusters):
    
    if not isinstance(myList, list) or len(myList) == 0:
        raise ValueError('Input list must contain at least one point')
    if not isinstance(n_clusters, int) or n_clusters <= 0:
        raise ValueError('Number of clusters must be a positive integer')
    points = np.array(myList)
    kmeans = KMeans(n_clusters=n_clusters, random_state=42, n_init=10)
    kmeans.fit(points)
    fig, ax = plt.subplots()
    ax.scatter(points[:, 0], points[:, 1], c=kmeans.labels_, alpha=0.6)
    ax.scatter(kmeans.cluster_centers_[:, 0], kmeans.cluster_centers_[:, 1],
        marker='x', color='red', s=100, linewidths=2)
    return ax

