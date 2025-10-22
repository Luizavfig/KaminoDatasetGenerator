# Clone zero-shot llama3.1:latest-complete 1 ['refac_1', 'refac_3', 'refac_4']
import os
import shutil


def task_func(filename, dest_dir):
    """
    Copies a file to a specified destination directory and clears its contents.

    Args:
        filename (str): Path to the source file.
        dest_dir (str): Destination directory path.

    Returns:
        str: Absolute path of the copied file.

    Raises:
        OSError: If the source and destination directories are the same.
        FileNotFoundError: If the source file does not exist.
    """
    if os.path.abspath(filename) == os.path.abspath(dest_dir):
        raise OSError('Source and destination cannot be the same')
    try:
        os.makedirs(dest_dir)
    except FileExistsError:
        pass
    dest = shutil.copy(filename, dest_dir)
    with open(filename, 'w') as original_file:
        original_file.truncate(0)
    return os.path.abspath(dest)

