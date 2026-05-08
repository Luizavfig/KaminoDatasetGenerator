/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:7776631
*  Stack Overflow answer #:7776787
*  And Stack Overflow answer#:7776649
*/
public void ProcessRequest (HttpContext context) {
    context.Response.ContentType = "application/x-javascript";
    HttpWebRequest request = (HttpWebRequest) WebRequest.Create ("http://widgets.twimg.com/j/2/widget.js");
    request.Accept = "application/javascript";
    request.KeepAlive = false;
    request.Method = "GET";
    HttpWebResponse webresponse = (HttpWebResponse) request.GetResponse ();
    Encoding enc = System.Text.Encoding.GetEncoding (1252);
    StreamReader loResponseStream = new StreamReader (webresponse.GetResponseStream (), enc);
    string Response = loResponseStream.ReadToEnd ();
    context.Response.Write (Response);
}

public override void ProcessRequest (HttpContext context) {
    int bytesProcessed = 0;
    Stream remoteStream = null;
    Stream localStream = null;
    context.Response.ContentType = "application/octet-stream";
    WebRequest request = WebRequest.Create ("http://widgets.twimg.com/j/2/widget.js");
    request.ContentType = "application/octet-stream";
    using (WebResponse response = request.GetResponse ())
    {
        using (Stream requestStream = response.GetResponseStream ())
        {
            localStream = File.Create (@"c:\1.y2yy");
            byte [] buffer = new byte [1024];
            int bytesRead;
            do
                {
                    bytesRead = requestStream.Read (buffer, 0, buffer.Length);
                    localStream.Write (buffer, 0, bytesRead);
                    bytesProcessed += bytesRead;
                } while (bytesRead > 0);
            localStream.Close ();
        }}}

