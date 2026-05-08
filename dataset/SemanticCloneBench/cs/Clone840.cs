/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:4239858
*  Stack Overflow answer #:4240201
*  And Stack Overflow answer#:4239913
*/
string Commaize (IEnumerable < string > list) {
    string previous = null;
    StringBuilder sb = new StringBuilder ();
    foreach (string s in list) {
        if (previous != null)
            sb.AppendFormat ("{0}, ", previous);
        previous = s;
    }
    if (previous != null) {
        if (sb.Length > 0)
            sb.AppendFormat ("and {0}", previous);
        else
            sb.Append (previous);
    }
    return sb.ToString ();
}

string Commaize (IEnumerable < string > sequence) {
    IList < string > list = sequence as IList < string >;
    if (list == null)
        list = sequence.ToList ();
    if (list.Count == 0)
        return "";
    else if (list.Count == 1)
        return list.First ();
    else
        return String.Join (", ", list.Take (list.Count - 1).ToArray ()) + " and " + list.Last ();
}

