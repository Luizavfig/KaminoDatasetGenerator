/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:2319983
*  Stack Overflow answer #:2320124
*  And Stack Overflow answer#:2324414
*/
private Image RezizeImage (Image img, int maxWidth, int maxHeight) {
    if (img.Height < maxHeight && img.Width < maxWidth)
        return img;
    using (img)
    {
        Double xRatio = (double) img.Width / maxWidth;
        Double yRatio = (double) img.Height / maxHeight;
        Double ratio = Math.Max (xRatio, yRatio);
        int nnx = (int) Math.Floor (img.Width / ratio);
        int nny = (int) Math.Floor (img.Height / ratio);
        Bitmap cpy = new Bitmap (nnx, nny, PixelFormat.Format32bppArgb);
        using (Graphics gr = Graphics.FromImage (cpy))
        {
            gr.Clear (Color.Transparent);
            gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
            gr.DrawImage (img, new Rectangle (0, 0, nnx, nny), new Rectangle (0, 0, img.Width, img.Height), GraphicsUnit.Pixel);
        } return cpy;
    }}

public static Image Resize (Image image, int width, int height, RotateFlipType rotateFlipType) {
    var rotatedImage = image.Clone () as Image;
    rotatedImage.RotateFlip (rotateFlipType);
    var newSize = CalculateResizedDimensions (rotatedImage, width, height);
    var resizedImage = new Bitmap (newSize.Width, newSize.Height, PixelFormat.Format32bppArgb);
    resizedImage.SetResolution (72, 72);
    using (var graphics = Graphics.FromImage (resizedImage))
    {
        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
        graphics.SmoothingMode = SmoothingMode.AntiAlias;
        graphics.CompositingQuality = CompositingQuality.HighQuality;
        graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
        using (var attribute = new ImageAttributes ())
        {
            attribute.SetWrapMode (WrapMode.TileFlipXY);
            graphics.DrawImage (rotatedImage, new Rectangle (new Point (0, 0), newSize), 0, 0, rotatedImage.Width, rotatedImage.Height, GraphicsUnit.Pixel, attribute);
        }} return resizedImage;
}

