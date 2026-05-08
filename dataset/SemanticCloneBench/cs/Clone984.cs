/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:3382498
*  Stack Overflow answer #:27512480
*  And Stack Overflow answer#:27512480
*/
[SecurityCritical] public static string GetCookieInternal (Uri uri, bool throwIfNoCookie) {
    uint pchCookieData = 0;
    string url = UriToString (uri);
    uint flag = (uint) NativeMethods.InternetFlags.INTERNET_COOKIE_HTTPONLY;
    if (NativeMethods.InternetGetCookieEx (url, null, null, ref pchCookieData, flag, IntPtr.Zero)) {
        pchCookieData ++;
        StringBuilder cookieData = new StringBuilder ((int) pchCookieData);
        if (NativeMethods.InternetGetCookieEx (url, null, cookieData, ref pchCookieData, flag, IntPtr.Zero)) {
            DemandWebPermission (uri);
            return cookieData.ToString ();
        }
    }
    int lastErrorCode = Marshal.GetLastWin32Error ();
    if (throwIfNoCookie || (lastErrorCode != (int) NativeMethods.ErrorFlags.ERROR_NO_MORE_ITEMS)) {
        throw new Win32Exception (lastErrorCode);
    }
    return null;
}

private static void DemandWebPermission (Uri uri) {
    string uriString = UriToString (uri);
    if (uri.IsFile) {
        string localPath = uri.LocalPath;
        new FileIOPermission (FileIOPermissionAccess.Read, localPath).Demand ();
    } else {
        new WebPermission (NetworkAccess.Connect, uriString).Demand ();
    }
}

