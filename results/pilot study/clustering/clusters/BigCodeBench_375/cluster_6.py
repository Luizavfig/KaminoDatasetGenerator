# Clone zero-shot deepseek-r1:14b-test 1 ['refac_1', 'refac_4', 'refac_5']
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

# Clone zero-shot deepseek-r1:14b-test 1 ['refac_2', 'refac_6', 'refac_7']
import numpy as np
from matplotlib import pyplot as plt


def task_func(l):
    if not isinstance(l, np.ndarray) or l.ndim != 2 or l.shape[1] < 2:
        raise ValueError(
            'Input must be a 2D numpy array with at least two columns.')
    centered_data = l - np.mean(l, axis=0)
    cov_matrix = np.cov(centered_data, rowvar=False)
    eigen_values, eigen_vectors = np.linalg.eigh(cov_matrix)
    sorted_idx = np.argsort(eigen_values)[::-1]
    eigen_values = eigen_values[sorted_idx]
    eigen_vectors = eigen_vectors[:, sorted_idx]
    pc = np.dot(centered_data, eigen_vectors)
    fig, ax = plt.subplots()
    scatter = ax.scatter(pc[:, 0], pc[:, 1])
    ax.set_title('PCA Result')
    ax.set_xlabel('First Principal Component')
    ax.set_ylabel('Second Principal Component')
    return ax

# Clone zero-shot deepseek-r1:14b-test 1 ['refac_1', 'refac_3', 'refac_4']
import numpy as np
from sklearn.decomposition import PCA
import matplotlib.pyplot as plt


def task_func(arr):
    """
    Perform Principal Component Analysis (PCA) on the given 2D array and plot the first two principal components.

    Parameters:
        arr (numpy.ndarray): A 2D numpy array of shape (n, 2)

    Returns:
        matplotlib.axes.Axes: The Axes object containing the PCA result plot
    """
    pca = PCA(n_components=2)
    principal_components = pca.fit_transform(arr)
    fig, ax = plt.subplots()
    scatter = ax.scatter(principal_components[:, 0], principal_components[:, 1]
        )
    ax.set_xlabel('First Principal Component')
    ax.set_ylabel('Second Principal Component')
    ax.set_title('PCA Result')
    if arr.shape[1] >= 3:
        unique_classes = np.unique(arr[:, 2])
        colors = plt.cm.viridis(np.linspace(0, 1, len(unique_classes)))
        for cls, color in zip(unique_classes, colors):
            mask = arr[:, 2] == cls
            ax.scatter(principal_components[mask, 0], principal_components[
                mask, 1], c=color, label=cls)
        ax.legend()
    return ax

# Clone zero-shot deepseek-r1:14b-test 1 ['refac_2', 'refac_4', 'refac_6']
import numpy as np
from matplotlib import pyplot as plt


def task_func(data):
    """
    Perform PCA on the given 2D array and plot the first two principal components.

    Args:
        data (numpy.ndarray): A 2D array where each row represents a sample and each column represents a feature.

    Returns:
        matplotlib.axes.Axes: The axes object containing the PCA plot.

    Raises:
        ValueError: If the input data does not have at least two features or is not a numpy array.
    """
    if not isinstance(data, np.ndarray) or data.ndim != 2 or data.shape[1] < 2:
        raise ValueError(
            'Input must be a 2D numpy array with at least two columns.')
    mean = np.mean(data, axis=0)
    centered_data = data - mean
    covariance_matrix = np.cov(centered_data, rowvar=False)
    eigenvalues, eigenvectors = np.linalg.eigh(covariance_matrix)
    sorted_indices = np.argsort(eigenvalues)[::-1]
    eigenvalues = eigenvalues[sorted_indices]
    eigenvectors = eigenvectors[:, sorted_indices]
    principal_components = centered_data.dot(eigenvectors)
    fig, ax = plt.subplots()
    scatter = ax.scatter(principal_components[:, 0], principal_components[:, 1]
        )
    ax.set_xlabel('First Principal Component')
    ax.set_ylabel('Second Principal Component')
    ax.set_title('PCA Result')
    return ax

