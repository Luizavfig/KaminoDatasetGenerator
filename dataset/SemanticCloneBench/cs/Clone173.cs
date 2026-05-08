/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:735350
*  Stack Overflow answer #:45046326
*  And Stack Overflow answer#:48057707
*/
internal static string GetIPAddress (HttpRequestBase request) {
    string forwarded = request.Headers ["Forwarded"];
    if (! String.IsNullOrEmpty (forwarded)) {
        foreach (string segment in forwarded.Split (',') [0].Split (';')) {
            string [] pair = segment.Trim ().Split ('=');
            if (pair.Length == 2 && pair [0].Equals ("for", StringComparison.OrdinalIgnoreCase)) {
                string ip = pair [1].Trim ('"');
                int left = ip.IndexOf ('['), right = ip.IndexOf (']');
                if (left == 0 && right > 0) {
                    return ip.Substring (1, right - 1);
                }
                int colon = ip.IndexOf (':');
                if (colon != - 1) {
                    return ip.Substring (0, colon);
                }
                return ip;
            }
        }
    }
    string xForwardedFor = request.Headers ["X-Forwarded-For"];
    if (! String.IsNullOrEmpty (xForwardedFor)) {
        return xForwardedFor.Split (',') [0];
    }
    return request.UserHostAddress;
}

public static string GetIPAddress (this HttpRequest Request) {
    if (Request.Headers ["CF-CONNECTING-IP"] != null)
        return Request.Headers ["CF-CONNECTING-IP"].ToString ();
    if (Request.ServerVariables ["HTTP_X_FORWARDED_FOR"] != null) {
        string ipAddress = Request.ServerVariables ["HTTP_X_FORWARDED_FOR"];
        if (! string.IsNullOrEmpty (ipAddress)) {
            string [] addresses = ipAddress.Split (',');
            if (addresses.Length != 0) {
                return addresses [0];
            }
        }
    }
    return Request.UserHostAddress;
}

