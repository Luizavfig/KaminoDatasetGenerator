/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:9314172
*  Stack Overflow answer #:9314420
*  And Stack Overflow answer#:9314368
*/
public static string GetAllMessages (this Exception ex) {
    if (ex == null)
        throw new ArgumentNullException ("ex");
    StringBuilder sb = new StringBuilder ();
    while (ex != null) {
        if (! string.IsNullOrEmpty (ex.Message)) {
            if (sb.Length > 0)
                sb.Append (" ");
            sb.Append (ex.Message);
        }
        ex = ex.InnerException;
    }
    return sb.ToString ();
}

public static IEnumerable < Exception > GetInnerExceptions (this Exception ex) {
    if (ex == null) {
        throw new ArgumentNullException ("ex");
    }
    var innerException = ex;
    do
        {
            yield return innerException;
            innerException = innerException.InnerException;
        } while (innerException != null);
}

