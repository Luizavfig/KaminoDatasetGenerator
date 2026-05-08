/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:1947951
*  Stack Overflow answer #:1949265
*  And Stack Overflow answer#:1948004
*/
private void LoadGroup (TGroup group, string groupName, TGrid grid) {
    VList < T > returnList = FetchInformation (group);
    if (Session [groupName] != null) {
        List < T > tempList = (List < T >) Session [groupName];
        returnList.AddRange (tempList);
    }
    grid.DataSource = returnList;
    grid.DataBind ();
}

private void LoadGroup (string option) {
    switch (option.ToUpper ()) {
        case "ALPHA" :
            BindGroup (ManagerContext.Current.Group1, "alphaGroup", uxAlphaGrid);
            break;
        case "BRAVO" :
            BindGroup (ManagerContext.Current.Group2, "bravoGroup", uxBravoGrid);
            break;
        case "CHARLIE" :
            BindGroup (ManagerContext.Current.Group3, "charlieGroup", uxCharlieGrid);
            break;
        case "DELTA" :
            BindGroup (ManagerContext.Current.Group4, "deltaGroup", uxDeltaGrid);
            break;
        default :
            break;
    }
}

