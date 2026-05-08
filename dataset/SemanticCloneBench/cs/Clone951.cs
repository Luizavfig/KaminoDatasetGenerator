/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:44659312
*  Stack Overflow answer #:44659520
*  And Stack Overflow answer#:44659765
*/
private static void SqlCommandPrepareEx (string connectionString) {
    using (SqlConnection connection = new SqlConnection (connectionString))
    {
        connection.Open ();
        SqlCommand command = new SqlCommand (null, connection);
        command.CommandText = "INSERT INTO Region (RegionID, RegionDescription) " + "VALUES (@id, @desc)";
        SqlParameter idParam = new SqlParameter ("@id", SqlDbType.Int, 0);
        SqlParameter descParam = new SqlParameter ("@desc", SqlDbType.Text, 100);
        idParam.Value = 20;
        descParam.Value = "First Region";
        command.Parameters.Add (idParam);
        command.Parameters.Add (descParam);
        command.Prepare ();
        command.ExecuteNonQuery ();
        command.Parameters [0].Value = 21;
        command.Parameters [1].Value = "Second Region";
        command.ExecuteNonQuery ();
    }}

public static void updateClark (string cid, string path) {
    var cmdStr = "UPDATE tbl_Path SET folder_path=@path WHERE clark_id=@cid";
    using (var con = ConnectionDB.connection ())
    {
        con.Open ();
        using (var cmd = new SqlCommand (cmdStr, con))
        {
            cmd.Parameters.AddWithValue (new SqlParameter ("@path", path));
            cmd.Parameters.AddWithValue (new SqlParameter ("@cid", cid));
            cmd.ExecuteNonQuery ();
        }}}

