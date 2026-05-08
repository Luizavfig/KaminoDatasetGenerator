/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:8670151
*  Stack Overflow answer #:8670205
*  And Stack Overflow answer#:8670202
*/
private BitmapSource BitmaptoBitmapsource (System.Drawing.Bitmap bitmap) {
    BitmapSource bms;
    IntPtr hBitmap = bitmap.GetHbitmap ();
    BitmapSizeOptions sizeOptions = BitmapSizeOptions.FromEmptyOptions ();
    try {
        bms = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap (hBitmap, IntPtr.Zero, Int32Rect.Empty, sizeOptions);
        bms.Freeze ();
    }
    finally {
        DeleteObject (hBitmap);
    }
    return bms;
}

private BitmapSource BitmaptoBitmapsource (System.Drawing.Bitmap bitmap) {
    BitmapSource bms;
    IntPtr hBitmap = bitmap.GetHbitmap ();
    BitmapSizeOptions sizeOptions = BitmapSizeOptions.FromEmptyOptions ();
    bms = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap (hBitmap, IntPtr.Zero, Int32Rect.Empty, sizeOptions);
    bms.Freeze ();
    DeleteObject (hBitmap);
    return bms;
}

