# Cluster 0 - Representative clone zero-shot deepseek-r1:14b-test 1 ['refac_3', 'refac_5', 'refac_7']
import numpy as np
from sklearn.decomposition import PCA
import matplotlib.pyplot as plt


def task_func(l):
    pca = PCA(n_components=2)
    principal_components = pca.fit_transform(l)
    fig, ax = plt.subplots()
    scatter = ax.scatter(principal_components[:, 0], principal_components[:, 1]
        )
    ax.set_xlabel('First Principal Component')
    ax.set_ylabel('Second Principal Component')
    ax.set_title('PCA Result')
    return ax

# Cluster 1 - Representative clone cot gpt-oss:20b-test 1 ['refac_2', 'refac_6', 'refac_7']
import logging
import numpy as np
import matplotlib.pyplot as plt
from sklearn.decomposition import PCA
logging.basicConfig(level=logging.INFO)
logger = logging.getLogger(__name__)


def task_func(l):
    if not isinstance(l, np.ndarray):
        logger.error('Input is not a numpy array')
        raise TypeError('Input must be a numpy.ndarray')
    if l.ndim != 2:
        logger.error('Input array must be 2-dimensional')
        raise ValueError('Input array must be 2-dimensional')
    if not np.issubdtype(l.dtype, np.number):
        logger.error('Input array must contain numeric data')
        raise TypeError('Input array must contain numeric data')
    n_samples, n_features = l.shape
    if n_samples < 2 or n_features < 2:
        logger.error('Input array must have at least 2 samples and 2 features')
        raise ValueError(
            'Input array must have at least 2 samples and 2 features')
    if not isinstance(l, np.ndarray):
        logger.error('Duplicate check: Input is not a numpy array')
        raise TypeError('Input must be a numpy.ndarray')
    try:
        pca = PCA(n_components=2)
        transformed = pca.fit_transform(l)
    except Exception as e:
        logger.exception('PCA computation failed')
        raise RuntimeError('PCA computation failed') from e
    try:
        pca2 = PCA(n_components=2)
        transformed2 = pca2.fit_transform(l)
    except Exception as e:
        logger.exception('Duplicate PCA computation failed')
        raise RuntimeError('Duplicate PCA computation failed') from e
    try:
        fig, ax = plt.subplots()
        ax.scatter(transformed[:, 0], transformed[:, 1], s=20, color='blue')
        ax.set_title('PCA Result')
        ax.set_xlabel('First Principal Component')
        ax.set_ylabel('Second Principal Component')
    except Exception as e:
        logger.exception('Plotting failed')
        raise RuntimeError('Plotting failed') from e
    return ax

# Cluster 2 - Representative clone cot gpt-oss:20b-test 1 ['refac_1', 'refac_4', 'refac_5']
import numpy as np
import matplotlib.pyplot as plt


def task_func(l):
    """Perform PCA and plot first two components."""
    mean = np.mean(l, axis=0)
    centered = l - mean
    cov = np.cov(centered, rowvar=False)
    eigvals, eigvecs = np.linalg.eigh(cov)
    idx = np.argsort(eigvals)[::-1]
    eigvecs = eigvecs[:, idx]
    proj = centered @ eigvecs[:, :2]
    fig, ax = plt.subplots()
    ax.scatter(proj[:, 0], proj[:, 1])
    ax.set_title('PCA Result')
    ax.set_xlabel('First Principal Component')
    ax.set_ylabel('Second Principal Component')
    return ax

# Cluster 3 - Representative clone zero-shot gpt-oss:20b-test 1 ['refac_1', 'refac_3', 'refac_4']
import numpy as np
import matplotlib.pyplot as plt


def task_func(data):
    """Perform PCA and plot the first two principal components."""
    X = np.asarray(data, dtype=float)
    Xc = X - X.mean(axis=0)
    U, S, Vt = np.linalg.svd(Xc, full_matrices=False)
    comps = tuple(Vt[:2])
    proj = Xc @ np.array(comps).T
    pts = {'pc1': proj[:, 0], 'pc2': proj[:, 1]}
    fig, ax = plt.subplots()
    ax.scatter(pts['pc1'], pts['pc2'])
    ax.set_title('PCA Result')
    ax.set_xlabel('First Principal Component')
    ax.set_ylabel('Second Principal Component')
    return ax

# Cluster 4 - Representative clone cot gemma3:latest-test 1 ['refac_2', 'refac_5', 'refac_6']
import numpy as np
import matplotlib.pyplot as plt


def task_func(l):
    u, s, v = np.linalg.svd(l)
    plt.figure(figsize=(8, 6))
    plt.scatter(l[:, 0], l[:, 1])
    plt.title('PCA Result')
    plt.xlabel('First Principal Component')
    plt.ylabel('Second Principal Component')
    plt.axis('equal')
    plt.show()
    return plt.gca()

# Cluster 5 - Representative clone cot gpt-oss:20b-test 1 ['refac_1', 'refac_3', 'refac_7']
import numpy as np
import matplotlib.pyplot as plt


def task_func(data):
    m = {i: np.mean(data[:, i]) for i in range(data.shape[1])}
    centered = np.array([[(data[j, i] - m[i]) for i in range(data.shape[1])
        ] for j in range(data.shape[0])])
    cov = np.dot(centered.T, centered) / (data.shape[0] - 1)
    vals, vecs = np.linalg.eigh(cov)
    idx = sorted(range(len(vals)), key=lambda k: vals[k], reverse=True)
    vecs_sorted = np.array([vecs[:, i] for i in idx])
    proj = np.dot(centered, vecs_sorted[:, :2])
    fig, ax = plt.subplots()
    ax.scatter(proj[:, 0], proj[:, 1])
    ax.set_title('PCA Result')
    ax.set_xlabel('First Principal Component')
    ax.set_ylabel('Second Principal Component')
    return ax

# Cluster 6 - Representative clone zero-shot deepseek-r1:14b-test 1 ['refac_1', 'refac_4', 'refac_5']
import numpy as np
import matplotlib.pyplot as plt


def task_func(data):
    """
    Perform PCA on the given 2D array and plot the first two principal components.

    Parameters:
        data (numpy.ndarray): A 2D numpy array of shape (n_samples, n_features)

    Returns:
        matplotlib.axes.Axes: The Axes object containing the plotted results
    """
    centered_data = data - np.mean(data, axis=0)
    covariance_matrix = np.cov(centered_data, rowvar=False)
    eigen_values, eigen_vectors = np.linalg.eigh(covariance_matrix)
    sorted_indices = np.argsort(eigen_values)[::-1]
    eigen_values = eigen_values[sorted_indices]
    eigen_vectors = eigen_vectors[:, sorted_indices]
    principal_components = centered_data.dot(eigen_vectors)
    fig, ax = plt.subplots()
    scatter = ax.scatter(principal_components[:, 0], principal_components[:, 1]
        )
    ax.set_title('PCA Result')
    ax.set_xlabel('First Principal Component')
    ax.set_ylabel('Second Principal Component')
    return ax

# Cluster 7 - Representative clone zero-shot deepseek-r1:14b-test 1 ['refac_2', 'refac_5', 'refac_6']
import numpy as np
from sklearn.decomposition import PCA


def task_func(data):
    if not isinstance(data, np.ndarray) or len(data.shape) != 2:
        raise ValueError('Input must be a 2D numpy array.')
    if data.shape[1] < 2:
        raise ValueError('Data must have at least two features for PCA.')
    normalized_data = data - np.mean(data, axis=0)
    pca = PCA(n_components=2)
    principal_components = pca.fit_transform(normalized_data)
    plt.figure()
    scatter = plt.scatter(principal_components[:, 0], principal_components[
        :, 1])
    plt.title('PCA Result')
    plt.xlabel('First Principal Component')
    plt.ylabel('Second Principal Component')
    return plt.gca()

