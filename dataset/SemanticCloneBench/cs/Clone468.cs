/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:553611
*  Stack Overflow answer #:38413602
*  And Stack Overflow answer#:38413602
*/
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

public static byte [] ConvertBitmapSourceToByteArray (BitmapSource image) {
    byte [] data;
    BitmapEncoder encoder = new JpegBitmapEncoder ();
    encoder.Frames.Add (BitmapFrame.Create (image));
    using (MemoryStream ms = new MemoryStream ())
    {
        encoder.Save (ms);
        data = ms.ToArray ();
    } return data;
}

