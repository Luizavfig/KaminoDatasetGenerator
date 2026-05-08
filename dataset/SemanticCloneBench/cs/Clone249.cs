/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:2575216
*  Stack Overflow answer #:2575452
*  And Stack Overflow answer#:32261547
*/
protected override void WndProc (ref Message m) {
    if (m.Msg == 0x84) {
        Point pos = new Point (m.LParam.ToInt32 ());
        pos = this.PointToClient (pos);
        if (pos.Y < cCaption) {
            m.Result = (IntPtr) 2;
            return;
        }
        if (pos.X >= this.ClientSize.Width - cGrip && pos.Y >= this.ClientSize.Height - cGrip) {
            m.Result = (IntPtr) 17;
            return;
        }
    }
    base.WndProc (ref m);
}

protected override void WndProc (ref Message message) {
    base.WndProc (ref message);
    if (message.Msg == 0x84) {
        var cursor = this.PointToClient (Cursor.Position);
        if (TopLeft.Contains (cursor))
            message.Result = (IntPtr) HTTOPLEFT;
        else if (TopRight.Contains (cursor))
            message.Result = (IntPtr) HTTOPRIGHT;
        else if (BottomLeft.Contains (cursor))
            message.Result = (IntPtr) HTBOTTOMLEFT;
        else if (BottomRight.Contains (cursor))
            message.Result = (IntPtr) HTBOTTOMRIGHT;
        else if (Top.Contains (cursor))
            message.Result = (IntPtr) HTTOP;
        else if (Left.Contains (cursor))
            message.Result = (IntPtr) HTLEFT;
        else if (Right.Contains (cursor))
            message.Result = (IntPtr) HTRIGHT;
        else if (Bottom.Contains (cursor))
            message.Result = (IntPtr) HTBOTTOM;
    }
}

