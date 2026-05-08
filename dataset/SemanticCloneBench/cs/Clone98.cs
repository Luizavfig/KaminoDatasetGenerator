/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:3615800
*  Stack Overflow answer #:3615831
*  And Stack Overflow answer#:12631127
*/
private static void DownloadRemoteImageFile (string uri, string fileName) {
    HttpWebRequest request = (HttpWebRequest) WebRequest.Create (uri);
    HttpWebResponse response = (HttpWebResponse) request.GetResponse ();
    if ((response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Moved || response.StatusCode == HttpStatusCode.Redirect) && response.ContentType.StartsWith ("image", StringComparison.OrdinalIgnoreCase)) {
        using (Stream inputStream = response.GetResponseStream ())
        using (Stream outputStream = File.OpenWrite (fileName))
        {
            byte [] buffer = new byte [4096];
            int bytesRead;
            do
                {
                    bytesRead = inputStream.Read (buffer, 0, buffer.Length);
                    outputStream.Write (buffer, 0, bytesRead);
                } while (bytesRead != 0);
        }}
}

private static bool DownloadRemoteImageFile (string uri, string fileName) {
    HttpWebRequest request = (HttpWebRequest) WebRequest.Create (uri);
    HttpWebResponse response;
    try {
        response = (HttpWebResponse) request.GetResponse ();
    }
    catch (Exception) {
        return false;
    }
    if ((response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Moved || response.StatusCode == HttpStatusCode.Redirect) && response.ContentType.StartsWith ("image", StringComparison.OrdinalIgnoreCase)) {
        using (Stream inputStream = response.GetResponseStream ())
        using (Stream outputStream = File.OpenWrite (fileName))
        {
            byte [] buffer = new byte [4096];
            int bytesRead;
            do
                {
                    bytesRead = inputStream.Read (buffer, 0, buffer.Length);
                    outputStream.Write (buffer, 0, bytesRead);
                } while (bytesRead != 0);
        } return true;
    } else
        return false;
}

