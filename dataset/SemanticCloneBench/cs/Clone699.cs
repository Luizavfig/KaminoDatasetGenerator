/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:6668810
*  Stack Overflow answer #:6668909
*  And Stack Overflow answer#:6668861
*/
public static void DisplayIPAddresses () {
    StringBuilder sb = new StringBuilder ();
    NetworkInterface [] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces ();
    foreach (NetworkInterface network in networkInterfaces) {
        IPInterfaceProperties properties = network.GetIPProperties ();
        foreach (IPAddressInformation address in properties.UnicastAddresses) {
            if (address.Address.AddressFamily != AddressFamily.InterNetwork)
                continue;
            if (IPAddress.IsLoopback (address.Address))
                continue;
            sb.AppendLine (address.Address.ToString () + " (" + network.Name + ")");
        }
    }
    MessageBox.Show (sb.ToString ());
}

public static string GetIP4Address () {
    string IP4Address = String.Empty;
    foreach (IPAddress IPA in Dns.GetHostAddresses (Dns.GetHostName ())) {
        if (IPA.AddressFamily == AddressFamily.InterNetwork) {
            IP4Address = IPA.ToString ();
            break;
        }
    }
    return IP4Address;
}

