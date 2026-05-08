/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:21751747
*  Stack Overflow answer #:42178963
*  And Stack Overflow answer#:21752100
*/
public static unsafe Bitmap CreateAlphaBitmap (Bitmap srcBitmap, PixelFormat targetPixelFormat) {
    var result = new Bitmap (srcBitmap.Width, srcBitmap.Height, targetPixelFormat);
    var bmpBounds = new Rectangle (0, 0, srcBitmap.Width, srcBitmap.Height);
    var srcData = srcBitmap.LockBits (bmpBounds, ImageLockMode.ReadOnly, srcBitmap.PixelFormat);
    var destData = result.LockBits (bmpBounds, ImageLockMode.ReadOnly, targetPixelFormat);
    var srcDataPtr = (byte *) srcData.Scan0;
    var destDataPtr = (byte *) destData.Scan0;
    try {
        for (int y = 0; y <= srcData.Height - 1; y ++) {
            for (int x = 0; x <= srcData.Width - 1; x ++) {
                var position = srcData.Stride * y + 4 * x;
                var position2 = destData.Stride * y + 4 * x;
                memcpy (destDataPtr + position2, srcDataPtr + position, (UIntPtr) 4);
            }
        }
    }
    finally {
        srcBitmap.UnlockBits (srcData);
        result.UnlockBits (destData);
    }
    return result;
}

public static Bitmap CreateAlphaBitmap (Bitmap srcBitmap, PixelFormat targetPixelFormat) {
    Bitmap result = new Bitmap (srcBitmap.Width, srcBitmap.Height, targetPixelFormat);
    Rectangle bmpBounds = new Rectangle (0, 0, srcBitmap.Width, srcBitmap.Height);
    BitmapData srcData = srcBitmap.LockBits (bmpBounds, ImageLockMode.ReadOnly, srcBitmap.PixelFormat);
    bool isAlplaBitmap = false;
    try {
        for (int y = 0; y <= srcData.Height - 1; y ++) {
            for (int x = 0; x <= srcData.Width - 1; x ++) {
                Color pixelColor = Color.FromArgb (Marshal.ReadInt32 (srcData.Scan0, (srcData.Stride * y) + (4 * x)));
                if (pixelColor.A > 0 & pixelColor.A < 255) {
                    isAlplaBitmap = true;
                }
                result.SetPixel (x, y, pixelColor);
            }
        }
    }
    finally {
        srcBitmap.UnlockBits (srcData);
    }
    if (isAlplaBitmap) {
        return result;
    } else {
        return srcBitmap;
    }
}

