/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:10837082
*  Stack Overflow answer #:19050773
*  And Stack Overflow answer#:10844325
*/
[HttpPost] public ActionResult Create () {
    string jsonPostData;
    using (var stream = Request.InputStream)
    {
        stream.Position = 0;
        using (var reader = new System.IO.StreamReader (stream))
        {
            jsonPostData = reader.ReadToEnd ();
        }} var foo = Newtonsoft.Json.JsonConvert.DeserializeObject < IDictionary < string, object > > (jsonPostData) ["foo"];
    return Json (new {success = true});
}

public void OnAuthorization (AuthorizationContext filterContext) {
    var request = filterContext.RequestContext.HttpContext.Request;
    var body = request.InputStream;
    var encoding = request.ContentEncoding;
    var reader = new StreamReader (body, encoding);
    var json = reader.ReadToEnd ();
    var ser = new JavaScriptSerializer ();
    var jsonDictionary = ser.Deserialize < Dictionary < string, string > > (json);
    request.InputStream.Position = 0;
}

