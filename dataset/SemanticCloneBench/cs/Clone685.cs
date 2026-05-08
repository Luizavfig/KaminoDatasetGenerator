/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:32399948
*  Stack Overflow answer #:32402002
*  And Stack Overflow answer#:32404243
*/
public void ValidateBearerToken (OwinContext context) {
    try {
        var tokenHandler = new JwtSecurityTokenHandler ();
        byte [] securityKey = GetBytes ("some key");
        SecurityToken securityToken;
        var validationParameters = new TokenValidationParameters () {ValidAudience = "http://localhost:2000", IssuerSigningToken = new BinarySecretSecurityToken (securityKey), ValidIssuer = "Self"};
        var auth = context.Request.Headers ["Authorization"];
        if (! string.IsNullOrWhiteSpace (auth) && auth.Contains ("Bearer")) {
            var token = auth.Split (' ') [1];
            var principal = tokenHandler.ValidateToken (token, validationParameters, out securityToken);
            context.Request.User = principal;
        }
    }
    catch (Exception ex) {
        var message = ex.Message;
    }
}

public ActionResoult Login (string token) {
    if (_tokenManager.IsValid (token)) {
        var user = _myUserManager.GetUserRoles (token);
        var ident = new ClaimsIdentity (new [] {new Claim (ClaimTypes.NameIdentifier, token), new Claim ("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider", "ASP.NET Identity", "http://www.w3.org/2001/XMLSchema#string"), new Claim (ClaimTypes.Name, user.Username), new Claim (ClaimTypes.Role, user.Roles [0]), new Claim (ClaimTypes.Role, user.Roles [1]),}, DefaultAuthenticationTypes.ApplicationCookie);
        HttpContext.GetOwinContext ().Authentication.SignIn (new AuthenticationProperties {IsPersistent = false}, ident);
        return RedirectToAction ("MyAction");
    }
    ModelState.AddModelError ("", "We could not authorize you :(");
    return View ();
}

