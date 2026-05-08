/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:10447015
*  Stack Overflow answer #:10447409
*  And Stack Overflow answer#:35659652
*/
private void SaveFileToDatabase (string filePath) {
    String strConnection = "Data Source=.\\SQLEXPRESS;AttachDbFilename='C:\\Users\\Hemant\\documents\\visual studio 2010\\Projects\\CRMdata\\CRMdata\\App_Data\\Database1.mdf';Integrated Security=True;User Instance=True";
    String excelConnString = String.Format ("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0\"", filePath);
    using (OleDbConnection excelConnection = new OleDbConnection (excelConnString))
    {
        using (OleDbCommand cmd = new OleDbCommand ("Select [ID],[Name],[Designation] from [Sheet1$]", excelConnection))
        {
            excelConnection.Open ();
            using (OleDbDataReader dReader = cmd.ExecuteReader ())
            {
                using (SqlBulkCopy sqlBulk = new SqlBulkCopy (strConnection))
                {
                    sqlBulk.DestinationTableName = "Excel_table";
                    sqlBulk.WriteToServer (dReader);
                }}}}}

private static void DataReaderBulkCopySample () {
    using (var reader = new ExcelDataReader (@"test.xlsx"))
    {
        var cols = Enumerable.Range (0, reader.FieldCount).Select (i = > reader.GetName (i)).ToArray ();
        DataHelper.CreateTableIfNotExists (ConnectionString, TableName, cols);
        using (var bulkCopy = new SqlBulkCopy (ConnectionString))
        {
            bulkCopy.EnableStreaming = true;
            bulkCopy.DestinationTableName = TableName;
            foreach (var col in cols)
                bulkCopy.ColumnMappings.Add (col, col);
            bulkCopy.WriteToServer (reader);
        }}}

