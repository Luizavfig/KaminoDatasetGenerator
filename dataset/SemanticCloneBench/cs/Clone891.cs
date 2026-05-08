/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:4793405
*  Stack Overflow answer #:4793495
*  And Stack Overflow answer#:4803242
*/
public bool Enable () {
    try {
        CheckStatus (status);
        CheckStatus (status);
        CheckStatus (status);
        return true;
    }
    catch (InvalidStatusException) {
        Trace.WriteLine ("Error");
        return false;
    }
}

bool Enable () {
    foreach (var b in StatusChecks ()) {
        if (! b) {
            Trace.WriteLine ("Error");
            return false;
        }
    }
    return true;
}

