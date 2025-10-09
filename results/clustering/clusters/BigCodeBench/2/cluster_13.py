# Clone zero-shot gpt-oss:latest-uml 1 nfr5
import random
import statistics


def task_func(LETTERS):
    """
    Generate random integer lists for each letter, compute their means,
    and return a dictionary sorted by mean values in descending order.
    """
    data = {letter: [random.randint(1, 100) for _ in range(10)] for letter in
        LETTERS}
    means = {letter: statistics.mean(values) for letter, values in data.items()
        }
    sorted_letters = sorted(means, key=means.get, reverse=True)
    sorted_dict = {letter: data[letter] for letter in sorted_letters}
    return sorted_dict


if __name__ == '__main__':
    print(task_func(['a', 'b', 'c']))

