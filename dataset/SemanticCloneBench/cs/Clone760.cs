/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:32382810
*  Stack Overflow answer #:36996595
*  And Stack Overflow answer#:32385784
*/
[HttpGet] public ActionResult Logout () {
    Session ["id1"] = null;
    Session ["id2"] = null;
    Session ["id3"] = null;
    Session ["id4"] = null;
    Session ["Region"] = null;
    Session.Clear ();
    Session.RemoveAll ();
    Session.Abandon ();
    Response.AddHeader ("Cache-control", "no-store, must-revalidate, private, no-cache");
    Response.AddHeader ("Pragma", "no-cache");
    Response.AddHeader ("Expires", "0");
    Response.AppendToLog ("window.location.reload();");
    return RedirectToAction ("Index", "Login");
}

public override void OnActionExecuting (FilterExecutingContext filterContext) {
    HttpSessionStateBase session = filterContext.HttpContext.Session;
    Controller controller = filterContext.Controller as Controller;
    if (controller != null) {
        if (session != null && session ["authstatus"] == null) {
            filterContext.Result = new RedirectToRouteResult (new RouteValueDictionary {{"controller", "Login"}, {"action", "Index"}});
        }
    }
    base.OnActionExecuting (filterContext);
}

