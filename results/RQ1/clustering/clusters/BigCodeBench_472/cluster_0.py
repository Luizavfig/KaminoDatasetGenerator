# Clone zero-shot gemma3:latest-ast 1 ['refac_1', 'refac_4', 'refac_5']
import numpy as np
import matplotlib.pyplot as plt
from sklearn.cluster import KMeans


def task_func(myList, n_clusters):
    
    points = np.array(myList)
    kmeans = KMeans(n_clusters=n_clusters, random_state=42, n_init=10)
    kmeans.fit(points)
    labels = kmeans.labels_
    centers = kmeans.cluster_centers_
    fig = plt.figure()
    ax = fig.add_subplot(111)
    ax.scatter(points[:, 0], points[:, 1], c=labels, cmap='viridis')
    ax.scatter(centers[:, 0], centers[:, 1], c='red', marker='x', s=100)
    return ax

# Clone zero-shot gemma3:latest-ast 1 ['refac_1', 'refac_3', 'refac_4']
import numpy as np
import matplotlib.pyplot as plt
from sklearn.cluster import KMeans


def task_func(myList, n_clusters):
    
    points = np.array(myList)
    kmeans = KMeans(n_clusters=n_clusters, random_state=42, n_init=10)
    kmeans.fit(points)
    labels = kmeans.labels_
    centers = kmeans.cluster_centers_
    fig = plt.figure()
    ax = fig.add_subplot(111)
    ax.scatter(points[:, 0], points[:, 1], c=labels, cmap='viridis')
    ax.scatter(centers[:, 0], centers[:, 1], c='red', marker='x', s=100)
    return ax

# Clone cot gemma3:latest-ast 1 ['refac_3', 'refac_5', 'refac_7']
import matplotlib.pyplot as plt
from sklearn.cluster import KMeans
import numpy as np


def task_func(myList, n_clusters):
    kmeans = KMeans(n_clusters=n_clusters, random_state=42, n_init=10)
    kmeans.fit(myList)
    labels = kmeans.labels_
    centers = kmeans.cluster_centers_
    fig, ax = plt.subplots()
    ax.scatter(np.array(myList)[:, 0], np.array(myList)[:, 1], c=labels)
    ax.scatter(np.array(centers)[:, 0], np.array(centers)[:, 1], marker='x',
        color='red')
    return ax

# Clone cot gemma3:latest-ast 1 ['refac_2', 'refac_4', 'refac_6']
import numpy as np
import matplotlib.pyplot as plt
from sklearn.cluster import KMeans


def task_func(myList, n_clusters):
    
    kmeans = KMeans(n_clusters=n_clusters, random_state=42, n_init=10)
    kmeans.fit(myList)
    labels = kmeans.labels_
    centers = kmeans.cluster_centers_
    fig = plt.figure()
    ax = fig.add_subplot(111)
    ax.scatter(np.array(myList)[:, 0], np.array(myList)[:, 1], c=labels,
        cmap='viridis')
    ax.scatter(np.array(centers)[:, 0], np.array(centers)[:, 1], marker='x',
        color='red')
    return ax

# Clone cot gemma3:latest-ast 1 ['refac_1', 'refac_3', 'refac_7']
import numpy as np
import matplotlib.pyplot as plt
from sklearn.cluster import KMeans
import random


def task_func(myList, n_clusters):
    points = np.array(myList)
    kmeans = KMeans(n_clusters=n_clusters, random_state=42, n_init=10)
    kmeans.fit(points)
    labels = kmeans.labels_
    centers = kmeans.cluster_centers_
    fig, ax = plt.subplots()
    ax.scatter(points[:, 0], points[:, 1], c=labels, cmap='viridis')
    ax.scatter(centers[:, 0], centers[:, 1], marker='x', color='red')
    return ax

