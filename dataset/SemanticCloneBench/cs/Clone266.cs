/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:2753820
*  Stack Overflow answer #:2753853
*  And Stack Overflow answer#:2753854
*/
public static string GetUa (HttpRequest hr) {
    try {
        string originalBrowser = hr.ServerVariables ["X-OperaMini-Phone-UA"];
        string anotherOriginalBrowser = hr.ServerVariables ["X-Device-User-Agent"];
        if (! String.IsNullOrEmpty (originalBrowser))
            return "OPERAMINI " + originalBrowser;
        else if (! String.IsNullOrEmpty (anotherOriginalBrowser))
            return "NOVARRA " + anotherOriginalBrowser;
        else
            return hr.UserAgent.ToString ();
    }
    catch {
        return "No UA Found";
    }
}

public static string GetUa (HttpRequest hr) {
    try {
        string originalBrowser = hr.ServerVariables ["X-OperaMini-Phone-UA"];
        string anotherOriginalBrowser = hr.ServerVariables ["X-Device-User-Agent"];
        return ! String.IsNullOrEmpty (originalBrowser) ? "OPERAMINI " + originalBrowser : ! String.IsNullOrEmpty (anotherOriginalBrowser) ? "NOVARRA " + anotherOriginalBrowser : hr.UserAgent;
    }
    catch {
        return "No UA Found";
    }
}

