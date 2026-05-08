/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:14193976
*  Stack Overflow answer #:14195574
*  And Stack Overflow answer#:14195574
*/
void GetFolders (DirectoryInfo d, TreeNode node) {
    try {
        DirectoryInfo [] dInfo = d.GetDirectories ();
        if (dInfo.Length > 0) {
            TreeNode treeNode = new TreeNode ();
            foreach (DirectoryInfo driSub in dInfo) {
                treeNode = node.Nodes.Add (driSub.Name, driSub.Name, 0, 0);
                GetFiles (driSub, treeNode);
                GetFolders (driSub, treeNode);
            }
        }
    }
    catch (Exception ex) {
    }
}

void GetFiles (DirectoryInfo d, TreeNode node) {
    var files = d.GetFiles ("*.*");
    FileInfo [] subfileInfo = files.ToArray < FileInfo > ();
    if (subfileInfo.Length > 0) {
        for (int j = 0; j < subfileInfo.Length; j ++) {
            bool isHidden = ((File.GetAttributes (subfileInfo [j].FullName) & FileAttributes.Hidden) == FileAttributes.Hidden);
            if (! isHidden) {
                TreeNode treeNode = new TreeNode ();
                string path = subfileInfo [j].FullName;
                string name = subfileInfo [j].Name;
                treeNode = node.Nodes.Add (path, name);
            }
        }
    }
}

