/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:16119349
*  Stack Overflow answer #:16120065
*  And Stack Overflow answer#:16120065
*/
void webBrowser1_DocumentCompleted (object sender, WebBrowserDocumentCompletedEventArgs e) {
    foreach (HtmlElement element in webBrowser1.Document.GetElementsByTagName ("button")) {
        if (element.GetAttribute ("ClassName") == "mybtn") {
            Point controlLoc = this.PointToScreen (webBrowser1.Location);
            controlLoc.X = controlLoc.X + element.OffsetRectangle.Left;
            controlLoc.Y = controlLoc.Y + element.OffsetRectangle.Top;
            Cursor.Position = controlLoc;
            MouseSimulator.ClickRightMouseButton ();
        }
    }
}

public static void ClickRightMouseButton () {
    INPUT mouseDownInput = new INPUT ();
    mouseDownInput.type = SendInputEventType.InputMouse;
    mouseDownInput.mkhi.mi.dwFlags = MouseEventFlags.MOUSEEVENTF_RIGHTDOWN;
    SendInput (1, ref mouseDownInput, Marshal.SizeOf (new INPUT ()));
    INPUT mouseUpInput = new INPUT ();
    mouseUpInput.type = SendInputEventType.InputMouse;
    mouseUpInput.mkhi.mi.dwFlags = MouseEventFlags.MOUSEEVENTF_RIGHTUP;
    SendInput (1, ref mouseUpInput, Marshal.SizeOf (new INPUT ()));
}

