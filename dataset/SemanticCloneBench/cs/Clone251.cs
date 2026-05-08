/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:2575216
*  Stack Overflow answer #:32261547
*  And Stack Overflow answer#:25964705
*/
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

protected override void WndProc (ref Message m) {
    int x = (int) (m.LParam.ToInt64 () & 0xFFFF);
    int y = (int) ((m.LParam.ToInt64 () & 0xFFFF0000) > > 16);
    Point pt = PointToClient (new Point (x, y));
    if (m.Msg == 0x84) {
        switch (resize.getMosuePosition (pt, this)) {
            case "l" :
                m.Result = (IntPtr) 10;
                return;
            case "r" :
                m.Result = (IntPtr) 11;
                return;
            case "a" :
                m.Result = (IntPtr) 12;
                return;
            case "la" :
                m.Result = (IntPtr) 13;
                return;
            case "ra" :
                m.Result = (IntPtr) 14;
                return;
            case "u" :
                m.Result = (IntPtr) 15;
                return;
            case "lu" :
                m.Result = (IntPtr) 16;
                return;
            case "ru" :
                m.Result = (IntPtr) 17;
                return;
            case "" :
                m.Result = pt.Y < 32 ? (IntPtr) 2 : (IntPtr) 1;
                return;
        }
    }
    base.WndProc (ref m);
}

