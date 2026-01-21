# Clone zero-shot deepseek-r1:14b-code 1 ['refac_1', 'refac_3', 'refac_4']
import os
import shutil
import errno


def task_func(filename: str, dest_dir: str) ->str:
    """Copies a file to a destination directory and clears its original content."""
    os.makedirs(dest_dir, exist_ok=True)
    dest = shutil.copy(filename, dest_dir)
    with open(filename, 'w') as f:
        pass
    return os.path.abspath(dest)

