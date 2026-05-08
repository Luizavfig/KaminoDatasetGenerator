/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:2575216
*  Stack Overflow answer #:2575452
*  And Stack Overflow answer#:25964705
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

