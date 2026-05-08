/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:41185153
*  Stack Overflow answer #:41185154
*  And Stack Overflow answer#:41185154
*/
public override string ToString () {
    builder.Clear ();
    bool hasHyperlink = ! string.IsNullOrEmpty (Hyperlink);
    bool hasColor = ! string.IsNullOrEmpty (HexColor);
    if (hasHyperlink) {
        builder.Append ("<a href=\"");
        builder.Append (Hyperlink);
        builder.Append ("\"><![CDATA[");
    }
    if (hasColor) {
        builder.Append ("<span style='color:");
        builder.Append (HexColor);
        builder.Append ("'>");
    }
    builder.AppendLine (Data);
    if (hasHyperlink)
        builder.Append ("</a>");
    return builder.ToString ();
}

public override string ToString () {
    builder.Clear ();
    builder.AppendLine ("<html>");
    builder.AppendLine ("<head></head>");
    builder.AppendLine ("<body>");
    builder.AppendLine ("<table>");
    builder.AppendLine ("<col>");
    foreach (List < HDNData > row in data) {
        builder.AppendLine ("<tr>");
        foreach (HDNData col in row) {
            builder.AppendLine ("<td>");
            builder.Append (col.ToString ());
            builder.AppendLine ("</td>");
        }
        builder.AppendLine ("</tr>");
    }
    builder.AppendLine ("</table>");
    builder.AppendLine ("</body>");
    builder.AppendLine ("</html>");
    return builder.ToString ();
}

