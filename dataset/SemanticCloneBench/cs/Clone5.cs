/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:20564862
*  Stack Overflow answer #:28647821
*  And Stack Overflow answer#:36484715
*/
static void ResourceKeyChanged (DependencyObject d, DependencyPropertyChangedEventArgs e) {
    var target = d as FrameworkElement;
    var newVal = e.NewValue as Tuple < object, DependencyProperty >;
    if (target == null || newVal == null)
        return;
    var dp = newVal.Item2;
    if (newVal.Item1 == null) {
        target.SetValue (dp, dp.GetMetadata (target).DefaultValue);
        return;
    }
    target.SetResourceReference (dp, newVal.Item1);
}

private static void ResourceKeyChanged (DependencyObject d, DependencyPropertyChangedEventArgs e) {
    var fe = d as FrameworkElement;
    if (fe != null) {
        lock (locker)
        {
            DependencyProperty targetProperty;
            if (ReverseMap.TryGetValue (e.Property, out targetProperty)) {
                fe.SetResourceReference (targetProperty, e.NewValue);
            }
        }}
}

