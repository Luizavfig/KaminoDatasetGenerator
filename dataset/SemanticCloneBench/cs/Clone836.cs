/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:17577184
*  Stack Overflow answer #:38838792
*  And Stack Overflow answer#:38838792
*/
public static DataTable GetWorksheetAsDataTable (ExcelWorksheet worksheet) {
    var dt = new DataTable (worksheet.Name);
    dt.Columns.AddRange (GetDataColumns (worksheet).ToArray ());
    var headerOffset = 1;
    var width = dt.Columns.Count;
    var depth = GetTableDepth (worksheet, headerOffset);
    for (var i = 1; i <= depth; i ++) {
        var row = dt.NewRow ();
        for (var j = 1; j <= width; j ++) {
            var currentValue = worksheet.Cells [i + headerOffset, j].Value;
            row [j - 1] = currentValue == null ? null : currentValue.ToString ();
        }
        dt.Rows.Add (row);
    }
    return dt;
}

private static IEnumerable < string > GatherColumnNames (ExcelWorksheet worksheet) {
    var columns = new List < string > ();
    var i = 1;
    var j = 1;
    var columnName = worksheet.Cells [i, j].Value;
    while (columnName != null) {
        columns.Add (GetUniqueColumnName (columns, columnName.ToString ()));
        j ++;
        columnName = worksheet.Cells [i, j].Value;
    }
    return columns;
}

