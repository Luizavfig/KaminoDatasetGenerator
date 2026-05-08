/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:15666703
*  Stack Overflow answer #:15666984
*  And Stack Overflow answer#:15666793
*/
private void button6_Click (object sender, EventArgs e) {
    string select = (listView1.SelectedItems.Count > 0) ? (listView1.SelectedItems [0].Text) : null;
    if (! string.IsNullOrWhiteSpace (select)) {
        listView1.BeginUpdate ();
        pths.Remove (select);
        rec.Remove (select);
        listView1.EndUpdate ();
        string s = String.Join ("; ", pths.ToArray ());
        string r = String.Join ("; ", rec.ToArray ());
    }
    Disp ();
}

private void button6_Click (object sender, EventArgs e) {
    foreach (ListViewItem eachItem in listView1.SelectedItems) {
        listView1.Items.Remove (eachItem);
        if (pths.Any (o = > o == eachItem.Text)) {
            pths.Remove (eachItem.Text);
        }
        if (rec.Any (o = > o == eachItem.Text)) {
            rec.Remove (eachItem.Text);
        }
    }
}

