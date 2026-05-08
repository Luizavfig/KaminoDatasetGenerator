/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:1732443
*  Stack Overflow answer #:3498791
*  And Stack Overflow answer#:15369563
*/
private static void CenterWindow (IntPtr hChildWnd) {
    Rectangle recChild = new Rectangle (0, 0, 0, 0);
    bool success = GetWindowRect (hChildWnd, ref recChild);
    int width = recChild.Width - recChild.X;
    int height = recChild.Height - recChild.Y;
    Rectangle recParent = new Rectangle (0, 0, 0, 0);
    success = GetWindowRect (_owner.Handle, ref recParent);
    Point ptCenter = new Point (0, 0);
    ptCenter.X = recParent.X + ((recParent.Width - recParent.X) / 2);
    ptCenter.Y = recParent.Y + ((recParent.Height - recParent.Y) / 2);
    Point ptStart = new Point (0, 0);
    ptStart.X = (ptCenter.X - (width / 2));
    ptStart.Y = (ptCenter.Y - (height / 2));
    ptStart.X = (ptStart.X < 0) ? 0 : ptStart.X;
    ptStart.Y = (ptStart.Y < 0) ? 0 : ptStart.Y;
    int result = MoveWindow (hChildWnd, ptStart.X, ptStart.Y, width, height, false);
}

private void CenterWindow (IntPtr hChildWnd) {
    Rectangle recChild = new Rectangle (0, 0, 0, 0);
    bool success = GetWindowRect (hChildWnd, ref recChild);
    if (! success) {
        return;
    }
    int width = recChild.Width - recChild.X;
    int height = recChild.Height - recChild.Y;
    Rectangle recParent = new Rectangle (0, 0, 0, 0);
    success = GetWindowRect (owner.Handle, ref recParent);
    if (! success) {
        return;
    }
    Point ptCenter = new Point (0, 0);
    ptCenter.X = recParent.X + ((recParent.Width - recParent.X) / 2);
    ptCenter.Y = recParent.Y + ((recParent.Height - recParent.Y) / 2);
    Point ptStart = new Point (0, 0);
    ptStart.X = (ptCenter.X - (width / 2));
    ptStart.Y = (ptCenter.Y - (height / 2));
    Task.Factory.StartNew (() = > SetWindowPos (hChildWnd, (IntPtr) 0, ptStart.X, ptStart.Y, width, height, SetWindowPosFlags.SWP_ASYNCWINDOWPOS | SetWindowPosFlags.SWP_NOSIZE | SetWindowPosFlags.SWP_NOACTIVATE | SetWindowPosFlags.SWP_NOOWNERZORDER | SetWindowPosFlags.SWP_NOZORDER));
}

