/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:27764692
*  Stack Overflow answer #:34079152
*  And Stack Overflow answer#:39757799
*/
public static bool Validate (string encodedResponse) {
    if (string.IsNullOrEmpty (encodedResponse))
        return false;
    var client = new System.Net.WebClient ();
    var secret = ConfigurationManager.AppSettings ["Google.ReCaptcha.Secret"];
    if (string.IsNullOrEmpty (secret))
        return false;
    var googleReply = client.DownloadString (string.Format ("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secret, encodedResponse));
    var serializer = new System.Web.Script.Serialization.JavaScriptSerializer ();
    var reCaptcha = serializer.Deserialize < ReCaptcha > (googleReply);
    return reCaptcha.Success;
}

public static string Validate (string EncodedResponse, string RemoteIP) {
    var client = new WebClient ();
    string PrivateKey = "PRIVATE KEY";
    WebRequest req = WebRequest.Create ("https://www.google.com/recaptcha/api/siteverify");
    string postData = String.Format ("secret={0}&response={1}&remoteip={2}", PrivateKey, EncodedResponse, RemoteIP);
    byte [] send = Encoding.Default.GetBytes (postData);
    req.Method = "POST";
    req.ContentType = "application/x-www-form-urlencoded";
    req.ContentLength = send.Length;
    Stream sout = req.GetRequestStream ();
    sout.Write (send, 0, send.Length);
    sout.Flush ();
    sout.Close ();
    WebResponse res = req.GetResponse ();
    StreamReader sr = new StreamReader (res.GetResponseStream ());
    string returnvalue = sr.ReadToEnd ();
    var captchaResponse = JsonConvert.DeserializeObject < RecaptchaHandler > (returnvalue);
    return captchaResponse.Success;
}

