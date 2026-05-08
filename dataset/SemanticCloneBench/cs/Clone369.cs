/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:20632660
*  Stack Overflow answer #:20680863
*  And Stack Overflow answer#:20681153
*/
protected static bool TestaIntegracaoErpMigplus () {
    bool ret = true;
    try {
        string connectionStringMigplus = WebConfigurationManager.ConnectionStrings ["ConnectionStringMigplus"].ConnectionString;
        using (SqlConnection Conn = new SqlConnection (connectionStringMigplus))
        {
            Conn.Open ();
        }}
    catch (Exception) {
        ret = false;
    }
    return ret;
}

protected static bool TestaIntegracaoErpMigplus () {
    string connectionStringMigplus = WebConfigurationManager.ConnectionStrings ["ConnectionStringMigplus"].ConnectionString;
    var task = Task.Factory.StartNew < bool > (() = > {
        bool ret = true;
        using (SqlConnection Conn = new SqlConnection (connectionStringMigplus))
        {
            try {
                Conn.Open ();
            }
            catch (SqlException) {
                ret = false;
            }
        } return ret;
    });
    if (task.Wait ()) {
        return task.Result;
    }
    return false;
}

