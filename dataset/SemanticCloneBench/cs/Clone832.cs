/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:12349163
*  Stack Overflow answer #:12363204
*  And Stack Overflow answer#:12363204
*/
private DataTable GetMenuData () {
    using (SqlConnection con = new SqlConnection (ConfigurationManager.ConnectionStrings ["ServerString"].ConnectionString))
    {
        using (SqlCommand cmd = new SqlCommand ("SELECT MenuID,MenuName,ParentID FROM MenuItems", con))
        {
            SqlDataAdapter da = new SqlDataAdapter (cmd);
            DataTable dt = new DataTable ();
            da.Fill (dt);
            return dt;
        }}}

private void AddTopMenuItems (DataTable menuData) {
    DataView view = new DataView (menuData);
    view.RowFilter = "ParentID = 0";
    foreach (DataRowView row in view) {
        MenuItem newMenuItem = new MenuItem (row ["MenuName"].ToString (), row ["MenuID"].ToString ());
        menuBar.Items.Add (newMenuItem);
        AddChildMenuItems (menuData, newMenuItem);
    }
}

