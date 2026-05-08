/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:10045061
*  Stack Overflow answer #:10045123
*  And Stack Overflow answer#:10045213
*/
public void UpdateDescription (DataTable dataTable) {
    if (dataTable != null && dataTable.Rows.Count > 0) {
        foreach (DataRow dr in dataTable.Rows) {
            String dataDesc = dr ["DataDesc"].ToString ();
            if (! dr.IsNull ("DataDesc")) {
                if (dataDesc.Contains ("STATE")) {
                    dataDesc = dataDesc.Replace ("STATE", "").Trim ();
                }
                if (dataDesc.Contains ("HELLO ALL")) {
                    dataDesc = dataDesc.Replace ("HELLO ALL", "").Trim ();
                }
                if (dataDesc.Contains ("(")) {
                    dataDesc = dataDesc.Remove (dataDesc.IndexOf ("(")).Trim ();
                }
            }
            dr ["DataDesc"] = dataDesc;
        }
    }
}

public void UpdateDescription (DataTable dataTable) {
    if ((dataTable != null) && (0 < dataTable.Rows.Count)) {
        int rowIndex = 0;
        if (rowIndex < dataTable.Rows.Count) {
            DataRow dr = dataTable.Rows [rowIndex];
            if (! dr.IsNull ("DataDesc")) {
                string dataDesc = dr ["DataDesc"].ToString ();
                if (dataDesc.Contains ("STATE")) {
                    dataDesc = dataDesc.Replace ("STATE", "").Trim ();
                }
                if (dataDesc.Contains ("HELLO ALL")) {
                    dataDesc = dataDesc.Replace ("HELLO ALL", "").Trim ();
                }
                if (dataDesc.Contains ("(")) {
                    dataDesc = dataDesc.Remove (dataDesc.IndexOf ("(")).Trim ();
                }
                dr ["DataDesc"] = dataDesc;
            }
        }
        rowIndex ++;
    }
}

