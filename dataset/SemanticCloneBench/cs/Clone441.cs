/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:806944
*  Stack Overflow answer #:2681056
*  And Stack Overflow answer#:807330
*/
public static String dt2JSON (DataTable dt) {
    var rows = new List < Object > ();
    foreach (DataRow row in dt.Rows) {
        var rowData = new Dictionary < string, object > ();
        foreach (DataColumn col in dt.Columns)
            rowData [col.ColumnName] = row [col];
        rows.Add (rowData);
    }
    var js = new JavaScriptSerializer ();
    return js.Serialize (new {rows = rows});
}

public static String dt2JSON (DataTable dt) {
    StringBuilder s = new StringBuilder ("{\"rows\":[");
    bool firstLine = true;
    foreach (DataRow dr in dt.Rows) {
        if (firstLine) {
            firstLine = false;
        } else {
            s.Append (',');
        }
        s.Append ('{');
        for (int i = 0; i < dr.Table.Columns.Count; i ++) {
            if (i > 0) {
                s.Append (',');
            }
            string name = dt.Columns [i].ColumnName;
            string value = dr [i].ToString ();
            s.Append ('"').Append (name.Replace ("\\", "\\\\").Replace ("\"", "\\\"")).Append ("\":\"").Append (value.Replace ("\\", "\\\\").Replace ("\"", "\\\"")).Append ('"');
        }
        s.Append ("}");
    }
    s.Append ("]}");
    return s.ToString ();
}

