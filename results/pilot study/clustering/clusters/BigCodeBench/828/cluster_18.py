# Clone zero-shot gpt-oss:20b-ast 1 ['refac_1', 'refac_3', 'refac_7']
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

