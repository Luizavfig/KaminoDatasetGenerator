/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:8442193
*  Stack Overflow answer #:8442430
*  And Stack Overflow answer#:8443315
*/
public static bool SiteExists (string path) {
    SPSite site;
    try {
        site = new SPSite (path);
    }
    catch (FileNotFoundException e) {
        return false;
    }
    finally {
        if (site != null)
            site.Dispose ();
    }
    return true;
}

public static bool SiteExists (string url) {
    try {
        using (SPSite site = new SPSite (url))
        {
            using (SPWeb web = site.OpenWeb (url, true))
            {
                return true;
            }}}
    catch (FileNotFoundException) {
        return false;
    }
}

