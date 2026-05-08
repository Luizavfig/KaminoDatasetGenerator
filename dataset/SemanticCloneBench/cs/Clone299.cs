/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:1996139
*  Stack Overflow answer #:1996143
*  And Stack Overflow answer#:1996158
*/
public static string CombinePaths (params string [] paths) {
    if (paths == null) {
        return null;
    }
    string currentPath = paths [0];
    for (int i = 1; i < paths.Length; i ++) {
        currentPath = Path.Combine (currentPath, paths [i]);
    }
    return currentPath;
}

public static string CombinePaths (string path1, params string [] paths) {
    if (path1 == null) {
        throw new ArgumentNullException ("path1");
    }
    if (paths == null) {
        throw new ArgumentNullException ("paths");
    }
    return paths.Aggregate (path1, (acc, p) = > Path.Combine (acc, p));
}

