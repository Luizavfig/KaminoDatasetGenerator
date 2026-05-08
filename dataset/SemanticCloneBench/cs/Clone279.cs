/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:463894
*  Stack Overflow answer #:464125
*  And Stack Overflow answer#:464285
*/
public static string Verify (string valueToBind, object dataSource) {
    Type type = dataSource.GetType ();
    MethodInfo select = type.GetMethod ("Select");
    PropertyInfo parameters = type.GetProperty ("Parameters");
    PropertyInfo parameterGetter = null;
    object parametersInstance = null;
    if (parameters != null) {
        parametersInstance = parameters.GetValue (dataSource, null);
        type = parametersInstance.GetType ();
        parameterGetter = type.GetProperty ("Item");
    }
    if (select != null && parameters != null && parameterGetter != null) {
        if (ListContainsValue (baseInstance.GetEntityList (), valueToBind))
            return valueToBind;
        CustomParameter p = parameterGetter.GetValue (parametersInstance, new object [] {"WhereClause"}) as CustomParameter;
        if (p != null) {
            p.Value = "IsActive=true OR Id=" + valueToBind;
            select.Invoke (dataSource, null);
            return valueToBind;
        }
    }
    return string.Empty;
}

public string Verify (string valueToBind, object dataSource) {
    IListDataSource listDataSource = dataSource as IListDataSource;
    if (listDataSource != null) {
        if (ListContainsValue (listDataSource.GetEntityList (), valueToBind))
            return valueToBind;
    }
    Type type = dataSource.GetType ();
    MethodInfo select = type.GetMethod ("Select", new Type [0]);
    PropertyInfo parameterCollectionInfo = type.GetProperty ("Parameters");
    ParameterCollection pc = parameterCollectionInfo.GetValue (dataSource, null) as ParameterCollection;
    if (pc != null) {
        CustomParameter p = pc ["WhereClause"] as CustomParameter;
        if (p != null) {
            p.Value = "IsActive=true OR Id=" + valueToBind;
            select.Invoke (dataSource, null);
            return valueToBind;
        }
    }
    return string.Empty;
}

