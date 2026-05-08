/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:1649959
*  Stack Overflow answer #:4361655
*  And Stack Overflow answer#:4361655
*/
public static bool HitTest (Rectangle ctrlRect, IntPtr ctrlHandle, Point p, IntPtr ExcludeWindow) {
    enumedwindowPtrs.Clear ();
    enumedwindowRects.Clear ();
    callBackPtr = new CallBackPtr (EnumCallBack);
    EnumDesktopWindows (IntPtr.Zero, callBackPtr, 0);
    Region r = new Region (ctrlRect);
    bool StartClipping = false;
    for (int i = enumedwindowRects.Count - 1; i >= 0; i --) {
        if (StartClipping && enumedwindowPtrs [i] != ExcludeWindow) {
            r.Exclude (enumedwindowRects [i]);
        }
        if (enumedwindowPtrs [i] == ctrlHandle)
            StartClipping = true;
    }
    return r.IsVisible (p);
}

private static bool EnumCallBack (int hwnd, int lParam) {
    if (IsWindow ((IntPtr) hwnd) && IsWindowVisible ((IntPtr) hwnd) && ! IsIconic ((IntPtr) hwnd)) {
        enumedwindowPtrs.Add ((IntPtr) hwnd);
        RECT rct;
        if (GetWindowRect ((IntPtr) hwnd, out rct)) {
            enumedwindowRects.Add (new Rectangle (rct.Left, rct.Top, rct.Right - rct.Left, rct.Bottom - rct.Top));
        } else {
            enumedwindowRects.Add (new Rectangle (0, 0, 0, 0));
        }
    }
    return true;
}

