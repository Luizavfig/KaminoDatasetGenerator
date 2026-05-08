/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:45069963
*  Stack Overflow answer #:45070015
*  And Stack Overflow answer#:45070015
*/
static void Main (string [] args) {
    unpack ();
    Process process = new Process ();
    process.StartInfo.FileName = "exe1.exe";
    process.Start ();
    process.WaitForExit ();
    process = new Process ();
    process.StartInfo.FileName = "exe2.exe";
    process.Start ();
    process.WaitForExit ();
    process = new Process ();
    process.StartInfo.FileName = @"C:\Windows\SysWOW64\WindowsPowerShell\v1.0\powershell.exe";
    process.StartInfo.Arguments = "ps1.ps1";
    process.Start ();
    process.WaitForExit ();
}

static void unpack () {
    if (! File.Exists ("exe1.exe"))
        File.WriteAllBytes ("exe1.exe", myNs.Properties.Resources.exe1);
    if (! File.Exists ("exe2.exe"))
        File.WriteAllBytes ("exe2.exe", myNs.Properties.Resources.exe2);
    if (! File.Exists ("ps1.ps"))
        if (! File.Exists ("ps1.ps"))
            File.WriteAllBytes ("ps1.ps", myNs.Properties.Resources.ps1);
}

