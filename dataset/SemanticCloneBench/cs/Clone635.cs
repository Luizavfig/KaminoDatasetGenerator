/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:38852389
*  Stack Overflow answer #:38913895
*  And Stack Overflow answer#:38913895
*/
void grid_CellFormatting (object sender, DataGridViewCellFormattingEventArgs e) {
    var grid = sender as DataGridView;
    var parameterColumnName = "A";
    var start = 0;
    var end = grid.RowCount - 1;
    var resultRowIndex = 0;
    var resultColumnName = "B";
    if (e.RowIndex == resultRowIndex && grid.Columns [e.ColumnIndex].Name == resultColumnName) {
        var list = Enumerable.Range (start, end - start + 1).Select (i = > grid.Rows [i].Cells [parameterColumnName].Value).Where (x = > x != null && x != DBNull.Value).Cast < int > ();
        if (list.Any ())
            e.Value = list.Max ();
    }
}

void Form1_Load (object sender, EventArgs e) {
    Random r = new Random ();
    var dt = new DataTable ();
    dt.Columns.Add ("A", typeof (int));
    dt.Columns.Add ("B", typeof (int));
    for (int i = 0; i < 10; i ++)
        dt.Rows.Add (r.Next (100));
    grid.DataSource = dt;
    grid.CellFormatting += grid_CellFormatting;
    grid.CellEndEdit += grid_CellEndEdit;
}

