/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:3681052
*  Stack Overflow answer #:6181746
*  And Stack Overflow answer#:3682217
*/
public static string GetAbsoluteUrl (string relativeUrl) {
    if (String.IsNullOrEmpty (relativeUrl))
        return String.Empty;
    if (relativeUrl.StartsWith ("http://", StringComparison.OrdinalIgnoreCase) || relativeUrl.StartsWith ("https://", StringComparison.OrdinalIgnoreCase))
        return relativeUrl;
    if (HttpContext.Current == null)
        return relativeUrl;
    HttpContext context = HttpContext.Current;
    if (relativeUrl.StartsWith ("/"))
        relativeUrl = relativeUrl.Insert (0, "~");
    Page page = context.Handler as Page;
    if (page != null) {
        relativeUrl = page.ResolveUrl (relativeUrl);
    } else {
        if (! relativeUrl.StartsWith ("~/"))
            relativeUrl = relativeUrl.Insert (0, "~/");
        relativeUrl = VirtualPathUtility.ToAbsolute (relativeUrl);
    }
    var url = context.Request.Url;
    var port = url.Port != 80 ? (":" + url.Port) : String.Empty;
    return String.Format ("{0}://{1}{2}{3}", url.Scheme, url.Host, port, relativeUrl);
}

public static string GetAbsoluteUrl (string url) {
    if (String.IsNullOrEmpty (url)) {
        return String.Empty;
    }
    if (url.StartsWith ("http://", StringComparison.OrdinalIgnoreCase) || url.StartsWith ("https://", StringComparison.OrdinalIgnoreCase)) {
        return url;
    }
    HttpContext context = HttpContext.Current;
    if (url.StartsWith ("~/")) {
        url = (context.Handler as Page).ResolveUrl (url);
    }
    string port = (context.Request.Url.Port != 80 && context.Request.Url.Port != 443) ? ":" + context.Request.Url.Port : String.Empty;
    return context.Request.Url.Scheme + Uri.SchemeDelimiter + context.Request.Url.Host + port + "/" + url.TrimStart ('/');
}

