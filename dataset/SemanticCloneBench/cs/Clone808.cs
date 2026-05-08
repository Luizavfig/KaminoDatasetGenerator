/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:326802
*  Stack Overflow answer #:384756
*  And Stack Overflow answer#:384756
*/
private static void IsCheckedChanged (DependencyObject d, DependencyPropertyChangedEventArgs e) {
    if (isValueChanging)
        return;
    bool ? isChecked = (bool ?) e.NewValue;
    if (isChecked != null) {
        BindingExpression exp = BindingOperations.GetBindingExpression (d, ValueProperty);
        object dataItem = GetUnderlyingDataItem (exp.DataItem);
        PropertyInfo pi = dataItem.GetType ().GetProperty (exp.ParentBinding.Path.Path);
        byte mask = Convert.ToByte (GetMask (d));
        byte value = Convert.ToByte (pi.GetValue (dataItem, null));
        if (isChecked.Value) {
            if ((value & mask) == 0) {
                value = (byte) (value + mask);
            }
        } else {
            if ((value & mask) != 0) {
                value = (byte) (value - mask);
            }
        }
        pi.SetValue (dataItem, value, null);
    }
}

private static void ValueChanged (DependencyObject d, DependencyPropertyChangedEventArgs e) {
    isValueChanging = true;
    byte mask = Convert.ToByte (GetMask (d));
    byte value = Convert.ToByte (e.NewValue);
    BindingExpression exp = BindingOperations.GetBindingExpression (d, IsCheckedProperty);
    object dataItem = GetUnderlyingDataItem (exp.DataItem);
    PropertyInfo pi = dataItem.GetType ().GetProperty (exp.ParentBinding.Path.Path);
    pi.SetValue (dataItem, (value & mask) != 0, null);
    ((CheckBox) d).IsChecked = (value & mask) != 0;
    isValueChanging = false;
}

