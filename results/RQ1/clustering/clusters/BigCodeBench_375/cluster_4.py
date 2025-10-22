# Clone zero-shot gemma3:latest-test 1 ['refac_2', 'refac_6', 'refac_7']
import numpy as np
import matplotlib.pyplot as plt


def task_func(l):
    if not isinstance(l, np.ndarray):
        raise TypeError('Input must be a NumPy array.')
    if l.ndim != 2 or l.shape[1] != 2:
        raise ValueError('Input array must be 2D with 2 columns.')
    U, s, Vt = np.linalg.svd(l)
    plt.figure(figsize=(8, 6))
    plt.scatter(l[:, 0], l[:, 1])
    plt.title('PCA Result')
    plt.xlabel('First Principal Component')
    plt.ylabel('Second Principal Component')
    plt.axis('equal')
    plt.grid(True)
    plt.show()
    return plt.gca()

# Clone zero-shot gemma3:latest-test 1 ['refac_2', 'refac_4', 'refac_6']
import numpy as np
import matplotlib.pyplot as plt


def task_func(l):
    """
    Performs Principal Component Analysis (PCA) on the given array 
    and records the first two main components.
    """
    if not isinstance(l, np.ndarray):
        raise TypeError('Input must be a NumPy array.')
    if l.ndim != 2:
        raise ValueError('Input array must be 2D.')
    U, s, V = np.linalg.svd(l)
    plt.figure(figsize=(8, 6))
    plt.scatter(l[:, 0], l[:, 1])
    plt.title('PCA Result')
    plt.xlabel('First Principal Component')
    plt.ylabel('Second Principal Component')
    plt.axis('equal')
    plt.grid(True)
    plt.show()
    return plt.gca()

# Clone cot gemma3:latest-test 1 ['refac_2', 'refac_6', 'refac_7']
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

# Clone cot gemma3:latest-test 1 ['refac_1', 'refac_3', 'refac_4']
import numpy as np
import matplotlib.pyplot as plt


def task_func(l):
    u, s, v = np.linalg.svd(l)
    plt.figure()
    plt.scatter(l[:, 0], l[:, 1])
    plt.title('PCA Result')
    plt.xlabel('First Principal Component')
    plt.ylabel('Second Principal Component')
    plt.axis('equal')
    plt.show()
    return plt.gca()

# Clone cot gemma3:latest-test 1 ['refac_2', 'refac_5', 'refac_6']
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

# Clone cot gemma3:latest-test 1 ['refac_2', 'refac_4', 'refac_6']
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

# Clone cot gemma3:latest-test 1 ['refac_1', 'refac_3', 'refac_7']
import numpy as np
import matplotlib.pyplot as plt


def task_func(l):
    u, s, v = np.linalg.svd(l)
    plt.figure()
    plt.scatter(l[:, 0], l[:, 1])
    plt.title('PCA Result')
    plt.xlabel('First Principal Component')
    plt.ylabel('Second Principal Component')
    plt.axis('equal')
    plt.show()
    return plt.gca()

