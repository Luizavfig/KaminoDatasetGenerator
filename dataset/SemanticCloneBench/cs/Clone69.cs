/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:13876372
*  Stack Overflow answer #:14124048
*  And Stack Overflow answer#:14124048
*/
[PermissionSet (SecurityAction.Demand, Name = "FullTrust")] private void InitializeInputFileWatchers () {
    for (int i = 0; i < this.InputFiles.Count; i ++) {
        if (File.Exists (this.InputFiles [i])) {
            InputFileInfo info = new InputFileInfo ();
            info.Fullpath = ((FileModuleSettings) this.Settings).InputFiles [i];
            info.Watcher.Changed += this.OnFileChange;
            this.inputFileList.AddOrUpdate (info.Fullpath, info, (e, v) = > {
                return info;
            });
        }
    }
}

[PermissionSet (SecurityAction.Demand, Name = "FullTrust")] private void OnFileChange (object source, FileSystemEventArgs e) {
    InputFileInfo info;
    if (this.inputFileList.TryGetValue (e.FullPath, out info)) {
        DateTime lastWriteTime = System.IO.File.GetLastWriteTime (e.FullPath);
        if (info.LastHandledChange != lastWriteTime) {
            TimeSpan span = lastWriteTime.Subtract (info.LastHandledChange);
            if (span.Days == 0 && span.Hours == 0 && span.Minutes == 0 && span.Seconds == 0 && span.TotalMilliseconds < this.MinimumFileChangePeriod) {
            } else {
                info.LastHandledChange = lastWriteTime;
                this.inputFileList.AddOrUpdate (e.FullPath, info, (a, v) = > {
                    return info;
                });
                lock (this.readLockerObject)
                {
                    this.ReadFile (e.FullPath);
                }}
        }
    }
}

