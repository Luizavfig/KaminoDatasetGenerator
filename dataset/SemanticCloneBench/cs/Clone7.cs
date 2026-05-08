/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:2163829
*  Stack Overflow answer #:14230916
*  And Stack Overflow answer#:13160437
*/
public Bitmap RotateImage (double angle) {
    SizeF size = CalculateSize (radAngle);
    Bitmap rotatedBmp = new Bitmap ((int) size.Width, (int) size.Height);
    Graphics g = Graphics.FromImage (rotatedBmp);
    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
    g.CompositingQuality = CompositingQuality.HighQuality;
    g.SmoothingMode = SmoothingMode.HighQuality;
    g.PixelOffsetMode = PixelOffsetMode.HighQuality;
    g.TranslateTransform (topPoint.X, topPoint.Y);
    g.RotateTransform (GetDegree (radAngle));
    g.DrawImage (image, new RectangleF (0, 0, size.Width, size.Height));
    g.Dispose ();
    return rotatedBmp;
}

public Image RotateImage (Image img) {
    var bmp = new Bitmap (img);
    using (Graphics gfx = Graphics.FromImage (bmp))
    {
        gfx.Clear (Color.White);
        gfx.DrawImage (img, 0, 0, img.Width, img.Height);
    } bmp.RotateFlip (RotateFlipType.Rotate270FlipNone);
    return bmp;
}

