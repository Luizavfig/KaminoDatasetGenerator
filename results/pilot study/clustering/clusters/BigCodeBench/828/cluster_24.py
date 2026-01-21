# Clone cot gpt-oss:20b-complete 1 ['refac_1', 'refac_3', 'refac_4']
import os
import shutil
from pathlib import Path


def task_func(source_file, dest_dir):
    src = Path(source_file)
    if not src.is_file():
        raise FileNotFoundError(f"No such file: '{source_file}'")
    dest_dir_path = Path(dest_dir)
    if src.parent.resolve() == dest_dir_path.resolve():
        raise OSError('Source and destination directories are the same')
    dest_dir_path.mkdir(parents=True, exist_ok=True)
    dest_file = dest_dir_path / src.name
    shutil.copy2(src, dest_file)
    src.write_text('')
    return str(dest_file.resolve())

