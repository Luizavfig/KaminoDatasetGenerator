# Cluster 0 - Representative clone zero-shot deepseek-r1:14b-test 1 ['refac_1', 'refac_3', 'refac_4']
def task_func(script_name='backup.sh', log_file='/home/user/backup_log.json'):
    import os
    import subprocess
    from datetime import datetime
    if not os.path.isfile(script_name):
        raise FileNotFoundError(f"Script '{script_name}' does not exist")
    start_time = datetime.now().strftime('%Y-%m-%d %H:%M:%S')
    try:
        exit_status = subprocess.call([script_name])
        end_time = datetime.now().strftime('%Y-%m-%d %H:%M:%S')
        result = {'start_time': start_time, 'end_time': end_time,
            'exit_status': exit_status}
        with open(log_file, 'w') as f:
            import json
            json.dump(result, f)
        return result
    except Exception as e:
        raise RuntimeError(f'Script execution failed: {str(e)}')

