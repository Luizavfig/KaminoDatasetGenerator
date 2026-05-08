/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:43804446
*  Stack Overflow answer #:51649562
*  And Stack Overflow answer#:43891035
*/
public static void DownloadLargeFile (string DownloadFileName, string FilePath, string ContentType, HttpResponse response) {
    Stream stream = null;
    int bufferSize = 1048576;
    byte [] buffer = new Byte [bufferSize];
    int length;
    long lengthToRead;
    try {
        stream = new FileStream (FilePath, FileMode.Open, FileAccess.Read, FileShare.Read);
        lengthToRead = stream.Length;
        response.ContentType = ContentType;
        response.AddHeader ("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode (DownloadFileName, System.Text.Encoding.UTF8));
        while (lengthToRead > 0) {
            if (response.IsClientConnected) {
                length = stream.Read (buffer, 0, bufferSize);
                response.OutputStream.Write (buffer, 0, length);
                response.Flush ();
                lengthToRead = lengthToRead - length;
            } else {
                lengthToRead = - 1;
            }
        }
    }
    catch (Exception exp) {
        response.ContentType = "text/html";
        response.Write ("Error : " + exp.Message);
    }
    finally {
        if (stream != null) {
            stream.Close ();
        }
        response.End ();
        response.Close ();
    }
}

public ActionResult Download () {
    var filePath = @"file path from server";
    Response.Clear ();
    Response.ContentType = "application/octet-stream";
    Response.AppendHeader ("Content-Disposition", "filename=" + filePath);
    Response.TransmitFile (filePath);
    Response.End ();
    return Index ();
}

