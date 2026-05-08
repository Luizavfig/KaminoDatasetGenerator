/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:1521157
*  Stack Overflow answer #:1521236
*  And Stack Overflow answer#:1521286
*/
protected override void OnPaint (PaintEventArgs e) {
    float x = 10.0F;
    float y = 10.0F;
    string drawString = "123";
    using (SolidBrush brush = new SolidBrush (Color.Black))
    using (Font drawFont = new Font ("Arial", 16))
    {
        foreach (char c in drawString.ToCharArray ()) {
            PointF p = new PointF (x, y);
            e.Graphics.DrawString (c.ToString (), drawFont, brush, p);
            y += drawFont.Height;
        }
    } base.OnPaint (e);
}

protected override void OnPaint (PaintEventArgs e) {
    float x = 10.0F;
    float y = 10.0F;
    Font drawFont = new Font ("Arial", 16);
    SolidBrush drawBrush = new SolidBrush (Color.Black);
    StringFormat sf = new StringFormat ();
    sf.Alignment = StringAlignment.Center;
    foreach (char c in Text.ToCharArray ()) {
        PointF p = new PointF (x, y);
        e.Graphics.DrawString (c.ToString (), drawFont, drawBrush, p, sf);
        y += drawFont.Height;
    }
}

