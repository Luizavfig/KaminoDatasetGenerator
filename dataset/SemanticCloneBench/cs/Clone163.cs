/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:5486417
*  Stack Overflow answer #:5486611
*  And Stack Overflow answer#:5486502
*/
private void button1_Click (object sender, EventArgs e) {
    string w = "insert into checkmultiuser(username) values (@username)";
    c.Open ();
    using (SqlCommand cmd = new SqlCommand (w, c))
    {
        cmd.Parameters.Add ("@username", SqlDbType.VarChar);
        cmd.Parameters ["@username"].Value = textBox1.Text;
        cmd.ExecuteNonQuery ();
    }}

private void button1_Click (object sender, EventArgs e) {
    _cmd.Parameters [UsernameParm].Value = textBox1.Text;
    try {
        _cn.Open ();
        _cmd.ExecuteNonQuery ();
    }
    catch (Exception ex) {
    }
    finally {
        _cn.Close ();
    }
}

