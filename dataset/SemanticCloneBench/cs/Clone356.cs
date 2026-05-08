/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:13097269
*  Stack Overflow answer #:13097429
*  And Stack Overflow answer#:13097757
*/
string SendCmd (string cmd, string ip, int port) {
    var client = new TcpClient (ip, port);
    var data = Encoding.GetEncoding (1252).GetBytes (cmd);
    var stm = client.GetStream ();
    stm.ReadTimeout = 250;
    stm.Write (data, 0, data.Length);
    byte [] resp = new byte [2048];
    var memStream = new MemoryStream ();
    int bytesread = stm.Read (resp, 0, resp.Length);
    while (bytesread > 0) {
        memStream.Write (resp, 0, bytesread);
        bytesread = stm.Read (resp, 0, resp.Length);
    }
    return Encoding.GetEncoding (1252).GetString (memStream.ToArray ());
}

string SendCmd (string cmd, string ip, int port) {
    var client = new TcpClient (ip, port);
    var data = Encoding.GetEncoding (1252).GetBytes (cmd);
    var stm = client.GetStream ();
    stm.Write (data, 0, data.Length);
    byte [] resp = new byte [2048];
    var memStream = new MemoryStream ();
    var bytes = 0;
    client.Client.ReceiveTimeout = 20;
    do
        {
            try {
                bytes = stm.Read (resp, 0, resp.Length);
                memStream.Write (resp, 0, bytes);
            }
            catch (IOException ex) {
                var socketExept = ex.InnerException as SocketException;
                if (socketExept == null || socketExept.ErrorCode != 10060)
                    throw ex;
                bytes = 0;
            }
        } while (bytes > 0);
    return Encoding.GetEncoding (1252).GetString (memStream.ToArray ());
}

