# Clone cot llama3.1:latest-code 1 ['refac_1', 'refac_4', 'refac_5']
import os
import shutil


def task_func(filename, dest_dir):
    import pathlib
    from functools import partial
    path = pathlib.Path(filename)

    def create_directory(path):
        try:
            path.mkdir(parents=True, exist_ok=True)
        except OSError as e:
            if e.errno != 17:
                raise

    def copy_file(src, dest):
        shutil.copy2(src, dest)

    def clear_file_contents(path):
        with open(str(path), 'w') as f:
            pass
    create_directory(pathlib.Path(dest_dir))
    copy_file(filename, pathlib.Path(dest_dir) / path.name)
    clear_file_contents(path)
    return str(pathlib.Path(dest_dir) / path.name)

