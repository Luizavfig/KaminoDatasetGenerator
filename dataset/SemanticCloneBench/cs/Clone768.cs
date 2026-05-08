/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:1078003
*  Stack Overflow answer #:9806736
*  And Stack Overflow answer#:24563008
*/
private static string NextUniqueFilename (string fileName, Func < string, bool > inUse) {
    if (! inUse (fileName)) {
        return fileName;
    }
    var name = Path.GetFileNameWithoutExtension (fileName);
    var extension = Path.GetExtension (fileName);
    if (name == null) {
        throw new Exception ("File name without extension returned null.");
    }
    const int max = 9999;
    for (var i = 1; i < max; i ++) {
        var nextUniqueFilename = string.Format ("{0} ({1}){2}", name, i, extension);
        if (! inUse (nextUniqueFilename)) {
            return nextUniqueFilename;
        }
    }
    throw new Exception (string.Format ("Too many files by this name. Limit: {0}", max));
}

private string getNextFileName (string fileName) {
    string extension = Path.GetExtension (fileName);
    int i = 0;
    while (File.Exists (fileName)) {
        if (i == 0)
            fileName = fileName.Replace (extension, "(" + ++ i + ")" + extension);
        else
            fileName = fileName.Replace ("(" + i + ")" + extension, "(" + ++ i + ")" + extension);
    }
    return fileName;
}

