/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:7852824
*  Stack Overflow answer #:7858932
*  And Stack Overflow answer#:29749715
*/
public bool PreFilterMessage (ref Message m) {
    if (m.Msg == 0x20a) {
        Point pos = new Point (m.LParam.ToInt32 () & 0xffff, m.LParam.ToInt32 () > > 16);
        IntPtr hWnd = WindowFromPoint (pos);
        if (hWnd != IntPtr.Zero && hWnd != m.HWnd && Control.FromHandle (hWnd) != null) {
            SendMessage (hWnd, m.Msg, m.WParam, m.LParam);
            return true;
        }
    }
    return false;
}

public bool PreFilterMessage (ref Message m) {
    if (m.Msg != 0x20a)
        return false;
    Point mouseAbsolutePosition = new Point (m.LParam.ToInt32 ());
    Point mouseRelativePosition = mCtrl.PointToClient (mouseAbsolutePosition);
    IntPtr hControlUnderMouse = WindowFromPoint (mouseAbsolutePosition);
    Control controlUnderMouse = Control.FromHandle (hControlUnderMouse);
    if (controlUnderMouse != mCtrl)
        return false;
    MouseButtons buttons = GetMouseButtons (m.WParam.ToInt32 ());
    int delta = m.WParam.ToInt32 () > > 16;
    var e = new MouseEventArgs (buttons, 0, mouseRelativePosition.X, mouseRelativePosition.Y, delta);
    mOnMouseWheel (e);
    return true;
}

