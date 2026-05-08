/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:3005095
*  Stack Overflow answer #:23128209
*  And Stack Overflow answer#:3005196
*/
public System.Collections.Generic.Dictionary < string, string > GetAllTables (System.Data.SqlClient.SqlConnection _connection) {
    if (_connection.State == System.Data.ConnectionState.Closed)
        _connection.Open ();
    System.Data.DataTable dt = _connection.GetSchema ("Tables");
    System.Collections.Generic.Dictionary < string, string > tables = new System.Collections.Generic.Dictionary < string, string > ();
    foreach (System.Data.DataRow row in dt.Rows) {
        if (row [3].ToString ().Equals ("BASE TABLE", StringComparison.OrdinalIgnoreCase)) {
            string tableName = row [2].ToString ();
            string schema = row [1].ToString ();
            tables.Add (tableName, schema);
        }
    }
    _connection.Close ();
    return tables;
}

string [] GetAllTables (SqlConnection connection) {
    List < string > result = new List < string > ();
    SqlCommand cmd = new SqlCommand ("SELECT name FROM sys.Tables", connection);
    System.Data.SqlClient.SqlDataReader reader = cmd.ExecuteReader ();
    while (reader.Read ())
        result.Add (reader ["name"].ToString ());
    return result.ToArray ();
}

