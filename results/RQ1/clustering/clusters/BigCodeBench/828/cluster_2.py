# Clone zero-shot deepseek-r1:14b-test 1 ['refac_1', 'refac_4', 'refac_5']
import os
import shutil


def task_func(filename: str, dest_dir: str) ->str:
    """
    Copy a file to a specified destination directory and clear its contents.

    Args:
        filename (str): The path to the source file.
        dest_dir (str): The path to the destination directory.

    Returns:
        str: The absolute path to the copied file within the destination directory.

    Raises:
        FileNotFoundError: If the source file does not exist.
        OSError: If the destination directory is the same as the source file's directory.
    """
    os.makedirs(dest_dir, exist_ok=True)
    copied_file = shutil.copy2(filename, dest_dir)
    with open(filename, 'w') as f:
        pass
    return copied_file

