# Clone zero-shot deepseek-r1-uml 1 nfr5
import random


def task_func(letters):
    """
    Generates a dictionary with keys from the input list and values as the mean of randomly generated lists.
    Each letter key has a value which is the mean of a list containing 1 to 10 random integers between 0 and 100.
    """
    num_elements = random.randint(1, 10)
    random_dict = {letter: [random.randint(0, 100) for _ in range(
        num_elements)] for letter in letters}
    mean_dict = {}
    for letter, numbers in random_dict.items():
        if len(numbers) == 0:
            continue
        mean_value = sum(numbers) / len(numbers)
        mean_dict[letter] = round(mean_value, 2)
    return mean_dict


if __name__ == '__main__':
    example_letters = ['a', 'b', 'c']
    result = task_func(example_letters)
    print(result)

