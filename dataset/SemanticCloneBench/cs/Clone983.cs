/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:29944757
*  Stack Overflow answer #:29945249
*  And Stack Overflow answer#:29945249
*/
public static void Main (string [] args) {
    foreach (string path in args) {
        if (File.Exists (path)) {
            ProcessFile (path);
        } else if (Directory.Exists (path)) {
            ProcessDirectory (path);
        } else {
            Console.WriteLine ("{0} is not a valid file or directory.", path);
        }
    }
}

public static void ProcessDirectory (string targetDirectory) {
    string [] fileEntries = Directory.GetFiles (targetDirectory);
    foreach (string fileName in fileEntries)
        ProcessFile (fileName);
    string [] subdirectoryEntries = Directory.GetDirectories (targetDirectory);
    foreach (string subdirectory in subdirectoryEntries)
        ProcessDirectory (subdirectory);
}

