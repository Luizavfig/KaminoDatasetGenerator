/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:977071
*  Stack Overflow answer #:977112
*  And Stack Overflow answer#:2872047
*/
public override void OnAuthorization (AuthorizationContext filterContext) {
    if (filterContext == null) {
        throw new ArgumentNullException ("filterContext");
    }
    if (AuthorizeCore (filterContext.HttpContext)) {
        SetCachePolicy (filterContext);
    } else if (! filterContext.HttpContext.User.Identity.IsAuthenticated) {
        filterContext.Result = new HttpUnauthorizedResult ();
    } else if (filterContext.HttpContext.User.IsInRole ("SuperUser")) {
        SetCachePolicy (filterContext);
    } else {
        ViewDataDictionary viewData = new ViewDataDictionary ();
        viewData.Add ("Message", "You do not have sufficient privileges for this operation.");
        filterContext.Result = new ViewResult {MasterName = this.MasterName, ViewName = this.ViewName, ViewData = viewData};
    }
}

public override void OnAuthorization (AuthorizationContext filterContext) {
    base.OnAuthorization (filterContext);
    if (! _isAuthorized) {
        filterContext.Result = new HttpUnauthorizedResult ();
    } else if (filterContext.HttpContext.User.IsInRole ("Administrator") || filterContext.HttpContext.User.IsInRole ("User") || filterContext.HttpContext.User.IsInRole ("Manager")) {
        SetCachePolicy (filterContext);
    } else {
        filterContext.Controller.TempData.Add ("RedirectReason", "You are not authorized to access this page.");
        filterContext.Result = new RedirectResult ("~/Error");
    }
}

