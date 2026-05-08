/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:10891857
*  Stack Overflow answer #:10892587
*  And Stack Overflow answer#:38861647
*/
public static byte [] ReadFully (Stream input) {
    byte [] buffer = new byte [16 * 1024];
    input.Position = 0;
    using (MemoryStream ms = new MemoryStream ())
    {
        int read;
        while ((read = input.Read (buffer, 0, buffer.Length)) > 0) {
            ms.Write (buffer, 0, read);
        }
        return ms.ToArray ();
    }}

public static string ReadFully (string blobUri, string itemUri) {
    CloudBlobContainer cloudBlobContainer = new CloudBlobContainer (new Uri (blobUri));
    CloudBlob blobReference = cloudBlobContainer.GetBlobReference (itemUri);
    using (var stream = blobReference.OpenRead ())
    {
        using (StreamReader reader = new StreamReader (stream))
        {
            return reader.ReadToEnd ();
        }}}

