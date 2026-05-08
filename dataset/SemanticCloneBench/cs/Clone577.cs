/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:209133
*  Stack Overflow answer #:43524961
*  And Stack Overflow answer#:43524961
*/
public static string GetMessage (Exception i_oException, string i_sCulture) {
    CultureInfo oCultureInfo = null;
    try {
        oCultureInfo = new CultureInfo (i_sCulture);
    }
    catch {
        oCultureInfo = CultureInfo.InvariantCulture;
    }
    return GetMessage (i_oException, oCultureInfo);
}

public static string GetMessage (Exception i_oException, CultureInfo i_oCultureInfo) {
    if (i_oException == null)
        return null;
    if (i_oCultureInfo == null)
        i_oCultureInfo = CultureInfo.InvariantCulture;
    if (ms_dictCultureExceptionMessages == null)
        return null;
    if (! ms_dictCultureExceptionMessages.ContainsKey (i_oCultureInfo))
        return CreateMessage (i_oException, i_oCultureInfo);
    Dictionary < string, string > dictExceptionMessage = ms_dictCultureExceptionMessages [i_oCultureInfo];
    string sExceptionName = i_oException.GetType ().FullName;
    sExceptionName = MakeXMLCompliant (sExceptionName);
    Win32Exception oWin32Exception = (Win32Exception) i_oException;
    if (oWin32Exception != null)
        sExceptionName += "_" + oWin32Exception.NativeErrorCode;
    if (dictExceptionMessage.ContainsKey (sExceptionName))
        return dictExceptionMessage [sExceptionName];
    else
        return CreateMessage (i_oException, i_oCultureInfo);
}

