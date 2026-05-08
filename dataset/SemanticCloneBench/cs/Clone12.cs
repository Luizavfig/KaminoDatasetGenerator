/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:573922
*  Stack Overflow answer #:576209
*  And Stack Overflow answer#:4244517
*/
public string ReadCookie (string name) {
    if (HttpContext.Current.Response.Cookies.AllKeys.Contains (name)) {
        var cookie = HttpContext.Current.Response.Cookies [name];
        return cookie.Value;
    }
    if (HttpContext.Current.Request.Cookies.AllKeys.Contains (name)) {
        var cookie = HttpContext.Current.Request.Cookies [name];
        return cookie.Value;
    }
    return null;
}

public string ReadCookie (string strCookieName) {
    foreach (string strCookie in HttpContext.Current.Response.Cookies.AllKeys) {
        if (strCookie == strCookieName) {
            return HttpContext.Current.Response.Cookies [strCookie].Value;
        }
    }
    foreach (string strCookie in HttpContext.Current.Request.Cookies.AllKeys) {
        if (strCookie == strCookieName) {
            return HttpContext.Current.Request.Cookies [strCookie].Value;
        }
    }
    return null;
}

