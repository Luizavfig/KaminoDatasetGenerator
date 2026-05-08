/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:778678
*  Stack Overflow answer #:2498036
*  And Stack Overflow answer#:7490884
*/
protected override void OnPaint (PaintEventArgs e) {
    if (brush == null || brush.Color != this.ForeColor)
        brush = new SolidBrush (this.ForeColor);
    Rectangle rec = new Rectangle (0, 0, this.Width, this.Height);
    if (ProgressBarRenderer.IsSupported)
        ProgressBarRenderer.DrawHorizontalBar (e.Graphics, rec);
    rec.Width = (int) (rec.Width * ((double) Value / Maximum)) - 4;
    rec.Height = rec.Height - 4;
    e.Graphics.FillRectangle (brush, 2, 2, rec.Width, rec.Height);
}

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

