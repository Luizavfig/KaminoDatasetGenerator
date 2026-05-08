/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:17922308
*  Stack Overflow answer #:26294681
*  And Stack Overflow answer#:26294681
*/
private static void SetIEVersioneKeyforWebBrowserControl (string appName, int ieval) {
    RegistryKey Regkey = null;
    try {
        Regkey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey (@"SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", true);
        if (Regkey == null) {
            YukLoggerObj.logWarnMsg ("Application FEATURE_BROWSER_EMULATION Failed - Registry key Not found");
            return;
        }
        string FindAppkey = Convert.ToString (Regkey.GetValue (appName));
        if (FindAppkey == "" + ieval) {
            YukLoggerObj.logInfoMsg ("Application FEATURE_BROWSER_EMULATION already set to " + ieval);
            Regkey.Close ();
            return;
        }
        Regkey.SetValue (appName, unchecked ((int) ieval), RegistryValueKind.DWord);
        FindAppkey = Convert.ToString (Regkey.GetValue (appName));
        if (FindAppkey == "" + ieval)
            YukLoggerObj.logInfoMsg ("Application FEATURE_BROWSER_EMULATION changed to " + ieval + "; changes will be visible at application restart");
        else
            YukLoggerObj.logWarnMsg ("Application FEATURE_BROWSER_EMULATION setting failed; current value is  " + ieval);
    }
    catch (Exception ex) {
        YukLoggerObj.logWarnMsg ("Application FEATURE_BROWSER_EMULATION setting failed; " + ex.Message);
    }
    finally {
        if (Regkey != null)
            Regkey.Close ();
    }
}

[STAThread] static void Main () {
    if (! mutex.WaitOne (TimeSpan.FromSeconds (2), false)) {
        return;
    }
    try {
        Application.EnableVisualStyles ();
        Application.SetCompatibleTextRenderingDefault (false);
        var targetApplication = Process.GetCurrentProcess ().ProcessName + ".exe";
        int ie_emulation = 10000;
        try {
            string tmp = Properties.Settings.Default.ie_emulation;
            ie_emulation = int.Parse (tmp);
        }
        catch {
        }
        SetIEVersioneKeyforWebBrowserControl (targetApplication, ie_emulation);
        m_webLoader = new FormMain ();
        Application.Run (m_webLoader);
    }
    finally {
        mutex.ReleaseMutex ();
    }
}

