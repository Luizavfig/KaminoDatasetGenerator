/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:9906486
*  Stack Overflow answer #:10764243
*  And Stack Overflow answer#:10764243
*/
public string GetAccessToken () {
    var facebookCookie = HttpContext.Current.Request.Cookies ["fbsr_" + _appId];
    if (facebookCookie != null && facebookCookie.Value != null) {
        string jsoncode = System.Text.ASCIIEncoding.ASCII.GetString (FromBase64ForUrlString (facebookCookie.Value.Split (new char [] {'.'}) [1]));
        var tokenParams = HttpUtility.ParseQueryString (GetAccessToken ((string) JObject.Parse (jsoncode) ["code"]));
        _accessToken = tokenParams ["access_token"];
        return _accessToken;
    } else
        return null;
}

private string GetAccessToken (string code) {
    string url = string.Format ("https://graph.facebook.com/oauth/access_token?client_id={0}&redirect_uri={1}&client_secret={2}&code={3}", _appId, "", _appSecret, code.Replace ("\"", ""));
    System.Net.HttpWebRequest request = System.Net.WebRequest.Create (url) as System.Net.HttpWebRequest;
    System.Net.HttpWebResponse response = null;
    try {
        using (response = request.GetResponse () as System.Net.HttpWebResponse)
        {
            System.IO.StreamReader reader = new System.IO.StreamReader (response.GetResponseStream ());
            string retVal = reader.ReadToEnd ();
            return retVal;
        }}
    catch {
        return null;
    }
}

