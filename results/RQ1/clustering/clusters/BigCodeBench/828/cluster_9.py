# Clone zero-shot llama3.1:latest-test 1 ['refac_2', 'refac_4', 'refac_6']
import os
import shutil
from pathlib import Path


def task_func(filename: str, dest_dir: str) ->str:
    if filename == dest_dir:
        raise OSError('Source and destination directories are the same')
    src_path = Path(filename)
    dest_path = Path(dest_dir) / src_path.name
    os.makedirs(dest_dir, exist_ok=True)
    shutil.copy2(filename, dest_path)
    with open(src_path, 'w') as f:
        pass
    return str(dest_path.resolve())

