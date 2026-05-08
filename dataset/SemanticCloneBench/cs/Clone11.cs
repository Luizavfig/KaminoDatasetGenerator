/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:2163829
*  Stack Overflow answer #:2163854
*  And Stack Overflow answer#:12670294
*/
public static Image RotateImage (Image img, float rotationAngle) {
    Bitmap bmp = new Bitmap (img.Width, img.Height);
    Graphics gfx = Graphics.FromImage (bmp);
    gfx.TranslateTransform ((float) bmp.Width / 2, (float) bmp.Height / 2);
    gfx.RotateTransform (rotationAngle);
    gfx.TranslateTransform (- (float) bmp.Width / 2, - (float) bmp.Height / 2);
    gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;
    gfx.DrawImage (img, new Point (0, 0));
    gfx.Dispose ();
    return bmp;
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

