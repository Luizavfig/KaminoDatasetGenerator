/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:23469580
*  Stack Overflow answer #:23469844
*  And Stack Overflow answer#:23469860
*/
protected void TextBox1_TextChanged1 (object sender, EventArgs e) {
    dt = g1.return_dt ("select name from tbl_data_show");
    if (dt.Rows.Count > 0) {
        if (TextBox1.Text == dt.Rows [0] ["name"]) {
            Label1.Text = "4";
            Label1.Visible = true;
        } else if (TextBox1.Text != dt.Rows [0] ["name"]) {
            Label2.Text = "5";
            Label2.Visible = true;
        } else {
            Label1.Visible = false;
            Label2.Visible = false;
        }
    }
}

protected void TextBox1_TextChanged1 (object sender, EventArgs e) {
    SqlConnection con = new SqlConnection (ConfigurationManager.ConnectionStrings ["conn"].ConnectionString);
    con.Open ();
    SqlCommand cmd = new SqlCommand ("select name from tbl_data_show where name='" + TextBox1.Text + "'", con);
    SqlDataReader dr = cmd.ExecuteReader ();
    if (dr.HasRows) {
        while (dr.Read ()) {
            Panel1.Visible = true;
        }
    } else {
        Panel1.Visible = false;
    }
    con.Close ();
}

