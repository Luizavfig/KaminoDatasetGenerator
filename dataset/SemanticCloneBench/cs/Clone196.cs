/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:621577
*  Stack Overflow answer #:26327002
*  And Stack Overflow answer#:29919287
*/
protected override void WndProc (ref Message m) {
    base.WndProc (ref m);
    if (m.Msg == WM_CLIPBOARDUPDATE) {
        IDataObject iData = Clipboard.GetDataObject ();
        if (iData.GetDataPresent (DataFormats.Text)) {
            string text = (string) iData.GetData (DataFormats.Text);
        } else if (iData.GetDataPresent (DataFormats.Bitmap)) {
            Bitmap image = (Bitmap) iData.GetData (DataFormats.Bitmap);
        }
    }
}

protected override void WndProc (ref Message m) {
    switch (m.Msg) {
        case WM_DRAWCLIPBOARD :
            ClipChanged ();
            SendMessage (nextClipboardViewer, m.Msg, m.WParam, m.LParam);
            break;
        case WM_CHANGECBCHAIN :
            if (m.WParam == nextClipboardViewer)
                nextClipboardViewer = m.LParam;
            else
                SendMessage (nextClipboardViewer, m.Msg, m.WParam, m.LParam);
            break;
        default :
            base.WndProc (ref m);
            break;
    }
}

