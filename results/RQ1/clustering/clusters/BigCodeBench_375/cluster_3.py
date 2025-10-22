# Clone zero-shot gpt-oss:20b-test 1 ['refac_1', 'refac_3', 'refac_4']
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

# Clone cot gpt-oss:20b-test 1 ['refac_1', 'refac_3', 'refac_4']
import numpy as np
import matplotlib.pyplot as plt


def task_func(l):
    """Perform PCA on 2D array and plot first two components."""
    X = np.asarray(l, dtype=float)
    mean = tuple(X.mean(axis=0))
    Xc = X - np.array(mean)
    U, S, Vt = np.linalg.svd(Xc, full_matrices=False)
    scores = Xc @ Vt.T
    fig, ax = plt.subplots()
    ax.scatter(scores[:, 0], scores[:, 1])
    ax.set_title('PCA Result')
    ax.set_xlabel('First Principal Component')
    ax.set_ylabel('Second Principal Component')
    return ax

