/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:2163829
*  Stack Overflow answer #:13160437
*  And Stack Overflow answer#:12670294
*/
public Image RotateImage (Image img) {
    var bmp = new Bitmap (img);
    using (Graphics gfx = Graphics.FromImage (bmp))
    {
        gfx.Clear (Color.White);
        gfx.DrawImage (img, 0, 0, img.Width, img.Height);
    } bmp.RotateFlip (RotateFlipType.Rotate270FlipNone);
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

