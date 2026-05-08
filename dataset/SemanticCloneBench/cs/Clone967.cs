/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:373925
*  Stack Overflow answer #:10606271
*  And Stack Overflow answer#:373954
*/
public static DataTable ImportExcelXML (string Filename) {
    DataSet DS = new DataSet ();
    DS.ReadXml (Filename);
    DataTable Raw = new DataTable ();
    Raw = DS.Tables ["Data"];
    int ColumnNumber = Raw.Columns.Count;
    DataTable ImportData = new DataTable ();
    List < string > RowData = new List < string > ();
    for (int Counter = 0; Counter < Raw.Rows.Count; Counter ++) {
        if (Counter < ColumnNumber) {
            ImportData.Columns.Add (Raw.Rows [Counter].ItemArray.GetValue (1).ToString ());
        } else {
            if ((Counter % ColumnNumber == 0) && (Counter != ColumnNumber)) {
                ImportData.Rows.Add (GenerateRow (ImportData, RowData));
                RowData.Clear ();
            }
            RowData.Add (Raw.Rows [Counter].ItemArray.GetValue (1).ToString ());
        }
    }
    ImportData.Rows.Add (GenerateRow (ImportData, RowData));
    return ImportData;
}

public void WriteExcelStyledCell (object value, CellStyle style) {
    if (_writer == null)
        throw new InvalidOperationException ("Cannot write after closing.");
    _writer.WriteStartElement ("Cell", "urn:schemas-microsoft-com:office:spreadsheet");
    _writer.WriteAttributeString ("StyleID", "urn:schemas-microsoft-com:office:spreadsheet", style.ToString ());
    _writer.WriteStartElement ("Data", "urn:schemas-microsoft-com:office:spreadsheet");
    switch (style) {
        case CellStyle.General :
            _writer.WriteAttributeString ("Type", "urn:schemas-microsoft-com:office:spreadsheet", "String");
            break;
        case CellStyle.Number : case CellStyle.Currency :
            _writer.WriteAttributeString ("Type", "urn:schemas-microsoft-com:office:spreadsheet", "Number");
            break;
        case CellStyle.ShortDate : case CellStyle.DateTime :
            _writer.WriteAttributeString ("Type", "urn:schemas-microsoft-com:office:spreadsheet", "DateTime");
            break;
    }
    _writer.WriteValue (value);
    _writer.WriteEndElement ();
    _writer.WriteEndElement ();
}

