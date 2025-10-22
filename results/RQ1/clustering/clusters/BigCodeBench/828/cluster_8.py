# Clone zero-shot deepseek-r1:14b-test 1 ['refac_3', 'refac_5', 'refac_7']
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

