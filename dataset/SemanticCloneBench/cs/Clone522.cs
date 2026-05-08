/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:37832232
*  Stack Overflow answer #:37834555
*  And Stack Overflow answer#:37832644
*/
public void EnableControls (ControlCollection ctrl, bool isEnable) {
    foreach (Control item in ctrl) {
        if (item.HasControls ())
            EnableControls (item.Controls, isEnable);
        else if (item is WebControl)
            ((WebControl) item).Enabled = isEnable;
        else if (item is HtmlControl)
            ((HtmlControl) item).Disabled = ! isEnable;
    }
}

public static void EnableControls (this Page page, ControlCollection ctrl, bool isEnable) {
    if (ctrl == null)
        ctrl = page.Controls;
    foreach (Control item in ctrl) {
        if (item.Controls.Count > 0)
            EnableControls (page, item.Controls, isEnable);
        if (item.GetType () == typeof (DropDownList))
            ((DropDownList) item).Enabled = isEnable;
        else if (item.GetType () == typeof (TextBox))
            ((TextBox) item).Enabled = isEnable;
        else if (item.GetType () == typeof (Button))
            ((Button) item).Enabled = isEnable;
        else if (item.GetType () == typeof (HtmlInputButton))
            ((HtmlInputButton) item).Disabled = ! isEnable;
    }
}

