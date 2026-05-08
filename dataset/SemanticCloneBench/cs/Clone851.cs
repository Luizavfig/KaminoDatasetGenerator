/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:5821808
*  Stack Overflow answer #:5821884
*  And Stack Overflow answer#:11294506
*/
static void Main (string [] args) {
    HttpWebRequest request;
    HttpWebResponse response = null;
    StreamReader reader;
    StringBuilder sbSource;
    string uri = "https://yoursubdomain.harvestapp.com/projects";
    string username = "youremail@somewhere.com";
    string password = "yourharvestpassword";
    string usernamePassword = username + ":" + password;
    ServicePointManager.ServerCertificateValidationCallback = Validator;
    try {
        request = WebRequest.Create (uri) as HttpWebRequest;
        request.MaximumAutomaticRedirections = 1;
        request.AllowAutoRedirect = true;
        request.Accept = "application/xml";
        request.ContentType = "application/xml";
        request.UserAgent = "harvest_api_sample.cs";
        request.Headers.Add ("Authorization", "Basic " + Convert.ToBase64String (new ASCIIEncoding ().GetBytes (usernamePassword)));
        using (response = request.GetResponse () as HttpWebResponse)
        {
            if (request.HaveResponse == true && response != null) {
                reader = new StreamReader (response.GetResponseStream (), Encoding.UTF8);
                sbSource = new StringBuilder (reader.ReadToEnd ());
                Console.WriteLine (sbSource.ToString ());
            }
        }}
    catch (WebException wex) {
        if (wex.Response != null) {
            using (HttpWebResponse errorResponse = (HttpWebResponse) wex.Response)
            {
                Console.WriteLine ("The server returned '{0}' with the status code {1} ({2:d}).", errorResponse.StatusDescription, errorResponse.StatusCode, errorResponse.StatusCode);
            }} else {
            Console.WriteLine (wex);
        }
    }
    finally {
        if (response != null) {
            response.Close ();
        }
    }
}

public static string getProjects () {
    string uri = "https://<companyname>.harvestapp.com/projects";
    HttpClient http = new HttpClient ();
    http.Request.Accept = HttpContentTypes.ApplicationJson;
    http.Request.ContentType = HttpContentTypes.ApplicationJson;
    http.Request.SetBasicAuthentication (username, password);
    http.Request.ForceBasicAuth = true;
    HttpResponse response = http.Get (uri);
    return response.RawText;
}

