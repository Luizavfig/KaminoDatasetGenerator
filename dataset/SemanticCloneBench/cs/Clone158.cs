/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:17642858
*  Stack Overflow answer #:17643510
*  And Stack Overflow answer#:17643201
*/
public void ResetFields (Control.ControlCollection Controls) {
    foreach (Control control in Controls) {
        if (control is TextBox) {
            control.Text = string.Empty;
        } else if (control is NumericUpDown) {
            ((NumericUpDown) control).Value = 3;
        } else if (control.Controls.Count > 0) {
            this.ResetFields (control.Controls);
        }
    }
}

public void ResetFields (Control.ControlCollection Controls) {
    foreach (Control control in Controls) {
        if (control is TextBox) {
            control.Text = string.Empty;
        }
        if (control is NumericUpDown) {
            NumericUpDown updown = control as NumericUpDown;
            updown.Value = 3;
        }
        if (control.Controls.Count > 0) {
            this.ResetFields (control.Controls);
        }
    }
}

