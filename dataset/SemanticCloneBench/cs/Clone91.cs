/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:4747428
*  Stack Overflow answer #:4747563
*  And Stack Overflow answer#:4748383
*/
int [] getRGB (Bitmap bmp, int line) {
    var data = bmp.LockBits (new Rectangle (0, 0, bmp.Width, bmp.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
    try {
        var ptr = (IntPtr) ((long) data.Scan0 + data.Stride * (bmp.Height - line - 1));
        var ret = new int [bmp.Width];
        System.Runtime.InteropServices.Marshal.Copy (ptr, ret, 0, ret.Length * 4);
        return ret;
    }
    finally {
        bmp.UnlockBits (data);
    }
}

public static void getRGB (this Bitmap image, int startX, int startY, int w, int h, int [] rgbArray, int offset, int scansize) {
    const int PixelWidth = 3;
    const PixelFormat PixelFormat = PixelFormat.Format24bppRgb;
    if (image == null)
        throw new ArgumentNullException ("image");
    if (rgbArray == null)
        throw new ArgumentNullException ("rgbArray");
    if (startX < 0 || startX + w > image.Width)
        throw new ArgumentOutOfRangeException ("startX");
    if (startY < 0 || startY + h > image.Height)
        throw new ArgumentOutOfRangeException ("startY");
    if (w < 0 || w > scansize || w > image.Width)
        throw new ArgumentOutOfRangeException ("w");
    if (h < 0 || (rgbArray.Length < offset + h * scansize) || h > image.Height)
        throw new ArgumentOutOfRangeException ("h");
    BitmapData data = image.LockBits (new Rectangle (startX, startY, w, h), System.Drawing.Imaging.ImageLockMode.ReadOnly, PixelFormat);
    try {
        byte [] pixelData = new Byte [data.Stride];
        for (int scanline = 0; scanline < data.Height; scanline ++) {
            Marshal.Copy (data.Scan0 + (scanline * data.Stride), pixelData, 0, data.Stride);
            for (int pixeloffset = 0; pixeloffset < data.Width; pixeloffset ++) {
                rgbArray [offset + (scanline * scansize) + pixeloffset] = (pixelData [pixeloffset * PixelWidth + 2] << 16) + (pixelData [pixeloffset * PixelWidth + 1] << 8) + pixelData [pixeloffset * PixelWidth];
            }
        }
    }
    finally {
        image.UnlockBits (data);
    }
}

