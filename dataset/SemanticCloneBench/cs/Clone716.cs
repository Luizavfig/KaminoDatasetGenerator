/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:799655
*  Stack Overflow answer #:799791
*  And Stack Overflow answer#:2147312
*/
private static Control FindControlIterative (this Control control, string id) {
    Control ctl = control;
    LinkedList < Control > controls = new LinkedList < Control > ();
    while (ctl != null) {
        if (ctl.ID == id) {
            return ctl;
        }
        foreach (Control child in ctl.Controls) {
            if (child.ID == id) {
                return child;
            }
            if (child.HasControls ()) {
                controls.AddLast (child);
            }
        }
        ctl = controls.First.Value;
        controls.Remove (ctl);
    }
    return null;
}

public static Control FindControlRecursive (string controlId, Control parent) {
    foreach (Control control in parent.Controls) {
        Control result = FindControlRecursive (controlId, control);
        if (result != null) {
            return result;
        }
    }
    return parent.FindControl (controlId);
}

