/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:4086105
*  Stack Overflow answer #:5836630
*  And Stack Overflow answer#:4086979
*/
private static void ExpandItemWithInitialExpandedAttribute (PropertyGrid propertyGrid, GridItem gridItem) {
    if (gridItem != null) {
        if (gridItem.GridItemType == GridItemType.Property && gridItem.Expandable) {
            object [] objs = gridItem.Value.GetType ().GetCustomAttributes (typeof (PropertyGridInitialExpandedAttribute), false);
            if (objs.Length > 0) {
                if (((PropertyGridInitialExpandedAttribute) objs [0]).InitialExpanded) {
                    gridItem.Expanded = true;
                }
            }
        }
        foreach (GridItem childItem in gridItem.GridItems) {
            ExpandItemWithInitialExpandedAttribute (propertyGrid, childItem);
        }
    }
}

private static void ExpandGroup (PropertyGrid propertyGrid, string groupName) {
    GridItem root = propertyGrid.SelectedGridItem;
    while (root.Parent != null)
        root = root.Parent;
    if (root != null) {
        foreach (GridItem g in root.GridItems) {
            if (g.GridItemType == GridItemType.Category && g.Label == groupName) {
                g.Expanded = true;
                break;
            }
        }
    }
}

