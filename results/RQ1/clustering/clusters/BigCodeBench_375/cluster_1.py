# Clone cot gpt-oss:20b-test 1 ['refac_2', 'refac_6', 'refac_7']
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

