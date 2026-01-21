# Clone cot gpt-oss:20b-code 1 ['refac_2', 'refac_6', 'refac_7']
import pathlib
import logging
import os
logging.basicConfig(level=logging.ERROR)


def task_func(filename, dest_dir):
    if not isinstance(filename, str):
        raise TypeError('filename must be a string')
    if not isinstance(dest_dir, str):
        raise TypeError('dest_dir must be a string')
    src_path = pathlib.Path(filename)
    if not src_path.is_file():
        raise FileNotFoundError(f'File {filename} does not exist')
    dest_dir_path = pathlib.Path(dest_dir)
    if dest_dir_path == src_path.parent:
        raise OSError('Destination directory is the same as source file parent'
            )
    try:
        dest_dir_path.mkdir(parents=True, exist_ok=True)
    except Exception as e:
        logging.error(f'Could not create destination directory: {e}')
        raise
    if dest_dir_path.exists():
        if not dest_dir_path.is_dir():
            raise NotADirectoryError(f'{dest_dir} is not a directory')
    dest_file_path = dest_dir_path / src_path.name
    if dest_file_path.exists():
        if dest_file_path.is_file():
            pass
        else:
            raise FileExistsError(f'{dest_file_path} exists and is not a file')
    try:
        content = src_path.read_bytes()
        dest_file_path.write_bytes(content)
    except Exception as e:
        logging.error(f'Error copying file: {e}')
        raise
    if dest_file_path.exists():
        if dest_file_path.is_file():
            pass
        else:
            raise FileExistsError(f'{dest_file_path} exists and is not a file')
    try:
        src_path.write_bytes(b'')
    except Exception as e:
        logging.error(f'Error clearing original file: {e}')
        raise
    return str(dest_file_path.resolve())

