# Clone zero-shot deepseek-r1-ast 1 nfr0
def task_func(d):
    count_dict = {}
    for num_list in d.values():
        for num in num_list:
            count_dict[num] = count_dict.get(num, 0) + 1
    return count_dict

# Clone zero-shot deepseek-r1-ast 1 nfr1
def task_func(d):
    count_dict = {}
    for num_list in d.values():
        for num in num_list:
            count_dict[num] = count_dict.get(num, 0) + 1
    return count_dict

# Clone zero-shot deepseek-r1-translation 1 nfr0
def task_func(d):
    count_dict = {}
    for sublist in d.values():
        for num in sublist:
            count_dict[num] = count_dict.get(num, 0) + 1
    return {int(key): int(value) for key, value in count_dict.items()}

# Clone zero-shot deepseek-r1-translation 1 nfr1
def task_func(d):
    count_dict = {}
    for sublist in d.values():
        for num in sublist:
            count_dict[num] = count_dict.get(num, 0) + 1
    return {int(key): value for key, value in count_dict.items()}

# Clone zero-shot deepseek-r1-translation 1 nfr3
def task_func(d: dict) ->dict:
    count_dict = {}
    for sublist in d.values():
        for num in sublist:
            count_dict[num] = count_dict.get(num, 0) + 1
    return count_dict

# Clone zero-shot llama4:latest-translation 1 nfr0
def task_func(d):
    count_dict = {}
    for lst in d.values():
        for elem in lst:
            count_dict[elem] = count_dict.get(elem, 0) + 1
    return count_dict

# Clone zero-shot llama4:latest-translation 1 nfr1
def task_func(d):
    count_dict = {}
    for lst in d.values():
        for num in lst:
            count_dict[num] = count_dict.get(num, 0) + 1
    return count_dict

# Clone few-shot deepseek-r1-ast 1 nfr0
def task_func(d):
    count_dict = {}
    for num_list in d.values():
        for num in num_list:
            count_dict[num] = count_dict.get(num, 0) + 1
    return count_dict

# Clone few-shot deepseek-r1-ast 1 nfr1
def task_func(d):
    count_dict = {}
    for num_list in d.values():
        for num in num_list:
            count_dict[num] = count_dict.get(num, 0) + 1
    return count_dict

# Clone few-shot deepseek-r1-ast 1 nfr3
def task_func(d):
    count_dict = {}
    for num_list in d.values():
        for num in num_list:
            count_dict[num] = count_dict.get(num, 0) + 1
    return count_dict

# Clone few-shot deepseek-r1-ast 1 nfr4
def task_func(d):
    count_dict = {}
    for numbers in d.values():
        for num in numbers:
            count_dict[num] = count_dict.get(num, 0) + 1
    return count_dict

# Clone few-shot deepseek-r1-translation 1 nfr0
def task_func(d: dict) ->dict:
    count_dict = {}
    for sublist in d.values():
        for num in sublist:
            count_dict[num] = count_dict.get(num, 0) + 1
    return {k: v for k, v in count_dict.items()}

# Clone few-shot deepseek-r1-translation 1 nfr1
def task_func(d: dict) ->dict:
    count_dict = {}
    for sublist in d.values():
        for num in sublist:
            count_dict[num] = count_dict.get(num, 0) + 1
    return {k: v for k, v in count_dict.items()}

# Clone few-shot deepseek-r1-translation 1 nfr3
def task_func(d: dict) ->dict:
    count_dict = {}
    for sublist in d.values():
        for num in sublist:
            count_dict[num] = count_dict.get(num, 0) + 1
    return {k: v for k, v in count_dict.items()}

# Clone few-shot deepseek-r1-translation 1 nfr4
def task_func(d: dict) ->dict:
    count_dict = {}
    for sublist in d.values():
        for num in sublist:
            count_dict[num] = count_dict.get(num, 0) + 1
    return {k: v for k, v in count_dict.items()}

# Clone cot deepseek-r1-minimal 1 nfr0
def task_func(d):
    count_dict = {}
    for sublist in d.values():
        for num in sublist:
            count_dict[num] = count_dict.get(num, 0) + 1
    return count_dict

# Clone cot deepseek-r1-minimal 1 nfr4
def task_func(d):
    count_dict = {}
    for numbers in d.values():
        for num in numbers:
            count_dict[num] = count_dict.get(num, 0) + 1
    return count_dict

# Clone cot deepseek-r1-ast 1 nfr0
def task_func(d):
    count_dict = {}
    for num_list in d.values():
        for num in num_list:
            count_dict[num] = count_dict.get(num, 0) + 1
    return count_dict

# Clone cot deepseek-r1-ast 1 nfr1
def task_func(d):
    count_dict = {}
    for num_list in d.values():
        for num in num_list:
            count_dict[num] = count_dict.get(num, 0) + 1
    return count_dict

# Clone cot deepseek-r1-ast 1 nfr3
def task_func(d):
    count_dict = {}
    for num_list in d.values():
        for num in num_list:
            count_dict[num] = count_dict.get(num, 0) + 1
    return count_dict

# Clone cot deepseek-r1-ast 1 nfr4
def task_func(d):
    count_dict = {}
    for numbers in d.values():
        for num in numbers:
            count_dict[num] = count_dict.get(num, 0) + 1
    return count_dict

# Clone cot deepseek-r1-ast 1 nfr5
def task_func(d):
    count_dict = {}
    for numbers in d.values():
        for num in numbers:
            count_dict[num] = count_dict.get(num, 0) + 1
    return count_dict

# Clone cot deepseek-r1-translation 1 nfr0
def task_func(d):
    count_dict = {}
    for key in d:
        for num in d[key]:
            count_dict[num] = count_dict.get(num, 0) + 1
    return count_dict

# Clone cot deepseek-r1-translation 1 nfr1
def task_func(d):
    count_dict = {}
    for sublist in d.values():
        for num in sublist:
            count_dict[num] = count_dict.get(num, 0) + 1
    return {k: v for k, v in count_dict.items()}

# Clone cot deepseek-r1-translation 1 nfr3
def task_func(d):
    count_dict = {}
    for sublist in d.values():
        for num in sublist:
            count_dict[num] = count_dict.get(num, 0) + 1
    return {int(k): v for k, v in count_dict.items()}

# Clone cot deepseek-r1-translation 1 nfr4
def task_func(d):
    count_dict = {}
    for sublist in d.values():
        for num in sublist:
            count_dict[num] = count_dict.get(num, 0) + 1
    return {k: v for k, v in count_dict.items()}

# Clone few-shot llama4:latest-requirements 1 nfr3
def task_func(d):
    result = {}
    for value in d.values():
        for item in value:
            result[item] = result.get(item, 0) + 1
    return result

# Clone few-shot llama4:latest-requirements 1 nfr5
def task_func(d):
    result = {}
    for value in d.values():
        for item in value:
            result[item] = result.get(item, 0) + 1
    return result

# Clone few-shot llama4:latest-translation 1 nfr0
def task_func(d):
    count_dict = {}
    for lst in d.values():
        for item in lst:
            count_dict[item] = count_dict.get(item, 0) + 1
    return count_dict

# Clone few-shot llama4:latest-translation 1 nfr1
def task_func(d):
    count_dict = {}
    for lst in d.values():
        for item in lst:
            count_dict[item] = count_dict.get(item, 0) + 1
    return count_dict

# Clone cot llama4:latest-requirements 1 nfr0
def task_func(d):
    result = {}
    for v in d.values():
        for i in v:
            result[i] = result.get(i, 0) + 1
    return result

# Clone cot llama4:latest-requirements 1 nfr1
def task_func(d):
    result = {}
    for v in d.values():
        for i in v:
            result[i] = result.get(i, 0) + 1
    return result

# Clone cot llama4:latest-requirements 1 nfr3
def task_func(d):
    result = {}
    for v in d.values():
        for i in v:
            result[i] = result.get(i, 0) + 1
    return result

# Clone cot llama4:latest-requirements 1 nfr5
def task_func(d):
    result = {}
    for v in d.values():
        for i in v:
            result[i] = result.get(i, 0) + 1
    return result

# Clone cot llama4:latest-translation 1 nfr1
def task_func(d):
    count_dict = {}
    for value in d.values():
        for item in value:
            count_dict[item] = count_dict.get(item, 0) + 1
    return count_dict

# Clone zero-shot gpt-oss:latest-minimal 1 nfr0
def task_func(d):
    counts = {}
    for lst in d.values():
        for num in lst:
            counts[num] = counts.get(num, 0) + 1
    return counts

# Clone zero-shot gpt-oss:latest-minimal 1 nfr1
def task_func(d):
    counts = {}
    for lst in d.values():
        for num in lst:
            counts[num] = counts.get(num, 0) + 1
    return counts


sample = {'a': [1, 2, 3], 'b': [2, 3, 4], 'c': [1, 4, 4]}
print(task_func(sample))

# Clone zero-shot gpt-oss:latest-minimal 1 nfr3
def task_func(d):
    counts = {}
    for lst in d.values():
        for num in lst:
            counts[num] = counts.get(num, 0) + 1
    return counts


print(task_func({}))

# Clone zero-shot gpt-oss:latest-minimal 1 nfr5
def task_func(d: dict) ->dict:
    counts = {}
    for lst in d.values():
        for num in lst:
            counts[num] = counts.get(num, 0) + 1
    return counts


print(task_func({'a': [1, 2, 3], 'b': [2, 3, 4]}))

# Clone zero-shot gpt-oss:latest-requirements 1 nfr0
def task_func(d):
    result = {}
    for values in d.values():
        for item in values:
            result[item] = result.get(item, 0) + 1
    return result


print(task_func({}))

# Clone zero-shot gpt-oss:latest-requirements 1 nfr1
def task_func(d):
    result = {}
    for values in d.values():
        for item in values:
            result[item] = result.get(item, 0) + 1
    return result


print(task_func({'a': [1, 2, 3], 'b': [2, 3, 4]}))

# Clone zero-shot gpt-oss:latest-requirements 1 nfr3
def task_func(d):
    result = {}
    for iterable in d.values():
        for item in iterable:
            result[item] = result.get(item, 0) + 1
    return result


print(task_func({}))

# Clone zero-shot gpt-oss:latest-requirements 1 nfr4
def task_func(d):
    result = {}
    for iterable in d.values():
        for item in iterable:
            result[item] = result.get(item, 0) + 1
    return result


print(task_func({'a': [1, 2, 3], 'b': [2, 3, 4]}))

# Clone zero-shot gpt-oss:latest-requirements 1 nfr5
def task_func(d):
    result = {}
    for values in d.values():
        for item in values:
            result[item] = result.get(item, 0) + 1
    return result


print(task_func({}))

# Clone zero-shot gpt-oss:latest-ast 1 nfr0
def task_func(d):
    result = {}
    for lst in d.values():
        for num in lst:
            result[num] = result.get(num, 0) + 1
    return result


print(task_func({'a': [1, 2, 3], 'b': [2, 3, 4]}))

# Clone zero-shot gpt-oss:latest-ast 1 nfr1
def task_func(d):
    counts = {}
    for lst in d.values():
        for num in lst:
            counts[num] = counts.get(num, 0) + 1
    return counts


print(task_func({'a': [1, 2, 3], 'b': [2, 3, 4]}))

# Clone zero-shot gpt-oss:latest-ast 1 nfr3
def task_func(d):
    counts = {}
    for lst in d.values():
        for num in lst:
            counts[num] = counts.get(num, 0) + 1
    return counts


print(task_func({'a': [1, 2, 3], 'b': [2, 3, 4]}))

# Clone zero-shot gpt-oss:latest-ast 1 nfr4
def task_func(d):
    result = {}
    for lst in d.values():
        for num in lst:
            result[num] = result.get(num, 0) + 1
    return result


print(task_func({}))

# Clone zero-shot gpt-oss:latest-ast 1 nfr5
def task_func(d):
    result = {}
    for lst in d.values():
        for num in lst:
            result[num] = result.get(num, 0) + 1
    return result


if __name__ == '__main__':
    sample = {'a': [1, 2, 2], 'b': [2, 3]}
    print(task_func(sample))

# Clone zero-shot gpt-oss:latest-translation 1 nfr0
def task_func(d):
    count_dict = {}
    for lst in d.values():
        for num in lst:
            count_dict[num] = count_dict.get(num, 0) + 1
    return count_dict


print(task_func({}))

# Clone zero-shot gpt-oss:latest-translation 1 nfr1
def task_func(d):
    count = {}
    for lst in d.values():
        for num in lst:
            count[num] = count.get(num, 0) + 1
    return count


print(task_func({}))

# Clone zero-shot gpt-oss:latest-translation 1 nfr4
def task_func(d: dict[str, list[int]]) ->dict[int, int]:
    counts: dict[int, int] = {}
    for lst in d.values():
        for num in lst:
            counts[num] = counts.get(num, 0) + 1
    return counts


print(task_func({}))

# Clone few-shot gpt-oss:latest-complete 1 nfr1
def task_func(d):
    counts = {}
    for lst in d.values():
        for num in lst:
            if not isinstance(num, int):
                raise TypeError('All elements must be integers')
            counts[num] = counts.get(num, 0) + 1
    return counts


print(task_func({}))

# Clone few-shot gpt-oss:latest-minimal 1 nfr0
def task_func(d):
    counts = {}
    for lst in d.values():
        for num in lst:
            counts[num] = counts.get(num, 0) + 1
    return counts


print(task_func({}))

# Clone few-shot gpt-oss:latest-minimal 1 nfr1
def task_func(d):
    counts = {}
    for lst in d.values():
        for num in lst:
            counts[num] = counts.get(num, 0) + 1
    return counts


print(task_func({}))

# Clone few-shot gpt-oss:latest-minimal 1 nfr3
def task_func(d):
    counts = {}
    for lst in d.values():
        for num in lst:
            counts[num] = counts.get(num, 0) + 1
    return counts


print(task_func({'a': [1, 2, 3], 'b': [2, 3, 4]}))

# Clone few-shot gpt-oss:latest-minimal 1 nfr4
def task_func(d: dict) ->dict:
    counts = {}
    for lst in d.values():
        for num in lst:
            counts[num] = counts.get(num, 0) + 1
    return counts


print(task_func({}))

# Clone few-shot gpt-oss:latest-minimal 1 nfr5
def task_func(d: dict) ->dict:
    counts = {}
    for lst in d.values():
        for num in lst:
            counts[num] = counts.get(num, 0) + 1
    return counts


print(task_func({'a': [1, 2, 1], 'b': [2, 3]}))

# Clone few-shot gpt-oss:latest-requirements 1 nfr0
def task_func(d):
    result = {}
    for iterable in d.values():
        for item in iterable:
            result[item] = result.get(item, 0) + 1
    return result


print(task_func({'x': [1, 2, 3], 'y': [2, 3, 4]}))

# Clone few-shot gpt-oss:latest-requirements 1 nfr1
def task_func(d):
    counts = {}
    for iterable in d.values():
        for item in iterable:
            counts[item] = counts.get(item, 0) + 1
    return counts


print(task_func({}))

# Clone few-shot gpt-oss:latest-requirements 1 nfr3
def task_func(d):
    result = {}
    for iterable in d.values():
        for item in iterable:
            result[item] = result.get(item, 0) + 1
    return result


print(task_func({}))

# Clone few-shot gpt-oss:latest-requirements 1 nfr4
def task_func(d):
    counts = {}
    for iterable in d.values():
        for item in iterable:
            counts[item] = counts.get(item, 0) + 1
    return counts


print(task_func({}))

# Clone few-shot gpt-oss:latest-requirements 1 nfr5
def task_func(d):
    result = {}
    for iterable in d.values():
        for item in iterable:
            result[item] = result.get(item, 0) + 1
    return result


print(task_func({'a': [1, 2, 1], 'b': [2, 3]}))

# Clone few-shot gpt-oss:latest-ast 1 nfr1
def task_func(d):
    counts = {}
    for lst in d.values():
        for num in lst:
            counts[num] = counts.get(num, 0) + 1
    return counts


print(task_func({'a': [1, 2, 2], 'b': [2, 3]}))

# Clone few-shot gpt-oss:latest-ast 1 nfr3
def task_func(d):
    counts = {}
    for lst in d.values():
        for num in lst:
            counts[num] = counts.get(num, 0) + 1
    return counts


print(task_func({'a': [1, 2, 3], 'b': [2, 3, 4]}))

# Clone few-shot gpt-oss:latest-ast 1 nfr4
def task_func(d):
    counts = {}
    for lst in d.values():
        for num in lst:
            counts[num] = counts.get(num, 0) + 1
    return counts


print(task_func({'a': [1, 2, 3], 'b': [2, 3, 4]}))

# Clone few-shot gpt-oss:latest-ast 1 nfr5
def task_func(d):
    result = {}
    for lst in d.values():
        for num in lst:
            result[num] = result.get(num, 0) + 1
    return result


print(task_func({'a': [1, 2, 3], 'b': [2, 3, 4]}))

# Clone few-shot gpt-oss:latest-translation 1 nfr0
def task_func(d: dict) ->dict:
    count = {}
    for lst in d.values():
        for num in lst:
            count[num] = count.get(num, 0) + 1
    return count

# Clone few-shot gpt-oss:latest-translation 1 nfr1
def task_func(d):
    counts = {}
    for lst in d.values():
        for num in lst:
            counts[num] = counts.get(num, 0) + 1
    return counts


print(task_func({}))

# Clone few-shot gpt-oss:latest-translation 1 nfr3
def task_func(d: dict[str, list[int]]) ->dict[int, int]:
    counts: dict[int, int] = {}
    for lst in d.values():
        for num in lst:
            counts[num] = counts.get(num, 0) + 1
    return counts


print(task_func({}))

# Clone few-shot gpt-oss:latest-translation 1 nfr4
def task_func(d):
    counts = {}
    for lst in d.values():
        for num in lst:
            counts[num] = counts.get(num, 0) + 1
    return counts


print(task_func({}))

# Clone cot gpt-oss:latest-minimal 1 nfr0
def task_func(d):
    counts = {}
    for lst in d.values():
        for num in lst:
            counts[num] = counts.get(num, 0) + 1
    return counts


print(task_func({}))

# Clone cot gpt-oss:latest-minimal 1 nfr1
def task_func(d):
    counts = {}
    for lst in d.values():
        for num in lst:
            counts[num] = counts.get(num, 0) + 1
    return counts


print(task_func({}))

# Clone cot gpt-oss:latest-minimal 1 nfr3
def task_func(d):
    counts = {}
    for lst in d.values():
        for num in lst:
            counts[num] = counts.get(num, 0) + 1
    return counts


print(task_func({'a': [1, 2, 1], 'b': [2, 3]}))

# Clone cot gpt-oss:latest-minimal 1 nfr4
def task_func(d):
    counts = {}
    for lst in d.values():
        for num in lst:
            counts[num] = counts.get(num, 0) + 1
    return counts


print(task_func({}))

# Clone cot gpt-oss:latest-minimal 1 nfr5
def task_func(d):
    counts = {}
    for lst in d.values():
        for num in lst:
            counts[num] = counts.get(num, 0) + 1
    return counts


print(task_func({'a': [1, 2, 1], 'b': [2, 3]}))

# Clone cot gpt-oss:latest-requirements 1 nfr0
def task_func(d):
    result = {}
    for iterable in d.values():
        for num in iterable:
            result[num] = result.get(num, 0) + 1
    return result


print(task_func({'a': [1, 2, 3], 'b': [2, 3, 4]}))

# Clone cot gpt-oss:latest-requirements 1 nfr1
def task_func(d):
    result = {}
    for lst in d.values():
        for num in lst:
            result[num] = result.get(num, 0) + 1
    return result


print(task_func({'a': [1, 2, 3], 'b': [2, 3, 4]}))

# Clone cot gpt-oss:latest-requirements 1 nfr4
def task_func(d):
    counts = {}
    for iterable in d.values():
        for item in iterable:
            counts[item] = counts.get(item, 0) + 1
    return counts


print(task_func({}))

# Clone cot gpt-oss:latest-requirements 1 nfr5
def task_func(d):
    result = {}
    for iterable in d.values():
        for item in iterable:
            result[item] = result.get(item, 0) + 1
    return result

# Clone cot gpt-oss:latest-uml 1 nfr1
def task_func(d):
    counts = {}
    for lst in d.values():
        for num in lst:
            counts[num] = counts.get(num, 0) + 1
    return counts


print(task_func({}))

# Clone cot gpt-oss:latest-ast 1 nfr0
def task_func(d):
    counts = {}
    for lst in d.values():
        for num in lst:
            counts[num] = counts.get(num, 0) + 1
    return counts


print(task_func({'a': [1, 2, 3], 'b': [2, 3, 4]}))

# Clone cot gpt-oss:latest-ast 1 nfr1
def task_func(d):
    counts = {}
    for lst in d.values():
        for num in lst:
            counts[num] = counts.get(num, 0) + 1
    return counts


print(task_func({'a': [1, 2, 3], 'b': [2, 3, 4]}))

# Clone cot gpt-oss:latest-ast 1 nfr3
def task_func(d):
    counts = {}
    for lst in d.values():
        for num in lst:
            counts[num] = counts.get(num, 0) + 1
    return counts


print(task_func({'a': [1, 2, 3], 'b': [2, 3, 4]}))

# Clone cot gpt-oss:latest-ast 1 nfr4
def task_func(d):
    counts = {}
    for lst in d.values():
        for num in lst:
            counts[num] = counts.get(num, 0) + 1
    return counts


print(task_func({'a': [1, 2, 2], 'b': [2, 3]}))

# Clone cot gpt-oss:latest-ast 1 nfr5
def task_func(d):
    counts = {}
    for lst in d.values():
        for num in lst:
            counts[num] = counts.get(num, 0) + 1
    return counts

# Clone cot gpt-oss:latest-translation 1 nfr0
def task_func(d):
    counts = {}
    for lst in d.values():
        for num in lst:
            counts[num] = counts.get(num, 0) + 1
    return counts


print(task_func({}))

# Clone cot gpt-oss:latest-translation 1 nfr1
def task_func(d):
    counts = {}
    for lst in d.values():
        for num in lst:
            counts[num] = counts.get(num, 0) + 1
    return counts

# Clone cot gpt-oss:latest-translation 1 nfr3
def task_func(d):
    counts = {}
    for lst in d.values():
        for num in lst:
            counts[num] = counts.get(num, 0) + 1
    return counts


print(task_func({}))

# Clone cot gpt-oss:latest-translation 1 nfr5
def task_func(d: dict[str, list[int]]) ->dict[int, int]:
    counts: dict[int, int] = {}
    for lst in d.values():
        for num in lst:
            counts[num] = counts.get(num, 0) + 1
    return counts


print(task_func({}))

# Clone zero-shot gpt-oss:20b-complete 1 nfr1
def task_func(d):
    counts = {}
    for lst in d.values():
        for num in lst:
            if not isinstance(num, int):
                raise TypeError('All items must be integers')
            counts[num] = counts.get(num, 0) + 1
    return counts

# Clone zero-shot gpt-oss:20b-minimal 1 nfr0
def task_func(d):
    counts = {}
    for lst in d.values():
        for num in lst:
            counts[num] = counts.get(num, 0) + 1
    return counts

# Clone zero-shot gpt-oss:20b-minimal 1 nfr1
def task_func(d: dict) ->dict:
    result = {}
    for lst in d.values():
        for num in lst:
            result[num] = result.get(num, 0) + 1
    return result

# Clone zero-shot gpt-oss:20b-requirements 1 nfr0
def task_func(d):
    counts = {}
    for iterable in d.values():
        for item in iterable:
            counts[item] = counts.get(item, 0) + 1
    return counts

# Clone zero-shot gpt-oss:20b-requirements 1 nfr1
def task_func(d):
    result = {}
    for values in d.values():
        for num in values:
            result[num] = result.get(num, 0) + 1
    return result

# Clone zero-shot gpt-oss:20b-requirements 1 nfr4
def task_func(d):
    result = {}
    for values in d.values():
        for item in values:
            result[item] = result.get(item, 0) + 1
    return result

# Clone zero-shot gpt-oss:20b-ast 1 nfr0
def task_func(d):
    result = {}
    for lst in d.values():
        for num in lst:
            result[num] = result.get(num, 0) + 1
    return result

# Clone zero-shot gpt-oss:20b-ast 1 nfr1
def task_func(d):
    counts = {}
    for lst in d.values():
        for num in lst:
            counts[num] = counts.get(num, 0) + 1
    return counts

# Clone zero-shot gpt-oss:20b-ast 1 nfr3
def task_func(d):
    counts = {}
    for lst in d.values():
        for num in lst:
            counts[num] = counts.get(num, 0) + 1
    return counts

# Clone zero-shot gpt-oss:20b-ast 1 nfr4
def task_func(d):
    counts = {}
    for lst in d.values():
        for num in lst:
            counts[num] = counts.get(num, 0) + 1
    return counts

# Clone zero-shot gpt-oss:20b-ast 1 nfr5
def task_func(d):
    counts = {}
    for values in d.values():
        for number in values:
            counts[number] = counts.get(number, 0) + 1
    return counts

# Clone zero-shot gpt-oss:20b-translation 1 nfr0
def task_func(d: dict) ->dict:
    counts = {}
    for lst in d.values():
        for num in lst:
            counts[num] = counts.get(num, 0) + 1
    return counts

# Clone zero-shot gpt-oss:20b-translation 1 nfr1
def task_func(d):
    """Count occurrences of integers across all lists in the dictionary."""
    result = {}
    for lst in d.values():
        for num in lst:
            result[num] = result.get(num, 0) + 1
    return result

# Clone zero-shot gpt-oss:20b-translation 1 nfr3
from typing import Dict, List


def task_func(d: Dict[str, List[int]]) ->Dict[int, int]:
    counts: Dict[int, int] = {}
    for lst in d.values():
        for num in lst:
            counts[num] = counts.get(num, 0) + 1
    return counts

# Clone zero-shot gpt-oss:20b-translation 1 nfr4
def task_func(d):
    counts = {}
    for lst in d.values():
        for num in lst:
            counts[num] = counts.get(num, 0) + 1
    return counts

# Clone few-shot gpt-oss:20b-complete 1 nfr1
def task_func(d):
    counts = {}
    for lst in d.values():
        for num in lst:
            if not isinstance(num, int):
                raise TypeError
            counts[num] = counts.get(num, 0) + 1
    return counts

# Clone few-shot gpt-oss:20b-minimal 1 nfr0
def task_func(d):
    counts = {}
    for lst in d.values():
        for num in lst:
            counts[num] = counts.get(num, 0) + 1
    return counts

# Clone few-shot gpt-oss:20b-minimal 1 nfr1
def task_func(d):
    counts = {}
    for lst in d.values():
        for num in lst:
            counts[num] = counts.get(num, 0) + 1
    return counts

# Clone few-shot gpt-oss:20b-minimal 1 nfr3
def task_func(d):
    counts = {}
    for lst in d.values():
        for num in lst:
            counts[num] = counts.get(num, 0) + 1
    return counts

# Clone few-shot gpt-oss:20b-requirements 1 nfr0
def task_func(d):
    result = {}
    for lst in d.values():
        for num in lst:
            result[num] = result.get(num, 0) + 1
    return result

# Clone few-shot gpt-oss:20b-requirements 1 nfr1
def task_func(d):
    result = {}
    for values in d.values():
        for num in values:
            result[num] = result.get(num, 0) + 1
    return result

# Clone few-shot gpt-oss:20b-requirements 1 nfr3
def task_func(d):
    """
    Count occurrences of integers across all iterable values in the input dictionary.

    Parameters
    ----------
    d : dict
        Dictionary where keys are strings and values are iterables of integers.

    Returns
    -------
    dict
        Mapping from each unique integer to its total count across all values.
    """
    if not d:
        return {}
    counts = {}
    for iterable in d.values():
        for item in iterable:
            counts[item] = counts.get(item, 0) + 1
    return counts

# Clone few-shot gpt-oss:20b-requirements 1 nfr5
def task_func(d):
    counts = {}
    for iterable in d.values():
        for item in iterable:
            counts[item] = counts.get(item, 0) + 1
    return counts

# Clone few-shot gpt-oss:20b-ast 1 nfr0
def task_func(d):
    counts = {}
    for lst in d.values():
        for num in lst:
            counts[num] = counts.get(num, 0) + 1
    return counts

# Clone few-shot gpt-oss:20b-ast 1 nfr1
def task_func(d):
    counts = {}
    for lst in d.values():
        for num in lst:
            counts[num] = counts.get(num, 0) + 1
    return counts

# Clone few-shot gpt-oss:20b-ast 1 nfr3
def task_func(d):
    result = {}
    for lst in d.values():
        for num in lst:
            result[num] = result.get(num, 0) + 1
    return result

# Clone few-shot gpt-oss:20b-ast 1 nfr4
def task_func(d):
    counts = {}
    for lst in d.values():
        for num in lst:
            counts[num] = counts.get(num, 0) + 1
    return counts

# Clone few-shot gpt-oss:20b-ast 1 nfr5
def task_func(d: dict[str, list[int]]) ->dict[int, int]:
    """Count how many times each integer appears across all lists in the dictionary."""
    counts: dict[int, int] = {}
    for numbers in d.values():
        for value in numbers:
            counts[value] = counts.get(value, 0) + 1
    return counts

# Clone few-shot gpt-oss:20b-translation 1 nfr1
def task_func(d):
    counts = {}
    for lst in d.values():
        for num in lst:
            counts[num] = counts.get(num, 0) + 1
    return counts

# Clone few-shot gpt-oss:20b-translation 1 nfr4
def task_func(d):
    if not d:
        return {}
    counts = {}
    for lst in d.values():
        for num in lst:
            counts[num] = counts.get(num, 0) + 1
    return counts

# Clone cot gpt-oss:20b-complete 1 nfr1
def task_func(d):
    counts = {}
    for lst in d.values():
        for num in lst:
            if not isinstance(num, int):
                raise TypeError('All items must be integers')
            counts[num] = counts.get(num, 0) + 1
    return counts

# Clone cot gpt-oss:20b-minimal 1 nfr0
def task_func(d):
    counts = {}
    for lst in d.values():
        for num in lst:
            counts[num] = counts.get(num, 0) + 1
    return counts

# Clone cot gpt-oss:20b-minimal 1 nfr1
def task_func(d):
    counts = {}
    for lst in d.values():
        for num in lst:
            counts[num] = counts.get(num, 0) + 1
    return counts

# Clone cot gpt-oss:20b-minimal 1 nfr4
def task_func(d):
    result = {}
    for lst in d.values():
        for num in lst:
            result[num] = result.get(num, 0) + 1
    return result

# Clone cot gpt-oss:20b-requirements 1 nfr3
def task_func(d):
    result = {}
    for values in d.values():
        for num in values:
            result[num] = result.get(num, 0) + 1
    return result

# Clone cot gpt-oss:20b-requirements 1 nfr4
def task_func(d):
    result = {}
    for values in d.values():
        for num in values:
            result[num] = result.get(num, 0) + 1
    return result

# Clone cot gpt-oss:20b-requirements 1 nfr5
def task_func(d: dict[str, list[int]]) ->dict[int, int]:
    """
    Count occurrences of integers across all lists in the input dictionary.

    Parameters:
        d (dict[str, list[int]]): Dictionary mapping strings to lists of integers.

    Returns:
        dict[int, int]: Dictionary mapping each integer to its total count
        across all lists. Returns an empty dictionary if the input is empty.
    """
    counts: dict[int, int] = {}
    for values in d.values():
        for num in values:
            counts[num] = counts.get(num, 0) + 1
    return counts

# Clone cot gpt-oss:20b-ast 1 nfr0
def task_func(d):
    counts = {}
    for lst in d.values():
        for num in lst:
            counts[num] = counts.get(num, 0) + 1
    return counts

# Clone cot gpt-oss:20b-ast 1 nfr1
def task_func(d):
    result = {}
    for lst in d.values():
        for num in lst:
            result[num] = result.get(num, 0) + 1
    return result

# Clone cot gpt-oss:20b-ast 1 nfr3
def task_func(d):
    result = {}
    for lst in d.values():
        for num in lst:
            result[num] = result.get(num, 0) + 1
    return result

# Clone cot gpt-oss:20b-ast 1 nfr4
def task_func(d):
    counts = {}
    for lst in d.values():
        for num in lst:
            counts[num] = counts.get(num, 0) + 1
    return counts

# Clone cot gpt-oss:20b-ast 1 nfr5
def task_func(d):
    counts = {}
    for lst in d.values():
        for num in lst:
            counts[num] = counts.get(num, 0) + 1
    return counts

# Clone cot gpt-oss:20b-translation 1 nfr1
def task_func(d):
    count_dict = {}
    for lst in d.values():
        for num in lst:
            count_dict[num] = count_dict.get(num, 0) + 1
    return count_dict

# Clone cot gpt-oss:20b-translation 1 nfr4
def task_func(d: dict[str, list[int]]) ->dict[int, int]:
    counts: dict[int, int] = {}
    for lst in d.values():
        for num in lst:
            counts[num] = counts.get(num, 0) + 1
    return counts

