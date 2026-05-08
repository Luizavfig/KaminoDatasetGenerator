/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:19298534
*  Stack Overflow answer #:19299255
*  And Stack Overflow answer#:19299255
*/
protected void btnSubmit_Click2 (object sender, EventArgs e) {
    string RelaseDate = Calendar1.SelectedDate.Date.ToString ();
    int cnt;
    using (SqlConnection conn = new SqlConnection ("Server; Database; Integrated security = true"))
    using (SqlCommand cmd = new SqlCommand ("Insert into T_TADA_tempform(EMPID,DIVID,DesigID) values(@EMPID,@DIVID,@DesigID)", conn))
    {
        cmd.Parameters.AddWithValue ("@EMPID", ddlname.SelectedValue);
        cmd.Parameters.AddWithValue ("@DIVID", lbldesig.Text);
        cmd.Parameters.AddWithValue ("@DesigID", lbldiv.Text);
        conn.Open ();
        cnt = cmd.ExecuteNonQuery ();
    } if (cnt == 1) {
        Response.Redirect ("form.aspx");
    } else
        Response.Write ("Form has not been submitted,Please Try again!");
}

private void GetName () {
    using (SqlConnection conn = new SqlConnection ("Server; Database; Integrated security = true"))
    using (SqlCommand cmd = new SqlCommand ("Select EMPID,Name FROM M_employee where IsActive=1 ORDER BY Name", conn))
    using (DataSet objDs = new DataSet ())
    using (SqlDataAdapter sd = new SqlDataAdapter (cmd))
    {
        conn.Open ();
        sd.Fill (objDs);
        if (objDs.Tables [0].Rows.Count > 0) {
            ddlname.DataSource = objDs.Tables [0];
            ddlname.DataTextField = "Name";
            ddlname.DataValueField = "EMPID";
            ddlname.DataBind ();
            ddlname.Items.Insert (0, "--Select--");
        }
    }}

