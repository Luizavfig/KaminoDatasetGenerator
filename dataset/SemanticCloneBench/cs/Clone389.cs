/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:38112108
*  Stack Overflow answer #:38112227
*  And Stack Overflow answer#:38112730
*/
private static void Main (string [] args) {
    Uri [] uris = {new Uri ("http://www.google.com"), new Uri ("http://www.yahoo.com")};
    Parallel.ForEach (uris, uri = > {
        using (var webClient = new MyWebClient ())
        {
            try {
                var data = webClient.DownloadData (uri);
            }
            catch (Exception ex) {
                Console.WriteLine (ex.ToString ());
            }
        }});
}

private static void Main (string [] args) {
    Uri [] uris = {new Uri ("http://www.google.com"), new Uri ("http://www.yahoo.com")};
    foreach (var uri in uris) {
        var webClient = new WebClient ();
        webClient.DownloadDataCompleted += OnWebClientDownloadDataCompleted;
        webClient.DownloadDataAsync (uri);
    }
    Thread.Sleep (Timeout.Infinite);
}

