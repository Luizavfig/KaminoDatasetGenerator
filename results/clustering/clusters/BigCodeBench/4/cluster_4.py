# Clone zero-shot gpt-oss:20b-complete 1 nfr3
def task_func(d):
    """
    Count occurrences of integer values across all lists in a dictionary.

    Parameters
    ----------
    d : dict
        A mapping where each value is a list of integers.

    Returns
    -------
    dict
        A dictionary mapping each integer to its total count across all lists.

    Raises
    ------
    TypeError
        If any element in any list is not an instance of int.
    """
    counts = {}
    for lst in d.values():
        for item in lst:
            if not isinstance(item, int):
                raise TypeError(f'Non-integer value encountered: {item!r}')
            counts[item] = counts.get(item, 0) + 1
    return counts

# Clone few-shot gpt-oss:20b-complete 1 nfr0
from collections import Counter


def task_func(d):
    """
    Count occurrences of integer values in the lists that are the values of the input dictionary.

    Parameters
    ----------
    d : dict
        Dictionary where each value is expected to be an iterable of integers.

    Returns
    -------
    dict
        Mapping from each integer found to its total count across all lists.

    Raises
    ------
    TypeError
        If any element in any of the lists is not an integer.
    """
    all_values = []
    for value_list in d.values():
        for item in value_list:
            if not isinstance(item, int):
                raise TypeError(f'Non-integer value encountered: {item!r}')
            all_values.append(item)
    return dict(Counter(all_values))

# Clone cot gpt-oss:20b-complete 1 nfr3
import collections


def task_func(d):
    """
    Count occurrences of each integer in all list values of the dictionary.

    Parameters
    ----------
    d : dict
        Mapping from keys to lists of integers.

    Returns
    -------
    dict
        Mapping from integer to its total count across all lists.

    Raises
    ------
    TypeError
        If any element in the lists is not an integer.
    """
    counter = collections.Counter()
    for lst in d.values():
        for item in lst:
            if not isinstance(item, int):
                raise TypeError(f'Non-integer element encountered: {item!r}')
            counter[item] += 1
    return dict(counter)

