/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:32856055
*  Stack Overflow answer #:32856144
*  And Stack Overflow answer#:32856213
*/
private void btnClear_Click (object sender, EventArgs e) {
    for (byte i = 0; i < TextBoxes.Length; i ++) {
        if (this.Controls.ContainsKey ("txt" + TextBoxes [i])) {
            TextBox txtBox = this.Controls ["txt" + TextBoxes [i]] as TextBox;
            if (txtBox != null) {
                txtBox.Text = "";
            }
        }
    }
}

void ClearTextBox (Control c) {
    var t = c as Textbox;
    if (t != null)
        t.Value = string.Empty;
    foreach (var child in c.Controls)
        ClearTextBox (child);
}

