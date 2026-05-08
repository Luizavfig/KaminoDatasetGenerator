/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:735350
*  Stack Overflow answer #:38546807
*  And Stack Overflow answer#:48057707
*/
public static string GetIPAddress (this HttpRequest Request) {
    if (Request.Headers ["CF-CONNECTING-IP"] != null)
        return Request.Headers ["CF-CONNECTING-IP"].ToString ();
    if (Request.ServerVariables ["HTTP_X_FORWARDED_FOR"] != null)
        return Request.ServerVariables ["HTTP_X_FORWARDED_FOR"].ToString ();
    return Request.UserHostAddress;
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

