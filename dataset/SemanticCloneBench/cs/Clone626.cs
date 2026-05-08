/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:12759177
*  Stack Overflow answer #:12760163
*  And Stack Overflow answer#:12759738
*/
private void mainForm_KeyDown (object sender, KeyEventArgs e) {
    if (e.KeyCode.Equals (Keys.Enter)) {
        if (txtUserName.Text.Length > 0) {
            if (txtUserName.Focused) {
                Regex rg = new Regex (txtUserName.Text, RegexOptions.IgnoreCase);
                for (int i = 0; i < txtUserName.AutoCompleteCustomSource.Count; i ++) {
                    if (rg.IsMatch (txtUserName.AutoCompleteCustomSource [i])) {
                        txtUserName.Text = txtUserName.AutoCompleteCustomSource [i];
                        txtPassword.Focus ();
                        return;
                    }
                }
            }
            if (txtPassword.Text.Length > 0) {
                btnLogin_Click (null, null);
            } else {
                txtPassword.Focus ();
            }
        } else {
            txtUserName.Focus ();
        }
    }
}

private void btnLogin_Click (object sender, EventArgs e) {
    if (txtUserName.Text.Equals ("Administrator") && txtPassword.Text.Equals ("123")) {
        MessageBox.Show ("Administrator");
    } else if (txtUserName.Text.Equals ("Clerk") && txtPassword.Text.Equals ("123")) {
        MessageBox.Show ("Clerk");
    } else {
        MessageBox.Show ("Please Enter correct details", "Login Error");
    }
}

