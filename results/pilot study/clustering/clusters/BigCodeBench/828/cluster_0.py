# Clone zero-shot deepseek-r1:14b-complete 1 ['refac_2', 'refac_4', 'refac_6']
import os
from pathlib import Path
import shutil


def task_func(filename: str, dest_dir: str) ->str:
    """Copy a file to the specified destination directory and clear its contents.

    Args:
        filename (str): Path to the source file.
        dest_dir (str): Path to the destination directory.

    Returns:
        str: Absolute path of the copied file.

    Raises:
        FileNotFoundError: If the source file does not exist.
        OSError: If there's an issue creating the destination directory or copying the file.
    """
    if not os.path.isfile(filename):
        raise FileNotFoundError(f"Source file '{filename}' does not exist.")
    dest_path = Path(dest_dir)
    dest_path.mkdir(parents=True, exist_ok=True)
    copied_file = shutil.copy2(str(filename), str(dest_path))
    with open(filename, 'w', encoding='utf-8') as f:
        pass
    return os.path.abspath(copied_file)

