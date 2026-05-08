/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:42172946
*  Stack Overflow answer #:42173169
*  And Stack Overflow answer#:42176423
*/
public static ScrollViewer FindScrollViewer (FlowDocumentScrollViewer flowDocumentScrollViewer) {
    if (VisualTreeHelper.GetChildrenCount (flowDocumentScrollViewer) == 0) {
        return null;
    }
    DependencyObject firstChild = VisualTreeHelper.GetChild (flowDocumentScrollViewer, 0);
    if (firstChild == null) {
        return null;
    }
    Decorator border = VisualTreeHelper.GetChild (firstChild, 0) as Decorator;
    if (border == null) {
        return null;
    }
    return border.Child as ScrollViewer;
}

public static IEnumerable < T > FindVisualChildren < T > (DependencyObject depObj) where T : DependencyObject {
    if (depObj != null) {
        for (int i = 0; i < VisualTreeHelper.GetChildrenCount (depObj); i ++) {
            DependencyObject child = VisualTreeHelper.GetChild (depObj, i);
            if (child != null && child is T) {
                yield return (T) child;
            }
            foreach (T childOfChild in FindVisualChildren < T > (child)) {
                yield return childOfChild;
            }
        }
    }
}

