/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:19058504
*  Stack Overflow answer #:19058663
*  And Stack Overflow answer#:19058524
*/
void comboboxrefresh () {
    cnn.Open ();
    SqlCommand cmd = new SqlCommand ("SELECT EmployeeID,EmployeeFirstName,EmployeeLastName FROM Employees", cnn);
    SqlDataReader dr = cmd.ExecuteReader ();
    if (dr.HasRows) {
        combobox1.ValueMember = "Id";
        combobox1.DisplayMember = "FullName";
        while (dr.Read ()) {
            comboBox1.Items.Add (new {FullName = dr.GetString (1) + " " + dr.GetString (2), Id = dr.GetInt32 (0)});
        }
    }
    cnn.Close ();
}

void comboboxrefresh () {
    cnn.Open ();
    SqlCommand cmd = new SqlCommand ("SELECT EmployeeID, (EmployeeFirstName + EmployeeLastName) as EmployeeName FROM Employees", cnn);
    DataTable table = new Datatable ();
    SqlDataAdapter adapter = new SqlDataAdapter (cmd);
    adapter.Fill (table);
    comboBox1.DisplayMember = "EmployeeName";
    comboBox1.ValueMember = "EmployeeID";
    comboBox1.DataSource = table;
    cnn.Close ();
}

