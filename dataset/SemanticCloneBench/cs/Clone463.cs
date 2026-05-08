/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:6731333
*  Stack Overflow answer #:6732338
*  And Stack Overflow answer#:6731518
*/
private void CheckLog () {
    bool found = false;
    while (! found) {
        while ((s = sr.ReadLine ()) != null) {
            if (s.Contains ("test")) {
                _found = true;
                break;
            }
        }
        if (found) {
        } else {
        }
    }
}

private void CheckLog () {
    while (! Singleton.Instance.Found) {
        Thread.Sleep (5000);
        if (! System.IO.File.Exists ("Command.bat"))
            continue;
        using (System.IO.StreamReader sr = System.IO.File.OpenText ("Command.bat"))
        {
            while ((s = sr.ReadLine ()) != null) {
                if (s.Contains ("mp4:production/CATCHUP/")) {
                    Singleton.Instance.Found = true;
                    break;
                }
            }
        } if (Singleton.Instance.Found) {
            var result = Regex.Replace (s, @"rtmpdump", string.Empty);
            s = result;
            RemoveEXELog ();
            RemoveHostFile ();
            Process p = new Process ();
            p.StartInfo.WorkingDirectory = "dump";
            p.StartInfo.FileName = "test.exe";
            p.StartInfo.Arguments = s;
            p.Start ();
            p.WaitForExit ();
            MessageBox.Show ("Operation Successful!");
            string myPath = @"dump";
            System.Diagnostics.Process prc = new System.Diagnostics.Process ();
            prc.StartInfo.FileName = myPath;
            prc.Start ();
            ClearLog ();
            LogTrue ();
        }
    }
}

