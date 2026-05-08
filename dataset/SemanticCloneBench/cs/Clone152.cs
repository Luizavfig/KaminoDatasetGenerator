/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:17748446
*  Stack Overflow answer #:17753710
*  And Stack Overflow answer#:24625951
*/
protected override void WndProc (ref Message m) {
    const UInt32 WM_NCHITTEST = 0x0084;
    const UInt32 WM_MOUSEMOVE = 0x0200;
    const UInt32 HTBOTTOMRIGHT = 17;
    const int RESIZE_HANDLE_SIZE = 10;
    bool handled = false;
    if (m.Msg == WM_NCHITTEST || m.Msg == WM_MOUSEMOVE) {
        Size formSize = this.Size;
        Point screenPoint = new Point (m.LParam.ToInt32 ());
        Point clientPoint = this.PointToClient (screenPoint);
        Rectangle hitBox = new Rectangle (formSize.Width - RESIZE_HANDLE_SIZE, formSize.Height - RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE);
        if (hitBox.Contains (clientPoint)) {
            m.Result = (IntPtr) HTBOTTOMRIGHT;
            handled = true;
        }
    }
    if (! handled)
        base.WndProc (ref m);
}

protected override void WndProc (ref Message m) {
    const UInt32 WM_NCHITTEST = 0x0084;
    const UInt32 WM_MOUSEMOVE = 0x0200;
    const UInt32 HTLEFT = 10;
    const UInt32 HTRIGHT = 11;
    const UInt32 HTBOTTOMRIGHT = 17;
    const UInt32 HTBOTTOM = 15;
    const UInt32 HTBOTTOMLEFT = 16;
    const UInt32 HTTOP = 12;
    const UInt32 HTTOPLEFT = 13;
    const UInt32 HTTOPRIGHT = 14;
    const int RESIZE_HANDLE_SIZE = 10;
    bool handled = false;
    if (m.Msg == WM_NCHITTEST || m.Msg == WM_MOUSEMOVE) {
        Size formSize = this.Size;
        Point screenPoint = new Point (m.LParam.ToInt32 ());
        Point clientPoint = this.PointToClient (screenPoint);
        Dictionary < UInt32, Rectangle > boxes = new Dictionary < UInt32, Rectangle > () {{HTBOTTOMLEFT, new Rectangle (0, formSize.Height - RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE)}, {HTBOTTOM, new Rectangle (RESIZE_HANDLE_SIZE, formSize.Height - RESIZE_HANDLE_SIZE, formSize.Width - 2 * RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE)}, {HTBOTTOMRIGHT, new Rectangle (formSize.Width - RESIZE_HANDLE_SIZE, formSize.Height - RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE)}, {HTRIGHT, new Rectangle (formSize.Width - RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE, formSize.Height - 2 * RESIZE_HANDLE_SIZE)}, {HTTOPRIGHT, new Rectangle (formSize.Width - RESIZE_HANDLE_SIZE, 0, RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE)}, {HTTOP, new Rectangle (RESIZE_HANDLE_SIZE, 0, formSize.Width - 2 * RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE)}, {HTTOPLEFT, new Rectangle (0, 0, RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE)}, {HTLEFT, new Rectangle (0, RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE, formSize.Height - 2 * RESIZE_HANDLE_SIZE)}};
        foreach (KeyValuePair < UInt32, Rectangle > hitBox in boxes) {
            if (this.WindowState != FormWindowState.Maximized && hitBox.Value.Contains (clientPoint)) {
                m.Result = (IntPtr) hitBox.Key;
                handled = true;
                break;
            }
        }
    }
    if (! handled)
        base.WndProc (ref m);
}

