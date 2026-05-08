/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:26839260
*  Stack Overflow answer #:26839411
*  And Stack Overflow answer#:26839361
*/
public static void Main (String [] args) {
    using (SqlConnection sqlConn = new SqlConnection ("some connection string"))
    {
        sqlConn.Open ();
        using (SqlCommand comm = new SqlCommand ("some query; some other query;", conn))
        using (var sqlReader = comm.ExecuteReader ())
        {
            while (sqlReader.Read ()) {
            }
            if (sqlReader.NextResult ()) {
                while (sqlReader.Read ()) {
                }
            }
        }}}

public static void Main (String [] args) {
    using (SqlConnection sqlConn = new SqlConnection ("some connection string"))
    {
        sqlConn.Open ();
        using (SqlCommand comm = new SqlCommand ("some query", conn))
        using (var sqlReader = comm.ExecuteReader ())
        {
            while (sqlReader.Read ()) {
            }
        } using (SqlCommand comm = new SqlCommand ("some query", conn))
        using (var sqlReader = comm.ExecuteReader ())
        {
            while (sqlReader.Read ()) {
            }
        }}}

