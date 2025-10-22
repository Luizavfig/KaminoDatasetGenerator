# Clone zero-shot gemma3:latest-code 1 ['refac_2', 'refac_5', 'refac_6']
import pathlib
import shutil
import tempfile


def task_func(filename, dest_dir):
    file_path = pathlib.Path(filename)
    dest_path = pathlib.Path(dest_dir)
    if not dest_path.is_dir():
        try:
            dest_path.mkdir(parents=True)
        except Exception as e:
            raise OSError(f'Failed to create destination directory: {e}')
    dest_file_path = dest_path / file_path.name
    shutil.copy2(filename, dest_file_path)
    with open(filename, 'w') as original_file:
        original_file.truncate(0)
    return str(dest_file_path.resolve())

