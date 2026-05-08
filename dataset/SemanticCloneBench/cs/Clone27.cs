/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:778678
*  Stack Overflow answer #:5622633
*  And Stack Overflow answer#:2498036
*/
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

