/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:1979915
*  Stack Overflow answer #:12013240
*  And Stack Overflow answer#:16437936
*/
static public bool URLExists (string url) {
    bool result = false;
    WebRequest webRequest = WebRequest.Create (url);
    webRequest.Timeout = 1200;
    webRequest.Method = "HEAD";
    HttpWebResponse response = null;
    try {
        response = (HttpWebResponse) webRequest.GetResponse ();
        result = true;
    }
    catch (WebException webException) {
        Debug.Log (url + " doesn't exist: " + webException.Message);
    }
    finally {
        if (response != null) {
            response.Close ();
        }
    }
    return result;
}

public bool URLExists (string url) {
    bool result = true;
    WebRequest webRequest = WebRequest.Create (url);
    webRequest.Timeout = 1200;
    webRequest.Method = "HEAD";
    try {
        webRequest.GetResponse ();
    }
    catch {
        result = false;
    }
    return result;
}

