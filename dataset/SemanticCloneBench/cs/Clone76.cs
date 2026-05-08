/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:210650
*  Stack Overflow answer #:210671
*  And Stack Overflow answer#:2425028
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

private bool IsValidImage (string filename) {
    Stream imageStream = null;
    try {
        imageStream = new FileStream (filename, FileMode.Open);
        if (imageStream.Length > 0) {
            byte [] header = new byte [30];
            string [] imageHeaders = new [] {"BM", "GIF", Encoding.ASCII.GetString (new byte [] {137, 80, 78, 71}), "MM\x00\x2a", "II\x2a\x00"};
            imageStream.Read (header, 0, header.Length);
            bool isImageHeader = imageHeaders.Count (str = > Encoding.ASCII.GetString (header).StartsWith (str)) > 0;
            if (imageStream != null) {
                imageStream.Close ();
                imageStream.Dispose ();
                imageStream = null;
            }
            if (isImageHeader == false) {
                using (BinaryReader br = new BinaryReader (File.Open (filename, FileMode.Open)))
                {
                    UInt16 soi = br.ReadUInt16 ();
                    UInt16 jfif = br.ReadUInt16 ();
                    return soi == 0xd8ff && (jfif == 0xe0ff || jfif == 57855);
                }}
            return isImageHeader;
        }
        return false;
    }
    catch {
        return false;
    }
    finally {
        if (imageStream != null) {
            imageStream.Close ();
            imageStream.Dispose ();
        }
    }
}

