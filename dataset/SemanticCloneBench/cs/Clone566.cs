/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:1922040
*  Stack Overflow answer #:8646204
*  And Stack Overflow answer#:24199315
*/
public Image ResizeImage (Image source, RectangleF destinationBounds) {
    RectangleF sourceBounds = new RectangleF (0.0f, 0.0f, (float) source.Width, (float) source.Height);
    RectangleF scaleBounds = new RectangleF ();
    Image destinationImage = new Bitmap ((int) destinationBounds.Width, (int) destinationBounds.Height);
    Graphics graph = Graphics.FromImage (destinationImage);
    graph.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
    graph.FillRectangle (new SolidBrush (System.Drawing.Color.White), destinationBounds);
    float resizeRatio, sourceRatio;
    float scaleWidth, scaleHeight;
    sourceRatio = (float) source.Width / (float) source.Height;
    if (sourceRatio >= 1.0f) {
        resizeRatio = destinationBounds.Width / sourceBounds.Width;
        scaleWidth = destinationBounds.Width;
        scaleHeight = sourceBounds.Height * resizeRatio;
        float trimValue = destinationBounds.Height - scaleHeight;
        graph.DrawImage (source, 0, (trimValue / 2), destinationBounds.Width, scaleHeight);
    } else {
        resizeRatio = destinationBounds.Height / sourceBounds.Height;
        scaleWidth = sourceBounds.Width * resizeRatio;
        scaleHeight = destinationBounds.Height;
        float trimValue = destinationBounds.Width - scaleWidth;
        graph.DrawImage (source, (trimValue / 2), 0, scaleWidth, destinationBounds.Height);
    }
    return destinationImage;
}

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

