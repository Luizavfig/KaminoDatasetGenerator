/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:9564174
*  Stack Overflow answer #:9564425
*  And Stack Overflow answer#:38413662
*/
private static BitmapImage LoadImage (byte [] imageData) {
    if (imageData == null || imageData.Length == 0)
        return null;
    var image = new BitmapImage ();
    using (var mem = new MemoryStream (imageData))
    {
        mem.Position = 0;
        image.BeginInit ();
        image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
        image.CacheOption = BitmapCacheOption.OnLoad;
        image.UriSource = null;
        image.StreamSource = mem;
        image.EndInit ();
    } image.Freeze ();
    return image;
}

public static byte [] ConvertBitmapSourceToByteArray (BitmapEncoder encoder, ImageSource imageSource) {
    byte [] bytes = null;
    var bitmapSource = imageSource as BitmapSource;
    if (bitmapSource != null) {
        encoder.Frames.Add (BitmapFrame.Create (bitmapSource));
        using (var stream = new MemoryStream ())
        {
            encoder.Save (stream);
            bytes = stream.ToArray ();
        }}
    return bytes;
}

