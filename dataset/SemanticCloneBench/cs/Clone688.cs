/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:30844637
*  Stack Overflow answer #:30844823
*  And Stack Overflow answer#:30844823
*/
static void Main (string [] args) {
    string [] cDirectories = Directory.GetDirectories ("C:\\");
    List < DirectorySize > listSizes = new List < DirectorySize > ();
    for (int i = 0; i < cDirectories.Length; i ++) {
        long size = GetDirectorySize (cDirectories [i]);
        if (size != - 1) {
            listSizes.Add (new DirectorySize () {DirectoryName = cDirectories [i], DirectorySizes = size});
        }
    }
}

private static long GetDirectorySize (string folderPath) {
    try {
        DirectoryInfo di = new DirectoryInfo (folderPath);
        return di.EnumerateFiles ("*", SearchOption.AllDirectories).Sum (fi = > fi.Length);
    }
    catch {
        return - 1;
    }
}

