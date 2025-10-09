# Clone few-shot gpt-oss:latest-ast 1 nfr1
import random
import statistics


def task_func(LETTERS):
    random_dict = {}
    for letter in LETTERS:
        length = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(length)]
        random_dict[letter] = values
    mean_list = []
    for key, vals in random_dict.items():
        mean_val = statistics.mean(vals)
        mean_list.append((key, vals, mean_val))
    mean_list.sort(key=lambda x: x[2], reverse=True)
    sorted_dict = {}
    for key, vals, _ in mean_list:
        sorted_dict[key] = vals
    return sorted_dict


print(task_func(['a', 'b', 'c', 'd']))

# Clone cot gpt-oss:latest-requirements 1 nfr4
import random
import statistics


def task_func(LETTERS):
    if not LETTERS:
        return {}
    unique_letters = set(LETTERS)
    data = []
    for letter in unique_letters:
        length = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(length)]
        mean_val = statistics.mean(values)
        data.append((letter, values, mean_val))
    data.sort(key=lambda x: x[2], reverse=True)
    return {letter: values for letter, values, _ in data}


print(task_func(['A', 'B', 'C', 'A']))

