/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:35351849
*  Stack Overflow answer #:35500973
*  And Stack Overflow answer#:35544487
*/
protected void btnExport_Click (object sender, EventArgs e) {
    try {
        DataTable dt = new DataTable ("GridView_Data");
        foreach (TableCell cell in GridView1.HeaderRow.Cells) {
            dt.Columns.Add (cell.Text);
        }
        foreach (GridViewRow row in GridView1.Rows) {
            TextBox txtNameRow = (TextBox) row.FindControl ("txtName");
            Label lblCountryRow = (Label) row.FindControl ("lblCountry");
            DataRow drow = dt.NewRow ();
            for (int i = 0; i < GridView1.Columns.Count; i ++) {
                drow [i] = row.Cells [i].Text;
            }
            drow ["Name"] = txtNameRow.Text;
            drow ["Country"] = lblCountryRow.Text;
            dt.Rows.Add (drow);
        }
        using (XLWorkbook wb = new XLWorkbook ())
        {
            wb.Worksheets.Add (dt);
            Response.Clear ();
            Response.Buffer = true;
            Response.Charset = "";
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader ("content-disposition", "attachment;filename=GV.xlsx");
            using (MemoryStream MyMemoryStream = new MemoryStream ())
            {
                wb.SaveAs (MyMemoryStream);
                MyMemoryStream.WriteTo (Response.OutputStream);
                Response.Flush ();
                Response.End ();
            }}}
    catch (Exception ex) {
        throw;
    }
}

internal static void ExportToXcel_SomeReport (DataTable dt, string fileName, Page page) {
    var recCount = dt.Rows.Count;
    RemoveHtmlSpecialChars (dt);
    fileName = string.Format (fileName, DateTime.Now.ToString ("MMddyyyy_hhmmss"));
    var xlsx = new XLWorkbook ();
    var ws = xlsx.Worksheets.Add ("Some Report Name");
    ws.Style.Font.Bold = true;
    ws.Cell ("C5").Value = "YOUR REPORT NAME";
    ws.Cell ("C5").Style.Font.FontColor = XLColor.Black;
    ws.Cell ("C5").Style.Font.SetFontSize (16.0);
    ws.Cell ("E5").Value = DateTime.Now.ToString ("MM/dd/yyyy HH:mm");
    ws.Range ("C5:E5").Style.Font.SetFontSize (16.0);
    ws.Cell ("A7").Value = string.Format ("{0} Records", recCount);
    ws.Style.Font.Bold = false;
    ws.Cell (9, 1).InsertTable (dt.AsEnumerable ());
    ws.Row (9).InsertRowsBelow (1);
    ws.Columns ("1-9").AdjustToContents ();
    ws.Tables.Table (0).ShowAutoFilter = true;
    ws.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
    DynaGenExcelFile (fileName, page, xlsx);
}

