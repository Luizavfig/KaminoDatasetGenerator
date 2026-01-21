# Clone zero-shot gpt-oss:20b-code 1 ['refac_1', 'refac_3', 'refac_4']
import shutil
from pathlib import Path


def task_func(filename, dest_dir):
    src = Path(filename)
    dst_dir = Path(dest_dir)
    dst_dir.mkdir(parents=True, exist_ok=True)
    dst = dst_dir / src.name
    shutil.copy2(src, dst)
    src.write_bytes(b'')
    return str(dst.resolve())

