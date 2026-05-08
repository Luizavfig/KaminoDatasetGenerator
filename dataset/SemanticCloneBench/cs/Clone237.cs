/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:6684206
*  Stack Overflow answer #:6694592
*  And Stack Overflow answer#:6693307
*/
public RegionContext GetContext (string regionCode) {
    RegionContext temp = null;
    RegionContext rc = null;
    try {
        if (! this.contextCache.TryGetValue (regionCode.ToUpper (), out rc)) {
            temp = new RegionContext (regionCode);
            this.contextCache.Add (regionCode.ToUpper (), temp);
            rc = temp;
            temp = null;
        }
        return rc;
    }
    finally {
        if (temp != null) {
            temp.Dispose ();
        }
    }
}

public RegionContext GetContext (string regionCode) {
    RegionContext rc = null;
    if (! this.contextCache.TryGetValue (regionCode.ToUpper (), out rc)) {
        RegionContext newContext = new RegionContext (regionCode);
        try {
            this.contextCache.Add (regionCode.ToUpper (), newContext);
        }
        catch {
            newContext.Dispose ();
            throw;
        }
        rc = newContext;
    }
    return rc;
}

