/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:2292360
*  Stack Overflow answer #:29209268
*  And Stack Overflow answer#:23608859
*/
public static void OnAutoScrollToCurrentItemChanged (DependencyObject obj, DependencyPropertyChangedEventArgs e) {
    var listBox = obj as ListBox;
    if (listBox == null)
        return;
    var newValue = (bool) e.NewValue;
    if (newValue)
        listBox.SelectionChanged += listBoxSelectionChanged;
    else
        listBox.SelectionChanged -= listBoxSelectionChanged;
}

public static void OnAutoScrollToCurrentItemChanged (DependencyObject s, DependencyPropertyChangedEventArgs e) {
    var listBox = s as ListBox;
    if (listBox != null) {
        var listBoxItems = listBox.Items;
        if (listBoxItems != null) {
            var newValue = (bool) e.NewValue;
            var autoScrollToCurrentItemWorker = new EventHandler ((s1, e2) = > OnAutoScrollToCurrentItem (listBox, listBox.Items.CurrentPosition));
            if (newValue)
                listBoxItems.CurrentChanged += autoScrollToCurrentItemWorker;
            else
                listBoxItems.CurrentChanged -= autoScrollToCurrentItemWorker;
        }
    }
}

