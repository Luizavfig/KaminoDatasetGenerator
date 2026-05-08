/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:2422212
*  Stack Overflow answer #:6989909
*  And Stack Overflow answer#:6469957
*/
public string Export (bool includeHeaderLine) {
    StringBuilder sb = new StringBuilder ();
    IList < PropertyInfo > propertyInfos = typeof (T).GetProperties ();
    if (includeHeaderLine) {
        foreach (PropertyInfo propertyInfo in propertyInfos) {
            sb.Append (propertyInfo.Name).Append (",");
        }
        sb.Remove (sb.Length - 1, 1).AppendLine ();
    }
    foreach (T obj in Objects) {
        foreach (PropertyInfo propertyInfo in propertyInfos) {
            sb.Append (MakeValueCsvFriendly (propertyInfo.GetValue (obj, null))).Append (",");
        }
        sb.Remove (sb.Length - 1, 1).AppendLine ();
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

