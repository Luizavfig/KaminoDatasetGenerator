/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:1647815
*  Stack Overflow answer #:12184020
*  And Stack Overflow answer#:31292989
*/
void DataGridCellPreviewMouseLeftButtonDown (object sender, System.Windows.Input.MouseButtonEventArgs e) {
    DataGridCell cell = sender as DataGridCell;
    if (cell != null && ! cell.IsEditing && ! cell.IsReadOnly) {
        if (! cell.IsFocused) {
            cell.Focus ();
        }
        DataGrid dataGrid = LogicalTreeWalker.FindParentOfType < DataGrid > (cell);
        if (dataGrid != null) {
            if (dataGrid.SelectionUnit != DataGridSelectionUnit.FullRow) {
                if (! cell.IsSelected)
                    cell.IsSelected = true;
            } else {
                DataGridRow row = LogicalTreeWalker.FindParentOfType < DataGridRow > (cell);
                if (row != null && ! row.IsSelected) {
                    row.IsSelected = true;
                }
            }
        }
    }
}

private static void OnIsEnabledForStyleChanged (DependencyObject d, DependencyPropertyChangedEventArgs e) {
    UIElement uie = d as UIElement;
    if (uie != null) {
        var behColl = Interaction.GetBehaviors (uie);
        var existingBehavior = behColl.FirstOrDefault (b = > b.GetType () == typeof (TBehavior)) as TBehavior;
        if ((bool) e.NewValue == false && existingBehavior != null) {
            behColl.Remove (existingBehavior);
        } else if ((bool) e.NewValue == true && existingBehavior == null) {
            behColl.Add (new TBehavior ());
        }
    }
}

