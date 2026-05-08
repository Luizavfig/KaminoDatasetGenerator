/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:1922040
*  Stack Overflow answer #:24199315
*  And Stack Overflow answer#:5654940
*/
public static Bitmap ResizeImage (Image image, int width, int height) {
    var destRect = new Rectangle (0, 0, width, height);
    var destImage = new Bitmap (width, height);
    destImage.SetResolution (image.HorizontalResolution, image.VerticalResolution);
    using (var graphics = Graphics.FromImage (destImage))
    {
        graphics.CompositingMode = CompositingMode.SourceCopy;
        graphics.CompositingQuality = CompositingQuality.HighQuality;
        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
        graphics.SmoothingMode = SmoothingMode.HighQuality;
        graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
        using (var wrapMode = new ImageAttributes ())
        {
            wrapMode.SetWrapMode (WrapMode.TileFlipXY);
            graphics.DrawImage (image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
        }} return destImage;
}

private void ResizeImage (Image img, double maxWidth, double maxHeight) {
    double resizeWidth = img.Source.Width;
    double resizeHeight = img.Source.Height;
    double aspect = resizeWidth / resizeHeight;
    if (resizeWidth > maxWidth) {
        resizeWidth = maxWidth;
        resizeHeight = resizeWidth / aspect;
    }
    if (resizeHeight > maxHeight) {
        aspect = resizeWidth / resizeHeight;
        resizeHeight = maxHeight;
        resizeWidth = resizeHeight * aspect;
    }
    img.Width = resizeWidth;
    img.Height = resizeHeight;
}

