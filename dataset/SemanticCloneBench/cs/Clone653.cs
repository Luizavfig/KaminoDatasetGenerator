/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:25180835
*  Stack Overflow answer #:32235263
*  And Stack Overflow answer#:37057459
*/
public static void ProcessSQLScriptFile (string script) {
    try {
        SqlConnection con = new SqlConnection (Properties.Settings.Default.SQLConDefault);
        con.Open ();
        Server server = new Server (new ServerConnection (con));
        server.ConnectionContext.ExecuteNonQuery (script);
        con.Close ();
    }
    catch (SqlException e) {
        Console.WriteLine ("SQL Exception: " + e.Message);
    }
    catch (Exception e) {
        Console.WriteLine ("Exception: " + e.Message);
    }
}

public void Schema_Create () {
    string sqlConnectionString = "connection string here";
    FileInfo file = new FileInfo (@"filepath to script.sql");
    string script = file.OpenText ().ReadToEnd ();
    SqlConnection conn = new SqlConnection (sqlConnectionString);
    Server server = new Server (new ServerConnection (conn));
    try {
        server.ConnectionContext.ExecuteNonQuery (script);
    }
    catch (Exception ex) {
        Console.WriteLine ("Error: " + ex.InnerException.Message);
    }
    file.OpenText ().Close ();
    conn.Close ();
}

