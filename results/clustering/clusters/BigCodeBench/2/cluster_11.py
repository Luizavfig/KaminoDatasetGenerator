# Clone few-shot gpt-oss:20b-ast 1 nfr3
import random
import statistics


def task_func(LETTERS):
    if not LETTERS:
        return {}
    data = {}
    for letter in LETTERS:
        length = random.randint(1, 10)
        numbers = []
        for _ in range(length):
            numbers.append(random.randint(0, 100))
        data[letter] = numbers

    def mean_of_pair(pair):
        return statistics.mean(pair[1])
    sorted_items = sorted(data.items(), key=mean_of_pair, reverse=True)
    sorted_dict = {}
    for k, v in sorted_items:
        sorted_dict[k] = v
    return sorted_dict

