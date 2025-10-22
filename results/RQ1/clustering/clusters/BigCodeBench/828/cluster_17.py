# Clone zero-shot gemma3:latest-ast 1 ['refac_2', 'refac_6', 'refac_7']
import shutil
import os
import logging
logger = logging.getLogger(__name__)


def task_func(filename, dest_dir):
    try:
        if not os.path.exists(filename):
            raise FileNotFoundError(f'File not found: {filename}')
        if not os.path.exists(dest_dir):
            os.makedirs(dest_dir)
        shutil.copy2(filename, os.path.join(dest_dir, os.path.basename(
            filename)))
        open(filename, 'w').close()
        copied_file_path = os.path.join(dest_dir, os.path.basename(filename))
        return copied_file_path
    except Exception as e:
        logger.exception('An error occurred during file copy and erasure:')
        raise

