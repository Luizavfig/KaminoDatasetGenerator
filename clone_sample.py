# BigCodeBench/751 - Sample random numbers based on a given weighted distribution and return a histogram of the samples.
# original_code 
import random
from collections import Counter
def task_func(values, weights, n_samples):
    samples = random.choices(values, weights=weights, k=n_samples)
    histogram = dict(Counter(samples))
    return histogram 

#selected zero-shot deepseek-r1:14b-code 1 ['refac_2,refac_5,refac_6']
import random
from collections import defaultdict
def task_func(values, weights, n_samples):
    samples = [random.choices(values, weights=weights)[0] for _ in range(n_samples)]
    histogram = defaultdict(int)
    for sample in samples: histogram[sample] += 1
    return dict(histogram) 


# similar to original
import random
import collections
def task_func(values, weights, n_samples):
    samples = random.choices(values, weights=weights, k=n_samples)
    histogram = collections.Counter(samples)
    return dict(histogram)

# similar with selected zero-shot deepseek-r1:14b-ast 1 ['refac_2,refac_5,refac_6']
import random
from collections import Counter
def task_func(values, weights, n_samples):
    samples = [random.choices(values, weights=weights)[0] for _ in range(n_samples)]
    histogram = {}
    counts = Counter(samples)
    for value in values:
        histogram[value] = counts.get(value, 0)
    return histogram

