/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:6484567
*  Stack Overflow answer #:6484591
*  And Stack Overflow answer#:6485074
*/
static void Main (string [] args) {
    Console.WriteLine ("Start notepad and hit any key...");
    Console.ReadKey (true);
    Process [] processes = Process.GetProcessesByName ("notepad");
    foreach (Process p in processes) {
        var handle = p.MainWindowHandle;
        SetWindowPos (handle, new IntPtr (SpecialWindowHandles.HWND_TOP), 10, 10, 450, 450, SetWindowPosFlags.SWP_SHOWWINDOW);
        break;
    }
}

static void Main (string [] args) {
    Process [] processes = Process.GetProcessesByName ("notepad");
    foreach (Process p in processes) {
        IntPtr handle = p.MainWindowHandle;
        RECT Rect = new RECT ();
        if (GetWindowRect (handle, ref Rect))
            MoveWindow (handle, Rect.left, Rect.right, Rect.right - Rect.left, Rect.bottom - Rect.top + 50, true);
    }
}

