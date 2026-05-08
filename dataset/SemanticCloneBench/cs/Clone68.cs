/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:1764809
*  Stack Overflow answer #:39489908
*  And Stack Overflow answer#:37726722
*/
private void OnChanged (object source, FileSystemEventArgs e) {
    string fullFilePath = e.FullPath.ToString ();
    string fullURL = buildTheUrlFromStudyXML (fullFilePath);
    System.Diagnostics.Process.Start ("iexplore", fullURL);
    Timer timer = new Timer ();
    ((FileSystemWatcher) source).Changed -= new FileSystemEventHandler (OnChanged);
    timer.Interval = 1000;
    timer.Elapsed += new ElapsedEventHandler (t_Elapsed);
    timer.Start ();
}

void OnChanged (object sender, FileSystemEventArgs e) {
    if (let == false) {
        string mgs = string.Format ("File {0} | {1}", e.FullPath, e.ChangeType);
        Console.WriteLine ("onchange: " + mgs);
        let = true;
    } else {
        let = false;
    }
}

