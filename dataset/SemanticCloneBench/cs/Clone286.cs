/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:36488295
*  Stack Overflow answer #:36636935
*  And Stack Overflow answer#:36636630
*/
protected bool URLExists (string url, params int [] acceptableCodes) {
    Func < string, int > getStatusCode = pageUrl = > {
        var statusCode = - 1;
        var webRequest = (HttpWebRequest) WebRequest.Create (pageUrl);
        webRequest.Timeout = 1200;
        webRequest.Method = "GET";
        HttpWebResponse response = null;
        try {
            response = webRequest.GetResponse () as HttpWebResponse;
        }
        catch (WebException webException) {
            response = webException.Response as HttpWebResponse;
        }
        finally {
            if (response != null) {
                statusCode = (int) response.StatusCode;
                response.Close ();
            }
        }
        return statusCode;
    };
    Func < int, bool > isStatusCodeOk = code = > {
        if (acceptableCodes != null && acceptableCodes.Contains (code)) {
            return true;
        }
        if (code >= 100 && code < 400) {
            return true;
        }
        if (code >= 500 && code <= 510) {
            return false;
        }
        return false;
    };
    var statusCode = getStatusCode (url);
    return isStatusCodeOk (statusCode);
}

public static bool URLExists (string url) {
    HttpStatusCode result = default (HttpStatusCode);
    var request = (HttpWebRequest) WebRequest.Create (url);
    request.AllowAutoRedirect = false;
    request.Method = "HEAD";
    try {
        using (var response = request.GetResponse () as HttpWebResponse)
        {
            if (response != null) {
                if (response.StatusCode == HttpStatusCode.OK)
                    return true;
                if (response.StatusCode == HttpStatusCode.Redirect) {
                    string uriString = response.Headers ["Location"];
                    return URLExists (uriString);
                }
                response.Close ();
            }
        } return false;
    }
    catch (WebException e) {
        using (WebResponse response = e.Response)
        {
            HttpWebResponse httpResponse = (HttpWebResponse) response;
            Console.WriteLine ("Error code: {0}", httpResponse.StatusCode);
            return false;
        }}
}

