/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:7852824
*  Stack Overflow answer #:29749715
*  And Stack Overflow answer#:13754686
*/
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

public bool PreFilterMessage (ref Message m) {
    var parent = _ctrl.Parent;
    if (parent != null && m.Msg == 0x20a) {
        var pos = new Point (m.LParam.ToInt32 () & 0xffff, m.LParam.ToInt32 () > > 16);
        var clientPos = _ctrl.PointToClient (pos);
        if (_ctrl.ClientRectangle.Contains (clientPos) && ReferenceEquals (_ctrl, parent.GetChildAtPoint (parent.PointToClient (pos)))) {
            var wParam = m.WParam.ToInt32 ();
            Func < int, MouseButtons, MouseButtons > getButton = (flag, button) = > ((wParam & flag) == flag) ? button : MouseButtons.None;
            var buttons = getButton (wParam & 0x0001, MouseButtons.Left) | getButton (wParam & 0x0010, MouseButtons.Middle) | getButton (wParam & 0x0002, MouseButtons.Right) | getButton (wParam & 0x0020, MouseButtons.XButton1) | getButton (wParam & 0x0040, MouseButtons.XButton2);
            var delta = wParam > > 16;
            var e = new MouseEventArgs (buttons, 0, clientPos.X, clientPos.Y, delta);
            _onMouseWheel (e);
            return true;
        }
    }
    return false;
}

