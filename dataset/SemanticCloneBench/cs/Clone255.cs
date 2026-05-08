/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:40167833
*  Stack Overflow answer #:40168094
*  And Stack Overflow answer#:40228871
*/
protected void Application_Error (object sender, EventArgs e) {
    Exception exception = Server.GetLastError () as Exception;
    if (exception != null) {
        Context.ClearError ();
        Context.Response.TrySkipIisCustomErrors = true;
        string path = (exception is HttpException && (exception as HttpException).GetHttpCode () == 404) ? "~/Error/NotFound?errorMessage=" + exception.Message : "~/Error/Index?errorMessage=" + exception.Message;
        Context.Server.TransferRequest (path, false);
    }
}

protected void Application_Error () {
    Exception exception = Server.GetLastError ();
    var httpException = exception as HttpException;
    Response.Clear ();
    Server.ClearError ();
    var routeData = new RouteData ();
    routeData.Values ["controller"] = "Errors";
    routeData.Values ["action"] = "Common";
    routeData.Values ["exception"] = exception;
    Response.StatusCode = 500;
    if (httpException != null) {
        Response.StatusCode = httpException.GetHttpCode ();
        switch (Response.StatusCode) {
            case 403 :
                routeData.Values ["action"] = "Http403";
                break;
            case 404 :
                routeData.Values ["action"] = "Http404";
                break;
            case 400 :
                routeData.Values ["action"] = "Http400";
                break;
        }
    }
    Response.TrySkipIisCustomErrors = true;
    IController errorsController = new ErrorsController ();
    var rc = new RequestContext (new HttpContextWrapper (Context), routeData);
    errorsController.Execute (rc);
}

