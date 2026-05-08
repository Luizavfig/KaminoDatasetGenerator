/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:505353
*  Stack Overflow answer #:25572779
*  And Stack Overflow answer#:13701716
*/
public void DisableForm (ControlCollection ctrls) {
    foreach (Control ctrl in ctrls) {
        if (ctrl is TextBox)
            ((TextBox) ctrl).Enabled = false;
        if (ctrl is Button)
            ((Button) ctrl).Enabled = false;
        else if (ctrl is DropDownList)
            ((DropDownList) ctrl).Enabled = false;
        else if (ctrl is CheckBox)
            ((CheckBox) ctrl).Enabled = false;
        else if (ctrl is RadioButton)
            ((RadioButton) ctrl).Enabled = false;
        else if (ctrl is HtmlInputButton)
            ((HtmlInputButton) ctrl).Disabled = true;
        else if (ctrl is HtmlInputText)
            ((HtmlInputText) ctrl).Disabled = true;
        else if (ctrl is HtmlSelect)
            ((HtmlSelect) ctrl).Disabled = true;
        else if (ctrl is HtmlInputCheckBox)
            ((HtmlInputCheckBox) ctrl).Disabled = true;
        else if (ctrl is HtmlInputRadioButton)
            ((HtmlInputRadioButton) ctrl).Disabled = true;
        DisableForm (ctrl.Controls);
    }
}

private void ControlStateSwitch (bool state) {
    foreach (var x in from Control c in Page.Controls
        from Control x in c.Controls
        select x)
        if (ctrl is ASPxTextBox)
            ((ASPxTextBox) x).Enabled = status;
        else if (x is ASPxDateEdit)
            ((ASPxDateEdit) x).Enabled = status;
}

