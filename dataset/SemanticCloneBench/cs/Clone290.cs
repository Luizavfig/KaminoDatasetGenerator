/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:53102
*  Stack Overflow answer #:53118
*  And Stack Overflow answer#:53122
*/
public static String Combine (String path1, String path2) {
    if (path1 == null || path2 == null)
        throw new ArgumentNullException ((path1 == null) ? "path1" : "path2");
    Contract.EndContractBlock ();
    CheckInvalidPathChars (path1);
    CheckInvalidPathChars (path2);
    return CombineNoChecks (path1, path2);
}

public static string Combine (string path1, string path2) {
    if ((path1 == null) || (path2 == null)) {
        throw new ArgumentNullException ((path1 == null) ? "path1" : "path2");
    }
    CheckInvalidPathChars (path1);
    CheckInvalidPathChars (path2);
    if (path2.Length == 0) {
        return path1;
    }
    if (path1.Length == 0) {
        return path2;
    }
    if (IsPathRooted (path2)) {
        return path2;
    }
    char ch = path1 [path1.Length - 1];
    if (((ch != DirectorySeparatorChar) && (ch != AltDirectorySeparatorChar)) && (ch != VolumeSeparatorChar)) {
        return (path1 + DirectorySeparatorChar + path2);
    }
    return (path1 + path2);
}

