/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:724148
*  Stack Overflow answer #:724184
*  And Stack Overflow answer#:727763
*/
static List < Info > RecursiveScan2 (string directory) {
    IntPtr INVALID_HANDLE_VALUE = new IntPtr (- 1);
    WIN32_FIND_DATAW findData;
    IntPtr findHandle = INVALID_HANDLE_VALUE;
    var info = new List < Info > ();
    try {
        findHandle = FindFirstFileW (directory + @"\*", out findData);
        if (findHandle != INVALID_HANDLE_VALUE) {
            do
                {
                    if (findData.cFileName == "." || findData.cFileName == "..")
                        continue;
                    string fullpath = directory + (directory.EndsWith ("\\") ? "" : "\\") + findData.cFileName;
                    bool isDir = false;
                    if ((findData.dwFileAttributes & FileAttributes.Directory) != 0) {
                        isDir = true;
                        info.AddRange (RecursiveScan2 (fullpath));
                    }
                    info.Add (new Info () {CreatedDate = findData.ftCreationTime.ToDateTime (), ModifiedDate = findData.ftLastWriteTime.ToDateTime (), IsDirectory = isDir, Path = fullpath});
                } while (FindNextFile (findHandle, out findData));
        }
    }
    finally {
        if (findHandle != INVALID_HANDLE_VALUE)
            FindClose (findHandle);
    }
    return info;
}

public void RecurseTest (DirectoryInfo dirInfo, StringBuilder sb, int depth) {
    _dirCounter ++;
    if (depth > _maxDepth)
        _maxDepth = depth;
    var array = dirInfo.GetFileSystemInfos ();
    foreach (var item in array) {
        sb.Append (item.FullName);
        if (item is DirectoryInfo) {
            sb.Append (" (D)");
            sb.AppendLine ();
            RecurseTest (item as DirectoryInfo, sb, depth + 1);
        } else {
            _fileCounter ++;
        }
        sb.AppendLine ();
    }
}

