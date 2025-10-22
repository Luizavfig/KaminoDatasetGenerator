# Clone cot gemma3:latest-complete 1 ['refac_1', 'refac_4', 'refac_5']
import os
import shutil
import tempfile


def task_func(filename, dest_dir):
    os.makedirs(dest_dir, exist_ok=True)
    shutil.copy2(filename, os.path.join(dest_dir, os.path.basename(filename)))
    open(filename, 'w').truncate(0)
    return os.path.abspath(os.path.join(dest_dir, os.path.basename(filename)))

