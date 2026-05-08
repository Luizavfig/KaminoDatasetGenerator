/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:24703930
*  Stack Overflow answer #:24704402
*  And Stack Overflow answer#:24704402
*/
private void LoadNewCheckboxes () {
    dynamic listGroupCount = 10;
    List < System.Windows.Forms.CheckBox > CheckBoxes = new List < System.Windows.Forms.CheckBox > ();
    for (int i = 0; i <= listGroupCount - 1; i ++) {
        System.Windows.Forms.CheckBox chkbox = new System.Windows.Forms.CheckBox ();
        chkbox.Text = i.ToString ();
        chkbox.Name = "txt" + i.ToString ();
        chkbox.CheckedChanged += new EventHandler (chkbox_CheckedChanged);
        chkbox.CheckStateChanged += new EventHandler (chkbox_CheckStateChanged);
        chkbox.Width = 200;
        chkbox.AutoSize = true;
        this.Controls.Add (chkbox);
        CheckBoxes.Add (chkbox);
        if (i == 0) {
            chkbox.Location = new System.Drawing.Point (5, 10);
        } else {
            chkbox.Location = new System.Drawing.Point (5, (CheckBoxes [i - 1].Top + CheckBoxes [i - 1].Height + 10));
        }
    }
}

private void chkbox_CheckedChanged (object sender, EventArgs e) {
    System.Windows.Forms.CheckBox chkbox = (System.Windows.Forms.CheckBox) sender;
    if (chkbox != null) {
        Debug.WriteLine ("chkbox_CheckedChanged");
        Debug.WriteLine (chkbox.Text);
        Debug.WriteLine (chkbox.Checked.ToString ());
        Debug.WriteLine (chkbox.Name.ToString ());
    }
}

