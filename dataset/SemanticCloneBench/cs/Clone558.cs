/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:10080601
*  Stack Overflow answer #:19024356
*  And Stack Overflow answer#:29224637
*/
private void SetTableDescriptions (Type tableType) {
    string fullTableName = context.GetTableName (tableType);
    Regex regex = new Regex (@"(\[\w+\]\.)?\[(?<table>.*)\]");
    Match match = regex.Match (fullTableName);
    string tableName;
    if (match.Success)
        tableName = match.Groups ["table"].Value;
    else
        tableName = fullTableName;
    var tableAttrs = tableType.GetCustomAttributes (typeof (TableAttribute), false);
    if (tableAttrs.Length > 0)
        tableName = ((TableAttribute) tableAttrs [0]).Name;
    foreach (var prop in tableType.GetProperties (System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance)) {
        if (prop.PropertyType.IsClass && prop.PropertyType != typeof (string))
            continue;
        var attrs = prop.GetCustomAttributes (typeof (DisplayAttribute), false);
        if (attrs.Length > 0)
            SetColumnDescription (tableName, prop.Name, ((DisplayAttribute) attrs [0]).Name);
    }
}

private void SetTableDescriptions (Type tableType) {
    string fullTableName = context.GetTableName (tableType);
    Regex regex = new Regex (@"(\[\w+\]\.)?\[(?<table>.*)\]");
    Match match = regex.Match (fullTableName);
    string tableName;
    if (match.Success)
        tableName = match.Groups ["table"].Value;
    else
        tableName = fullTableName;
    var tableAttrs = tableType.GetCustomAttributes (typeof (TableAttribute), false);
    if (tableAttrs.Length > 0)
        tableName = ((TableAttribute) tableAttrs [0]).Name;
    string tableComment = reader.GetCommentsForResource (tableType, null, XmlResourceType.Type);
    if (! string.IsNullOrEmpty (tableComment))
        SetDescriptionForObject (tableName, null, tableComment);
    ObjectDocumentation [] columnComments = reader.GetCommentsForResource (tableType);
    foreach (var column in columnComments) {
        SetDescriptionForObject (tableName, column.PropertyName, column.Documentation);
    }
}

