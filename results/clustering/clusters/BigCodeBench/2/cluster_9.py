# Clone cot gemma3:latest-translation 1 nfr2
import random
import statistics
from collections import OrderedDict


def task_func(letters):
    randomDict = {}
    for letter in letters:
        count = random.randint(1, 10)
        randomNumbers = [random.randint(1, 101) for _ in range(count)]
        randomDict[letter] = randomNumbers
    sortedList = sorted(randomDict.items(), key=lambda item: statistics.
        mean(item[1]), reverse=True)
    sortedDict = OrderedDict()
    for letter, numbers in sortedList:
        sortedDict[letter] = numbers
    return sortedDict

# Clone few-shot gpt-oss:20b-translation 1 nfr2
import random
import statistics
from collections import OrderedDict


def task_func(letters):
    """
    Generate a dictionary mapping each letter to a list of random integers,
    then sort the dictionary by the mean of the integer lists in descending order.

    Parameters
    ----------
    letters : Iterable[str]
        An iterable of single-character strings to be used as dictionary keys.

    Returns
    -------
    OrderedDict
        An ordered dictionary with letters as keys and lists of integers as values,
        sorted by the mean of the lists in descending order.
    """
    random_dict = {}
    for letter in letters:
        count = random.randint(1, 10)
        numbers = [random.randint(0, 100) for _ in range(count)]
        random_dict[letter] = numbers
    sorted_items = sorted(random_dict.items(), key=lambda kv: statistics.
        mean(kv[1]), reverse=True)
    return OrderedDict(sorted_items)

