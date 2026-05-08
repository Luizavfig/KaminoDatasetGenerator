/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:20164677
*  Stack Overflow answer #:20164760
*  And Stack Overflow answer#:20164804
*/
protected void ddlcountry_SelectedIndexChanged (object sender, EventArgs e) {
    if (ddlcountry.Text != string.Empty) {
        MySqlCommand cd = new MySqlCommand (string.Format ("SELECT * FROM {0}_Animals", ddlcountry.Text), cs);
        cs.Open ();
        MySqlDataReader ddlSpecie = cd.ExecuteReader ();
        DdPetPist.DataSource = ddlSpecie;
        DdPetPist.DataValueField = "Specie";
        DdPetPist.DataTextField = "Specie";
        DdPetPist.DataBind ();
        cs.Close ();
        cs.Dispose ();
    }
}

protected void ddlcountry_SelectedIndexChanged (object sender, EventArgs e) {
    string country = ddlcountry.SelectedValue;
    string query = "SELECT * FROM " + country + "_Animals";
    MySqlCommand cd = new MySqlCommand (query, cs);
    cs.Open ();
    MySqlDataReader ddlSpecie = cd.ExecuteReader ();
    DdPetPist.DataSource = ddlSpecie;
    DdPetPist.DataValueField = "Specie";
    DdPetPist.DataTextField = "Specie";
    DdPetPist.DataBind ();
    cs.Close ();
    cs.Dispose ();
}

