/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:26375294
*  Stack Overflow answer #:26376321
*  And Stack Overflow answer#:26382248
*/
protected override void WndProc (ref Message m) {
    switch (m.Msg) {
        case 0xf :
            {
                g = Graphics.FromHwnd (this.Handle);
                Rectangle r = GetWndRect (this.Handle);
                g.DrawRectangle (p, r);
                Trace.WriteLine ("WM_PAINT: " + r.ToString ());
            } break;
    }
    Trace.WriteLine ("handled");
    base.WndProc (ref m);
}

protected override void WndProc (ref Message m) {
    base.WndProc (ref m);
    switch (m.Msg) {
        case 0x85 : case 0xf :
            {
                g = Graphics.FromHwnd (this.Handle);
                Rectangle r = GetWndRect (this.Handle);
                g.DrawRectangle (p, r);
                Trace.WriteLine ("WM_PAINT: " + r.ToString ());
            } break;
        case 0x05 :
            {
                InvalidateRect (this.Handle, IntPtr.Zero, true);
                Trace.WriteLine ("WM_SIZE");
            } break;
        default :
            Trace.WriteLine ("0x" + m.Msg.ToString ("X"));
            break;
    }
}

