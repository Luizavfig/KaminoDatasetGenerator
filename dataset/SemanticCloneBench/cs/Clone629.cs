/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:44508721
*  Stack Overflow answer #:44508836
*  And Stack Overflow answer#:44508819
*/
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

protected void EndReceive (IAsyncResult async) {
    string msg = "";
    int bytesRead = SimNetSocket.EndReceive (async);
    try {
        msg = ByteArrayToString (ReadBuffer, bytesRead);
    }
    catch (Exception e) {
        Debug.LogError (e);
    }
    Debug.Log ("RAW RECEIVE: " + msg);
    MessageBuffer += msg;
    BeginReceive ();
}

