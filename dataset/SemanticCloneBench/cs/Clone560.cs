/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:2811509
*  Stack Overflow answer #:9706464
*  And Stack Overflow answer#:2811746
*/
public static void DeleteEmptyDirs (this DirectoryInfo dir) {
    foreach (DirectoryInfo d in dir.GetDirectories ())
        d.DeleteEmptyDirs ();
    try {
        dir.Delete ();
    }
    catch (IOException) {
    }
    catch (UnauthorizedAccessException) {
    }
}

static void DeleteEmptyDirs (string dir) {
    if (String.IsNullOrEmpty (dir))
        throw new ArgumentException ("Starting directory is a null reference or an empty string", "dir");
    try {
        foreach (var d in Directory.EnumerateDirectories (dir)) {
            DeleteEmptyDirs (d);
        }
        var entries = Directory.EnumerateFileSystemEntries (dir);
        if (! entries.Any ()) {
            try {
                Directory.Delete (dir);
            }
            catch (UnauthorizedAccessException) {
            }
            catch (DirectoryNotFoundException) {
            }
        }
    }
    catch (UnauthorizedAccessException) {
    }
}

