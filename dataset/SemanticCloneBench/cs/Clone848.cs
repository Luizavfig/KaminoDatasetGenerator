/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:32823525
*  Stack Overflow answer #:32825190
*  And Stack Overflow answer#:32823984
*/
[STAThread] static void Main () {
    Application.EnableVisualStyles ();
    Application.SetCompatibleTextRenderingDefault (false);
    var form = new Form ();
    Control [] controls = {new TextBox (), new TextBox (),};
    Button [] buttons = {new NonSelectableButton {Text = "Prev"}, new NonSelectableButton {Text = "Next"},};
    foreach (var button in buttons)
        button.Click += (sender, e) = > MessageBox.Show ("Button " + ((Button) sender).Text + " clicked!");
    int y = 0;
    foreach (var item in controls.Concat (buttons)) {
        item.Left = 8;
        item.Top = y += 8;
        form.Controls.Add (item);
        y = item.Bottom;
    }
    Application.Run (form);
}

private void Form1_KeyPress (object sender, KeyPressEventArgs e) {
    if (this.ActiveControl is Button && e.KeyChar == (char) Keys.Space) {
        var button = this.ActiveControl;
        button.Enabled = false;
        Application.DoEvents ();
        button.Enabled = true;
        button.Focus ();
    }
}

