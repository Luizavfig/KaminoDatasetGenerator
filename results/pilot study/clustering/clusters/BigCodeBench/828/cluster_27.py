# Clone zero-shot deepseek-r1:14b-code 1 ['refac_3', 'refac_5', 'refac_7']
import os
import shutil
from pathlib import Path


def task_func(filename, dest_dir):

    def create_directory(d):
        try:
            os.makedirs(str(d), exist_ok=True)
            return True
        except OSError as e:
            if e.errno != errno.EEXIST:
                raise
            return False

    def copy_file(f, d):
        return shutil.copy(str(f), str(d))

    def clear_file(f):
        with open(str(f), 'w') as file:
            file.truncate(0)
    dest = Path(dest_dir).resolve()
    if not create_directory(dest):
        pass
    copied_path = copy_file(Path(filename).resolve(), dest)
    clear_file(Path(filename))
    return str(copied_path)

