/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:9924758
*  Stack Overflow answer #:9978889
*  And Stack Overflow answer#:9978889
*/
[WebMethod (EnableSession = true)] [ScriptMethod (ResponseFormat = ResponseFormat.Json)] public dynamic update () {
    if (Session ["user"] == null) {
        Session.Add ("user", new User ());
    }
    User user = (User) Session ["user"];
    user.responseModel = new ResponseModel ();
    if (user.updateListeners.Count > 0) {
        foreach (var updateMethod in user.updateListeners) {
            updateMethod.run ();
        }
        return JSON.Serialize (user.responseModel);
    }
    return null;
}

[WebMethod (EnableSession = true)] [ScriptMethod (ResponseFormat = ResponseFormat.Xml)] public void login (string email, string password) {
    if (Session ["user"] == null) {
        return;
    }
    User user = (User) Session ["user"];
    if (user.logged) {
        return;
    }
    if (user.Authenticate (email, password)) {
        user.logged = true;
        user.updateListeners.Add (new LoginScreenRemover ());
    }
}

