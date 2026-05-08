/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:19485909
*  Stack Overflow answer #:19486327
*  And Stack Overflow answer#:23427034
*/
protected void Button1_Click (object sender, EventArgs e) {
    DataTable dt = new DataTable ();
    if (dt.Columns.Count == 0) {
        dt.Columns.Add ("PayScale", typeof (string));
        dt.Columns.Add ("IncrementAmt", typeof (string));
        dt.Columns.Add ("Period", typeof (string));
    }
    DataRow NewRow = dt.NewRow ();
    NewRow [0] = TextBox1.Text;
    NewRow [1] = TextBox2.Text;
    dt.Rows.Add (NewRow);
    GridView1.DataSource = dt;
    GridViewl.DataBind ();
}

protected void TableGrid_RowDataBound (object sender, GridViewRowEventArgs e) {
    if (e.Row.RowIndex == - 1 && e.Row.RowType == DataControlRowType.Header) {
        GridViewRow gvRow = new GridViewRow (0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
        for (int i = 0; i < e.Row.Cells.Count; i ++) {
            TableCell tCell = new TableCell ();
            tCell.Text = "&nbsp;";
            gvRow.Cells.Add (tCell);
            Table tbl = e.Row.Parent as Table;
            tbl.Rows.Add (gvRow);
        }
    }
}

