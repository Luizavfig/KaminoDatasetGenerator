/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:7768555
*  Stack Overflow answer #:32055608
*  And Stack Overflow answer#:7785745
*/
protected override void WndProc (ref Message m) {
    if (m.Msg == 0x1300 + 40) {
        RECT rc = (RECT) m.GetLParam (typeof (RECT));
        rc.Left -= 0;
        rc.Right += 3;
        rc.Top -= 0;
        rc.Bottom += 3;
        Marshal.StructureToPtr (rc, m.LParam, true);
    }
    base.WndProc (ref m);
}

protected override void WndProc (ref Message m) {
    base.WndProc (ref m);
    if (m.Msg == WM_PAINT) {
        using (Graphics g = Graphics.FromHwnd (m.HWnd))
        {
            if (tabControl.Parent != null) {
                g.SetClip (new Rectangle (0, 0, tabControl.Width - 2, tabControl.Height - 1), CombineMode.Exclude);
                using (SolidBrush sb = new SolidBrush (tabControl.Parent.BackColor))
                g.FillRectangle (sb, new Rectangle (0, tabControl.ItemSize.Height + 2, tabControl.Width, tabControl.Height - (tabControl.ItemSize.Height + 2)));
            }
            if (tabControl.SelectedTab != null) {
                g.ResetClip ();
                Rectangle r = tabControl.SelectedTab.Bounds;
                g.SetClip (r, CombineMode.Exclude);
                using (SolidBrush sb = new SolidBrush (tabControl.SelectedTab.BackColor))
                g.FillRectangle (sb, new Rectangle (r.Left - 3, r.Top - 1, r.Width + 4, r.Height + 3));
            }
        }}
}

