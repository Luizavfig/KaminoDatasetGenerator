/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:808006
*  Stack Overflow answer #:808026
*  And Stack Overflow answer#:808033
*/
protected void btnAdd_Click (object sender, EventArgs e) {
    for (Int32 i = lstAvailableColors.Items.Count; i >= 0; i --) {
        ListItem item = lstAvailableColors.Items [i];
        if (item.Selected) {
            lstSelectedColors.Items.Add (item);
            lstAvailableColors.Items.Remove (item);
        }
    }
}

protected void btnAdd_Click (object sender, EventArgs e) {
    var selected = new List < ListItem > ();
    foreach (ListItem item in lstAvailableColors.Items) {
        if (item.Selected) {
            selected.Add (item);
            lstSelectedColors.Items.Add (item);
        }
    }
    foreach (ListItem item in selected) {
        lstAvailableColors.Items.Remove (item);
    }
}

