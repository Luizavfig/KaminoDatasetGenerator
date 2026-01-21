# Clone cot llama3.1:latest-code 1 ['refac_1', 'refac_3', 'refac_4']
import os
from pathlib import Path


def task_func(filename, dest_dir):
    src_path = Path(filename)
    dst_path = Path(dest_dir) / src_path.name
    if not dst_path.parent.exists():
        dst_path.parent.mkdir(parents=True)
    shutil.copy2(src_path, dst_path)
    with open(src_path, 'w') as f:
        pass
    return str(dst_path.resolve())

