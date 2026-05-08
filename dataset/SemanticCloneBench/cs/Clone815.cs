/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:2031824
*  Stack Overflow answer #:43195952
*  And Stack Overflow answer#:2031831
*/
public static bool IsAvailableNetworkActive () {
    if (! System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable ())
        return false;
    NetworkInterface [] interfaces = System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces ();
    return (from face in interfaces
        where face.OperationalStatus == OperationalStatus.Up
        where (face.NetworkInterfaceType != NetworkInterfaceType.Tunnel) && (face.NetworkInterfaceType != NetworkInterfaceType.Loopback)
        where (! (face.Name.ToLower ().Contains ("virtual") || face.Description.ToLower ().Contains ("virtual")))
        select face.GetIPv4Statistics ()).Any (statistics = > (statistics.BytesReceived > 0) && (statistics.BytesSent > 0));
}

public static bool CheckForInternetConnection () {
    try {
        using (var client = new WebClient ())
        using (client.OpenRead ("http://clients3.google.com/generate_204"))
        {
            return true;
        }}
    catch {
        return false;
    }
}

