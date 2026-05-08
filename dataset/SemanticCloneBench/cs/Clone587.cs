/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:13923193
*  Stack Overflow answer #:24701784
*  And Stack Overflow answer#:13923770
*/
public static IEnumerable < string > GetFilesInFtpDirectory (string url, string username, string password) {
    var request = (FtpWebRequest) WebRequest.Create (url);
    request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
    request.Credentials = new NetworkCredential (username, password);
    using (var response = (FtpWebResponse) request.GetResponse ())
    {
        using (var responseStream = response.GetResponseStream ())
        {
            var reader = new StreamReader (responseStream);
            while (! reader.EndOfStream) {
                var line = reader.ReadLine ();
                if (string.IsNullOrWhiteSpace (line) == false) {
                    yield return line.Split (new [] {' ', '\t'}).Last ();
                }
            }
        }}}

public string [] ListDirectory () {
    var list = listView1;
    var request = createRequest (TxtServer.Text, WebRequestMethods.Ftp.ListDirectory);
    using (var response = (FtpWebResponse) request.GetResponse ())
    {
        using (var stream = response.GetResponseStream ())
        {
            using (var reader = new StreamReader (stream, true))
            {
                while (! reader.EndOfStream) {
                    list.Items.Add (reader.ReadLine ());
                }
            }}} List < string > l = new List < string > ();
    return l.ToArray ();
}

