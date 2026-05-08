/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:1777668
*  Stack Overflow answer #:1778436
*  And Stack Overflow answer#:1777704
*/
[STAThread] static void Main () {
    bool createdNew = true;
    using (Mutex mutex = new Mutex (true, "MyMutexName", out createdNew))
    {
        if (createdNew) {
            Application.EnableVisualStyles ();
            Application.SetCompatibleTextRenderingDefault (false);
            Application.Run (new MainForm ());
        } else {
            Process currentProcess = Process.GetCurrentProcess ();
            foreach (Process process in Process.GetProcessesByName (currentProcess.ProcessName)) {
                if (process.Id != currentProcess.Id) {
                    IntPtr handle = process.MainWindowHandle;
                    if (handle != IntPtr.Zero)
                        SetForegroundWindow (handle);
                    else
                        PostMessage ((IntPtr) HWND_BROADCAST, WM_ACTIVATEAPP, IntPtr.Zero, IntPtr.Zero);
                    break;
                }
            }
        }
    }}

[STAThread] static void Main () {
    if (_single.WaitOne (TimeSpan.Zero, true)) {
        Application.EnableVisualStyles ();
        Application.SetCompatibleTextRenderingDefault (false);
        try {
            Application.Run (new MainForm ());
        }
        catch (Exception ex) {
        }
        finally {
            _single.ReleaseMutex ();
        }
    } else {
        PostMessage ((IntPtr) HWND_BROADCAST, WM_MY_MSG, new IntPtr (0xCDCD), new IntPtr (0xEFEF));
    }
}

