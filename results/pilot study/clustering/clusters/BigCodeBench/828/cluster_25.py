# Clone zero-shot gpt-oss:20b-complete 1 ['refac_2', 'refac_5', 'refac_6']
import logging
from pathlib import Path
logger = logging.getLogger(__name__)


def task_func(source_path: str, dest_dir: str) ->str:
    src = Path(source_path).resolve()
    if not src.is_file():
        logger.error('Source file does not exist: %s', source_path)
        raise FileNotFoundError(f"No such file: '{source_path}'")
    dest_dir_path = Path(dest_dir).resolve()
    if src.parent == dest_dir_path:
        logger.error('Source and destination directories are the same: %s',
            dest_dir)
        raise OSError('Source and destination directories are the same')
    try:
        dest_dir_path.mkdir(parents=True, exist_ok=True)
    except Exception as exc:
        logger.exception('Failed to create destination directory: %s', dest_dir
            )
        raise
    dest_file = dest_dir_path / src.name
    try:
        content = src.read_bytes()
        dest_file.write_bytes(content)
    except Exception as exc:
        logger.exception('Failed to copy file to destination: %s', dest_file)
        raise
    try:
        src.write_bytes(b'')
    except Exception as exc:
        logger.exception('Failed to clear original file: %s', src)
        raise
    return str(dest_file.resolve())

