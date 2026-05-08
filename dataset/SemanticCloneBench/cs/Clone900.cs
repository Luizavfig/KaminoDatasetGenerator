/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:13492134
*  Stack Overflow answer #:13493419
*  And Stack Overflow answer#:13492224
*/
public static void Main () {
    string baseIP = "192.168.1.";
    Console.WriteLine ("Pinging 255 destinations of D-class in {0}*", baseIP);
    CreatePingers (255);
    PingOptions po = new PingOptions (ttl, true);
    System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding ();
    byte [] data = enc.GetBytes ("abababababababababababababababab");
    SpinWait wait = new SpinWait ();
    int cnt = 1;
    Stopwatch watch = Stopwatch.StartNew ();
    foreach (Ping p in pingers) {
        lock (@lock)
        {
            instances += 1;
        } p.SendAsync (string.Concat (baseIP, cnt.ToString ()), timeOut, data, po);
        cnt += 1;
    }
    while (instances > 0) {
        wait.SpinOnce ();
    }
    watch.Stop ();
    DestroyPingers ();
    Console.WriteLine ("Finished in {0}. Found {1} active IP-addresses.", watch.Elapsed.ToString (), result);
    Console.ReadKey ();
}

private static void StartClient () {
    try {
        IPHostEntry ipHostInfo = Dns.Resolve ("host.contoso.com");
        IPAddress ipAddress = ipHostInfo.AddressList [0];
        IPEndPoint remoteEP = new IPEndPoint (ipAddress, port);
        Socket client = new Socket (AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        client.BeginConnect (remoteEP, new AsyncCallback (ConnectCallback), client);
        connectDone.WaitOne ();
        Send (client, "This is a test<EOF>");
        sendDone.WaitOne ();
        Receive (client);
        receiveDone.WaitOne ();
        Console.WriteLine ("Response received : {0}", response);
        client.Shutdown (SocketShutdown.Both);
        client.Close ();
    }
    catch (Exception e) {
        Console.WriteLine (e.ToString ());
    }
}

