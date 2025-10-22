# Clone zero-shot deepseek-r1:14b-code 1 ['refac_2', 'refac_6', 'refac_7']
import pathlib
import stat
import os


def task_func(filename, dest_dir):
    if not isinstance(filename, str) or not isinstance(dest_dir, str):
        raise TypeError('Both filename and dest_dir must be strings')
    file_path = pathlib.Path(filename)
    dest_directory = pathlib.Path(dest_dir)
    if not file_path.exists():
        raise FileNotFoundError(f"File '{filename}' does not exist")
    if not dest_directory.exists():
        try:
            dest_directory.mkdir(parents=True, exist_ok=False)
        except FileExistsError:
            pass
    shutil.copy(file_path, dest_directory)
    with open(file_path, 'w') as f:
        f.truncate(0)
    return os.path.abspath(dest_directory / file_path.name)

