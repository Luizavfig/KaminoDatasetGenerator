# Clone zero-shot deepseek-r1-requirements 1 nfr5
def task_func(d):
    """
    Returns a dictionary with keys as unique integers from the input lists and values as their counts.

    Args:
        d (dict): A dictionary where each key is a string and the value is a list of integers.

    Returns:
        dict: A dictionary mapping each integer to its count across all lists.
    """
    flattened_list = []
    for sublist in d.values():
        if isinstance(sublist, list):
            flattened_list.extend(sublist)
    return {item: flattened_list.count(item) for item in set(flattened_list)}

