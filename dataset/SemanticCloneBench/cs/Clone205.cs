/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:31662622
*  Stack Overflow answer #:31669635
*  And Stack Overflow answer#:31711463
*/
public string GetResultPIN () {
    StringBuilder sb = new StringBuilder ();
    sb.Append (mIPAD.pin.KSN);
    sb.Append ("," + mIPAD.pin.EPB);
    sb.Append ("," + mIPAD.getStatusCode ());
    sb.Append ("\r\n");
    Thread.Sleep (20 * 1000);
    return sb.ToString ();
}

public static bool GetResultPIN () {
    TimeSpan timeout = TimeSpan.FromSeconds (30);
    System.Diagnostics.Stopwatch SW = new System.Diagnostics.Stopwatch ();
    SW.Start ();
    while (mIPAD.getStatusCode () != 0 && SW.Elapsed < timeout) {
        System.Threading.Thread.Sleep (50);
    }
    return (mIPAD.getStatusCode () == 0);
}

