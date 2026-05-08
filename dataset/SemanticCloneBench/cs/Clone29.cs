/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:778678
*  Stack Overflow answer #:778866
*  And Stack Overflow answer#:2498036
*/
protected override void OnPaint (PaintEventArgs e) {
    Rectangle rec = e.ClipRectangle;
    rec.Width = (int) (rec.Width * ((double) Value / Maximum)) - 4;
    if (ProgressBarRenderer.IsSupported)
        ProgressBarRenderer.DrawHorizontalBar (e.Graphics, e.ClipRectangle);
    rec.Height = rec.Height - 4;
    e.Graphics.FillRectangle (Brushes.Red, 2, 2, rec.Width, rec.Height);
}

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

