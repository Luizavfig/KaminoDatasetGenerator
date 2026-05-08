/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:4327629
*  Stack Overflow answer #:38828231
*  And Stack Overflow answer#:38720924
*/
public static string GetUserCountryByIp (string ip) {
    IpInfo ipInfo = new IpInfo ();
    try {
        string info = new WebClient ().DownloadString ("http://ipinfo.io/" + ip);
        ipInfo = JsonConvert.DeserializeObject < IpInfo > (info);
        RegionInfo myRI1 = new RegionInfo (ipInfo.Country);
        ipInfo.Country = myRI1.EnglishName;
    }
    catch (Exception) {
        ipInfo.Country = null;
    }
    return ipInfo.Country;
}

public static string CityStateCountByIp (string IP) {
    var url = "http://freegeoip.net/json/" + IP;
    var request = System.Net.WebRequest.Create (url);
    using (WebResponse wrs = request.GetResponse ())
    using (Stream stream = wrs.GetResponseStream ())
    using (StreamReader reader = new StreamReader (stream))
    {
        string json = reader.ReadToEnd ();
        var obj = JObject.Parse (json);
        var City = (string) obj ["city"];
        return (City);
    } return "";
}

