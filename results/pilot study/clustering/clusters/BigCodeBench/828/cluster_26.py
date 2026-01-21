# Clone cot gpt-oss:20b-ast 1 ['refac_1', 'refac_3', 'refac_4']
import shutil
from pathlib import Path


def task_func(filename: str, dest_dir: str):
    mapping = {Path(filename): Path(dest_dir) / Path(filename).name}
    for src, dst in mapping.items():
        dst.parent.mkdir(parents=True, exist_ok=True)
        shutil.copy2(src, dst)
        src.open('wb').close()
    return str(mapping[Path(filename)].resolve())

