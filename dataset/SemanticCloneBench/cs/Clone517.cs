/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:25910641
*  Stack Overflow answer #:25929655
*  And Stack Overflow answer#:25929655
*/
[Route ("Login")] public HttpResponseMessage GetLogin () {
    string scope = HttpUtility.UrlEncode ("Space Seperated list of scopes");
    string redirectUri = HttpUtility.UrlEncode ("http://YourWebsiteURL/api/Account/OAuthCallback");
    string accessType = "Either online or offline";
    string requestUri = string.Format ("https://accounts.google.com/o/oauth2/auth?response_type=code&client_id={0}&redirect_uri={1}&scope={2}&access_type={3}&approval_prompt=auto&include_granted_scopes=true", _clientId, redirectUri, scope, accessType);
    HttpResponseMessage response = Request.CreateResponse (HttpStatusCode.MovedPermanently);
    response.Headers.Location = new Uri (requestUri);
    return response;
}

[Route ("OAuthCallback")] public HttpResponseMessage GetOAuthCallback (string code, string scope) {
    string redirectUri = HttpUtility.UrlEncode ("http://YourWebsiteURL/api/Account/OAuthCallback");
    string postMessage = string.Format ("code={0}&client_id={1}&client_secret={2}&redirect_uri={3}&grant_type=authorization_code", code, _clientId, "YourGoogleSecretCode", redirectUri);
    string jsonMessage;
    using (WebClient client = new WebClient ())
    {
        client.Headers [HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded; charset=utf-8";
        jsonMessage = client.UploadString ("https://accounts.google.com/o/oauth2/token", "POST", postMessage);
    } Token token = JsonConvert.DeserializeObject < Token > (jsonMessage);
}

