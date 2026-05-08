/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:30791592
*  Stack Overflow answer #:30792106
*  And Stack Overflow answer#:30791885
*/
public bool PreFilterMessage (ref System.Windows.Forms.Message Msg) {
    const int WM_LBUTTONDOWN = 0x0201;
    if (Msg.Msg == WM_LBUTTONDOWN) {
        Control ClickedControl = System.Windows.Forms.Control.FromChildHandle (Msg.HWnd);
        if (ClickedControl != null) {
            Button ClickedButton = ClickedControl as Button;
            if (ClickedButton != null) {
                System.Diagnostics.Debug.WriteLine ("CLICK =  Form: " + ClickedButton.Parent.Text + "  Control: " + ClickedButton.Text);
            }
        }
    }
    return false;
}

public bool PreFilterMessage (ref Message m) {
    if (m.Msg == 0x0201) {
        var ctrl = Control.FromHandle (m.HWnd);
        if (ctrl is Button)
            Debug.WriteLine (ctrl.Name);
    }
    return false;
}

