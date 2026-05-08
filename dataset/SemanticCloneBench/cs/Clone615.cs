/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:4369720
*  Stack Overflow answer #:44722621
*  And Stack Overflow answer#:4369749
*/
private static bool AlreadyRunning () {
    Process [] processes = Process.GetProcesses ();
    Process currentProc = Process.GetCurrentProcess ();
    logger.LogDebug ("Current proccess: {0}", currentProc.ProcessName);
    foreach (Process process in processes) {
        if (currentProc.ProcessName == process.ProcessName && currentProc.Id != process.Id) {
            logger.LogInformation ("Another instance of this process is already running: {pid}", process.Id);
            return true;
        }
    }
    return false;
}

static void Main () {
    string mutex_id = "MY_APP";
    using (Mutex mutex = new Mutex (false, mutex_id))
    {
        if (! mutex.WaitOne (0, false)) {
            MessageBox.Show ("Instance Already Running!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            return;
        }
    }}

