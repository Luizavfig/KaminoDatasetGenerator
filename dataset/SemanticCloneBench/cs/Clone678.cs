/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:5497064
*  Stack Overflow answer #:14668097
*  And Stack Overflow answer#:35887993
*/
static private string ProcessExecutablePath (Process process) {
    try {
        return process.MainModule.FileName;
    }
    catch {
        string query = "SELECT ExecutablePath, ProcessID FROM Win32_Process";
        ManagementObjectSearcher searcher = new ManagementObjectSearcher (query);
        foreach (ManagementObject item in searcher.Get ()) {
            object id = item ["ProcessID"];
            object path = item ["ExecutablePath"];
            if (path != null && id.ToString () == process.Id.ToString ()) {
                return path.ToString ();
            }
        }
    }
    return "";
}

public static string GetProcessPath (int processId) {
    string MethodResult = "";
    try {
        string Query = "SELECT ExecutablePath FROM Win32_Process WHERE ProcessId = " + processId;
        using (ManagementObjectSearcher mos = new ManagementObjectSearcher (Query))
        {
            using (ManagementObjectCollection moc = mos.Get ())
            {
                string ExecutablePath = (from mo in moc.Cast < ManagementObject > ()
                    select mo ["ExecutablePath"]).First ().ToString ();
                MethodResult = ExecutablePath;
            }}}
    catch {
    }
    return MethodResult;
}

