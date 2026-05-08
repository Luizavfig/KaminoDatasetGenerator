/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:14095552
*  Stack Overflow answer #:14095584
*  And Stack Overflow answer#:14095582
*/
public static string GetServByPort (short port, ProtocolType proto) {
    StringBuilder ans = new StringBuilder ();
    switch (proto) {
        case ProtocolType.Tcp :
            ans.Append ((TcpServices) port);
            break;
        case ProtocolType.Udp :
            ans.Append ((UdpServices) port);
            break;
    }
    ans.Append ("(").Append (port).Append (")");
    return ans.ToString ();
}

public static string GetServByPort (short port, ProtocolType proto) {
    switch (proto) {
        case ProtocolType.Tcp :
            return string.Format ("{0} ({1})", (TcpServices) port, port);
        case ProtocolType.Udp :
            return string.Format ("{0} ({1})", (UdpServices) port, port);
        default :
            return string.Format ("({0})", port);
    }
}

