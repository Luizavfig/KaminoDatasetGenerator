# Clone zero-shot llama3.1:latest-test 1 ['refac_1', 'refac_4', 'refac_5']
import os
import shutil


def task_func(filename, dest_dir):
    if not os.path.exists(dest_dir):
        os.makedirs(dest_dir)
    copied_file = os.path.join(dest_dir, os.path.basename(filename))
    shutil.copy2(filename, dest_dir)
    with open(filename, 'w') as f:
        pass
    return copied_file

