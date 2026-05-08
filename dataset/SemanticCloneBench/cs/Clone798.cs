/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:2929255
*  Stack Overflow answer #:2929681
*  And Stack Overflow answer#:2929681
*/
[STAThread] static void Main (string [] args) {
    Process [] p = Process.GetProcessesByName (Path.GetFileNameWithoutExtension (OnScreenKeyboardExe));
    if (p.Length == 0) {
        if (Thread.CurrentThread.GetApartmentState () == ApartmentState.STA) {
            ThreadStart start = new ThreadStart (StartOsk);
            Thread thread = new Thread (start);
            thread.SetApartmentState (ApartmentState.MTA);
            thread.Start ();
            thread.Join ();
        } else {
            StartOsk ();
        }
    } else {
        SendMessage (p [0].MainWindowHandle, WM_SYSCOMMAND, new IntPtr (SC_RESTORE), new IntPtr (0));
    }
}

static void StartOsk () {
    IntPtr ptr = new IntPtr ();
    bool sucessfullyDisabledWow64Redirect = false;
    if (System.Environment.Is64BitOperatingSystem) {
        sucessfullyDisabledWow64Redirect = Wow64DisableWow64FsRedirection (ref ptr);
    }
    ProcessStartInfo psi = new ProcessStartInfo ();
    psi.FileName = OnScreenKeyboardExe;
    psi.UseShellExecute = true;
    Process.Start (psi);
    if (System.Environment.Is64BitOperatingSystem)
        if (sucessfullyDisabledWow64Redirect)
            Wow64RevertWow64FsRedirection (ptr);
}

