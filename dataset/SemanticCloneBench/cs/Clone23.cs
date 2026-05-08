/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:19820963
*  Stack Overflow answer #:19821255
*  And Stack Overflow answer#:19821054
*/
private void newToolStripMenuItem_Click (object sender, EventArgs e) {
    if (f2 == null || f2.IsDisposed) {
        f2 = new Form2 ();
        f2.MdiParent = this;
        f2.Show ();
    } else {
        if (f2.WindowState == FormWindowState.Minimized) {
            f2.WindowState = FormWindowState.Normal;
        }
        f2.Activate ();
    }
}

private void newToolStripMenuItem_Click (object sender, EventArgs e) {
    var f2 = this.MdiChildren.OfType < Form2 > ().FirstOrDefault ();
    if (f2 != null) {
        f2.Show ();
        return;
    }
    Form2 f = new Form2 ();
    f.MdiParent = this;
    f.Show ();
}

