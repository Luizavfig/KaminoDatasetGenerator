/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:686355
*  Stack Overflow answer #:765586
*  And Stack Overflow answer#:765586
*/
public static void ConnectTo (string ip, int port) {
    sock = new Socket (AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    sock.Connect (ip, port);
    int handle = 0;
    var form1 = Form.ActiveForm as FormMain;
    if (form1 != null)
        handle = form1.GetHandle;
    if (handle == 0) {
        FormMain.PerformActionOnMainForm (form = > form.memo.Text += "An error occured: Error code WS_01_ASYNC_HANDLE");
        return;
    }
    Extern.WSAAsyncSelect (sock.Handle.ToInt32 (), handle, Values.MESSAGE_ASYNC, Values.FD_READ | Values.FD_CLOSE);
}

public static void Connect () {
    string ip = GetIPFromHost ("gwgt1.joymax.com");
    if (ip == "") {
        ip = GetIPFromHost ("gwgt2.joymax.com");
        if (ip == "") {
        }
        server += 2;
    } else
        server += 1;
    int port = 15779;
    ConnectTo (ip, port);
}

