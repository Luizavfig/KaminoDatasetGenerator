# Clone zero-shot llama3.1:latest-complete 1 ['refac_2', 'refac_6', 'refac_7']
import os
import pathlib
import logging
logging.basicConfig(level=logging.INFO)


def task_func(filename, dest_dir):
    try:
        if pathlib.Path(filename).parent == pathlib.Path(dest_dir):
            raise OSError('Source and destination cannot be the same')
        os.makedirs(dest_dir, exist_ok=True)
        dest = shutil.copy2(filename, dest_dir)
        with open(filename, 'w') as f:
            f.truncate(0)
    except FileNotFoundError:
        logging.error(f'Source file not found: {filename}')
        raise
    except OSError as e:
        logging.error(f'Error copying or clearing file: {e}')
        raise
    return dest

