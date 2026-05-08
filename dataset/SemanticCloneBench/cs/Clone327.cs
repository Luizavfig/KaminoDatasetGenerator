/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:39801635
*  Stack Overflow answer #:39801844
*  And Stack Overflow answer#:39801704
*/
[HttpPost] public ActionResult Register (UserVIewModel reg) {
    if (! ModelState.IsValid) {
        return View (model);
    }
    bool userExists = db.Users.FirstOrDefault (x = > x.UserName == reg.UserName) != null;
    if (userExists) {
        ModelState.AddModelError ("UserName", "UserName taken");
        return View (model);
    }
    var m = new User {UserName = reg.UserName, Email = reg.Email, FirstName = reg.FirstName, LastName = reg.LastName, Password = reg.Password};
    db.Users.Add (m);
    db.SaveChanges ();
    return RedirectToAction ("Login");
}

[HttpPost] public ActionResult Register (UserVIewModel reg) {
    if (ModelState.IsValid) {
        if (db.Users.Where (u = > u.UserName == reg.UserName).Any ()) {
        } else {
            var m = new User {UserName = reg.UserName, Email = reg.Email, FirstName = reg.FirstName, LastName = reg.LastName, Password = reg.Password};
            db.Users.Add (m);
            db.SaveChanges ();
            return RedirectToAction ("Login");
        }
    }
    return View ();
}

