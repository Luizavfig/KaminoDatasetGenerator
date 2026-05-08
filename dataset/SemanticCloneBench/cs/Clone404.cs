/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:7174077
*  Stack Overflow answer #:7174386
*  And Stack Overflow answer#:7174214
*/
static void Write (DataTable dt, string outputFilePath) {
    int [] maxLengths = new int [dt.Columns.Count];
    for (int i = 0; i < dt.Columns.Count; i ++) {
        maxLengths [i] = dt.Columns [i].ColumnName.Length;
        foreach (DataRow row in dt.Rows) {
            if (! row.IsNull (i)) {
                int length = row [i].ToString ().Length;
                if (length > maxLengths [i]) {
                    maxLengths [i] = length;
                }
            }
        }
    }
    using (StreamWriter sw = new StreamWriter (outputFilePath, false))
    {
        for (int i = 0; i < dt.Columns.Count; i ++) {
            sw.Write (dt.Columns [i].ColumnName.PadRight (maxLengths [i] + 2));
        }
        sw.WriteLine ();
        foreach (DataRow row in dt.Rows) {
            for (int i = 0; i < dt.Columns.Count; i ++) {
                if (! row.IsNull (i)) {
                    sw.Write (row [i].ToString ().PadRight (maxLengths [i] + 2));
                } else {
                    sw.Write (new string (' ', maxLengths [i] + 2));
                }
            }
            sw.WriteLine ();
        }
        sw.Close ();
    }}

public static void Write (DataTable dt, string filePath) {
    int i = 0;
    StreamWriter sw = null;
    sw = new StreamWriter (filePath, false);
    for (i = 0; i < dt.Columns.Count - 1; i ++) {
        sw.Write (dt.Columns [i].ColumnName + " ");
    }
    sw.Write (dt.Columns [i].ColumnName);
    sw.WriteLine ();
    foreach (DataRow row in dt.Rows) {
        object [] array = row.ItemArray;
        for (i = 0; i < array.Length - 1; i ++) {
            sw.Write (array [i] + " ");
        }
        sw.Write (array [i].ToString ());
        sw.WriteLine ();
    }
    sw.Close ();
}

