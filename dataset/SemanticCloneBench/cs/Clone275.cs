/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:616898
*  Stack Overflow answer #:771760
*  And Stack Overflow answer#:777219
*/
static void Main (string [] args) {
    Process process = new Process ();
    process.StartInfo.FileName = @"C:\my test folder\my test.bat";
    StringBuilder cmdLine = new StringBuilder ();
    cmdLine.Append (process.StartInfo.FileName);
    STARTUPINFO lpStartupInfo = new STARTUPINFO ();
    PROCESS_INFORMATION lpProcessInformation = new PROCESS_INFORMATION ();
    string workingDirectory = @"C:\my test folder\";
    CreateProcess (null, cmdLine, null, null, true, 0, IntPtr.Zero, workingDirectory, lpStartupInfo, lpProcessInformation);
}

public static int Main () {
    string error;
    try {
        ProcessStartInfo i = new ProcessStartInfo ();
        i.FileName = @"C:\long file path\run.cmd";
        i.WindowStyle = ProcessWindowStyle.Hidden;
        i.UseShellExecute = true;
        i.RedirectStandardOutput = false;
        using (Process p = Process.Start (i))
        {
            error = "No process object was returned from Process.Start";
            if (p != null) {
                p.WaitForExit ();
                if (p.ExitCode == 0) {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine ("OK");
                    Console.ResetColor ();
                    return 0;
                }
                error = "Process exit code was " + p.ExitCode;
            }
        }}
    catch (Win32Exception ex) {
        error = "(Win32Exception) " + ex.Message;
    }
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine ("Whooops: " + error);
    Console.ResetColor ();
    return 1;
}

