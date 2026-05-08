/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:929276
*  Stack Overflow answer #:929418
*  And Stack Overflow answer#:31882866
*/
static IEnumerable < string > GetFiles (string path) {
    Queue < string > queue = new Queue < string > ();
    queue.Enqueue (path);
    while (queue.Count > 0) {
        path = queue.Dequeue ();
        try {
            foreach (string subDir in Directory.GetDirectories (path)) {
                queue.Enqueue (subDir);
            }
        }
        catch (Exception ex) {
            Console.Error.WriteLine (ex);
        }
        string [] files = null;
        try {
            files = Directory.GetFiles (path);
        }
        catch (Exception ex) {
            Console.Error.WriteLine (ex);
        }
        if (files != null) {
            for (int i = 0; i < files.Length; i ++) {
                yield return files [i];
            }
        }
    }
}

internal static void EnumerateFiles (string sFullPath, List < FileInfo > fileInfoList) {
    try {
        DirectoryInfo di = new DirectoryInfo (sFullPath);
        FileInfo [] files = di.GetFiles ();
        foreach (FileInfo file in files)
            fileInfoList.Add (file);
        DirectoryInfo [] dirs = di.GetDirectories ();
        if (dirs == null || dirs.Length < 1)
            return;
        foreach (DirectoryInfo dir in dirs)
            EnumerateFiles (dir.FullName, fileInfoList);
    }
    catch (Exception ex) {
        Logger.Write ("Exception in Helper.EnumerateFiles", ex);
    }
}

