/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:11021880
*  Stack Overflow answer #:11022868
*  And Stack Overflow answer#:11022042
*/
public String getString (String sql) {
    using (DataSet ds = new DataSet ())
    {
        string connstring = String.Format ("Server={0};Port={1}; User Id={2};Password={3};Database={4};", tbHost, tbPort, tbUser, tbPass, tbDataBaseName);
        using (NpgsqlConnection conn = new NpgsqlConnection (connstring))
        {
            using (NpgsqlDataAdapter da = new NpgsqlDataAdapter (sql, conn))
            {
                da.Fill (ds);
                if (ds.Tables.Count > 0) {
                    DataTable dt = ds.Tables [0];
                    if (dt.Rows.Count > 0) {
                        object o = dt.Rows [0] [0];
                        if (o != DBNull.Value && o != null) {
                            return o.ToString ();
                        }
                    }
                }
            }}} return "0";
}

public String getString (String sql) {
    DataSet ds = new DataSet ();
    string connstring = String.Format ("Server={0};Port={1}; User Id={2};Password={3};Database={4};", tbHost, tbPort, tbUser, tbPass, tbDataBaseName);
    NpgsqlConnection conn = new NpgsqlConnection (connstring);
    conn.Open ();
    NpgsqlDataAdapter da = new NpgsqlDataAdapter (sql, conn);
    ds.Reset ();
    try {
        da.Fill (ds);
    }
    catch (Exception msg) {
    }
    finally {
        if (conn.State.ToString () == "Open") {
            conn.Close ();
        }
    }
    return ds.Tables.Count == 0 ? "0" : ds.Tables [0].Rows [0] [0].ToString ();
}

