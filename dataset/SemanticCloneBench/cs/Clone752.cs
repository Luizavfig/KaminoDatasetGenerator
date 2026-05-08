/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:16613577
*  Stack Overflow answer #:16744840
*  And Stack Overflow answer#:16794291
*/
private void DragDropTarget_DragEnter (object sender, Microsoft.Windows.DragEventArgs e) {
    var sw = sender as DataGridDragDropTarget;
    if (sw == null) {
        return;
    }
    if (GetAssignmentCondition (e)) {
        e.Effects = DragDropEffects.Link;
    } else {
        e.Effects = DragDropEffects.None;
    }
    e.Handled = true;
}

protected virtual void OnDragOver (SW.DragEventArgs args) {
    foreach (SW.DragEventHandler handler in _dragOver) {
        handler (this, args);
        if (args.Handled) {
            return;
        }
    }
    OnDragEvent (args);
}

