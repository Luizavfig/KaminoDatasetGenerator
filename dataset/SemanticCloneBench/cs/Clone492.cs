/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:7275135
*  Stack Overflow answer #:7275479
*  And Stack Overflow answer#:7275366
*/
static public void HideColumn (GridView gv, int columnIndex) {
    if (gv.HeaderRow != null)
        gv.HeaderRow.Cells [columnIndex].Style.Add ("display", "none");
    foreach (GridViewRow row in gv.Rows) {
        if (row.RowType == DataControlRowType.DataRow)
            row.Cells [columnIndex].Style.Add ("display", "none");
    }
}

public static void HideColumn (this Table table, string id) {
    int index = 0;
    bool columnFound = false;
    if (table.Rows.Count > 1) {
        TableHeaderRow headerRow = table.Rows [0] as TableHeaderRow;
        if (headerRow != null) {
            foreach (TableHeaderCell cell in headerRow.Cells) {
                if (cell.ID.ToLower () == id.ToLower ()) {
                    columnFound = true;
                    break;
                }
                index ++;
            }
        }
    }
    if (columnFound)
        HideColumn (table, index);
}

