/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:1335065
*  Stack Overflow answer #:42424560
*  And Stack Overflow answer#:42424560
*/
[PermissionSetAttribute (SecurityAction.Demand, Name = "FullTrust")] public static WindowsImpersonationContext doImpersonation (string svcUserName, string domainName, string password) {
    tokenHandle = IntPtr.Zero;
    dupeTokenHandle = IntPtr.Zero;
    bool returnValue = LogonUser (svcUserName, domainName, password, LOGON32_LOGON_INTERACTIVE, LOGON32_PROVIDER_WINNT50, ref tokenHandle);
    if (returnValue == false) {
        int ret = Marshal.GetLastWin32Error ();
        if (ret != NO_ERROR)
            throw new Exception ("LogonUser failed with error code : " + GetError (ret));
    }
    bool retVal = DuplicateToken (tokenHandle, SecurityImpersonation, ref dupeTokenHandle);
    if (retVal == false) {
        CloseHandle (tokenHandle);
        throw new Exception ("Exception thrown in trying to duplicate token.");
    } else {
        bool bRetVal = DuplicateToken (tokenHandle, (int) SecurityImpersonation, ref dupeTokenHandle);
        newId = new WindowsIdentity (dupeTokenHandle);
        WindowsImpersonationContext impersonatedUser = newId.Impersonate ();
        return impersonatedUser;
    }
}

public static WindowsImpersonationContext getWic (string userNameStringFromTextbox, string password) {
    try {
        string svcUser = userNameStringFromTextbox;
        string [] arrUser = new string [2];
        arrUser = svcUser.Split ('\\');
        string domain = arrUser [0];
        string svcUserName = arrUser [1];
        WindowsImpersonationContext wic = doImpersonation (svcUserName, domain, password);
        return wic;
    }
    catch (Exception ex) {
        ErrorLog.ErrorRoutine (new Exception ("getWic() Error: " + ex.ToString ()), ErrorMessage.NOTIFY_APP_ERROR);
        return null;
    }
}

