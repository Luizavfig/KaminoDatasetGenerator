/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:20873885
*  Stack Overflow answer #:21423145
*  And Stack Overflow answer#:21423145
*/
public static IntPtr getHWnd (string title) {
    IntPtr hWnd = FindWindow (null, title);
    BringWindowToTop (hWnd);
    SetActiveWindow (hWnd);
    SetForegroundWindow (hWnd);
    Thread.Sleep (500);
    foreach (Process process in Process.GetProcessesByName ("IExplore")) {
        if (process.MainWindowTitle.ToLower ().Contains (title.ToLower ())) {
            hWnd = process.MainWindowHandle;
            break;
        }
    }
    EnumProc proc = new EnumProc (EnumWindows);
    EnumChildWindows (hWnd, proc, ref hWnd);
    return hWnd;
}

public HTMLDocument GetHTMLDocument (IntPtr hWnd) {
    HTMLDocument document = null;
    int iMsg = 0;
    int iRes = 0;
    iMsg = RegisterWindowMessage ("WM_HTML_GETOBJECT");
    if (iMsg != 0) {
        SendMessageTimeout (hWnd, iMsg, 0, 0, SMTO_ABORTIFHUNG, 1000, out iRes);
        if (iRes != 0) {
            int hr = ObjectFromLresult (iRes, ref IID_IHTMLDocument, 0, ref document);
        }
    }
    return document;
}

