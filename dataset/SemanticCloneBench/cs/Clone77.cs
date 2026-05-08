/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:210650
*  Stack Overflow answer #:210671
*  And Stack Overflow answer#:211154
*/
bool IsValidImage (string filename) {
    try {
        using (BitmapImage newImage = new BitmapImage (filename))
        {
        }}
    catch (NotSupportedException) {
        return false;
    }
    return true;
}

static bool IsValidImage (Stream imageStream) {
    if (imageStream.Length > 0) {
        byte [] header = new byte [4];
        string [] imageHeaders = new [] {"\xFF\xD8", "BM", "GIF", Encoding.ASCII.GetString (new byte [] {137, 80, 78, 71})};
        imageStream.Read (header, 0, header.Length);
        bool isImageHeader = imageHeaders.Count (str = > Encoding.ASCII.GetString (header).StartsWith (str)) > 0;
        if (isImageHeader == true) {
            try {
                Image.FromStream (imageStream).Dispose ();
                imageStream.Close ();
                return true;
            }
            catch {
            }
        }
    }
    imageStream.Close ();
    return false;
}

