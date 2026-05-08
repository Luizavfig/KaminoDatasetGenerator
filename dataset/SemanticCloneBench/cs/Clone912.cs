/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:38340078
*  Stack Overflow answer #:53286250
*  And Stack Overflow answer#:52096996
*/
private Task OnSecurityTokenValidated (SecurityTokenValidatedNotification < OpenIdConnectMessage, OpenIdConnectAuthenticationOptions > context) {
    ClaimsIdentity claimsIdentity = (ClaimsIdentity) context.AuthenticationTicket.Identity;
    string access_token = context.ProtocolMessage.AccessToken;
    JwtSecurityTokenHandler hand = new JwtSecurityTokenHandler ();
    var tokenS = hand.ReadJwtToken (access_token);
    foreach (var claim in tokenS.Claims) {
        if (! claimsIdentity.HasClaim (claim.Type, claim.Value))
            claimsIdentity.AddClaim (claim);
    }
    return Task.FromResult (0);
}

protected string GetName (string token) {
    string secret = "this is a string used for encrypt and decrypt token";
    var key = Encoding.ASCII.GetBytes (secret);
    var handler = new JwtSecurityTokenHandler ();
    var tokenSecure = handler.ReadToken (token) as SecurityToken;
    var validations = new TokenValidationParameters {ValidateIssuerSigningKey = true, IssuerSigningKey = new SymmetricSecurityKey (key), ValidateIssuer = false, ValidateAudience = false};
    var claims = handler.ValidateToken (token, validations, out tokenSecure);
    return claims.Identity.Name;
}

