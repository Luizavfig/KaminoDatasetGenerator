/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:778678
*  Stack Overflow answer #:7490884
*  And Stack Overflow answer#:5622633
*/
protected override void OnPaint (PaintEventArgs e) {
    const int inset = 2;
    using (Image offscreenImage = new Bitmap (this.Width, this.Height))
    {
        using (Graphics offscreen = Graphics.FromImage (offscreenImage))
        {
            Rectangle rect = new Rectangle (0, 0, this.Width, this.Height);
            if (ProgressBarRenderer.IsSupported)
                ProgressBarRenderer.DrawHorizontalBar (offscreen, rect);
            rect.Inflate (new Size (- inset, - inset));
            rect.Width = (int) (rect.Width * ((double) this.Value / this.Maximum));
            if (rect.Width == 0)
                rect.Width = 1;
            LinearGradientBrush brush = new LinearGradientBrush (rect, this.BackColor, this.ForeColor, LinearGradientMode.Vertical);
            offscreen.FillRectangle (brush, inset, inset, rect.Width, rect.Height);
            e.Graphics.DrawImage (offscreenImage, 0, 0);
            offscreenImage.Dispose ();
        }}}

protected override void OnPaint (PaintEventArgs e) {
    LinearGradientBrush brush = null;
    Rectangle rec = new Rectangle (0, 0, this.Width, this.Height);
    double scaleFactor = (((double) Value - (double) Minimum) / ((double) Maximum - (double) Minimum));
    if (ProgressBarRenderer.IsSupported)
        ProgressBarRenderer.DrawHorizontalBar (e.Graphics, rec);
    rec.Width = (int) ((rec.Width * scaleFactor) - 4);
    rec.Height -= 4;
    brush = new LinearGradientBrush (rec, this.ForeColor, this.BackColor, LinearGradientMode.Vertical);
    e.Graphics.FillRectangle (brush, 2, 2, rec.Width, rec.Height);
}

