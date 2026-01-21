# Clone cot llama3.1:latest-test 1 ['refac_3', 'refac_5', 'refac_7']
import os
import shutil


def task_func(filename: str, dest_dir: str) ->str:
    src_path = os.path.abspath(filename)
    if not os.path.isfile(src_path):
        raise FileNotFoundError(f'Source file not found: {filename}')
    dest_dir_abs = os.path.abspath(dest_dir)
    src_dir = os.path.dirname(src_path)
    if src_dir == dest_dir_abs:
        raise OSError('Source and destination directories are the same')
    os.makedirs(dest_dir_abs, exist_ok=True)
    dest_path = os.path.join(dest_dir_abs, os.path.basename(src_path))
    shutil.copy2(src_path, dest_path)
    with open(src_path, 'w'):
        pass
    return dest_path

