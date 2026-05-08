/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:44508721
*  Stack Overflow answer #:44508882
*  And Stack Overflow answer#:44508836
*/
protected void EndReceive (IAsyncResult async) {
    try {
        int byteCount = SimNetSocket.EndReceive (async);
        string msg = Encoding.ASCII.GetString (ReadBuffer, 0, byteCount);
        Debug.Log ("RAW RECEIVE: " + msg);
        MessageBuffer += msg;
        BeginReceive ();
    }
    catch (IOException e) {
        Debug.LogError (e);
    }
}

protected void EndReceive (IAsyncResult async) {
    string msg = "";
    try {
        int received = SimNetSocket.EndReceive (async);
        var tmpArr = new byte [received];
        Buffer.BlockCopy (ReadBuffer, 0, tmpArr, 0, received);
        msg = ByteArrayToString (tmpArr);
        Debug.Log ("RAW RECEIVE: " + msg);
        MessageBuffer += msg;
        BeginReceive ();
    }
    catch (Exception e) {
        Debug.LogError (e);
    }
}

