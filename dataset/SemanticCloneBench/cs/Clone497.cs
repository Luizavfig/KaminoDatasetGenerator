/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:13838534
*  Stack Overflow answer #:13838829
*  And Stack Overflow answer#:13838605
*/
private string GetControlValue (string controlId) {
    var control = FindControl (controlId);
    if (control is ITextControl) {
        return ((ITextControl) control).Text;
    } else if (control is ICheckBoxControl) {
        return ((ICheckBoxControl) control).Checked.ToString ();
    } else {
        return null;
    }
}

private string GetControlValue (string controlId) {
    var control = FindControl (controlId);
    var radTextBox = control as RadTextBox;
    if (radTextBox != null) {
        return radTextBox.Text;
    }
    var radComboBox = control as RadComboBox;
    if (radComboBox != null) {
        return radComboBox.SelectedValue;
    }
    var checkBox = control as CheckBox;
    if (checkBox != null) {
        return checkBox.Checked.ToString ();
    }
    return null;
}

