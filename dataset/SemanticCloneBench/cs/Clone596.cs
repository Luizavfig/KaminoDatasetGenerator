/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:10954192
*  Stack Overflow answer #:10956388
*  And Stack Overflow answer#:10956388
*/
private static Bitmap CreateCrappyHandBitmap () {
    Bitmap bitmap = new Bitmap (100, 300, PixelFormat.Format32bppArgb);
    using (Graphics graphics = Graphics.FromImage (bitmap))
    {
        graphics.Clear (Color.Transparent);
        graphics.FillRectangle (Brushes.LightGray, 50 - 5, 0, 10, 300);
        graphics.FillPolygon (Brushes.LightSlateGray, new Point [] {new Point (50 - 30, 40), new Point (50 + 30, 40), new Point (50 + 20, 80), new Point (50 - 20, 80)});
        graphics.FillEllipse (Brushes.LightSlateGray, 0, 200, 100, 100);
    } return bitmap;
}

protected override void OnPaint (PaintEventArgs e) {
    e.Graphics.Clear (Color.AliceBlue);
    e.Graphics.DrawString (Text, Font, Brushes.Black, new RectangleF (0, 0, ClientSize.Width, ClientSize.Height), new StringFormat {Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center});
    e.Graphics.TranslateTransform (ClientSize.Width / 2, ClientSize.Height + 40);
    e.Graphics.RotateTransform (angle);
    e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
    e.Graphics.DrawImage (hand, 0 - hand.Width / 2, 0 - hand.Height + 50);
    e.Graphics.ResetTransform ();
    base.OnPaint (e);
}

