/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:5821351
*  Stack Overflow answer #:6267111
*  And Stack Overflow answer#:35065334
*/
protected void SessionAuthenticationModule_SessionSecurityTokenReceived (object sender, SessionSecurityTokenReceivedEventArgs e) {
    var sessionToken = e.SessionToken;
    SymmetricSecurityKey symmetricSecurityKey = null;
    if (sessionToken.SecurityKeys != null)
        symmetricSecurityKey = sessionToken.SecurityKeys.OfType < SymmetricSecurityKey > ().FirstOrDefault ();
    Condition.Requires (symmetricSecurityKey, "symmetricSecurityKey").IsNotNull ();
    if (sessionToken.ValidTo > DateTime.UtcNow) {
        var slidingExpiration = sessionToken.ValidTo - sessionToken.ValidFrom;
        e.SessionToken = new SessionSecurityToken (sessionToken.ClaimsPrincipal, sessionToken.ContextId, sessionToken.Context, sessionToken.EndpointId, slidingExpiration, symmetricSecurityKey);
        e.ReissueCookie = true;
    } else {
        var sessionAuthenticationModule = (SessionAuthenticationModule) sender;
        sessionAuthenticationModule.DeleteSessionTokenCookie ();
        e.Cancel = true;
    }
}

void SessionAuthenticationModule_SessionSecurityTokenReceived (object sender, System.IdentityModel.Services.SessionSecurityTokenReceivedEventArgs e) {
    DateTime now = DateTime.UtcNow;
    SessionSecurityToken sst = e.SessionToken;
    DateTime validFrom = sst.ValidFrom;
    DateTime validTo = sst.ValidTo;
    if ((now < validTo) && (now > validFrom.AddMinutes ((validTo.Minute - validFrom.Minute) / 2))) {
        SessionAuthenticationModule sam = sender as SessionAuthenticationModule;
        e.SessionToken = sam.CreateSessionSecurityToken (sst.ClaimsPrincipal, sst.Context, now, now.AddMinutes (2), sst.IsPersistent);
        e.ReissueCookie = true;
    }
}

