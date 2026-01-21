# Clone cot gpt-oss:20b-test 1 ['refac_1', 'refac_3', 'refac_7']
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

