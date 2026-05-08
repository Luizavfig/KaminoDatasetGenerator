/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:38947705
*  Stack Overflow answer #:38947843
*  And Stack Overflow answer#:38947804
*/
public override void OnException (ExceptionContext filterContext) {
    filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
    filterContext.ExceptionHandled = true;
    filterContext.HttpContext.Response.ClearContent ();
    var controllerName = (string) filterContext.RouteData.Values ["controller"];
    var actionName = (string) filterContext.RouteData.Values ["action"];
    var model = new HandleErrorInfo (filterContext.Exception, controllerName, actionName);
    filterContext.Result = new ViewResult {ViewName = View, MasterName = Master, ViewData = new ViewDataDictionary < HandleErrorInfo > (model), TempData = filterContext.Controller.TempData};
    filterContext.Exception = null;
}

protected override void OnException (ExceptionContext filterContext) {
    filterContext.ExceptionHandled = true;
    if (filterContext.HttpContext.Request.Headers ["X-Requested-With"] == "XMLHttpRequest") {
        filterContext.Result = new JsonResult {JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = new {Error = true, Message = filterContext.Exception.Message}};
        filterContext.HttpContext.Response.StatusCode = 500;
    } else {
        filterContext.Result = new ViewResult {ViewName = "Error.cshtml"};
    }
}

