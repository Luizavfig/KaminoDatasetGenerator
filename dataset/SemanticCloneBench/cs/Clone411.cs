/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:9291641
*  Stack Overflow answer #:9296304
*  And Stack Overflow answer#:23249016
*/
private static bool IsAlphaBitmap (Bitmap bmp, out BitmapData bmpData) {
    var bmpBounds = new Rectangle (0, 0, bmp.Width, bmp.Height);
    bmpData = bmp.LockBits (bmpBounds, ImageLockMode.ReadOnly, bmp.PixelFormat);
    try {
        var rowDataLength = bmpData.Width * 4;
        var buffer = new byte [rowDataLength];
        for (var y = 0; y < bmpData.Height; y ++) {
            Marshal.Copy ((IntPtr) ((int) bmpData.Scan0 + bmpData.Stride * y), buffer, 0, rowDataLength);
            for (int p = 0; p < rowDataLength; p += 4) {
                if (buffer [p] > 0 && buffer [p] < 255)
                    return true;
            }
        }
    }
    finally {
        bmp.UnlockBits (bmpData);
    }
    return false;
}

public bool IsAlphaBitmap (ref System.Drawing.Imaging.BitmapData BmpData) {
    byte [] Bytes = new byte [BmpData.Height * BmpData.Stride];
    Marshal.Copy (BmpData.Scan0, Bytes, 0, Bytes.Length);
    for (p = 3; p < Bytes.Length; p += 4) {
        if (Bytes [p] != 255)
            return true;
    }
    return false;
}

