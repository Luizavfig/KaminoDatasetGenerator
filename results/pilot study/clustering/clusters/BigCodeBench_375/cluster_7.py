# Clone zero-shot deepseek-r1:14b-test 1 ['refac_2', 'refac_5', 'refac_6']
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

