/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:3855956
*  Stack Overflow answer #:3856090
*  And Stack Overflow answer#:24405838
*/
public static string GetFullPath (string fileName) {
    if (File.Exists (fileName))
        return Path.GetFullPath (fileName);
    var values = Environment.GetEnvironmentVariable ("PATH");
    foreach (var path in values.Split (';')) {
        var fullPath = Path.Combine (path, fileName);
        if (File.Exists (fullPath))
            return fullPath;
    }
    return null;
}

public static string GetFullPath (string exeName) {
    try {
        using (Process p = new Process ())
        {
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.FileName = "where";
            p.StartInfo.Arguments = exeName;
            p.StartInfo.RedirectStandardOutput = true;
            p.Start ();
            string output = p.StandardOutput.ReadToEnd ();
            p.WaitForExit ();
            if (p.ExitCode != 0)
                return null;
            return output.Substring (0, output.IndexOf (Environment.NewLine));
        }}
    catch (Win32Exception) {
        throw new Exception ("'where' command is not on path");
    }
}

