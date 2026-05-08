/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:2422212
*  Stack Overflow answer #:19959674
*  And Stack Overflow answer#:6469957
*/
string MakeValueCsvFriendly (object value) {
    if (value == null)
        return "";
    if (value is INullable && ((INullable) value).IsNull)
        return "";
    if (value is DateTime) {
        if (((DateTime) value).TimeOfDay.TotalSeconds == 0)
            return ((DateTime) value).ToString ("yyyy-MM-dd");
        return ((DateTime) value).ToString ("yyyy-MM-dd HH:mm:ss");
    }
    string output = value.ToString ();
    if (output.Contains (delim) || output.Contains ("\""))
        output = '"' + output.Replace ("\"", "\"\"") + '"';
    if (Regex.IsMatch (output, @"(?:\r\n|\n|\r)"))
        output = string.Join (" ", Regex.Split (output, @"(?:\r\n|\n|\r)"));
    return output;
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

