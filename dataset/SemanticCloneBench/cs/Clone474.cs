/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:790542
*  Stack Overflow answer #:34538733
*  And Stack Overflow answer#:34538733
*/
public static bool SetBrowserEmulationVersion (BrowserEmulationVersion browserEmulationVersion) {
    bool result;
    result = false;
    try {
        RegistryKey key;
        key = Registry.CurrentUser.OpenSubKey (BrowserEmulationKey, true);
        if (key != null) {
            string programName;
            programName = Path.GetFileName (Environment.GetCommandLineArgs () [0]);
            if (browserEmulationVersion != BrowserEmulationVersion.Default) {
                key.SetValue (programName, (int) browserEmulationVersion, RegistryValueKind.DWord);
            } else {
                key.DeleteValue (programName, false);
            }
            result = true;
        }
    }
    catch (SecurityException) {
    }
    catch (UnauthorizedAccessException) {
    }
    return result;
}

public static bool SetBrowserEmulationVersion () {
    int ieVersion;
    BrowserEmulationVersion emulationCode;
    ieVersion = GetInternetExplorerMajorVersion ();
    if (ieVersion >= 11) {
        emulationCode = BrowserEmulationVersion.Version11;
    } else {
        switch (ieVersion) {
            case 10 :
                emulationCode = BrowserEmulationVersion.Version10;
                break;
            case 9 :
                emulationCode = BrowserEmulationVersion.Version9;
                break;
            case 8 :
                emulationCode = BrowserEmulationVersion.Version8;
                break;
            default :
                emulationCode = BrowserEmulationVersion.Version7;
                break;
        }
    }
    return SetBrowserEmulationVersion (emulationCode);
}

