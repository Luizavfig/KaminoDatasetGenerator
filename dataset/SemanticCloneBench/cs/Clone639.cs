/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:4194130
*  Stack Overflow answer #:4194158
*  And Stack Overflow answer#:4194158
*/
private void CalculateGridColWidthsRaport () {
    int diffWidth = 0;
    int colWidthsSum = 0;
    foreach (DataGridViewColumn col in this.dataGrid.Columns) {
        if (col.Visible) {
            colWidthsSum += col.Width;
            if (col.Resizable == DataGridViewTriState.False)
                diffWidth += col.Width;
        }
    }
    colWidthsSum += 24;
    int totalResizableWith = colWidthsSum - diffWidth;
    if (this.ParentForm.WindowState == FormWindowState.Maximized) {
        totalResizableWith = this.dataGrid.Width - diffWidth;
    }
    this.colWidthRaport = new List < decimal > ();
    foreach (DataGridViewColumn col in this.dataGrid.Columns) {
        this.colWidthRaport.Add ((decimal) totalResizableWith / (decimal) col.Width);
    }
}

private void ResizeGridColumns () {
    int diffWidth = 0;
    foreach (DataGridViewColumn col in this.dataGrid.Columns) {
        if (col.Resizable == DataGridViewTriState.False && col.Visible)
            diffWidth += col.Width;
    }
    int totalResizableWith = this.dataGrid.Width - diffWidth;
    this.dataGrid.ColumnWidthChanged -= new DataGridViewColumnEventHandler (dataGrid_ColumnWidthChanged);
    for (int i = 0; i < this.colWidthRaport.Count; i ++) {
        try {
            if (this.dataGrid.Columns [i].Resizable != DataGridViewTriState.False && this.dataGrid.Columns [i].Visible) {
                this.dataGrid.Columns [i].Width = (int) Math.Floor ((decimal) totalResizableWith / this.colWidthRaport [i]);
            }
        }
        catch {
        }
    }
    this.dataGrid.ColumnWidthChanged += new DataGridViewColumnEventHandler (dataGrid_ColumnWidthChanged);
}

