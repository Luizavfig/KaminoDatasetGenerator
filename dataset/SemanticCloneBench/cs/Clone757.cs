/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:6588447
*  Stack Overflow answer #:6590879
*  And Stack Overflow answer#:38102805
*/
public void ProcessRequest (HttpContext context) {
    ClearResponse (context);
    switch (context.Request.HttpMethod.ToUpper ()) {
        case "OPTIONS" :
            SetAllowCrossSiteRequestHeaders (context);
            SetAllowCrossSiteRequestOrigin (context);
            context.Response.End ();
            break;
        default :
            context.Response.Headers.Add ("Allow", "OPTIONS");
            context.Response.StatusCode = 405;
            break;
    }
    context.ApplicationInstance.CompleteRequest ();
}

private void Application_BeginRequest (Object source, EventArgs e) {
    HttpApplication application = (HttpApplication) source;
    HttpContext context = application.Context;
    string httpMethod = context.Request.HttpMethod.ToUpper ();
    if (httpMethod == "OPTIONS") {
        ClearResponse (context);
        SetAllowCrossSiteRequestHeaders (context);
        SetAllowCrossSiteRequestOrigin (context);
        context.ApplicationInstance.CompleteRequest ();
    } else {
        SetAllowCrossSiteRequestOrigin (context);
    }
}

