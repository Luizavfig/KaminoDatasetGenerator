/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:6508118
*  Stack Overflow answer #:45405629
*  And Stack Overflow answer#:29759970
*/
protected override void WndProc (ref Message m) {
    if (m.Msg == 0x0203) {
        int start = SelectionStart;
        if (start < 1)
            start = 1;
        int left = - 1;
        int right = Text.Length;
        int pos;
        foreach (char c in delimiterList) {
            pos = Text.LastIndexOf (c, start - 1);
            if (pos > left)
                left = pos;
            pos = Text.IndexOf (c, start);
            if (pos < right && pos != - 1)
                right = pos;
        }
        SelectionStart = left + 1;
        SelectionLength = right - left - 1;
        return;
    }
    base.WndProc (ref m);
}

protected override void WndProc (ref System.Windows.Forms.Message m) {
    if (m.Msg == 0x0203) {
        int start = this.SelectionStart;
        if (start < 1)
            start = 1;
        int left = this.Text.LastIndexOf (delimiter, start - 1);
        int right = this.Text.IndexOf (delimiter, start);
        if (right == - 1)
            right = Text.Length;
        this.SelectionStart = left + 1;
        this.SelectionLength = right - left - 1;
        return;
    }
    base.WndProc (ref m);
}

