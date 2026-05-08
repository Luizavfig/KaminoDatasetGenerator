/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:3751715
*  Stack Overflow answer #:30380876
*  And Stack Overflow answer#:3751751
*/
public Bitmap BitmapFromSource (System.Windows.Media.Imaging.BitmapSource bitmapsource) {
    var src = new System.Windows.Media.Imaging.FormatConvertedBitmap ();
    src.BeginInit ();
    src.Source = bitmapsource;
    src.DestinationFormat = System.Windows.Media.PixelFormats.Bgra32;
    src.EndInit ();
    Bitmap bitmap = new Bitmap (src.PixelWidth, src.PixelHeight, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
    var data = bitmap.LockBits (new Rectangle (Point.Empty, bitmap.Size), System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
    src.CopyPixels (System.Windows.Int32Rect.Empty, data.Scan0, data.Height * data.Stride, data.Stride);
    bitmap.UnlockBits (data);
    return bitmap;
}

private System.Drawing.Bitmap BitmapFromSource (BitmapSource bitmapsource) {
    System.Drawing.Bitmap bitmap;
    using (MemoryStream outStream = new MemoryStream ())
    {
        BitmapEncoder enc = new BmpBitmapEncoder ();
        enc.Frames.Add (BitmapFrame.Create (bitmapsource));
        enc.Save (outStream);
        bitmap = new System.Drawing.Bitmap (outStream);
    } return bitmap;
}

