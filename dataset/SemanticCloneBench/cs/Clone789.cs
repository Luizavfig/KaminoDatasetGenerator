/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:42266319
*  Stack Overflow answer #:42267098
*  And Stack Overflow answer#:42267098
*/
void OnShapeBrushChanged () {
    Brush rtn = default (Brush);
    for (int i = 0; i < ShapeChildren.Count; i ++) {
        Shape shape = ShapeChildren [i];
        if (i == 0) {
            rtn = shape.Fill;
        } else if (rtn != shape.Fill) {
            SetValue (FillDifferentProperty, default (Brush));
        } else
            SetValue (FillDifferentProperty, rtn);
    }
}

private static void OnFillPropertyChanged (DependencyObject d, DependencyPropertyChangedEventArgs e) {
    SvgGroup svg = (SvgGroup) d;
    if (e.NewValue != null && ! e.NewValue.Equals (e.OldValue)) {
        foreach (Shape shape in d.ShapeChildren) {
            shape.Fill = (Brush) e.NewValue;
        }
        d.OnShapeBrushChanged ();
    }
}

