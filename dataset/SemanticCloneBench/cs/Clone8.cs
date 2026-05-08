/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:2163829
*  Stack Overflow answer #:14230916
*  And Stack Overflow answer#:12670294
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

public static Bitmap RotateImage (Image image, PointF offset, float angle) {
    if (image == null)
        throw new ArgumentNullException ("image");
    Bitmap rotatedBmp = new Bitmap (image.Width, image.Height);
    rotatedBmp.SetResolution (image.HorizontalResolution, image.VerticalResolution);
    Graphics g = Graphics.FromImage (rotatedBmp);
    g.TranslateTransform (offset.X, offset.Y);
    g.RotateTransform (angle);
    g.TranslateTransform (- offset.X, - offset.Y);
    g.DrawImage (image, new PointF (0, 0));
    return rotatedBmp;
}

