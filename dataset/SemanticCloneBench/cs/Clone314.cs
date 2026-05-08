/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:3038140
*  Stack Overflow answer #:3038526
*  And Stack Overflow answer#:30532737
*/
private string GetJavaInstallationPath () {
    string environmentPath = Environment.GetEnvironmentVariable ("JAVA_HOME");
    if (! string.IsNullOrEmpty (environmentPath)) {
        return environmentPath;
    }
    string javaKey = "SOFTWARE\\JavaSoft\\Java Runtime Environment\\";
    using (Microsoft.Win32.RegistryKey rk = Microsoft.Win32.Registry.LocalMachine.OpenSubKey (javaKey))
    {
        string currentVersion = rk.GetValue ("CurrentVersion").ToString ();
        using (Microsoft.Win32.RegistryKey key = rk.OpenSubKey (currentVersion))
        {
            return key.GetValue ("JavaHome").ToString ();
        }}}

static string GetJavaInstallationPath () {
    string environmentPath = Environment.GetEnvironmentVariable ("JAVA_HOME");
    if (! string.IsNullOrEmpty (environmentPath)) {
        return environmentPath;
    }
    const string JAVA_KEY = "SOFTWARE\\JavaSoft\\Java Runtime Environment\\";
    var localKey = RegistryKey.OpenBaseKey (Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry32);
    using (var rk = localKey.OpenSubKey (JAVA_KEY))
    {
        if (rk != null) {
            string currentVersion = rk.GetValue ("CurrentVersion").ToString ();
            using (var key = rk.OpenSubKey (currentVersion))
            {
                return key.GetValue ("JavaHome").ToString ();
            }}
    } localKey = RegistryKey.OpenBaseKey (Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
    using (var rk = localKey.OpenSubKey (JAVA_KEY))
    {
        if (rk != null) {
            string currentVersion = rk.GetValue ("CurrentVersion").ToString ();
            using (var key = rk.OpenSubKey (currentVersion))
            {
                return key.GetValue ("JavaHome").ToString ();
            }}
    } return null;
}

