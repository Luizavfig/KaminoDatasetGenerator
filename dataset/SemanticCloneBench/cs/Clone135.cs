/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:11437903
*  Stack Overflow answer #:11446694
*  And Stack Overflow answer#:19313099
*/
protected void GridView1_RowUpdating (object sender, GridViewUpdateEventArgs e) {
    GridViewRow row = (GridViewRow) GridView1.Rows [e.RowIndex];
    int id = Int32.Parse (GridView1.DataKeys [e.RowIndex].Value.ToString ());
    TextBox tname = (TextBox) row.FindControl ("nam");
    TextBox tques = (TextBox) row.FindControl ("que");
    MySqlCommand cmd = new MySqlCommand ("update exam set name1=@name,ques=@ques where id = @id", con);
    cmd.Parameters.Add ("@id", MySqlDbType.Int16).Value = id;
    cmd.Parameters.Add ("@name", MySqlDbType.VarChar, 30).Value = tname.Text.Trim ();
    cmd.Parameters.Add ("@ques", MySqlDbType.VarChar, 40).Value = tques.Text.Trim ();
    con.Open ();
    cmd.ExecuteNonQuery ();
    GridView1.EditIndex = - 1;
    bind ();
}

protected void GridView1_RowUpdating (object sender, GridViewUpdateEventArgs e) {
    GridViewRow row = GridView1.Rows [e.RowIndex];
    obj1.Id = Convert.ToInt32 (GridView1.DataKeys [row.RowIndex].Value);
    obj1.Name = ((TextBox) row.Cells [1].Controls [1]).Text;
    obj1.Description = ((TextBox) row.Cells [2].Controls [1]).Text;
    obj1.Updatetbl ();
    GridView1.EditIndex = - 1;
    bindGvEdit ();
}

