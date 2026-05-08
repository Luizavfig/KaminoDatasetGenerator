/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:307688
*  Stack Overflow answer #:35936119
*  And Stack Overflow answer#:47017311
*/
public bool StartDownload (int timeout) {
    try {
        System.IO.Directory.CreateDirectory (Path.GetDirectoryName (_fullPathWhereToSave));
        if (File.Exists (_fullPathWhereToSave)) {
            File.Delete (_fullPathWhereToSave);
        }
        using (WebClient client = new WebClient ())
        {
            var ur = new Uri (_url);
            client.DownloadProgressChanged += WebClientDownloadProgressChanged;
            client.DownloadFileCompleted += WebClientDownloadCompleted;
            Console.WriteLine (@"Downloading file:");
            client.DownloadFileAsync (ur, _fullPathWhereToSave);
            _semaphore.Wait (timeout);
            return _result && File.Exists (_fullPathWhereToSave);
        }}
    catch (Exception e) {
        Console.WriteLine ("Was not able to download file!");
        Console.Write (e);
        return false;
    }
    finally {
        this._semaphore.Dispose ();
    }
}

private string DownloadFile (string url) {
    HttpWebRequest request = (HttpWebRequest) HttpWebRequest.Create (url);
    string filename = "";
    string destinationpath = Environment;
    if (! Directory.Exists (destinationpath)) {
        Directory.CreateDirectory (destinationpath);
    }
    using (HttpWebResponse response = (HttpWebResponse) request.GetResponseAsync ().Result)
    {
        string path = response.Headers ["Content-Disposition"];
        if (string.IsNullOrWhiteSpace (path)) {
            var uri = new Uri (url);
            filename = Path.GetFileName (uri.LocalPath);
        } else {
            ContentDisposition contentDisposition = new ContentDisposition (path);
            filename = contentDisposition.FileName;
        }
        var responseStream = response.GetResponseStream ();
        using (var fileStream = File.Create (System.IO.Path.Combine (destinationpath, filename)))
        {
            responseStream.CopyTo (fileStream);
        }} return Path.Combine (destinationpath, filename);
}

