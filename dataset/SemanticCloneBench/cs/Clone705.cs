/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:2284353
*  Stack Overflow answer #:26993357
*  And Stack Overflow answer#:21931808
*/
private void SetBitmapResourcesTransparent () {
    Image img;
    BitmapSource bmpSource;
    System.Drawing.Bitmap bmp;
    foreach (ResourceDictionary resdict in Application.Current.Resources.MergedDictionaries) {
        foreach (DictionaryEntry dictEntry in resdict) {
            if ((img = dictEntry.Value as Image) is Image && (bmpSource = img.Source as BitmapSource) is BitmapSource && (bmp = BitmapFromSource (bmpSource)) != null) {
                bmp.MakeTransparent (System.Drawing.Color.Magenta);
                bmpSource = ConvertBitmap (bmp);
                img.Source = bmpSource;
            }
        }
    }
}

public static Bitmap BitmapFromSource (BitmapSource bitmapsource) {
    Bitmap bitmap;
    using (var outStream = new MemoryStream ())
    {
        BitmapEncoder enc = new BmpBitmapEncoder ();
        enc.Frames.Add (BitmapFrame.Create (bitmapsource));
        enc.Save (outStream);
        bitmap = new Bitmap (outStream);
    } return bitmap;
}

