/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:1015170
*  Stack Overflow answer #:10145006
*  And Stack Overflow answer#:1015229
*/
private long [] GetHistogram (Bitmap image) {
    var histogram = new long [256];
    bool imageWasCloned = false;
    if (image.PixelFormat != PixelFormat.Format24bppRgb) {
        image = image.Clone (new Rectangle (0, 0, image.Width, image.Height), PixelFormat.Format24bppRgb);
        imageWasCloned = true;
    }
    BitmapData bmd = null;
    try {
        bmd = image.LockBits (new Rectangle (0, 0, image.Width, image.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
        const int pixelSize = 3;
        int height = bmd.Height;
        int width = bmd.Width;
        int rowPadding = bmd.Stride - (width * pixelSize);
        unsafe {
            byte * pixelPtr = (byte *) bmd.Scan0;
            for (int y = 0; y < height; ++ y) {
                for (int x = 0; x < width; ++ x) {
                    histogram [(pixelPtr [0] + pixelPtr [1] + pixelPtr [2]) / 3] ++;
                    pixelPtr += pixelSize;
                }
                pixelPtr += rowPadding;
            }
        }}
    finally {
        if (bmd != null)
            image.UnlockBits (bmd);
        if (imageWasCloned)
            image.Dispose ();
    }
    return histogram;
}

public void Histogram (double [] histogram, Rectangle roi) {
    BitmapData data = Util.SetImageToProcess (image, roi);
    if (image.PixelFormat != PixelFormat.Format8bppIndexed)
        return;
    if (histogram.Length < Util.GrayLevels)
        return;
    histogram.Initialize ();
    int width = data.Width;
    int height = data.Height;
    int offset = data.Stride - width;
    unsafe {
        byte * ptr = (byte *) data.Scan0;
        for (int y = 0; y < height; ++ y) {
            for (int x = 0; x < width; ++ x, ++ ptr)
                histogram [ptr [0]] ++;
            ptr += offset;
        }
    } image.UnlockBits (data);
}

