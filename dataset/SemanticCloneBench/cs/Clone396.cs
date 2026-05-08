/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:6994852
*  Stack Overflow answer #:47282884
*  And Stack Overflow answer#:47282884
*/
public static void d (Exception e) {
    try {
        MethodBase site = e.TargetSite;
        string methodName = site == null ? "" : site.Name;
        methodName = ExtractBracketed (methodName);
        StackTrace stkTrace = new System.Diagnostics.StackTrace (e, true);
        for (int i = 0; i < 3; i ++) {
            var frame = stkTrace.GetFrame (i);
            int lineNum = frame.GetFileLineNumber ();
            int colNum = frame.GetFileColumnNumber ();
            string className = ExtractBracketed (frame.GetMethod ().ReflectedType.FullName);
            Trace.WriteLine (ThreadAndDateInfo + "Exception: " + className + "." + methodName + ", Ln " + lineNum + " Col " + colNum + ": " + e.Message);
            if (lineNum + colNum > 0)
                break;
        }
    }
    catch (Exception ee) {
        Console.WriteLine ("Tracing exception in d(Exception e)" + ee.Message);
    }
}

public static void d (string str) {
    try {
        StackFrame frame = new StackFrame (1);
        var method = frame.GetMethod ();
        string name = ExtractBracketed (method.Name);
        Trace.WriteLine (ThreadAndDateInfo + method.DeclaringType + "." + name + ": " + str);
    }
    catch (Exception e) {
        Console.WriteLine ("Tracing exception in d(string str)" + e.Message);
    }
}

