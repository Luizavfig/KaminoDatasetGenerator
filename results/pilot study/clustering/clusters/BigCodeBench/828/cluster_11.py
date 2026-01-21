# Clone zero-shot llama3.1:latest-code 1 ['refac_1', 'refac_4', 'refac_5']
import os
from pathlib import Path


def task_func(filename: str, dest_dir: str) ->str:

    def create_directory(path):
        return Path(path).mkdir(parents=True, exist_ok=True)

    def copy_file(src, dst):
        with open(dst, 'w') as f:
            shutil.copyfile(src, f.name)
        return os.path.abspath(f.name)

    def clear_original_file(file_path):
        with open(file_path, 'w'):
            pass
    create_directory(dest_dir)
    copied_file = copy_file(filename, Path(dest_dir) / Path(filename).name)
    clear_original_file(filename)
    return copied_file

