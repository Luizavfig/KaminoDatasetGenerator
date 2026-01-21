# Clone zero-shot deepseek-r1:14b-test 1 ['refac_1', 'refac_3', 'refac_7']
import numpy as np
import matplotlib.pyplot as plt


def task_func(l):
    mean = np.mean(l, axis=0)
    centered_data = l - mean
    covariance_matrix = np.cov(centered_data.T)
    eigen_values, eigen_vectors = np.linalg.eigh(covariance_matrix)
    sorted_indices = np.argsort(eigen_values)[::-1]
    eigen_values = eigen_values[sorted_indices]
    eigen_vectors = eigen_vectors[:, sorted_indices]
    pc = np.dot(centered_data, eigen_vectors)
    fig, ax = plt.subplots()
    scatter = ax.scatter(pc[:, 0], pc[:, 1])
    ax.set_xlabel('First Principal Component')
    ax.set_ylabel('Second Principal Component')
    ax.set_title('PCA Result')
    return ax

# Clone zero-shot gpt-oss:20b-test 1 ['refac_2', 'refac_6', 'refac_7']
import numpy as np
import matplotlib.pyplot as plt
import logging
logging.basicConfig(level=logging.INFO)
logger = logging.getLogger(__name__)


def task_func(l):
    try:
        if not isinstance(l, np.ndarray):
            raise TypeError('Input must be a numpy array')
        if l.ndim != 2:
            raise ValueError('Input array must be 2-dimensional')
        if not np.issubdtype(l.dtype, np.number):
            raise TypeError('Input array must contain numeric data')
        mean = np.mean(l, axis=0)
        centered = l - mean
        cov = np.cov(centered, rowvar=False)
        eigvals, eigvecs = np.linalg.eigh(cov)
        idx = np.argsort(eigvals)[::-1]
        eigvecs = eigvecs[:, idx]
        projected = np.dot(centered, eigvecs[:, :2])
        fig, ax = plt.subplots()
        ax.scatter(projected[:, 0], projected[:, 1])
        ax.set_title('PCA Result')
        ax.set_xlabel('First Principal Component')
        ax.set_ylabel('Second Principal Component')
        return ax
    except Exception as e:
        logger.exception('Error in task_func')
        raise

# Clone zero-shot gpt-oss:20b-test 1 ['refac_2', 'refac_4', 'refac_6']
import numpy as np
import matplotlib.pyplot as plt
import logging
logging.basicConfig(level=logging.INFO)
logger = logging.getLogger(__name__)


def task_func(data):
    """
    Perform PCA on the input array and plot the first two principal components.
    """
    try:
        arr = np.asarray(data, dtype=float)
    except Exception as e:
        logger.error('Input cannot be converted to a numeric array: %s', e)
        raise ValueError('Input must be array-like with numeric values.'
            ) from e
    if arr.ndim != 2:
        logger.error('Input array has %d dimensions; expected 2.', arr.ndim)
        raise ValueError('Input must be a 2D array.')
    n_samples, n_features = arr.shape
    if n_features < 2:
        logger.error('Input array has only %d feature(s); at least 2 required.'
            , n_features)
        raise ValueError('Input must have at least two features for PCA.')
    mean = np.mean(arr, axis=0)
    centered = arr - mean
    cov = np.cov(centered, rowvar=False)
    eigvals, eigvecs = np.linalg.eigh(cov)
    idx = np.argsort(eigvals)[::-1]
    eigvecs = eigvecs[:, idx]
    pc1 = centered @ eigvecs[:, 0]
    pc2 = centered @ eigvecs[:, 1]
    projected = np.column_stack((pc1, pc2))
    fig, ax = plt.subplots()
    ax.scatter(projected[:, 0], projected[:, 1], c='blue', edgecolor='k', s=50)
    ax.set_title('PCA Result')
    ax.set_xlabel('First Principal Component')
    ax.set_ylabel('Second Principal Component')
    ax.grid(True)
    return ax

# Clone cot gpt-oss:20b-test 1 ['refac_1', 'refac_4', 'refac_5']
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

# Clone cot gpt-oss:20b-test 1 ['refac_2', 'refac_5', 'refac_6']
import numpy as np
import matplotlib.pyplot as plt
import logging


def task_func(data):
    logger = logging.getLogger(__name__)
    if not isinstance(data, np.ndarray):
        raise TypeError('Input must be a numpy array')
    if data.ndim != 2:
        raise ValueError('Input array must be 2-dimensional')
    n_samples, n_features = data.shape
    if n_samples < 2:
        raise ValueError('Input array must contain at least two samples')
    if n_features < 2:
        raise ValueError('Input array must have at least two features')
    mean = np.mean(data, axis=0)
    centered = data - mean
    cov = np.cov(centered, rowvar=False)
    eigvals, eigvecs = np.linalg.eigh(cov)
    idx = np.argsort(eigvals)[::-1]
    eigvecs = eigvecs[:, idx]
    pc = centered @ eigvecs[:, :2]
    fig, ax = plt.subplots()
    ax.scatter(pc[:, 0], pc[:, 1])
    ax.set_title('PCA Result')
    ax.set_xlabel('First Principal Component')
    ax.set_ylabel('Second Principal Component')
    return ax

# Clone cot gpt-oss:20b-complete 1 ['refac_1', 'refac_3', 'refac_4']
import numpy as np
import matplotlib.pyplot as plt


def task_func(l):
    centered = l - l.mean(axis=0)
    cov = np.cov(centered, rowvar=False)
    eigvals, eigvecs = np.linalg.eigh(cov)
    idx = np.argsort(eigvals)[::-1]
    eigvecs = eigvecs[:, idx[:2]]
    pcs = centered @ eigvecs
    fig, ax = plt.subplots()
    ax.scatter(pcs[:, 0], pcs[:, 1])
    ax.set_title('PCA Result')
    ax.set_xlabel('First Principal Component')
    ax.set_ylabel('Second Principal Component')
    return ax

# Clone cot gpt-oss:20b-complete 1 ['refac_2', 'refac_4', 'refac_6']
import numpy as np
import matplotlib.pyplot as plt
import logging
logging.basicConfig(level=logging.ERROR)
logger = logging.getLogger(__name__)


def task_func(l):
    try:
        arr = np.asarray(l)
    except Exception as e:
        logger.error('Input conversion to array failed: %s', e)
        raise ValueError('Input must be array-like') from e
    if arr.ndim != 2:
        raise ValueError('Input must be a 2D array')
    n_samples, n_features = arr.shape
    if n_features < 2:
        raise ValueError('Input must have at least two features')
    if n_samples < 1:
        raise ValueError('Input must contain at least one sample')
    if not np.issubdtype(arr.dtype, np.number):
        raise ValueError('Input array must contain numeric data')
    mean = arr.mean(axis=0)
    centered = arr - mean
    cov = np.cov(centered, rowvar=False, bias=False)
    eigvals, eigvecs = np.linalg.eigh(cov)
    idx = np.argsort(eigvals)[::-1]
    components = eigvecs[:, idx[:2]]
    projected = centered @ components
    fig, ax = plt.subplots()
    ax.scatter(projected[:, 0], projected[:, 1])
    ax.set_xlabel('First Principal Component')
    ax.set_ylabel('Second Principal Component')
    ax.set_title('PCA Result')
    return ax

