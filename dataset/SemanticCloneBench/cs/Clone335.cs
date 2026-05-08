/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:35684387
*  Stack Overflow answer #:35685632
*  And Stack Overflow answer#:35685053
*/
private void myBtn_Click (object sender, EventArgs e) {
    if (dataGridView1.SelectedRows.Count > 0) {
        var rowIndex = myDGV.SelectedRows [0].Index;
        var row = myDGV.Rows [rowIndex];
        var formLocation = this.Location;
        var gridLocation = myDGV.Location;
        var rowLocation = myDGV.GetRowDisplayRectangle (rowIndex, false).Location;
        newForm form = new newForm ();
        form.StartPosition = FormStartPosition.Manual;
        form.Location = GetPopupStartingLocation (new Point [] {formLocation, gridLocation, rowLocation}, row.Height);
        form.Show (this);
    }
}

private void myBtn_Click (object sender, EventArgs e) {
    if (myDGV.SelectedCells.Count > 0) {
        int i = myDGV.SelectedCells [0].RowIndex;
        DataGridViewRow r = myDGV.Rows [i];
        newForm form = new newForm ();
        form.StartPosition = FormStartPosition.Manual;
        var rect = myDGV.RectangleToScreen (myDGV.GetRowDisplayRectangle (i, false));
        form.Location = new Point (rect.Left, rect.Bottom);
        form.ShowDialog (this);
    }
}

