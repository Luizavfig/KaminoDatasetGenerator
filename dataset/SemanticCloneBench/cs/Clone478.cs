/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:26143767
*  Stack Overflow answer #:26143948
*  And Stack Overflow answer#:26143977
*/
public int AddDataScalar (string strU) {
    string strQueryExistence = @"IF EXISTS(SELECT 1 FROM [OB].[h].[OP_PEONS] 
                                 WHERE Executive= @stru) SELECT 1 ELSE SELECT 0";
    int inNum = 0;
    using (SqlConnection con = new SqlConnection (strConn))
    using (SqlCommand cmd = new SqlCommand (strQueryExistence, con))
    {
        con.Open ();
        cmd.Parameters.AddWithValue ("@stru", strU);
        inNum = Convert.ToInt32 (cmd.ExecuteScalar ());
    } return inNum;
}

public int AddDataScalar (string strU) {
    using (SqlConnection con = new SqlConnection (strConn))
    {
        con.Open ();
        strQueryExistence = @"SELECT 1
          FROM [OB].[h].[OP_PEONS]
         WHERE Executive = @prm_Executive";
        using (SqlCommand cmd = new SqlCommand (strQueryExistence, con))
        {
            cmd.Parameters.AddWithValue ("@prm_Executive", strU);
            return cmd.ExecuteScalar () == null ? 0 : 1;
        }}}

