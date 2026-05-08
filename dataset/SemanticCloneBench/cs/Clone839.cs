/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:42537050
*  Stack Overflow answer #:42538164
*  And Stack Overflow answer#:42538164
*/
private static int ? GetAssemblyDelimiterIndex (string fullyQualifiedTypeName) {
    int scope = 0;
    for (int i = 0; i < fullyQualifiedTypeName.Length; i ++) {
        char current = fullyQualifiedTypeName [i];
        switch (current) {
            case '[' :
                scope ++;
                break;
            case ']' :
                scope --;
                break;
            case ',' :
                if (scope == 0) {
                    return i;
                }
                break;
        }
    }
    return null;
}

public override object ReadJson (JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
    if (reader.TokenType == JsonToken.Null)
        return null;
    var propertyValue = (existingValue as PropertyValue ?? new PropertyValue ());
    var obj = JObject.Load (reader);
    var jValue = obj.GetValue ("CurrentValue", StringComparison.OrdinalIgnoreCase).RemoveFromLowestPossibleParent ();
    serializer.Populate (obj.CreateReader (), propertyValue);
    if (! string.IsNullOrEmpty (propertyValue.TypeName) && jValue != null) {
        string typeName, assemblyName;
        ReflectionUtils.SplitFullyQualifiedTypeName (propertyValue.TypeName, out typeName, out assemblyName);
        var type = serializer.Binder.BindToType (assemblyName, typeName);
        if (type != null)
            propertyValue.SetCurrentValue (jValue.ToObject (type, serializer));
    }
    return propertyValue;
}

