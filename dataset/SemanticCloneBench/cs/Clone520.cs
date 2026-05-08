/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:751056
*  Stack Overflow answer #:751149
*  And Stack Overflow answer#:751520
*/
public static string WebPageRead (string url) {
    if (String.IsNullOrEmpty (url)) {
        return null;
    }
    HttpWebRequest request = HttpWebRequest.Create (url) as HttpWebRequest;
    if (request == null) {
        return null;
    }
    request.Method = "GET";
    request.KeepAlive = false;
    request.ProtocolVersion = HttpVersion.Version10;
    using (WebResponse response = request.GetResponse ())
    {
        using (Stream stream = response.GetResponseStream ())
        {
            using (StreamReader reader = new StreamReader (stream, Encoding.UTF8))
            {
                return reader.ReadToEnd ();
            }}}}

public static string WebPageRead (string url) {
    string content = String.Empty;
    if (! String.IsNullOrEmpty (url)) {
        HttpWebRequest request = HttpWebRequest.Create (url) as HttpWebRequest;
        if (request != null) {
            request.Method = "GET";
            request.KeepAlive = false;
            request.ProtocolVersion = HttpVersion.Version10;
            try {
                using (WebResponse response = request.GetResponse ())
                {
                    using (Stream stream = response.GetResponseStream ())
                    {
                        using (StreamReader reader = new StreamReader (stream, Encoding.UTF8))
                        {
                            content = reader.ReadToEnd ();
                        }}}}
            catch (Exception exc) {
                throw exc;
            }
        }
    }
    return content;
}

