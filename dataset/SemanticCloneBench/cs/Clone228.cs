/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:1947951
*  Stack Overflow answer #:1949265
*  And Stack Overflow answer#:1947994
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
            BindData ("alphaGroup", uxAlphaGrid, FetchInformation (ManagerContext.Current.Group1));
            break;
        case "BRAVO" :
            BindData ("bravoGroup", uxBravoGrid, FetchInformation (ManagerContext.Current.Group2));
            break;
        case "CHARLIE" :
            BindData ("charlieGroup", uxCharlieGrid, FetchInformation (ManagerContext.Current.Group3));
            break;
        case "DELTA" :
            BindData ("deltaTeam", uxDeltaGrid, FetchInformation (ManagerContext.Current.Group4));
            break;
        default :
            break;
    }
}

