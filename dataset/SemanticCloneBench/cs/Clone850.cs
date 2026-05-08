/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:9993883
*  Stack Overflow answer #:9994292
*  And Stack Overflow answer#:36190163
*/
public static string Format (this TimeSpan obj) {
    StringBuilder sb = new StringBuilder ();
    if (obj.Hours != 0) {
        sb.Append (obj.Hours);
        sb.Append (" ");
        sb.Append ("hours");
        sb.Append (" ");
    }
    if (obj.Minutes != 0 || sb.Length != 0) {
        sb.Append (obj.Minutes);
        sb.Append (" ");
        sb.Append ("minutes");
        sb.Append (" ");
    }
    if (obj.Seconds != 0 || sb.Length != 0) {
        sb.Append (obj.Seconds);
        sb.Append (" ");
        sb.Append ("seconds");
        sb.Append (" ");
    }
    if (obj.Milliseconds != 0 || sb.Length != 0) {
        sb.Append (obj.Milliseconds);
        sb.Append (" ");
        sb.Append ("Milliseconds");
        sb.Append (" ");
    }
    if (sb.Length == 0) {
        sb.Append (0);
        sb.Append (" ");
        sb.Append ("Milliseconds");
    }
    return sb.ToString ();
}

public static string ReadableTime (int milliseconds) {
    var parts = new List < string > ();
    Action < int, string > add = (val, unit) = > {
        if (val > 0)
            parts.Add (val + unit);
    };
    var t = TimeSpan.FromMilliseconds (milliseconds);
    add (t.Days, "d");
    add (t.Hours, "h");
    add (t.Minutes, "m");
    add (t.Seconds, "s");
    add (t.Milliseconds, "ms");
    return string.Join (" ", parts);
}

