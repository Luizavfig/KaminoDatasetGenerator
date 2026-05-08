/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:9025789
*  Stack Overflow answer #:9026026
*  And Stack Overflow answer#:9025931
*/
[RequireHttps] [HttpPost] public ActionResult LogOn (LogOnModel model, string returnUrl) {
    if (ModelState.IsValid) {
        UserProfile profile = UserProfile.GetUserProfile (model.UserName);
        if (profile != null && ! profile.IsLockedOut) {
            if (MembershipService.ValidateUser (model.UserName, model.Password)) {
                FormsService.SignIn (model.UserName, model.RememberMe);
            } else {
                ModelState.AddModelError ("", "The user name or password provided is incorrect.");
            }
        } else {
            ModelState.AddModelError ("", "The user account does not exist or has been locked out.");
        }
    }
    return View (model);
}

public ActionResult LogOn (LogOnModel model) {
    if (! ModelState.IsValid) {
        this.ViewData ["LogOnError"] = "Bad Credentials.";
        return this.View (model);
    }
    if (! MembershipService.ValidateUser (model.UserName, model.Password)) {
        this.ViewData ["LogOnError"] = "Wrong Credentials.";
        return this.View (model);
    }
    MembershipUser user = Membership.GetUser (model.UserName);
    if (user == null) {
        this.ViewData ["LogOnError"] = "Race Condition: User previously deleted.";
        return this.View (model);
    }
    if (user.IsLockedOut) {
        this.ViewData ["LogOnError"] = "You are locked out.";
        return this.View (model);
    }
    FormsService.SignIn (model.UserName, model.RememberMe);
    return this.View ("LogOnSuccessful");
}

