/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:1316251
*  Stack Overflow answer #:1316377
*  And Stack Overflow answer#:1316377
*/
public static childItem FindVisualChild < childItem > (DependencyObject obj) where childItem : DependencyObject {
    for (int i = 0; i < VisualTreeHelper.GetChildrenCount (obj); i ++) {
        DependencyObject child = VisualTreeHelper.GetChild (obj, i);
        if (child != null && child is childItem)
            return (childItem) child;
        else {
            childItem childOfChild = FindVisualChild < childItem > (child);
            if (childOfChild != null)
                return childOfChild;
        }
    }
    return null;
}

private void ItemsList_DragOver (object sender, System.Windows.DragEventArgs e) {
    ListBox li = sender as ListBox;
    ScrollViewer sv = FindVisualChild < ScrollViewer > (ItemsList);
    double tolerance = 10;
    double verticalPos = e.GetPosition (li).Y;
    double offset = 3;
    if (verticalPos < tolerance) {
        sv.ScrollToVerticalOffset (sv.VerticalOffset - offset);
    } else if (verticalPos > li.ActualHeight - tolerance) {
        sv.ScrollToVerticalOffset (sv.VerticalOffset + offset);
    }
}

