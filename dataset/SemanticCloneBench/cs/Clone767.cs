/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:19914880
*  Stack Overflow answer #:35740601
*  And Stack Overflow answer#:19924829
*/
private void dataGridView1_CellFormatting (object sender, DataGridViewCellFormattingEventArgs e) {
    if (e.ColumnIndex == dataGridView1.Columns ["Rating"].Index && e.Value != null) {
        switch (e.Value.ToString ()) {
            case "1" :
                e.CellStyle.SelectionForeColor = Color.Red;
                e.CellStyle.ForeColor = Color.Red;
                e.Value = (char) 9733;
                break;
            case "2" :
                e.CellStyle.SelectionForeColor = Color.Brown;
                e.CellStyle.ForeColor = Color.Yellow;
                e.Value = (char) 9733;
                break;
            case "3" :
                e.CellStyle.SelectionForeColor = Color.Green;
                e.CellStyle.ForeColor = Color.Green;
                e.Value = (char) 9733;
                break;
            case "4" :
                e.CellStyle.SelectionForeColor = Color.Blue;
                e.CellStyle.ForeColor = Color.Blue;
                e.Value = (char) 9733;
                break;
            case "5" :
                e.CellStyle.SelectionForeColor = Color.Gold;
                e.CellStyle.ForeColor = Color.Gold;
                e.Value = (char) 9733;
                break;
        }
    }
}

protected override void OnMouseMove (DataGridViewCellMouseEventArgs e) {
    base.OnMouseMove (e);
    if (! mouseOver)
        mouseOver = true;
    if (IsReadOnly ())
        return;
    var lastStar = stars.Select ((x, i) = > new {x, i}).LastOrDefault (x = > x.x.IsVisible (e.Location));
    if (lastStar != null) {
        currentValue = lastStar.i + 1;
        DataGridView.Cursor = Cursors.Hand;
    } else if (RowIndex > - 1) {
        currentValue = (int) (Value ?? 0);
        DataGridView.Cursor = Cursors.Default;
    }
    DataGridView.InvalidateCell (this);
}

