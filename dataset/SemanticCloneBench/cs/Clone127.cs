/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:1337750
*  Stack Overflow answer #:13523565
*  And Stack Overflow answer#:26846116
*/
private static ImageFormat GetImageFormat (string fileName) {
    string extension = Path.GetExtension (fileName);
    if (string.IsNullOrEmpty (extension))
        throw new ArgumentException (string.Format ("Unable to determine file extension for fileName: {0}", fileName));
    switch (extension.ToLower ()) {
        case @".bmp" :
            return ImageFormat.Bmp;
        case @".gif" :
            return ImageFormat.Gif;
        case @".ico" :
            return ImageFormat.Icon;
        case @".jpg" : case @".jpeg" :
            return ImageFormat.Jpeg;
        case @".png" :
            return ImageFormat.Png;
        case @".tif" : case @".tiff" :
            return ImageFormat.Tiff;
        case @".wmf" :
            return ImageFormat.Wmf;
        default :
            throw new NotImplementedException ();
    }
}

private static ImageFormat GetImageFormat (string format) {
    ImageFormat imageFormat = null;
    try {
        var imageFormatConverter = new ImageFormatConverter ();
        imageFormat = (ImageFormat) imageFormatConverter.ConvertFromString (format);
    }
    catch (Exception) {
        throw;
    }
    return imageFormat;
}

