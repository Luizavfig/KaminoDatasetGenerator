/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:28468560
*  Stack Overflow answer #:28468953
*  And Stack Overflow answer#:28468953
*/
public static String GetString (object value) {
    if (value is string) {
        return value as string;
    } else if (value is IDictionary) {
        return GetString (value as IDictionary);
    } else if (value is IEnumerable) {
        return GetString (value as IEnumerable);
    } else {
        return value.ToString ();
    }
}

public static String GetString (IEnumerable l) {
    string s = "[";
    foreach (object i in l) {
        s += GetString (i) + ", ";
    }
    if (s != "[")
        s = s.Substring (0, s.Length - 2);
    return s + "]";
}

