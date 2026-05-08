/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:12510811
*  Stack Overflow answer #:16997242
*  And Stack Overflow answer#:16885844
*/
private void ScaleControls (Control c, ref Graphics g, double s) {
    List < Control > hold = null;
    foreach (Control ctrl in c.Controls) {
        if (ctrl is GroupBox || ctrl is Panel) {
            hold = new List < Control > ();
            foreach (Control gctrl in ctrl.Controls) {
                hold.Add (gctrl);
            }
            ctrl.Controls.Clear ();
        }
        Point oldLoc = ctrl.Location;
        Size oldSize = ctrl.Size;
        Font oldFont = ctrl.Font;
        ctrl.Location = new Point (ctrl.Location.X * s, ctrl.Location.Y * s);
        ctrl.Size = new Size (ctrl.Size.Width * s, ctrl.Height * s);
        ctrl.Font = new Font (ctrl.Font.FontFamily, ctrl.Font.Size * 5, ctrl.Font.Style, ctrl.Font.Unit);
        using (Bitmap bmp = new Bitmap (ctrl.Size.Width, ctrl.Size.Height))
        {
            ctrl.DrawToBitmap (bmp, ctrl.ClientRectangle);
            g.DrawImage (bmp, ctrl.Location);
        } ctrl.Location = oldLoc;
        ctrl.Size = oldSize;
        ctrl.Font = oldFont;
        if (ctrl is GroupBox || ctrl is Panel) {
            foreach (Control gctrl in hold) {
                ctrl.Controls.Add (gctrl);
            }
            ScaleControls (ctrl, g, s);
        }
    }
}

public void GetPrintArea (Panel pnl, Graphics gr) {
    if (pnl.Width > 0) {
        gr.PageScale = gr.VisibleClipBounds.Width / pnl.Width;
    }
    foreach (var ctl in pnl.Controls) {
        if (ctl is Label) {
            var lbl = (Label) ctl;
            gr.DrawString (lbl.Text, lbl.Font, new SolidBrush (lbl.ForeColor), lbl.Location.X, lbl.Location.Y);
        }
        if (ctl is PictureBox) {
            var pic = (PictureBox) ctl;
            gr.DrawImageUnscaledAndClipped (pic.Image, new Rectangle (pic.Location.X, pic.Location.Y, pic.Width, pic.Height));
        }
    }
}

