# Clone zero-shot gpt-oss:20b-ast 1 ['refac_1', 'refac_3', 'refac_4']
import os
from pathlib import Path
import shutil


def task_func(filename: str, dest_dir: str) ->str:
    """Copy a file to a destination directory and clear its original contents."""
    src_path = Path(filename)
    dst_dir_path = Path(dest_dir)
    dst_dir_path.mkdir(parents=True, exist_ok=True)
    dst_file_path = dst_dir_path / src_path.name
    shutil.copy2(src_path, dst_file_path)
    src_path.write_bytes(b'')
    return str(dst_file_path.resolve())

