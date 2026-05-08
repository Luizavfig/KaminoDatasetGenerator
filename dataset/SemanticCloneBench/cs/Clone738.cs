/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:2274668
*  Stack Overflow answer #:2304477
*  And Stack Overflow answer#:2304477
*/
public void Run () {
    System.Diagnostics.ProcessStartInfo ps = new System.Diagnostics.ProcessStartInfo ();
    ps.FileName = "netstat";
    ps.ErrorDialog = false;
    ps.Arguments = "-e 5";
    ps.CreateNoWindow = true;
    ps.UseShellExecute = false;
    ps.RedirectStandardOutput = true;
    ps.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
    using (System.Diagnostics.Process proc = new System.Diagnostics.Process ())
    {
        proc.StartInfo = ps;
        proc.EnableRaisingEvents = true;
        proc.Exited += new EventHandler (proc_Exited);
        proc.OutputDataReceived += new System.Diagnostics.DataReceivedEventHandler (proc_OutputDataReceived);
        proc.Start ();
        proc.BeginOutputReadLine ();
        proc.WaitForExit ();
    }}

public void PostCtrlC () {
    IntPtr ptr = FindWindow (null, @"C:\Windows\System32\netstat.exe");
    if (ptr != null) {
        SetForegroundWindow (ptr);
        Thread.Sleep (1000);
        WindowsInput.InputSimulator.SimulateModifiedKeyStroke (VirtualKeyCode.CONTROL, VirtualKeyCode.CANCEL);
        Thread.Sleep (1000);
    }
}

