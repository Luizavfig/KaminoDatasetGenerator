/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:34637185
*  Stack Overflow answer #:34649672
*  And Stack Overflow answer#:34647560
*/
public object Convert (object value, Type targetType, object parameter, string language) {
    if (value != null) {
        string source = value.ToString ();
        var ims = new InMemoryRandomAccessStream ();
        var bytes = Convert.FromBase64String (source);
        var dataWriter = new DataWriter (ims);
        dataWriter.WriteBytes (bytes);
        dataWriter.StoreAsync ();
        ims.Seek (0);
        var img = new BitmapImage ();
        img.SetSource (ims);
        return img;
    }
    return null;
}

public object Convert (object value, Type targetType, object parameter, string language) {
    if (value == null) {
        return null;
    }
    string item = value.ToString ();
    BitmapImage objBitmapImage = new BitmapImage ();
    objBitmapImage = NewViewModel.Base64StringToBitmap (item);
    return objBitmapImage;
}

