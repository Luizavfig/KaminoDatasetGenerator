/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:926227
*  Stack Overflow answer #:12699673
*  And Stack Overflow answer#:926325
*/
static string GetUserDomainName () {
    string domain = String.Empty;
    try {
        domain = Environment.UserDomainName;
        string machineName = Environment.MachineName;
        if (machineName.Equals (domain, StringComparison.OrdinalIgnoreCase)) {
            domain = String.Empty;
        }
    }
    catch {
    }
    return domain;
}

public static bool IsInDomain () {
    Win32.NetJoinStatus status = Win32.NetJoinStatus.NetSetupUnknownStatus;
    IntPtr pDomain = IntPtr.Zero;
    int result = Win32.NetGetJoinInformation (null, out pDomain, out status);
    if (pDomain != IntPtr.Zero) {
        Win32.NetApiBufferFree (pDomain);
    }
    if (result == Win32.ErrorSuccess) {
        return status == Win32.NetJoinStatus.NetSetupDomainName;
    } else {
        throw new Exception ("Domain Info Get Failed", new Win32Exception ());
    }
}

