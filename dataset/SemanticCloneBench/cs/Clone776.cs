/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:662879
*  Stack Overflow answer #:1174765
*  And Stack Overflow answer#:662940
*/
public static ManagementObject GetWebServerSettingsByServerComment (string serverComment) {
    ManagementObject returnValue = null;
    ManagementScope iisScope = new ManagementScope (@"\\localhost\root\MicrosoftIISv2", new ConnectionOptions ());
    iisScope.Connect ();
    if (iisScope.IsConnected) {
        ObjectQuery settingQuery = new ObjectQuery (String.Format ("Select * from IIsWebServerSetting where ServerComment = '{0}'", serverComment));
        ManagementObjectSearcher searcher = new ManagementObjectSearcher (iisScope, settingQuery);
        ManagementObjectCollection results = searcher.Get ();
        if (results.Count > 0) {
            foreach (ManagementObject manObj in results) {
                returnValue = manObj;
                if (returnValue != null) {
                    break;
                }
            }
        }
    }
    return returnValue;
}

public int GetWebSiteId (string serverName, string websiteName) {
    int result = - 1;
    DirectoryEntry w3svc = new DirectoryEntry (string.Format ("IIS://{0}/w3svc", serverName));
    foreach (DirectoryEntry site in w3svc.Children) {
        if (site.Properties ["ServerComment"] != null) {
            if (site.Properties ["ServerComment"].Value != null) {
                if (string.Compare (site.Properties ["ServerComment"].Value.ToString (), websiteName, false) == 0) {
                    result = int.Parse (site.Name);
                    break;
                }
            }
        }
    }
    return result;
}

