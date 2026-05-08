/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:5405895
*  Stack Overflow answer #:5406249
*  And Stack Overflow answer#:5406890
*/
private bool CheckConnection () {
    WebClient client = new WebClient ();
    try {
        using (client.OpenRead ("http://www.google.com"))
        {
        } return true;
    }
    catch (WebException) {
        return false;
    }
}

private bool CheckConnection (String URL) {
    try {
        HttpWebRequest request = (HttpWebRequest) WebRequest.Create (URL);
        request.Timeout = 5000;
        request.Credentials = CredentialCache.DefaultNetworkCredentials;
        HttpWebResponse response = (HttpWebResponse) request.GetResponse ();
        if (response.StatusCode == HttpStatusCode.OK)
            return true;
        else
            return false;
    }
    catch {
        return false;
    }
}

