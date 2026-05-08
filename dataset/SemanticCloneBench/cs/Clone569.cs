/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:5568043
*  Stack Overflow answer #:5568198
*  And Stack Overflow answer#:5568133
*/
public MyResponse MyMethod (string arg) {
    MyResponse abc = null;
    try {
        abc = new MyResponse ();
        using (Tracer myTracer = new Tracer (Constants.TraceLog))
        {
            return abc;
        }}
    catch {
        if (abc != null) {
            abc.Dispose ();
        }
        throw;
    }
}

public MyResponse MyMethod (string arg) {
    MyResponse tmpResponse = null;
    MyResponse response = null;
    try {
        tmpResponse = new MyResponse ();
        using (Tracer myTracer = new Tracer (Constants.TraceLog))
        {
        } response = tmpResponse;
        tmpResponse = null;
    }
    finally {
        if (tmpResponse != null)
            tmpResponse.Dispose ();
    }
    return response;
}

