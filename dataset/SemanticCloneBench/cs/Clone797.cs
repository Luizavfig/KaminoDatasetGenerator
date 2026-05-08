/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:424366
*  Stack Overflow answer #:424385
*  And Stack Overflow answer#:424772
*/
public static string GetStringValue (this AuthenticationMethod value) {
    string output = null;
    Type type = value.GetType ();
    FieldInfo fi = type.GetField (value.ToString ());
    StringValue [] attrs = fi.GetCustomAttributes (typeof (StringValue), false) as StringValue [];
    if (attrs.Length > 0)
        output = attrs [0].Value;
    return output;
}

private static string GetDescription (T optionValue) {
    var optionDescription = optionValue.ToString ();
    var optionInfo = typeof (T).GetField (optionDescription);
    if (Attribute.IsDefined (optionInfo, typeof (DescriptionAttribute))) {
        var attribute = (DescriptionAttribute) Attribute.GetCustomAttribute (optionInfo, typeof (DescriptionAttribute));
        return attribute.Description;
    }
    return optionDescription;
}

