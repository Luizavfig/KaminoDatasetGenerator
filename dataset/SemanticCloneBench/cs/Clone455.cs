/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:5012716
*  Stack Overflow answer #:5012854
*  And Stack Overflow answer#:5012787
*/
private void trvAvailableFiles_AfterCheck (object sender, TreeViewEventArgs e) {
    if (! _isCheckingInProgress) {
        _isCheckingInProgress = true;
        try {
            GetAvailableFiles ();
        }
        catch {
        }
        _isCheckingInProgress = false;
    }
}

private void trvAvailableFiles_AfterCheck (object sender, TreeViewEventArgs e) {
    EnableEvents (false);
    trvAvailableFiles.BeginUpdate ();
    var nodePath = e.Node.Tag.ToString ();
    bool isChecked = e.Node.Checked;
    e.Node.Nodes.Clear ();
    try {
        _fileTreeLogic.GetChildNodes (e.Node, true);
        e.Node.ExpandAll ();
        SetChildrenCheckState (e.Node, isChecked);
    }
    finally {
        trvAvailableFiles.EndUpdate ();
    }
    EnableEvents (true);
}

