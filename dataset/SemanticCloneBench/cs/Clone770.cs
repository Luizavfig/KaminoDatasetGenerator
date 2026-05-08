/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:17560201
*  Stack Overflow answer #:44886666
*  And Stack Overflow answer#:23151256
*/
public static string JoinAnd < T > (string separator, string sepLast, IEnumerable < T > values) {
    var sb = new StringBuilder ();
    var enumerator = values.GetEnumerator ();
    if (enumerator.MoveNext ()) {
        sb.Append (enumerator.Current);
    }
    object obj = null;
    if (enumerator.MoveNext ()) {
        obj = enumerator.Current;
    }
    while (enumerator.MoveNext ()) {
        sb.Append (separator);
        sb.Append (obj);
        obj = enumerator.Current;
    }
    if (obj != null) {
        sb.Append (sepLast);
        sb.Append (obj);
    }
    return sb.ToString ();
}

public static string OxbridgeAnd (this IEnumerable < string > collection) {
    var output = string.Empty;
    if (collection == null)
        return null;
    var list = collection.ToList ();
    if (! list.Any ())
        return output;
    if (list.Count == 1)
        return list.First ();
    var delimited = string.Join (", ", list.Take (list.Count - 1));
    output = string.Concat (delimited, ", and ", list.LastOrDefault ());
    return output;
}

