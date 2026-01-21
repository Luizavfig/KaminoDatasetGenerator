# Clone zero-shot gemma3:latest-complete 1 ['refac_3', 'refac_5', 'refac_7']
import os
import shutil
import errno


def task_func(filename, dest_dir):
    try:
        os.makedirs(dest_dir, exist_ok=True)
    except OSError as e:
        if e.errno != errno.EEXIST:
            raise
    shutil.copy2(filename, os.path.join(dest_dir, os.path.basename(filename)))
    with open(filename, 'w') as f:
        f.truncate(0)
    return os.path.abspath(os.path.join(dest_dir, os.path.basename(filename)))

