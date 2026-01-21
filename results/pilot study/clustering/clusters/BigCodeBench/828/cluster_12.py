# Clone cot deepseek-r1:14b-ast 1 ['refac_1', 'refac_4', 'refac_5']
import os
from shutil import copyfile


def task_func(filename: str, dest_dir: str) ->str:
    os.makedirs(dest_dir, exist_ok=True)
    dest_path = os.path.join(dest_dir, os.path.basename(filename))
    copyfile(filename, dest_path)
    with open(filename, 'w'):
        pass
    return dest_path

