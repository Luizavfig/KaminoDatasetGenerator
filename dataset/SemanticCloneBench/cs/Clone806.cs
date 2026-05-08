/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:2157276
*  Stack Overflow answer #:4379458
*  And Stack Overflow answer#:2157331
*/
static void HasRows (SqlConnection connection) {
    using (connection)
    using (SqlCommand command = new SqlCommand ("SELECT CategoryID, CategoryName FROM Categories;", connection))
    {
        connection.Open ();
        using (SqlDataReader reader = command.ExecuteReader ())
        {
            if (reader.HasRows) {
                while (reader.Read ()) {
                    Console.WriteLine ("{0}\t{1}", reader.GetInt32 (0), reader.GetString (1));
                }
            } else {
                Console.WriteLine ("No rows found.");
            }
            reader.Close ();
        }}}

private void CloseInternal (bool closeReader) {
    try {
    }
    catch (Exception ex) {
        this.Connection.Abort ();
        throw;
    }
    if (this.Connection != null && CommandBehavior.CloseConnection == true) {
        this.Connection.Close ();
    }
}

