/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:1478022
*  Stack Overflow answer #:2328519
*  And Stack Overflow answer#:3944375
*/
private Point GetLocationRelativeToForm (Control c) {
    Point controlLocationRelativeToForm1 = new Point ();
    Control currentControl = c;
    while (currentControl.Parent != null) {
        controlLocationRelativeToForm1.Offset (currentControl.Left, currentControl.Top);
        currentControl = currentControl.Parent;
    }
    Point controlScreenPoint = c.PointToScreen (Point.Empty);
    Point formScreenPoint = PointToScreen (Point.Empty);
    Point controlLocationRelativeToForm2 = controlScreenPoint - new Size (formScreenPoint);
    Point locationOnForm = c.FindForm ().PointToClient (c.Parent.PointToScreen (c.Location));
    Debug.Assert (controlLocationRelativeToForm1 == controlLocationRelativeToForm2);
    Debug.Assert (locationOnForm == controlLocationRelativeToForm1);
    Debug.Assert (locationOnForm == controlLocationRelativeToForm2);
    return controlLocationRelativeToForm1;
}

private Point FindLocation (Control ctrl) {
    if (ctrl.Parent is Form)
        return ctrl.Location;
    else {
        Point p = FindLocation (ctrl.Parent);
        p.X += ctrl.Location.X;
        p.Y += ctrl.Location.Y;
        return p;
    }
}

