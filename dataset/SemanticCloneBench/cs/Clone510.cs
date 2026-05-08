/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:27398386
*  Stack Overflow answer #:27398478
*  And Stack Overflow answer#:27398628
*/
public DataTable MethodName (string Param) {
    DataRow dr;
    DataTable dt = new DataTable ();
    dt.Columns.Add ("Order", Type.GetType ("System.Int32"));
    dt.Columns.Add ("Driver", Type.GetType ("System.Int32"));
    dr = dt.NewRow ();
    if (AnotherMethod1 (Param)) {
        dr ["Order"] = 1;
    } else {
        dr ["Order"] = 0;
    }
    if (AnotherMethod2 (Param)) {
        dr ["Driver"] = 1;
    } else {
        dr ["Driver"] = 0;
    }
    dt.Rows.Add (dr);
    return dt;
}

public DataTable MethodName (string Param) {
    DataTable dt = new DataTable ();
    dt.Columns.Add ("Order", typeof (Int32));
    dt.Columns.Add ("Driver", typeof (Int32));
    DataRow dr = dt.NewRow ();
    dr ["Order"] = AnotherMethod1 (Param) ? 1 : 0;
    dr ["Driver"] = AnotherMethod2 (Param) ? 1 : 0;
    dt.Rows.Add (dr);
    return dt;
}

