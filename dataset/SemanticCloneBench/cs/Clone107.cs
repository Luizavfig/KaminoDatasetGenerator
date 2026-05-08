/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:29529887
*  Stack Overflow answer #:29530963
*  And Stack Overflow answer#:29531509
*/
private void dataGridView1_CellContentClick (object sender, DataGridViewCellEventArgs e) {
    if (e.ColumnIndex == dataGridView1.Columns ["Your Column Name"].Index) {
        dataGridView1.EndEdit ();
        if ((bool) dataGridView1.Rows [e.RowIndex].Cells ["Your Column Name"].Value) {
            int colIndex = e.ColumnIndex;
            int rowIndex = e.RowIndex;
            dataGridView1.Rows [colIndex].Cells [rowIndex].ReadOnly = true;
        }
    }
}

private void dataGridView1_CellContentClick (object sender, DataGridViewCellEventArgs e) {
    var _dataGrid = (DataGridView) sender;
    int chkBoxColumnIndex = 1;
    if (e.ColumnIndex == chkBoxColumnIndex && e.RowIndex >= 0) {
        bool isChecked = _dataGrid [chkBoxColumnIndex, e.RowIndex].Value == null ? false : (bool) _dataGrid [chkBoxColumnIndex, e.RowIndex].Value;
        for (int i = 0; i < dataGridView1.Columns.Count; i ++) {
            _dataGrid [i, e.RowIndex].ReadOnly = isChecked;
        }
    }
}

