# Clone zero-shot llama3.1:latest-minimal 1 nfr0
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        num_list = [random.randint(0, 100) for _ in range(random.randint(1,
            10))]
        result[letter] = sum(num_list) / len(num_list)
    return result

# Clone zero-shot llama3.1:latest-minimal 1 nfr1
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        numbers = [random.randint(0, 100) for _ in range(random.randint(1, 10))
            ]
        result[letter] = sum(numbers) / len(numbers)
    return result

# Clone zero-shot llama3.1:latest-minimal 1 nfr3
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        numbers = [random.randint(0, 100) for _ in range(random.randint(1, 10))
            ]
        result[letter] = sum(numbers) / len(numbers)
    return result

# Clone zero-shot llama3.1:latest-minimal 1 nfr4
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        numbers = [random.randint(0, 100) for _ in range(random.randint(1, 10))
            ]
        result[letter] = sum(numbers) / len(numbers)
    return result

# Clone zero-shot llama3.1:latest-requirements 1 nfr0
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        num_values = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(num_values)]
        result[letter] = sum(values) / num_values
    return result

# Clone zero-shot llama3.1:latest-requirements 1 nfr1
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        num_integers = random.randint(1, 10)
        integers = [random.randint(0, 100) for _ in range(num_integers)]
        result[letter] = sum(integers) / num_integers
    return result

# Clone zero-shot llama3.1:latest-requirements 1 nfr3
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        num_values = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(num_values)]
        result[letter] = sum(values) / num_values
    return result

# Clone zero-shot llama3.1:latest-requirements 1 nfr4
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        num_elements = random.randint(1, 10)
        elements = [random.randint(0, 100) for _ in range(num_elements)]
        result[letter] = sum(elements) / num_elements
    return result

# Clone zero-shot llama3.1:latest-uml 1 nfr0
import random


def task_func(LETTERS):
    random_dict = {}
    for letter in LETTERS:
        random_list = [random.randint(0, 100) for _ in range(random.randint
            (1, 10))]
        random_dict[letter] = random_list
    mean_dict = {}
    for key, value in random_dict.items():
        mean_dict[key] = sum(value) / len(value)
    return mean_dict

# Clone zero-shot llama3.1:latest-uml 1 nfr1
import random


def task_func(LETTERS):
    random_dict = {}
    for letter in LETTERS:
        random_list = [random.randint(0, 100) for _ in range(random.randint
            (1, 10))]
        random_dict[letter] = random_list
    mean_dict = {}
    for key, value in random_dict.items():
        mean_dict[key] = sum(value) / len(value)
    return mean_dict

# Clone zero-shot llama3.1:latest-uml 1 nfr3
import random


def task_func(LETTERS):
    random_dict = {}
    for letter in LETTERS:
        numbers = [random.randint(0, 100) for _ in range(random.randint(1, 10))
            ]
        random_dict[letter] = sum(numbers) / len(numbers)
    return random_dict

# Clone zero-shot llama3.1:latest-uml 1 nfr4
import random


def task_func(LETTERS):
    random_dict = {}
    for letter in LETTERS:
        numbers = [random.randint(0, 100) for _ in range(random.randint(1, 10))
            ]
        random_dict[letter] = sum(numbers) / len(numbers)
    return random_dict

# Clone zero-shot llama3.1:latest-minimal 1 nfr5
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        num_list = [random.randint(0, 100) for _ in range(random.randint(1,
            10))]
        result[letter] = sum(num_list) / len(num_list)
    return result

# Clone zero-shot llama3.1:latest-requirements 1 nfr5
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        num_values = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(num_values)]
        result[letter] = sum(values) / num_values
    return result

# Clone zero-shot llama3.1:latest-uml 1 nfr5
import random


def task_func(LETTERS):
    random_dict = {}
    for letter in LETTERS:
        numbers = [random.randint(0, 100) for _ in range(random.randint(1, 10))
            ]
        random_dict[letter] = sum(numbers) / len(numbers)
    return random_dict

# Clone zero-shot deepseek-r1-minimal 1 nfr0
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        num_list = [random.randint(0, 100) for _ in range(random.randint(1,
            10))]
        mean_val = sum(num_list) / len(num_list)
        result[letter] = round(mean_val, 2)
    return result

# Clone zero-shot deepseek-r1-minimal 1 nfr1
import random


def task_func(LETTERS):
    means = {}
    for letter in LETTERS:
        num_list = [random.randint(0, 100) for _ in range(random.randint(1,
            10))]
        mean_val = sum(num_list) / len(num_list)
        means[letter] = round(mean_val, 2)
    return means

# Clone zero-shot deepseek-r1-requirements 1 nfr0
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        n = random.randint(1, 10)
        numbers = [random.randint(0, 100) for _ in range(n)]
        mean_val = sum(numbers) / len(numbers) if n > 0 else 0.0
        result[letter] = round(mean_val, 2)
    return result

# Clone zero-shot deepseek-r1-requirements 1 nfr1
import random


def task_func(LETTERS):
    if not LETTERS:
        return {}
    result = {}
    for letter in LETTERS:
        n = random.randint(1, 10)
        numbers = [random.randint(0, 100) for _ in range(n)]
        mean_val = sum(numbers) / len(numbers) if n > 0 else 0.0
        result[letter] = round(mean_val, 2)
    return result

# Clone zero-shot deepseek-r1-requirements 1 nfr3
import random


def task_func(LETTERS):
    if not LETTERS:
        return {}
    result = {}
    for letter in LETTERS:
        n = random.randint(1, 10)
        numbers = [random.randint(0, 100) for _ in range(n)]
        mean_val = sum(numbers) / len(numbers) if n > 0 else 0.0
        result[letter] = round(mean_val, 2)
    return result

# Clone zero-shot deepseek-r1-requirements 1 nfr4
import random


def task_func(LETTERS):
    """
    Returns a dictionary with keys from LETTERS and values as the mean of randomly generated lists.
    Each list has a length between 1 and 10, and contains integers uniformly distributed between 0 and 100.
    If LETTERS is empty, returns an empty dictionary.
    """
    if not LETTERS:
        return {}
    result = {}
    for letter in LETTERS:
        n = random.randint(1, 10)
        rand_list = [random.randint(0, 100) for _ in range(n)]
        mean_val = sum(rand_list) / n if n > 0 else 0.0
        result[letter] = round(mean_val, 2)
    return result

# Clone zero-shot deepseek-r1-requirements 1 nfr5
import random


def task_func(LETTERS):
    """
    Returns a dictionary with keys from LETTERS and values as the mean of randomly generated lists.
    Each list has a length between 1 and 10, and each element is an integer between 0 and 100.
    If LETTERS is empty, returns an empty dictionary.
    """
    if not LETTERS:
        return {}
    result = {}
    for letter in LETTERS:
        n = random.randint(1, 10)
        numbers = [random.randint(0, 100) for _ in range(n)]
        mean_val = sum(numbers) / len(numbers)
        result[letter] = round(mean_val, 2)
    return result

# Clone zero-shot deepseek-r1-uml 1 nfr0
import random


def task_func(letters):
    random_dict = {}
    for letter in letters:
        num_list = [random.randint(0, 100) for _ in range(random.randint(1,
            10))]
        mean_value = sum(num_list) / len(num_list)
        random_dict[letter] = round(mean_value, 2)
    return random_dict

# Clone zero-shot deepseek-r1-uml 1 nfr1
import random


def task_func(letters):
    random_dict = {}
    for letter in letters:
        num_list = [random.randint(0, 100) for _ in range(random.randint(1,
            10))]
        mean_value = sum(num_list) / len(num_list)
        random_dict[letter] = mean_value
    return random_dict

# Clone zero-shot deepseek-r1-uml 1 nfr3
import random


def task_func(letters):
    random_dict = {}
    for letter in letters:
        num_list = [random.randint(0, 100) for _ in range(random.randint(1,
            10))]
        mean_value = sum(num_list) / len(num_list)
        random_dict[letter] = round(mean_value, 2)
    return random_dict

# Clone zero-shot deepseek-r1-ast 1 nfr4
import random


def task_func(letters):
    result = {}
    for letter in letters:
        num_elements = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(num_elements)]
        mean_value = sum(values) / len(values)
        result[letter] = round(mean_value, 2)
    return result

# Clone zero-shot llama4:latest-minimal 1 nfr0
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        numbers = [random.randint(0, 100) for _ in range(random.randint(1, 10))
            ]
        result[letter] = sum(numbers) / len(numbers)
    return result

# Clone zero-shot llama4:latest-minimal 1 nfr1
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        numbers = [random.randint(0, 100) for _ in range(random.randint(1, 10))
            ]
        result[letter] = sum(numbers) / len(numbers)
    return result

# Clone zero-shot llama4:latest-minimal 1 nfr4
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        numbers = [random.randint(0, 100) for _ in range(random.randint(1, 10))
            ]
        result[letter] = sum(numbers) / len(numbers)
    return result

# Clone zero-shot llama4:latest-minimal 1 nfr5
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        random_integers = [random.randint(0, 100) for _ in range(random.
            randint(1, 10))]
        result[letter] = sum(random_integers) / len(random_integers)
    return result

# Clone zero-shot llama4:latest-requirements 1 nfr0
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        list_size = random.randint(1, 10)
        random_list = [random.randint(0, 100) for _ in range(list_size)]
        result[letter] = sum(random_list) / len(random_list)
    return result

# Clone zero-shot llama4:latest-requirements 1 nfr1
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        list_size = random.randint(1, 10)
        random_list = [random.randint(0, 100) for _ in range(list_size)]
        result[letter] = sum(random_list) / len(random_list)
    return result

# Clone zero-shot llama4:latest-requirements 1 nfr3
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        list_size = random.randint(1, 10)
        random_list = [random.randint(0, 100) for _ in range(list_size)]
        result[letter] = sum(random_list) / len(random_list)
    return result

# Clone zero-shot llama4:latest-requirements 1 nfr4
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        list_size = random.randint(1, 10)
        random_list = [random.randint(0, 100) for _ in range(list_size)]
        result[letter] = sum(random_list) / len(random_list)
    return result


print(task_func(['a', 'b', 'c']))

# Clone zero-shot llama4:latest-requirements 1 nfr5
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        list_size = random.randint(1, 10)
        random_list = [random.randint(0, 100) for _ in range(list_size)]
        result[letter] = sum(random_list) / len(random_list)
    return result

# Clone zero-shot llama4:latest-uml 1 nfr0
import random


def task_func(LETTERS):
    random_dict = {}
    for letter in LETTERS:
        random_list = [random.randint(0, 100) for _ in range(random.randint
            (1, 10))]
        random_dict[letter] = random_list
    mean_dict = {key: (sum(value) / len(value)) for key, value in
        random_dict.items()}
    return mean_dict

# Clone zero-shot llama4:latest-uml 1 nfr1
import random


def task_func(LETTERS):
    random_dict = {}
    for letter in LETTERS:
        random_list = [random.randint(0, 100) for _ in range(random.randint
            (1, 10))]
        random_dict[letter] = random_list
    mean_dict = {key: (sum(value) / len(value)) for key, value in
        random_dict.items()}
    return mean_dict

# Clone zero-shot llama4:latest-uml 1 nfr3
import random


def task_func(LETTERS):
    random_dict = {}
    for letter in LETTERS:
        random_list = [random.randint(0, 100) for _ in range(random.randint
            (1, 10))]
        random_dict[letter] = random_list
    mean_dict = {key: (sum(value) / len(value)) for key, value in
        random_dict.items()}
    return mean_dict

# Clone zero-shot llama4:latest-uml 1 nfr4
import random


def task_func(LETTERS):
    random_dict = {}
    for letter in LETTERS:
        random_list = [random.randint(0, 100) for _ in range(random.randint
            (1, 10))]
        random_dict[letter] = random_list
    mean_dict = {key: (sum(value) / len(value)) for key, value in
        random_dict.items()}
    return mean_dict

# Clone zero-shot llama4:latest-uml 1 nfr5
import random


def task_func(LETTERS):
    random_dict = {}
    for letter in LETTERS:
        random_list = [random.randint(0, 100) for _ in range(random.randint
            (1, 10))]
        random_dict[letter] = random_list
    mean_dict = {key: (sum(value) / len(value)) for key, value in
        random_dict.items()}
    return mean_dict

# Clone few-shot llama3.1:latest-minimal 1 nfr0
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        numbers = [random.randint(0, 100) for _ in range(random.randint(1, 10))
            ]
        result[letter] = sum(numbers) / len(numbers)
    return result

# Clone few-shot llama3.1:latest-minimal 1 nfr1
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        numbers = [random.randint(0, 100) for _ in range(random.randint(1, 10))
            ]
        result[letter] = sum(numbers) / len(numbers)
    return result

# Clone few-shot llama3.1:latest-minimal 1 nfr4
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        numbers = [random.randint(0, 100) for _ in range(random.randint(1, 10))
            ]
        result[letter] = sum(numbers) / len(numbers)
    return result

# Clone few-shot llama3.1:latest-minimal 1 nfr5
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        numbers = [random.randint(0, 100) for _ in range(random.randint(1, 10))
            ]
        result[letter] = numbers
    for key, value in result.items():
        result[key] = sum(value) / len(value)
    return result

# Clone few-shot llama3.1:latest-requirements 1 nfr0
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        num_values = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(num_values)]
        result[letter] = sum(values) / num_values
    return result

# Clone few-shot llama3.1:latest-requirements 1 nfr1
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        size = random.randint(1, 10)
        numbers = [random.randint(0, 100) for _ in range(size)]
        result[letter] = sum(numbers) / size
    return result

# Clone few-shot llama3.1:latest-requirements 1 nfr3
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        num_integers = random.randint(1, 10)
        integers = [random.randint(0, 100) for _ in range(num_integers)]
        result[letter] = sum(integers) / num_integers
    return result

# Clone few-shot llama3.1:latest-requirements 1 nfr4
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        num_integers = random.randint(1, 10)
        integers = [random.randint(0, 100) for _ in range(num_integers)]
        result[letter] = sum(integers) / num_integers
    return result

# Clone few-shot llama3.1:latest-requirements 1 nfr5
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        num_integers = random.randint(1, 10)
        integers = [random.randint(0, 100) for _ in range(num_integers)]
        result[letter] = sum(integers) / num_integers
    return result

# Clone few-shot llama3.1:latest-uml 1 nfr0
import random


def task_func(LETTERS):
    random_dict = {}
    for letter in LETTERS:
        numbers = [random.randint(0, 100) for _ in range(random.randint(1, 10))
            ]
        random_dict[letter] = numbers
    mean_dict = {}
    for letter, numbers in random_dict.items():
        mean_dict[letter] = sum(numbers) / len(numbers)
    return mean_dict

# Clone cot llama3.1:latest-minimal 1 nfr0
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        numbers = [random.randint(0, 100) for _ in range(random.randint(1, 10))
            ]
        result[letter] = sum(numbers) / len(numbers)
    return result

# Clone cot llama3.1:latest-minimal 1 nfr1
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        numbers = [random.randint(0, 100) for _ in range(random.randint(1, 10))
            ]
        result[letter] = sum(numbers) / len(numbers)
    return result

# Clone cot llama3.1:latest-minimal 1 nfr3
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        numbers = [random.randint(0, 100) for _ in range(random.randint(1, 10))
            ]
        result[letter] = sum(numbers) / len(numbers)
    return result

# Clone cot llama3.1:latest-minimal 1 nfr4
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        numbers = [random.randint(0, 100) for _ in range(random.randint(1, 10))
            ]
        result[letter] = sum(numbers) / len(numbers)
    return result

# Clone cot llama3.1:latest-minimal 1 nfr5
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        numbers = [random.randint(0, 100) for _ in range(random.randint(1, 10))
            ]
        result[letter] = numbers
    return {letter: (sum(numbers) / len(numbers)) for letter, numbers in
        result.items()}

# Clone cot llama3.1:latest-requirements 1 nfr0
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        num_values = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(num_values)]
        result[letter] = sum(values) / num_values
    return result

# Clone cot llama3.1:latest-requirements 1 nfr1
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        num_values = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(num_values)]
        result[letter] = sum(values) / num_values
    return result

# Clone cot llama3.1:latest-requirements 1 nfr3
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        num_integers = random.randint(1, 10)
        integers = [random.randint(0, 100) for _ in range(num_integers)]
        result[letter] = sum(integers) / num_integers
    return result

# Clone cot llama3.1:latest-requirements 1 nfr4
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        num_integers = random.randint(1, 10)
        integers = [random.randint(0, 100) for _ in range(num_integers)]
        result[letter] = sum(integers) / num_integers
    return result

# Clone cot llama3.1:latest-requirements 1 nfr5
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        num_values = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(num_values)]
        result[letter] = sum(values) / num_values
    return result

# Clone cot llama3.1:latest-uml 1 nfr0
import random


def task_func(LETTERS):
    random_dict = {}
    for letter in LETTERS:
        numbers = [random.randint(0, 100) for _ in range(random.randint(1, 10))
            ]
        random_dict[letter] = sum(numbers) / len(numbers)
    return random_dict

# Clone cot llama3.1:latest-uml 1 nfr1
import random


def task_func(LETTERS):
    random_dict = {}
    for letter in LETTERS:
        numbers = [random.randint(0, 100) for _ in range(random.randint(1, 10))
            ]
        random_dict[letter] = sum(numbers) / len(numbers)
    return random_dict

# Clone cot llama3.1:latest-uml 1 nfr4
import random


def task_func(LETTERS):
    random_dict = {}
    for letter in LETTERS:
        numbers = [random.randint(0, 100) for _ in range(random.randint(1, 10))
            ]
        random_dict[letter] = sum(numbers) / len(numbers)
    return random_dict

# Clone cot llama3.1:latest-uml 1 nfr5
import random


def task_func(LETTERS):
    random_dict = {}
    for letter in LETTERS:
        numbers = [random.randint(0, 100) for _ in range(random.randint(1, 10))
            ]
        random_dict[letter] = sum(numbers) / len(numbers)
    return random_dict

# Clone few-shot deepseek-r1-minimal 1 nfr3
import random


def task_func(LETTERS):
    means_dict = {}
    for letter in LETTERS:
        num_list = [random.randint(0, 100) for _ in range(random.randint(1,
            10))]
        mean_val = sum(num_list) / len(num_list)
        means_dict[letter] = round(mean_val, 2)
    return means_dict

# Clone few-shot deepseek-r1-requirements 1 nfr0
import random


def task_func(LETTERS):
    result_dict = {}
    for letter in LETTERS:
        n = random.randint(1, 10)
        random_list = [random.randint(0, 100) for _ in range(n)]
        mean_value = sum(random_list) / n
        result_dict[letter] = round(mean_value, 2)
    return result_dict

# Clone few-shot deepseek-r1-requirements 1 nfr1
import random


def task_func(LETTERS):
    result_dict = {}
    for letter in LETTERS:
        n = random.randint(1, 10)
        random_list = [random.randint(0, 100) for _ in range(n)]
        mean_value = sum(random_list) / n
        result_dict[letter] = round(mean_value, 2)
    return result_dict

# Clone few-shot deepseek-r1-requirements 1 nfr3
import random


def task_func(LETTERS):
    result_dict = {}
    for letter in LETTERS:
        n = random.randint(1, 10)
        random_list = [random.randint(0, 100) for _ in range(n)]
        mean_val = sum(random_list) / n
        result_dict[letter] = round(mean_val, 2)
    return result_dict

# Clone few-shot deepseek-r1-requirements 1 nfr4
import random


def task_func(LETTERS):
    result_dict = {}
    for letter in LETTERS:
        list_size = random.randint(1, 10)
        random_list = [random.randint(0, 100) for _ in range(list_size)]
        mean_value = sum(random_list) / len(random_list)
        result_dict[letter] = round(mean_value, 2)
    return result_dict

# Clone few-shot deepseek-r1-uml 1 nfr0
import random


def task_func(LETTERS):
    mean_dict = {}
    for letter in LETTERS:
        num_elements = random.randint(1, 10)
        numbers = [random.randint(0, 100) for _ in range(num_elements)]
        total = sum(numbers)
        mean_value = total / num_elements
        mean_dict[letter] = mean_value
    return mean_dict

# Clone few-shot deepseek-r1-uml 1 nfr1
import random


def task_func(LETTERS):
    random_dict = {}
    for letter in LETTERS:
        num_list = [random.randint(0, 100) for _ in range(random.randint(1,
            10))]
        mean_value = sum(num_list) / len(num_list)
        random_dict[letter] = mean_value
    return random_dict

# Clone few-shot deepseek-r1-uml 1 nfr3
import random


def task_func(letters):
    random_dict = {}
    for letter in letters:
        num_elements = random.randint(1, 10)
        numbers = [random.randint(0, 100) for _ in range(num_elements)]
        mean_value = sum(numbers) / len(numbers)
        random_dict[letter] = round(mean_value, 2)
    return random_dict

# Clone few-shot deepseek-r1-uml 1 nfr5
import random


def task_func(letters):
    """
    Generate a dictionary with keys from the input list and values as the mean of a randomly generated list of integers.
    Each letter's value is computed by generating a list of 1 to 10 random integers between 0 and 100, then calculating the mean.
    """
    mean_dict = {}
    for letter in letters:
        num_elements = random.randint(1, 10)
        random_list = [random.randint(0, 100) for _ in range(num_elements)]
        mean_value = sum(random_list) / num_elements
        mean_dict[letter] = mean_value
    return mean_dict

# Clone few-shot deepseek-r1-ast 1 nfr3
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        num_list = [random.randint(0, 100) for _ in range(random.randint(1,
            10))]
        mean_val = sum(num_list) / len(num_list)
        result[letter] = round(mean_val, 2)
    return result

# Clone few-shot deepseek-r1-ast 1 nfr4
import random


def task_func(letters):
    result = {}
    for letter in letters:
        num_list = [random.randint(0, 100) for _ in range(random.randint(1,
            10))]
        mean_val = sum(num_list) / len(num_list)
        result[letter] = round(mean_val, 2)
    return result

# Clone cot deepseek-r1-complete 1 nfr0
import random
import numpy as np


def task_func(letters):
    result = {}
    for letter in letters:
        num_elements = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(num_elements)]
        result[letter] = np.mean(values)
    return result

# Clone cot deepseek-r1-complete 1 nfr1
import random


def task_func(letters):
    result = {}
    for letter in letters:
        num_elements = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(num_elements)]
        try:
            import numpy as np
            result[letter] = np.mean(values)
        except ImportError:
            total = sum(values)
            result[letter] = total / num_elements
    return result

# Clone cot deepseek-r1-complete 1 nfr2
import random
import numpy as np


def task_func(letters):
    result = {}
    for letter in letters:
        num_elements = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(num_elements)]
        result[letter] = np.mean(values)
    return result

# Clone cot deepseek-r1-complete 1 nfr4
import random
import numpy as np


def task_func(letters):
    result = {}
    for letter in letters:
        num_elements = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(num_elements)]
        result[letter] = np.mean(values)
    return result

# Clone cot deepseek-r1-minimal 1 nfr3
import random


def task_func(letters):
    means = {}
    for letter in letters:
        num_integers = random.randint(1, 10)
        numbers = [random.randint(0, 100) for _ in range(num_integers)]
        mean_value = sum(numbers) / len(numbers)
        means[letter] = round(mean_value, 2)
    return means

# Clone cot deepseek-r1-minimal 1 nfr4
import random


def task_func(letters):
    """
    Create a dictionary with keys from the input list and values as the mean of randomly generated lists of integers.
    Each list has between 1 to 10 integers, each ranging from 0 to 100.
    """
    result = {}
    for letter in letters:
        num_elements = random.randint(1, 10)
        random_integers = [random.randint(0, 100) for _ in range(num_elements)]
        mean_value = sum(random_integers) / len(random_integers)
        result[letter] = round(mean_value, 2)
    return result

# Clone cot deepseek-r1-requirements 1 nfr0
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        n = random.randint(1, 10)
        rand_list = [random.randint(0, 100) for _ in range(n)]
        mean_val = sum(rand_list) / len(rand_list)
        result[letter] = round(mean_val, 2)
    return result

# Clone cot deepseek-r1-requirements 1 nfr1
import random


def task_func(LETTERS):
    if not LETTERS:
        return {}
    result = {}
    for letter in LETTERS:
        n = random.randint(1, 10)
        total = 0.0
        count = 0
        while count < n:
            num = random.randint(0, 100)
            total += num
            count += 1
        mean_val = total / n
        result[letter] = round(mean_val, 2)
    return result

# Clone cot deepseek-r1-requirements 1 nfr4
import random


def task_func(LETTERS):
    result_dict = {}
    for letter in LETTERS:
        n = random.randint(1, 10)
        numbers = [random.randint(0, 100) for _ in range(n)]
        mean_value = sum(numbers) / len(numbers)
        result_dict[letter] = round(mean_value, 2)
    return result_dict

# Clone cot deepseek-r1-requirements 1 nfr5
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        n = random.randint(1, 10)
        numbers = [random.randint(0, 100) for _ in range(n)]
        mean_value = sum(numbers) / n if n > 0 else 0.0
        result[letter] = round(mean_value, 2)
    return result

# Clone cot deepseek-r1-uml 1 nfr0
def task_func(LETTERS):
    import random
    random_dict = {}
    for letter in LETTERS:
        num_list = [random.randint(0, 100) for _ in range(random.randint(1,
            10))]
        mean_value = sum(num_list) / len(num_list)
        random_dict[letter] = mean_value
    return random_dict

# Clone cot deepseek-r1-uml 1 nfr1
def task_func(LETTERS):
    import random
    random_dict = {}
    for letter in LETTERS:
        num_elements = random.randint(1, 10)
        numbers = [random.randint(0, 100) for _ in range(num_elements)]
        random_dict[letter] = numbers
    mean_dict = {}
    for letter, numbers in random_dict.items():
        if len(numbers) > 0:
            mean_value = sum(numbers) / len(numbers)
            mean_dict[letter] = mean_value
    return mean_dict

# Clone cot deepseek-r1-uml 1 nfr4
def task_func(letters):
    import random
    random_dict = {}
    for letter in letters:
        num_elements = random.randint(1, 10)
        random_list = [random.randint(0, 100) for _ in range(num_elements)]
        random_dict[letter] = random_list
    mean_dict = {}
    for letter, lst in random_dict.items():
        if len(lst) == 0:
            mean_value = 0
        else:
            mean_value = sum(lst) / len(lst)
        mean_dict[letter] = mean_value
    return mean_dict

# Clone cot deepseek-r1-ast 1 nfr0
def task_func(LETTERS):
    import random
    result = {}
    for letter in LETTERS:
        num_list = [random.randint(0, 100) for _ in range(random.randint(1,
            10))]
        mean_val = sum(num_list) / len(num_list)
        result[letter] = mean_val
    return result

# Clone cot deepseek-r1-ast 1 nfr1
def task_func(LETTERS):
    import random
    result = {}
    for letter in LETTERS:
        num_list = [random.randint(0, 100) for _ in range(random.randint(1,
            10))]
        mean_val = sum(num_list) / len(num_list)
        result[letter] = mean_val
    return result

# Clone cot deepseek-r1-ast 1 nfr3
import random


def task_func(letters):
    means = {}
    for letter in letters:
        num_list = [random.randint(0, 100) for _ in range(random.randint(1,
            10))]
        mean_val = sum(num_list) / len(num_list)
        means[letter] = round(mean_val, 2)
    return means

# Clone cot deepseek-r1-ast 1 nfr4
import random


def task_func(letters):
    result = {}
    for letter in letters:
        num_elements = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(num_elements)]
        mean_value = sum(values) / len(values)
        result[letter] = round(mean_value, 2)
    return result

# Clone few-shot llama4:latest-minimal 1 nfr0
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        random_list = [random.randint(0, 100) for _ in range(random.randint
            (1, 10))]
        result[letter] = sum(random_list) / len(random_list)
    return result

# Clone few-shot llama4:latest-minimal 1 nfr1
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        numbers = [random.randint(0, 100) for _ in range(random.randint(1, 10))
            ]
        result[letter] = sum(numbers) / len(numbers)
    return result

# Clone few-shot llama4:latest-minimal 1 nfr3
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        random_list = [random.randint(0, 100) for _ in range(random.randint
            (1, 10))]
        result[letter] = sum(random_list) / len(random_list)
    return result

# Clone few-shot llama4:latest-minimal 1 nfr4
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        random_list = [random.randint(0, 100) for _ in range(random.randint
            (1, 10))]
        result[letter] = sum(random_list) / len(random_list)
    return result

# Clone few-shot llama4:latest-minimal 1 nfr5
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        random_list = [random.randint(0, 100) for _ in range(random.randint
            (1, 10))]
        result[letter] = sum(random_list) / len(random_list)
    return result

# Clone few-shot llama4:latest-requirements 1 nfr0
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        list_size = random.randint(1, 10)
        random_list = [random.randint(0, 100) for _ in range(list_size)]
        result[letter] = sum(random_list) / len(random_list)
    return result

# Clone few-shot llama4:latest-requirements 1 nfr1
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        list_size = random.randint(1, 10)
        random_list = [random.randint(0, 100) for _ in range(list_size)]
        result[letter] = sum(random_list) / len(random_list)
    return result

# Clone few-shot llama4:latest-requirements 1 nfr3
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        list_size = random.randint(1, 10)
        random_list = [random.randint(0, 100) for _ in range(list_size)]
        result[letter] = sum(random_list) / len(random_list)
    return result

# Clone few-shot llama4:latest-requirements 1 nfr4
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        list_size = random.randint(1, 10)
        random_list = [random.randint(0, 100) for _ in range(list_size)]
        result[letter] = sum(random_list) / len(random_list)
    return result

# Clone few-shot llama4:latest-requirements 1 nfr5
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        list_size = random.randint(1, 10)
        random_list = [random.randint(0, 100) for _ in range(list_size)]
        result[letter] = sum(random_list) / len(random_list)
    return result

# Clone few-shot llama4:latest-uml 1 nfr0
import random


def task_func(LETTERS):
    random_dict = {}
    for letter in LETTERS:
        random_list = [random.randint(0, 100) for _ in range(random.randint
            (1, 10))]
        random_dict[letter] = random_list
    mean_dict = {key: (sum(value) / len(value)) for key, value in
        random_dict.items()}
    return mean_dict

# Clone few-shot llama4:latest-uml 1 nfr1
import random


def task_func(LETTERS):
    random_dict = {}
    for letter in LETTERS:
        random_list = [random.randint(0, 100) for _ in range(random.randint
            (1, 10))]
        random_dict[letter] = random_list
    mean_dict = {key: (sum(value) / len(value)) for key, value in
        random_dict.items()}
    return mean_dict

# Clone few-shot llama4:latest-uml 1 nfr3
import random


def task_func(LETTERS):
    random_dict = {}
    for letter in LETTERS:
        random_list = [random.randint(0, 100) for _ in range(random.randint
            (1, 10))]
        random_dict[letter] = random_list
    mean_dict = {key: (sum(value) / len(value)) for key, value in
        random_dict.items()}
    return mean_dict

# Clone few-shot llama4:latest-uml 1 nfr4
import random


def task_func(LETTERS):
    random_dict = {}
    for letter in LETTERS:
        random_list = [random.randint(0, 100) for _ in range(random.randint
            (1, 10))]
        random_dict[letter] = random_list
    mean_dict = {key: (sum(value) / len(value)) for key, value in
        random_dict.items()}
    return mean_dict

# Clone few-shot llama4:latest-uml 1 nfr5
import random


def task_func(LETTERS):
    random_dict = {}
    for letter in LETTERS:
        random_list = [random.randint(0, 100) for _ in range(random.randint
            (1, 10))]
        random_dict[letter] = random_list
    mean_dict = {key: (sum(value) / len(value)) for key, value in
        random_dict.items()}
    return mean_dict

# Clone cot llama4:latest-minimal 1 nfr0
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        random_list = [random.randint(0, 100) for _ in range(random.randint
            (1, 10))]
        result[letter] = sum(random_list) / len(random_list)
    return result

# Clone cot llama4:latest-minimal 1 nfr1
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        numbers = [random.randint(0, 100) for _ in range(random.randint(1, 10))
            ]
        result[letter] = sum(numbers) / len(numbers)
    return result

# Clone cot llama4:latest-minimal 1 nfr3
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        random_list = [random.randint(0, 100) for _ in range(random.randint
            (1, 10))]
        result[letter] = sum(random_list) / len(random_list)
    return result

# Clone cot llama4:latest-minimal 1 nfr4
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        random_list = [random.randint(0, 100) for _ in range(random.randint
            (1, 10))]
        result[letter] = sum(random_list) / len(random_list)
    return result

# Clone cot llama4:latest-minimal 1 nfr5
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        random_list = [random.randint(0, 100) for _ in range(random.randint
            (1, 10))]
        result[letter] = sum(random_list) / len(random_list)
    return result

# Clone cot llama4:latest-requirements 1 nfr0
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        list_size = random.randint(1, 10)
        random_list = [random.randint(0, 100) for _ in range(list_size)]
        result[letter] = sum(random_list) / len(random_list)
    return result

# Clone cot llama4:latest-requirements 1 nfr1
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        list_size = random.randint(1, 10)
        random_list = [random.randint(0, 100) for _ in range(list_size)]
        result[letter] = sum(random_list) / len(random_list)
    return result

# Clone cot llama4:latest-requirements 1 nfr3
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        list_size = random.randint(1, 10)
        random_list = [random.randint(0, 100) for _ in range(list_size)]
        result[letter] = sum(random_list) / len(random_list)
    return result

# Clone cot llama4:latest-requirements 1 nfr4
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        list_size = random.randint(1, 10)
        random_list = [random.randint(0, 100) for _ in range(list_size)]
        result[letter] = sum(random_list) / len(random_list)
    return result

# Clone cot llama4:latest-requirements 1 nfr5
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        list_size = random.randint(1, 10)
        random_list = [random.randint(0, 100) for _ in range(list_size)]
        result[letter] = sum(random_list) / len(random_list)
    return result

# Clone cot llama4:latest-uml 1 nfr1
import random


def task_func(LETTERS):
    random_dict = {}
    for letter in LETTERS:
        random_list = [random.randint(0, 100) for _ in range(random.randint
            (1, 10))]
        random_dict[letter] = random_list
    mean_dict = {key: (sum(value) / len(value)) for key, value in
        random_dict.items()}
    return mean_dict

# Clone cot llama4:latest-uml 1 nfr3
import random


def task_func(LETTERS):
    random_dict = {}
    for letter in LETTERS:
        random_list = [random.randint(0, 100) for _ in range(random.randint
            (1, 10))]
        random_dict[letter] = random_list
    mean_dict = {key: (sum(value) / len(value)) for key, value in
        random_dict.items()}
    return mean_dict

# Clone cot llama4:latest-uml 1 nfr4
import random


def task_func(LETTERS):
    random_dict = {}
    for letter in LETTERS:
        random_list = [random.randint(0, 100) for _ in range(random.randint
            (1, 10))]
        random_dict[letter] = random_list
    mean_dict = {key: (sum(value) / len(value)) for key, value in
        random_dict.items()}
    return mean_dict

# Clone cot llama4:latest-uml 1 nfr5
import random


def task_func(LETTERS):
    random_dict = {}
    for letter in LETTERS:
        random_list = [random.randint(0, 100) for _ in range(random.randint
            (1, 10))]
        random_dict[letter] = random_list
    mean_dict = {key: (sum(value) / len(value)) for key, value in
        random_dict.items()}
    return mean_dict

# Clone few-shot gemma3:latest-requirements 1 nfr1
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        nums = [random.randint(0, 100) for _ in range(random.randint(1, 10))]
        result[letter] = sum(nums) / len(nums)
    return result

# Clone zero-shot gpt-oss:latest-minimal 1 nfr1
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        count = random.randint(1, 10)
        numbers = [random.randint(0, 100) for _ in range(count)]
        mean_value = sum(numbers) / count
        result[letter] = mean_value
    return result


print(task_func(['a', 'b', 'c']))

# Clone zero-shot gpt-oss:latest-minimal 1 nfr5
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        count = random.randint(1, 10)
        numbers = [random.randint(0, 100) for _ in range(count)]
        mean_value = sum(numbers) / count
        result[letter] = mean_value
    return result


print(task_func(['a', 'b', 'c']))

# Clone zero-shot gpt-oss:latest-requirements 1 nfr0
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        length = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(length)]
        result[letter] = sum(values) / length
    return result


print(task_func(['A', 'B', 'C']))

# Clone zero-shot gpt-oss:latest-requirements 1 nfr1
import random


def task_func(LETTERS):
    result = {}
    for key in LETTERS:
        length = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(length)]
        mean = sum(values) / length if length else 0.0
        result[key] = mean
    return result


print(task_func(['A', 'B', 'C']))

# Clone zero-shot gpt-oss:latest-requirements 1 nfr3
import random


def task_func(LETTERS):
    result = {}
    for key in LETTERS:
        length = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(length)]
        result[key] = sum(values) / length
    return result


print(task_func(['A', 'B', 'C']))

# Clone zero-shot gpt-oss:latest-requirements 1 nfr5
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        size = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(size)]
        mean = sum(values) / size
        result[letter] = float(mean)
    return result


print(task_func(['A', 'B', 'C']))

# Clone zero-shot gpt-oss:latest-uml 1 nfr0
import random


def task_func(LETTERS: list[str]) ->dict:
    result = {}
    for letter in LETTERS:
        nums = [random.randint(0, 100) for _ in range(random.randint(1, 10))]
        result[letter] = sum(nums) / len(nums)
    return result


print(task_func(['a', 'b', 'c']))

# Clone zero-shot gpt-oss:latest-uml 1 nfr1
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        length = random.randint(1, 10)
        numbers = [random.randint(0, 100) for _ in range(length)]
        mean_val = sum(numbers) / length
        result[letter] = mean_val
    return result


print(task_func(['A', 'B', 'C']))

# Clone zero-shot gpt-oss:latest-uml 1 nfr3
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        length = random.randint(1, 10)
        numbers = [random.randint(0, 100) for _ in range(length)]
        mean = sum(numbers) / length
        result[letter] = mean
    return result


print(task_func(['A', 'B', 'C']))

# Clone zero-shot gpt-oss:latest-ast 1 nfr1
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        length = random.randint(1, 10)
        numbers = [random.randint(0, 100) for _ in range(length)]
        mean_val = sum(numbers) / len(numbers)
        result[letter] = mean_val
    return result


print(task_func(['a', 'b', 'c']))

# Clone zero-shot gpt-oss:latest-ast 1 nfr3
import random


def task_func(LETTERS):
    means = {}
    for letter in LETTERS:
        n = random.randint(1, 10)
        nums = [random.randint(0, 100) for _ in range(n)]
        means[letter] = sum(nums) / n
    return means


print(task_func(['A', 'B', 'C']))

# Clone zero-shot gpt-oss:latest-ast 1 nfr5
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        length = random.randint(1, 10)
        numbers = [random.randint(0, 100) for _ in range(length)]
        result[letter] = sum(numbers) / len(numbers)
    return result


print(task_func(['A', 'B', 'C']))

# Clone zero-shot gpt-oss:latest-translation 1 nfr0
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        size = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(size)]
        mean_val = sum(values) / len(values) if values else 0.0
        result[letter] = mean_val
    return result


print(task_func([]))

# Clone zero-shot gpt-oss:latest-translation 1 nfr1
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        size = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(size)]
        result[letter] = sum(values) / size
    return result


print(task_func(['a', 'b', 'c']))

# Clone zero-shot gpt-oss:latest-translation 1 nfr3
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        size = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(size)]
        mean_val = sum(values) / size if size else 0.0
        result[letter] = mean_val
    return result


print(task_func([]))

# Clone zero-shot gpt-oss:latest-translation 1 nfr4
import random


def task_func(LETTERS):
    """
    Generate a dictionary where each key is a letter from LETTERS and the value is the mean
    of a randomly generated list of integers (1 to 10 integers, each between 0 and 100 inclusive).
    """
    result = {}
    for letter in LETTERS:
        size = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(size)]
        mean_value = sum(values) / size if values else 0.0
        result[letter] = mean_value
    return result


print(task_func(['A', 'B', 'C']))

# Clone few-shot gpt-oss:latest-minimal 1 nfr0
import random


def task_func(LETTERS):
    means = {}
    for letter in LETTERS:
        count = random.randint(1, 10)
        numbers = [random.randint(0, 100) for _ in range(count)]
        means[letter] = sum(numbers) / count
    return means


print(task_func(['a', 'b', 'c']))

# Clone few-shot gpt-oss:latest-minimal 1 nfr1
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        count = random.randint(1, 10)
        numbers = [random.randint(0, 100) for _ in range(count)]
        mean_val = sum(numbers) / count
        result[letter] = mean_val
    return result


print(task_func(['a', 'b', 'c']))

# Clone few-shot gpt-oss:latest-minimal 1 nfr3
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        length = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(length)]
        mean_val = sum(values) / length
        result[letter] = mean_val
    return result


print(task_func(['a', 'b', 'c']))

# Clone few-shot gpt-oss:latest-minimal 1 nfr4
import secrets


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        length = secrets.randbelow(10) + 1
        numbers = [secrets.randbelow(101) for _ in range(length)]
        mean_val = sum(numbers) / length
        result[letter] = mean_val
    return result


print(task_func(['a', 'b', 'c']))

# Clone few-shot gpt-oss:latest-requirements 1 nfr0
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        size = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(size)]
        result[letter] = sum(values) / size
    return result


print(task_func(['A', 'B', 'C']))

# Clone few-shot gpt-oss:latest-requirements 1 nfr1
import random


def task_func(LETTERS):
    result = {}
    for key in LETTERS:
        length = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(length)]
        result[key] = sum(values) / length
    return result


print(task_func(['A', 'B', 'C']))

# Clone few-shot gpt-oss:latest-requirements 1 nfr3
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        length = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(length)]
        result[letter] = sum(values) / length
    return result


print(task_func(['A', 'B', 'C']))

# Clone few-shot gpt-oss:latest-requirements 1 nfr4
import random


def task_func(LETTERS):
    result = {}
    rng = random.SystemRandom()
    for key in LETTERS:
        length = rng.randint(1, 10)
        values = [rng.randint(0, 100) for _ in range(length)]
        result[key] = sum(values) / length
    return result


print(task_func(['A', 'B', 'C']))

# Clone few-shot gpt-oss:latest-requirements 1 nfr5
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        length = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(length)]
        result[letter] = sum(values) / length
    return result


print(task_func([]))

# Clone few-shot gpt-oss:latest-uml 1 nfr0
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        count = random.randint(1, 10)
        numbers = [random.randint(0, 100) for _ in range(count)]
        mean_value = sum(numbers) / count
        result[letter] = mean_value
    return result


print(task_func(['a', 'b', 'c']))

# Clone few-shot gpt-oss:latest-uml 1 nfr1
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        length = random.randint(1, 10)
        numbers = [random.randint(0, 100) for _ in range(length)]
        mean = sum(numbers) / length
        result[letter] = mean
    return result

# Clone few-shot gpt-oss:latest-uml 1 nfr3
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        count = random.randint(1, 10)
        numbers = [random.randint(0, 100) for _ in range(count)]
        mean = sum(numbers) / count if count else 0
        result[letter] = mean
    return result


print(task_func(['a', 'b', 'c']))

# Clone few-shot gpt-oss:latest-translation 1 nfr0
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        size = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(size)]
        mean_value = sum(values) / size if values else 0.0
        result[letter] = mean_value
    return result


if __name__ == '__main__':
    print(task_func(['a', 'b', 'c']))

# Clone few-shot gpt-oss:latest-translation 1 nfr1
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        size = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(size)]
        result[letter] = sum(values) / size
    return result

# Clone few-shot gpt-oss:latest-translation 1 nfr3
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        size = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(size)]
        result[letter] = sum(values) / size if values else 0.0
    return result


print(task_func(['a', 'b', 'c']))

# Clone few-shot gpt-oss:latest-translation 1 nfr5
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        size = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(size)]
        mean_val = sum(values) / size if size else 0.0
        result[letter] = mean_val
    return result


print(task_func(['a', 'b', 'c']))

# Clone cot gpt-oss:latest-minimal 1 nfr0
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        length = random.randint(1, 10)
        numbers = [random.randint(0, 100) for _ in range(length)]
        mean_value = sum(numbers) / length
        result[letter] = mean_value
    return result


print(task_func(['a', 'b', 'c']))

# Clone cot gpt-oss:latest-minimal 1 nfr1
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        length = random.randint(1, 10)
        nums = [random.randint(0, 100) for _ in range(length)]
        mean = sum(nums) / length
        result[letter] = mean
    return result


print(task_func(['a', 'b', 'c']))

# Clone cot gpt-oss:latest-minimal 1 nfr3
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        count = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(count)]
        mean_val = sum(values) / len(values)
        result[letter] = mean_val
    return result


print(task_func(['a', 'b', 'c']))

# Clone cot gpt-oss:latest-requirements 1 nfr0
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        size = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(size)]
        result[letter] = sum(values) / size
    return result


print(task_func(['A', 'B', 'C']))

# Clone cot gpt-oss:latest-requirements 1 nfr1
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        length = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(length)]
        result[letter] = sum(values) / length
    return result


print(task_func([]))

# Clone cot gpt-oss:latest-requirements 1 nfr3
import random


def task_func(LETTERS):
    if not LETTERS:
        return {}
    result = {}
    for key in LETTERS:
        length = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(length)]
        result[key] = sum(values) / length
    return result


print(task_func(['A', 'B', 'C']))

# Clone cot gpt-oss:latest-requirements 1 nfr4
import random


def task_func(LETTERS):
    result = {}
    for key in LETTERS:
        size = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(size)]
        mean_val = sum(values) / size
        result[key] = mean_val
    return result


print(task_func([]))

# Clone cot gpt-oss:latest-requirements 1 nfr5
import random


def task_func(LETTERS):
    if not LETTERS:
        return {}
    result = {}
    for letter in LETTERS:
        size = random.randint(1, 10)
        numbers = [random.randint(0, 100) for _ in range(size)]
        result[letter] = sum(numbers) / size
    return result


print(task_func(['A', 'B', 'C']))

# Clone cot gpt-oss:latest-uml 1 nfr0
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        length = random.randint(1, 10)
        numbers = [random.randint(0, 100) for _ in range(length)]
        mean_value = sum(numbers) / length
        result[letter] = mean_value
    return result


print(task_func(['a', 'b', 'c']))

# Clone cot gpt-oss:latest-uml 1 nfr1
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        length = random.randint(1, 10)
        numbers = [random.randint(0, 100) for _ in range(length)]
        mean_value = sum(numbers) / length
        result[letter] = mean_value
    return result


print(task_func(['a', 'b', 'c']))

# Clone cot gpt-oss:latest-uml 1 nfr3
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        count = random.randint(1, 10)
        numbers = [random.randint(0, 100) for _ in range(count)]
        result[letter] = sum(numbers) / count
    return result


print(task_func(['A', 'B', 'C']))

# Clone cot gpt-oss:latest-uml 1 nfr4
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        count = random.randint(1, 10)
        numbers = [random.randint(0, 100) for _ in range(count)]
        mean_val = sum(numbers) / count
        result[letter] = mean_val
    return result


print(task_func(['A', 'B', 'C']))

# Clone cot gpt-oss:latest-uml 1 nfr5
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        count = random.randint(1, 10)
        numbers = [random.randint(0, 100) for _ in range(count)]
        mean = sum(numbers) / len(numbers)
        result[letter] = mean
    return result


print(task_func(['A', 'B', 'C']))

# Clone cot gpt-oss:latest-ast 1 nfr1
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        length = random.randint(1, 10)
        nums = [random.randint(0, 100) for _ in range(length)]
        mean_val = sum(nums) / length
        result[letter] = mean_val
    return result


print(task_func(['a', 'b', 'c']))

# Clone cot gpt-oss:latest-translation 1 nfr1
import random


def task_func(letters):
    result = {}
    for letter in letters:
        size = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(size)]
        mean = sum(values) / len(values) if values else 0.0
        result[letter] = mean
    return result


print(task_func([]))

# Clone cot gpt-oss:latest-translation 1 nfr3
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        size = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(size)]
        mean = sum(values) / size if values else 0.0
        result[letter] = mean
    return result


print(task_func(['a', 'b', 'c']))

# Clone cot gpt-oss:latest-translation 1 nfr5
import random


def task_func(letters):
    result = {}
    for letter in letters:
        size = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(size)]
        mean = sum(values) / len(values) if values else 0.0
        result[letter] = mean
    return result


if __name__ == '__main__':
    print(task_func([]))

# Clone zero-shot gpt-oss:20b-minimal 1 nfr1
def task_func(LETTERS):
    import random
    result = {}
    for letter in LETTERS:
        n = random.randint(1, 10)
        nums = [random.randint(0, 100) for _ in range(n)]
        mean = sum(nums) / len(nums)
        result[letter] = mean
    return result

# Clone zero-shot gpt-oss:20b-requirements 1 nfr0
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        length = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(length)]
        result[letter] = sum(values) / length
    return result

# Clone zero-shot gpt-oss:20b-requirements 1 nfr1
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        length = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(length)]
        result[letter] = sum(values) / length
    return result

# Clone zero-shot gpt-oss:20b-requirements 1 nfr3
import random


def task_func(LETTERS):
    if not LETTERS:
        return {}
    rng = random.SystemRandom()
    result = {}
    for key in LETTERS:
        length = rng.randint(1, 10)
        values = [rng.randint(0, 100) for _ in range(length)]
        mean_val = sum(values) / length
        result[key] = mean_val
    return result

# Clone zero-shot gpt-oss:20b-requirements 1 nfr4
import random


def task_func(LETTERS):
    result = {}
    for key in LETTERS:
        size = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(size)]
        mean = sum(values) / size
        result[key] = mean
    return result

# Clone zero-shot gpt-oss:20b-requirements 1 nfr5
import random


def task_func(LETTERS):
    if not LETTERS:
        return {}
    result = {}
    for key in LETTERS:
        n = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(n)]
        result[key] = sum(values) / n
    return result

# Clone zero-shot gpt-oss:20b-uml 1 nfr0
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        length = random.randint(1, 10)
        numbers = [random.randint(0, 100) for _ in range(length)]
        mean_value = sum(numbers) / length
        result[letter] = mean_value
    return result

# Clone zero-shot gpt-oss:20b-uml 1 nfr1
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        length = random.randint(1, 10)
        numbers = [random.randint(0, 100) for _ in range(length)]
        mean_val = sum(numbers) / length
        result[letter] = mean_val
    return result

# Clone zero-shot gpt-oss:20b-ast 1 nfr0
import random


def task_func(LETTERS):
    means = {}
    for letter in LETTERS:
        count = random.randint(1, 10)
        numbers = [random.randint(0, 100) for _ in range(count)]
        means[letter] = sum(numbers) / count
    return means

# Clone zero-shot gpt-oss:20b-ast 1 nfr3
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        size = random.randint(1, 10)
        total = 0
        for _ in range(size):
            total += random.randint(0, 100)
        result[letter] = total / size
    return result

# Clone zero-shot gpt-oss:20b-translation 1 nfr0
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        size = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(size)]
        mean_val = sum(values) / size
        result[letter] = mean_val
    return result

# Clone zero-shot gpt-oss:20b-translation 1 nfr1
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        size = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(size)]
        mean = sum(values) / size if size else 0.0
        result[letter] = mean
    return result

# Clone zero-shot gpt-oss:20b-translation 1 nfr3
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        size = random.randint(1, 10)
        values = [(random.random() * 100) for _ in range(size)]
        result[letter] = sum(values) / size
    return result

# Clone few-shot gpt-oss:20b-complete 1 nfr5
import random
import numpy as np


def task_func(LETTERS):
    """
    Generate a dictionary mapping each letter in LETTERS to the mean of a
    randomly generated list of integers. Each list contains between 1 and 10
    integers in the inclusive range [0, 100]. The returned means are Python
    floats.
    """
    result = {}
    for letter in LETTERS:
        list_len = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(list_len)]
        result[letter] = float(np.mean(values))
    return result

# Clone few-shot gpt-oss:20b-minimal 1 nfr0
import random


def task_func(LETTERS):
    means = {}
    for letter in LETTERS:
        count = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(count)]
        means[letter] = sum(values) / count
    return means

# Clone few-shot gpt-oss:20b-minimal 1 nfr1
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        length = random.randint(1, 10)
        numbers = [random.randint(0, 100) for _ in range(length)]
        mean_value = sum(numbers) / length
        result[letter] = mean_value
    return result

# Clone few-shot gpt-oss:20b-requirements 1 nfr0
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        size = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(size)]
        result[letter] = sum(values) / size
    return result

# Clone few-shot gpt-oss:20b-requirements 1 nfr1
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        size = random.randint(1, 10)
        total = 0
        for _ in range(size):
            total += random.randint(0, 100)
        result[letter] = total / size
    return result

# Clone few-shot gpt-oss:20b-requirements 1 nfr3
import random


def task_func(LETTERS):
    result = {}
    for key in LETTERS:
        length = random.randint(1, 10)
        numbers = [random.randint(0, 100) for _ in range(length)]
        result[key] = sum(numbers) / length
    return result

# Clone few-shot gpt-oss:20b-requirements 1 nfr4
import random


def task_func(LETTERS):
    """Return a dictionary mapping each letter to the mean of a random integer list."""
    if not LETTERS:
        return {}
    result = {}
    for key in LETTERS:
        count = random.randint(1, 10)
        numbers = [random.randint(0, 100) for _ in range(count)]
        result[key] = sum(numbers) / count
    return result

# Clone few-shot gpt-oss:20b-uml 1 nfr0
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        count = random.randint(1, 10)
        numbers = [random.randint(0, 100) for _ in range(count)]
        mean_value = sum(numbers) / count
        result[letter] = mean_value
    return result

# Clone few-shot gpt-oss:20b-uml 1 nfr1
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        size = random.randint(1, 10)
        nums = [random.randint(0, 100) for _ in range(size)]
        mean = sum(nums) / len(nums)
        result[letter] = mean
    return result

# Clone few-shot gpt-oss:20b-ast 1 nfr1
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        count = random.randint(1, 10)
        numbers = [random.randint(0, 100) for _ in range(count)]
        result[letter] = sum(numbers) / count
    return result

# Clone few-shot gpt-oss:20b-ast 1 nfr3
import random


def task_func(LETTERS):
    means = {}
    for letter in LETTERS:
        if not isinstance(letter, str) or len(letter) != 1:
            continue
        count = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(count)]
        means[letter] = sum(values) / count
    return means

# Clone few-shot gpt-oss:20b-translation 1 nfr0
import random


def task_func(LETTERS):
    mean_dict = {}
    for letter in LETTERS:
        size = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(size)]
        mean_dict[letter] = sum(values) / size
    return mean_dict

# Clone few-shot gpt-oss:20b-translation 1 nfr1
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        size = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(size)]
        result[letter] = sum(values) / size if values else 0.0
    return result

# Clone cot gpt-oss:20b-complete 1 nfr1
import random


def task_func(LETTERS):
    mean_dict = {}
    for key in LETTERS:
        length = random.randint(1, 10)
        numbers = [random.randint(0, 100) for _ in range(length)]
        mean_dict[key] = sum(numbers) / length
    return mean_dict

# Clone cot gpt-oss:20b-complete 1 nfr3
import random


def task_func(LETTERS):
    result = {}
    for k in LETTERS:
        length = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(length)]
        result[k] = sum(values) / length
    return result

# Clone cot gpt-oss:20b-minimal 1 nfr0
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        count = random.randint(1, 10)
        nums = [random.randint(0, 100) for _ in range(count)]
        result[letter] = sum(nums) / count
    return result

# Clone cot gpt-oss:20b-minimal 1 nfr1
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        length = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(length)]
        mean = sum(values) / len(values) if values else 0
        result[letter] = mean
    return result

# Clone cot gpt-oss:20b-minimal 1 nfr4
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        count = random.randint(1, 10)
        numbers = [random.randint(0, 100) for _ in range(count)]
        mean_value = sum(numbers) / count
        result[letter] = mean_value
    return result

# Clone cot gpt-oss:20b-requirements 1 nfr0
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        size = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(size)]
        mean_val = sum(values) / size
        result[letter] = mean_val
    return result

# Clone cot gpt-oss:20b-requirements 1 nfr3
import random


def task_func(LETTERS):
    if not LETTERS:
        return {}
    result = {}
    for key in LETTERS:
        size = random.randint(1, 10)
        numbers = [random.randint(0, 100) for _ in range(size)]
        result[key] = sum(numbers) / size
    return result

# Clone cot gpt-oss:20b-requirements 1 nfr5
import random


def task_func(LETTERS):
    if not LETTERS:
        return {}
    result = {}
    for letter in LETTERS:
        length = random.randint(1, 10)
        numbers = [random.randint(0, 100) for _ in range(length)]
        mean_value = sum(numbers) / length
        result[letter] = mean_value
    return result

# Clone cot gpt-oss:20b-uml 1 nfr0
import random


def task_func(LETTERS):
    random_dict = {}
    for letter in LETTERS:
        length = random.randint(1, 10)
        random_dict[letter] = [random.randint(0, 100) for _ in range(length)]
    mean_dict = {letter: (sum(nums) / len(nums)) for letter, nums in
        random_dict.items()}
    return mean_dict

# Clone cot gpt-oss:20b-uml 1 nfr1
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        count = random.randint(1, 10)
        numbers = [random.randint(0, 100) for _ in range(count)]
        mean_val = sum(numbers) / count
        result[letter] = mean_val
    return result

# Clone cot gpt-oss:20b-uml 1 nfr2
import random
import statistics
import numpy as np
import pandas as pd
import itertools
import functools


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        count = random.randint(1, 10)
        numbers = [random.randint(0, 100) for _ in range(count)]
        mean_val = pd.Series(numbers).mean()
        result[letter] = float(mean_val)
    return result

# Clone cot gpt-oss:20b-uml 1 nfr3
import random


def task_func(LETTERS):
    rng = random.SystemRandom()
    result = {}
    for letter in LETTERS:
        length = rng.randint(1, 10)
        numbers = [rng.randint(0, 100) for _ in range(length)]
        mean_value = sum(numbers) / length
        result[letter] = mean_value
    return result

# Clone cot gpt-oss:20b-ast 1 nfr1
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        length = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(length)]
        mean_val = sum(values) / length
        result[letter] = mean_val
    return result

# Clone cot gpt-oss:20b-ast 1 nfr3
import random


def task_func(LETTERS):
    means = {}
    for letter in LETTERS:
        num_values = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(num_values)]
        means[letter] = sum(values) / num_values
    return means

# Clone cot gpt-oss:20b-ast 1 nfr4
import random


def task_func(LETTERS):
    means = {}
    for letter in LETTERS:
        count = random.randint(1, 10)
        numbers = [random.randint(0, 100) for _ in range(count)]
        means[letter] = sum(numbers) / len(numbers)
    return means

# Clone cot gpt-oss:20b-translation 1 nfr0
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        size = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(size)]
        mean = sum(values) / len(values)
        result[letter] = mean
    return result

# Clone cot gpt-oss:20b-translation 1 nfr1
import random


def task_func(LETTERS):
    result = {}
    for letter in LETTERS:
        size = random.randint(1, 10)
        values = [random.randint(0, 100) for _ in range(size)]
        mean = sum(values) / size
        result[letter] = mean
    return result

