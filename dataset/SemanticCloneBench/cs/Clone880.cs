/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:1377246
*  Stack Overflow answer #:1377884
*  And Stack Overflow answer#:3582050
*/
protected override void WndProc (ref Message m) {
    switch (m.Msg) {
        case 0x46 :
            this.HandleWindowPosChanging (ref m);
            base.WndProc (ref m);
            break;
        default :
            base.WndProc (ref m);
            break;
    }
}

private void ResizeColumns (int controlWidth, bool ifShrinking) {
    if (Columns.Count < 1 || Parent == null)
        return;
    int borderGap = Width - ClientSize.Width;
    int desiredWidth = controlWidth - borderGap;
    if ((desiredWidth < Columns [0].Width) == ifShrinking)
        Columns [0].Width = desiredWidth;
}

