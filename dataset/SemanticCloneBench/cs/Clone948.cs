/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:30871093
*  Stack Overflow answer #:30981123
*  And Stack Overflow answer#:31052937
*/
void btnSubmitCountParticipant_Click (object sender, EventArgs e) {
    StringBuilder sbparticipantName = new StringBuilder ();
    Panel p1 = new Panel ();
    try {
        int numberofparticipants = Convert.ToInt32 (drpNoofparticipants.SelectedValue);
        ViewState ["numberofparticipants"] = numberofparticipants;
        Table tableparticipantName = new Table ();
        int rowcount = 1;
        int columnCount = numberofparticipants;
        for (int i = 0; i < rowcount; i ++) {
            TableRow row = new TableRow ();
            for (int j = 0; j < columnCount; j ++) {
                TableCell cell = new TableCell ();
                TextBox txtNameofParticipant = new TextBox ();
                txtNameofParticipant.ID = "txtNameofParticipant" + Convert.ToString (i);
                cell.ID = "cell" + Convert.ToString (i);
                cell.Controls.Add (txtNameofParticipant);
                row.Cells.Add (cell);
            }
            tableparticipantName.Rows.Add (row);
            p1.Controls.Add (tableparticipantName);
        }
        Cache ["TempPanel"] = p1;
        panelNameofParticipants.Controls.Add (p1);
    }
    catch (Exception ex) {
    }
}

protected void btnSave_Click (object sender, EventArgs e) {
    try {
        List < string > listParticipantName = new List < string > ();
        if (ViewState ["numberofparticipants"] != null) {
            int numberofparticipants = Convert.ToInt32 (ViewState ["numberofparticipants"]);
            foreach (Control c in panelNameofParticipants.Controls) {
                if (c is Table) {
                    foreach (TableRow row in c.Controls) {
                        int i = 0;
                        foreach (TableCell cell in row.Controls) {
                            if (cell.Controls [0] is TextBox) {
                                string findcontrol = "txtNameofParticipant" + i;
                                TextBox txtParticipantName = (TextBox) cell.Controls [0].FindControl (findcontrol);
                                listParticipantName.Add (txtParticipantName.Text);
                            }
                            i ++;
                        }
                    }
                }
            }
        }
    }
    catch (Exception ex) {
    }
}

