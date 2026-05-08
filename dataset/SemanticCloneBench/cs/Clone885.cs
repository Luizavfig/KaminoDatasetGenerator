/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:7800032
*  Stack Overflow answer #:7804972
*  And Stack Overflow answer#:9971515
*/
private static void ComboBox_SelectionChanged (object sender, SelectionChangedEventArgs e) {
    var comboBox = sender as ComboBox;
    if (comboBox != null && ! (bool) comboBox.Tag) {
        var bndExp = comboBox.GetBindingExpression (Selector.SelectedValueProperty);
        var currentItem = (KeyValuePair < int, int >) comboBox.SelectedItem;
        if (currentItem.Key >= 1 && currentItem.Key <= 4 && bndExp != null) {
            var dr = MessageBox.Show ("Want to select a Key of between 1 and 4?", "Please Confirm.", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (dr == MessageBoxResult.Yes) {
                bndExp.UpdateSource ();
            } else {
                comboBox.Tag = true;
                bndExp.UpdateTarget ();
                comboBox.Tag = false;
            }
        }
    }
}

private static void OnSelectedItemChanged (DependencyObject d, DependencyPropertyChangedEventArgs e) {
    var behavior = (CancellableSelectionBehavior) d;
    if (behavior.AssociatedObject == null) {
        System.Windows.Threading.Dispatcher.CurrentDispatcher.BeginInvoke (new Action (() = > {
            var selector = behavior.AssociatedObject;
            selector.SelectedValue = e.NewValue;
        }));
    } else {
        var selector = behavior.AssociatedObject;
        selector.SelectedValue = e.NewValue;
    }
}

