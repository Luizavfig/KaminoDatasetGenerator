/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:2422212
*  Stack Overflow answer #:19959674
*  And Stack Overflow answer#:6469957
*/
public string Export () {
    StringBuilder sb = new StringBuilder ();
    foreach (string field in fields)
        sb.Append (field).Append (delim);
    sb.AppendLine ();
    foreach (Dictionary < string, object > row in rows) {
        foreach (string field in fields)
            sb.Append (MakeValueCsvFriendly (row [field])).Append (delim);
        sb.AppendLine ();
    }
    return sb.ToString ();
}

public string Export () {
    StringBuilder sb = new StringBuilder ();
    if (! string.IsNullOrEmpty (addTitle)) {
        char [] csvTokens = new [] {'\"', ',', '\n', '\r'};
        if (addTitle.IndexOfAny (csvTokens) >= 0) {
            addTitle = "\"" + addTitle.Replace ("\"", "\"\"") + "\"";
        }
        sb.Append (addTitle).Append (",");
        sb.AppendLine ();
    }
    foreach (string field in fields)
        sb.Append (field).Append (",");
    sb.AppendLine ();
    foreach (Dictionary < string, object > row in rows) {
        foreach (string field in fields)
            sb.Append (MakeValueCsvFriendly (row [field])).Append (",");
        sb.AppendLine ();
    }
    return sb.ToString ();
}

