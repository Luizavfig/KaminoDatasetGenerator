# Cluster 0 - Representative clone zero-shot deepseek-r1:14b-complete 1 ['refac_2', 'refac_4', 'refac_6']
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

# Cluster 1 - Representative clone zero-shot llama3.1:latest-complete 1 ['refac_1', 'refac_3', 'refac_4']
import os
import shutil


def task_func(filename, dest_dir):
    """
    Copies a file to a specified destination directory and clears its contents.

    Args:
        filename (str): Path to the source file.
        dest_dir (str): Destination directory path.

    Returns:
        str: Absolute path of the copied file.

    Raises:
        OSError: If the source and destination directories are the same.
        FileNotFoundError: If the source file does not exist.
    """
    if os.path.abspath(filename) == os.path.abspath(dest_dir):
        raise OSError('Source and destination cannot be the same')
    try:
        os.makedirs(dest_dir)
    except FileExistsError:
        pass
    dest = shutil.copy(filename, dest_dir)
    with open(filename, 'w') as original_file:
        original_file.truncate(0)
    return os.path.abspath(dest)

# Cluster 2 - Representative clone zero-shot deepseek-r1:14b-test 1 ['refac_1', 'refac_4', 'refac_5']
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

# Cluster 3 - Representative clone zero-shot llama3.1:latest-complete 1 ['refac_2', 'refac_6', 'refac_7']
import os
import pathlib
import logging
logging.basicConfig(level=logging.INFO)


def task_func(filename, dest_dir):
    try:
        if pathlib.Path(filename).parent == pathlib.Path(dest_dir):
            raise OSError('Source and destination cannot be the same')
        os.makedirs(dest_dir, exist_ok=True)
        dest = shutil.copy2(filename, dest_dir)
        with open(filename, 'w') as f:
            f.truncate(0)
    except FileNotFoundError:
        logging.error(f'Source file not found: {filename}')
        raise
    except OSError as e:
        logging.error(f'Error copying or clearing file: {e}')
        raise
    return dest

# Cluster 4 - Representative clone zero-shot gemma3:latest-complete 1 ['refac_3', 'refac_5', 'refac_7']
import os
import shutil
import errno


def task_func(filename, dest_dir):
    try:
        os.makedirs(dest_dir, exist_ok=True)
    except OSError as e:
        if e.errno != errno.EEXIST:
            raise
    shutil.copy2(filename, os.path.join(dest_dir, os.path.basename(filename)))
    with open(filename, 'w') as f:
        f.truncate(0)
    return os.path.abspath(os.path.join(dest_dir, os.path.basename(filename)))

# Cluster 5 - Representative clone cot llama3.1:latest-complete 1 ['refac_2', 'refac_5', 'refac_6']
import os
import pathlib
from typing import Optional


def task_func(filename: str, dest_dir: str) ->Optional[str]:
    try:
        pathlib.Path(dest_dir).mkdir(parents=True, exist_ok=True)
        copied_file = shutil.copy(filename, dest_dir)
        with open(filename, 'w') as original_file:
            original_file.truncate(0)
        return os.path.abspath(copied_file)
    except OSError as e:
        if e.errno != 17:
            raise
    except FileNotFoundError:
        raise


import unittest
import tempfile
import shutil


class TestCases(unittest.TestCase):

    def setUp(self):
        self.test_dir = tempfile.mkdtemp()
        self.test_file = os.path.join(self.test_dir, 'test.txt')
        with open(self.test_file, 'w') as f:
            f.write('This is a test file.')

    def tearDown(self):
        shutil.rmtree(self.test_dir)

    def test_copy_and_erase(self):
        dest_dir = os.path.join(self.test_dir, 'dest')
        copied_file = task_func(self.test_file, dest_dir)
        self.assertTrue(os.path.isfile(copied_file))
        with open(self.test_file, 'r') as f:
            self.assertEqual(f.read(), '')

    def test_non_existent_dest_dir(self):
        dest_dir = os.path.join(self.test_dir, 'non_existent_dir')
        copied_file = task_func(self.test_file, dest_dir)
        self.assertTrue(os.path.isdir(dest_dir))
        self.assertTrue(os.path.isfile(copied_file))

    def test_overwrite_existing_file(self):
        dest_dir = os.path.join(self.test_dir, 'dest')
        os.makedirs(dest_dir, exist_ok=True)
        existing_file_path = os.path.join(dest_dir, 'test.txt')
        with open(existing_file_path, 'w') as f:
            f.write('Old content')
        copied_file = task_func(self.test_file, dest_dir)
        with open(copied_file, 'r') as f:
            self.assertEqual(f.read(), 'This is a test file.')

    def test_same_source_and_destination(self):
        with self.assertRaises(OSError):
            task_func(self.test_file, self.test_dir)

    def test_invalid_source_file(self):
        with self.assertRaises(FileNotFoundError):
            task_func('/invalid/path/to/file.txt', self.test_dir)

# Cluster 6 - Representative clone cot llama3.1:latest-code 1 ['refac_1', 'refac_4', 'refac_5']
import os
import shutil


def task_func(filename, dest_dir):
    import pathlib
    from functools import partial
    path = pathlib.Path(filename)

    def create_directory(path):
        try:
            path.mkdir(parents=True, exist_ok=True)
        except OSError as e:
            if e.errno != 17:
                raise

    def copy_file(src, dest):
        shutil.copy2(src, dest)

    def clear_file_contents(path):
        with open(str(path), 'w') as f:
            pass
    create_directory(pathlib.Path(dest_dir))
    copy_file(filename, pathlib.Path(dest_dir) / path.name)
    clear_file_contents(path)
    return str(pathlib.Path(dest_dir) / path.name)

# Cluster 7 - Representative clone cot llama3.1:latest-code 1 ['refac_1', 'refac_3', 'refac_4']
import os
from pathlib import Path


def task_func(filename, dest_dir):
    src_path = Path(filename)
    dst_path = Path(dest_dir) / src_path.name
    if not dst_path.parent.exists():
        dst_path.parent.mkdir(parents=True)
    shutil.copy2(src_path, dst_path)
    with open(src_path, 'w') as f:
        pass
    return str(dst_path.resolve())

# Cluster 8 - Representative clone zero-shot deepseek-r1:14b-test 1 ['refac_3', 'refac_5', 'refac_7']
import os
import shutil


def task_func(filename: str, dest_dir: str) ->str:

    def copy_file(src: str, dst: str) ->None:
        shutil.copy2(src, dst)

    def clear_file(file_path: str) ->None:
        with open(file_path, 'w') as f:
            pass
    if not os.path.exists(dest_dir):
        os.makedirs(dest_dir)
    file_name = os.path.basename(filename)
    dest_path = os.path.join(dest_dir, file_name)
    copy_file(filename, dest_path)
    clear_file(filename)
    return dest_path

# Cluster 9 - Representative clone zero-shot llama3.1:latest-test 1 ['refac_2', 'refac_4', 'refac_6']
import os
import shutil
from pathlib import Path


def task_func(filename: str, dest_dir: str) ->str:
    if filename == dest_dir:
        raise OSError('Source and destination directories are the same')
    src_path = Path(filename)
    dest_path = Path(dest_dir) / src_path.name
    os.makedirs(dest_dir, exist_ok=True)
    shutil.copy2(filename, dest_path)
    with open(src_path, 'w') as f:
        pass
    return str(dest_path.resolve())

# Cluster 10 - Representative clone zero-shot deepseek-r1:14b-code 1 ['refac_1', 'refac_3', 'refac_4']
import os
import shutil
import errno


def task_func(filename: str, dest_dir: str) ->str:
    """Copies a file to a destination directory and clears its original content."""
    os.makedirs(dest_dir, exist_ok=True)
    dest = shutil.copy(filename, dest_dir)
    with open(filename, 'w') as f:
        pass
    return os.path.abspath(dest)

# Cluster 11 - Representative clone zero-shot llama3.1:latest-code 1 ['refac_1', 'refac_4', 'refac_5']
import os
from pathlib import Path


def task_func(filename: str, dest_dir: str) ->str:

    def create_directory(path):
        return Path(path).mkdir(parents=True, exist_ok=True)

    def copy_file(src, dst):
        with open(dst, 'w') as f:
            shutil.copyfile(src, f.name)
        return os.path.abspath(f.name)

    def clear_original_file(file_path):
        with open(file_path, 'w'):
            pass
    create_directory(dest_dir)
    copied_file = copy_file(filename, Path(dest_dir) / Path(filename).name)
    clear_original_file(filename)
    return copied_file

# Cluster 12 - Representative clone cot deepseek-r1:14b-ast 1 ['refac_1', 'refac_4', 'refac_5']
import os
from shutil import copyfile


def task_func(filename: str, dest_dir: str) ->str:
    os.makedirs(dest_dir, exist_ok=True)
    dest_path = os.path.join(dest_dir, os.path.basename(filename))
    copyfile(filename, dest_path)
    with open(filename, 'w'):
        pass
    return dest_path

# Cluster 13 - Representative clone cot llama3.1:latest-test 1 ['refac_3', 'refac_5', 'refac_7']
import os
import shutil


def task_func(filename: str, dest_dir: str) ->str:
    src_path = os.path.abspath(filename)
    if not os.path.isfile(src_path):
        raise FileNotFoundError(f'Source file not found: {filename}')
    dest_dir_abs = os.path.abspath(dest_dir)
    src_dir = os.path.dirname(src_path)
    if src_dir == dest_dir_abs:
        raise OSError('Source and destination directories are the same')
    os.makedirs(dest_dir_abs, exist_ok=True)
    dest_path = os.path.join(dest_dir_abs, os.path.basename(src_path))
    shutil.copy2(src_path, dest_path)
    with open(src_path, 'w'):
        pass
    return dest_path

# Cluster 14 - Representative clone zero-shot llama3.1:latest-test 1 ['refac_1', 'refac_4', 'refac_5']
import os
import shutil


def task_func(filename, dest_dir):
    if not os.path.exists(dest_dir):
        os.makedirs(dest_dir)
    copied_file = os.path.join(dest_dir, os.path.basename(filename))
    shutil.copy2(filename, dest_dir)
    with open(filename, 'w') as f:
        pass
    return copied_file

# Cluster 15 - Representative clone cot gemma3:latest-complete 1 ['refac_1', 'refac_4', 'refac_5']
import os
import shutil
import tempfile


def task_func(filename, dest_dir):
    os.makedirs(dest_dir, exist_ok=True)
    shutil.copy2(filename, os.path.join(dest_dir, os.path.basename(filename)))
    open(filename, 'w').truncate(0)
    return os.path.abspath(os.path.join(dest_dir, os.path.basename(filename)))

# Cluster 16 - Representative clone zero-shot llama3.1:latest-code 1 ['refac_3', 'refac_5', 'refac_7']
import os
import shutil


def task_func(filename, dest_dir):

    def create_directory(directory_path):
        try:
            os.mkdir(directory_path)
        except FileExistsError:
            pass

    def copy_file(source_path, destination_path):
        return shutil.copy2(source_path, destination_path)

    def clear_file_content(file_path):
        with open(file_path, 'w') as file:
            pass
    create_directory(dest_dir)
    copied_file = copy_file(filename, os.path.join(dest_dir, os.path.
        basename(filename)))
    clear_file_content(filename)
    return os.path.abspath(copied_file)

# Cluster 17 - Representative clone zero-shot gemma3:latest-ast 1 ['refac_2', 'refac_6', 'refac_7']
import shutil
import os
import logging
logger = logging.getLogger(__name__)


def task_func(filename, dest_dir):
    try:
        if not os.path.exists(filename):
            raise FileNotFoundError(f'File not found: {filename}')
        if not os.path.exists(dest_dir):
            os.makedirs(dest_dir)
        shutil.copy2(filename, os.path.join(dest_dir, os.path.basename(
            filename)))
        open(filename, 'w').close()
        copied_file_path = os.path.join(dest_dir, os.path.basename(filename))
        return copied_file_path
    except Exception as e:
        logger.exception('An error occurred during file copy and erasure:')
        raise

# Cluster 18 - Representative clone zero-shot gpt-oss:20b-ast 1 ['refac_1', 'refac_3', 'refac_7']
import os, shutil


def task_func(filename, dest_dir):
    if not os.path.isdir(dest_dir):
        os.makedirs(dest_dir)
    mapping = {'src': filename, 'dst': os.path.join(dest_dir, os.path.
        basename(filename))}
    for key in mapping:
        if key == 'src':
            src_path = mapping[key]
        else:
            dst_path = mapping[key]
    shutil.copy2(src_path, dst_path)
    with open(src_path, 'w') as f:
        f.write('')
    paths = [src_path, dst_path]

    def inner():
        return None
    return os.path.abspath(dst_path)

# Cluster 19 - Representative clone zero-shot deepseek-r1:14b-code 1 ['refac_2', 'refac_6', 'refac_7']
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

# Cluster 20 - Representative clone cot gpt-oss:20b-code 1 ['refac_2', 'refac_6', 'refac_7']
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

# Cluster 21 - Representative clone zero-shot gemma3:latest-code 1 ['refac_2', 'refac_5', 'refac_6']
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

# Cluster 22 - Representative clone zero-shot gpt-oss:20b-ast 1 ['refac_1', 'refac_3', 'refac_4']
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

# Cluster 23 - Representative clone zero-shot gpt-oss:20b-code 1 ['refac_1', 'refac_3', 'refac_4']
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

# Cluster 24 - Representative clone cot gpt-oss:20b-complete 1 ['refac_1', 'refac_3', 'refac_4']
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

# Cluster 25 - Representative clone zero-shot gpt-oss:20b-complete 1 ['refac_2', 'refac_5', 'refac_6']
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

# Cluster 26 - Representative clone cot gpt-oss:20b-ast 1 ['refac_1', 'refac_3', 'refac_4']
import shutil
from pathlib import Path


def task_func(filename: str, dest_dir: str):
    mapping = {Path(filename): Path(dest_dir) / Path(filename).name}
    for src, dst in mapping.items():
        dst.parent.mkdir(parents=True, exist_ok=True)
        shutil.copy2(src, dst)
        src.open('wb').close()
    return str(mapping[Path(filename)].resolve())

# Cluster 27 - Representative clone zero-shot deepseek-r1:14b-code 1 ['refac_3', 'refac_5', 'refac_7']
import os
import shutil
from pathlib import Path


def task_func(filename, dest_dir):

    def create_directory(d):
        try:
            os.makedirs(str(d), exist_ok=True)
            return True
        except OSError as e:
            if e.errno != errno.EEXIST:
                raise
            return False

    def copy_file(f, d):
        return shutil.copy(str(f), str(d))

    def clear_file(f):
        with open(str(f), 'w') as file:
            file.truncate(0)
    dest = Path(dest_dir).resolve()
    if not create_directory(dest):
        pass
    copied_path = copy_file(Path(filename).resolve(), dest)
    clear_file(Path(filename))
    return str(copied_path)

