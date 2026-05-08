/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:14113931
*  Stack Overflow answer #:14118448
*  And Stack Overflow answer#:14115020
*/
public static void FillDropDownList (string Query, System.Windows.Forms.ComboBox DropDownName) {
    using (var cn = new SqlConnection (CONNECTION_STRING))
    {
        cn.Open ();
        DataTable dt = new DataTable ();
        try {
            SqlCommand cmd = new SqlCommand (Query, cn);
            SqlDataReader myReader = cmd.ExecuteReader ();
            dt.Load (myReader);
        }
        catch (SqlException e) {
            Console.WriteLine (e.ToString ());
            return;
        }
        DropDownName.DataSource = dt;
        DropDownName.ValueMember = "id";
        DropDownName.DisplayMember = "Name";
    }}

public void FillDropDownList (string Query, ComboBox DropDownName) {
    DataTable dt = new DataTable ();
    using (var cn = new SqlConnection (CONNECTION_STRING))
    {
        using (var cmd = new SqlCommand (Query, cn))
        {
            cn.Open ();
            try {
                dt.Load (cmd.ExecuteReader ());
            }
            catch (SqlException e) {
                MessageBox.Show ("There was an error accessing your data. DETAIL: " + e.ToString ());
            }
        }} DropDownName.DataSource = dt;
    DropDownName.ValueMember = dt.Columns [0].ColumnName;
    DropDownName.DisplayMember = dt.Columns [1].ColumnName;
}

