/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:10182751
*  Stack Overflow answer #:49572016
*  And Stack Overflow answer#:10182935
*/
static void Main (string [] args) {
    IPAddress localAdd = IPAddress.Parse (SERVER_IP);
    TcpListener listener = new TcpListener (localAdd, PORT_NO);
    Console.WriteLine ("Listening...");
    listener.Start ();
    while (true) {
        TcpClient client = listener.AcceptTcpClient ();
        NetworkStream nwStream = client.GetStream ();
        byte [] buffer = new byte [client.ReceiveBufferSize];
        int bytesRead = nwStream.Read (buffer, 0, client.ReceiveBufferSize);
        string dataReceived = Encoding.ASCII.GetString (buffer, 0, bytesRead);
        Console.WriteLine ("Received : " + dataReceived);
        Console.WriteLine ("Sending back : " + dataReceived);
        nwStream.Write (buffer, 0, bytesRead);
        client.Close ();
    }
    listener.Stop ();
    Console.ReadLine ();
}

static void Main (string [] args) {
    IPAddress localAdd = IPAddress.Parse (SERVER_IP);
    TcpListener listener = new TcpListener (localAdd, PORT_NO);
    Console.WriteLine ("Listening...");
    listener.Start ();
    TcpClient client = listener.AcceptTcpClient ();
    NetworkStream nwStream = client.GetStream ();
    byte [] buffer = new byte [client.ReceiveBufferSize];
    int bytesRead = nwStream.Read (buffer, 0, client.ReceiveBufferSize);
    string dataReceived = Encoding.ASCII.GetString (buffer, 0, bytesRead);
    Console.WriteLine ("Received : " + dataReceived);
    Console.WriteLine ("Sending back : " + dataReceived);
    nwStream.Write (buffer, 0, bytesRead);
    client.Close ();
    listener.Stop ();
    Console.ReadLine ();
}

