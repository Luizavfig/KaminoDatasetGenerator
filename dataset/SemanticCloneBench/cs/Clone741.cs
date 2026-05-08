/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:18852608
*  Stack Overflow answer #:28767887
*  And Stack Overflow answer#:28767887
*/
private IEnumerable < object [] > GetAllParameterObjects (MethodInfo methodUnderTest) {
    var type = PropertyHost ?? methodUnderTest.DeclaringType;
    var property = type.GetProperty (_propertyName, BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy);
    if (property == null)
        throw new ArgumentException (string.Format ("Could not find public static property {0} on {1}", _propertyName, type.FullName));
    var obj = property.GetValue (null, null);
    if (obj == null)
        return null;
    var enumerable = obj as IEnumerable < object [] >;
    if (enumerable != null)
        return enumerable;
    var singleEnumerable = obj as IEnumerable < object >;
    if (singleEnumerable != null)
        return singleEnumerable.Select (x = > new [] {x});
    throw new ArgumentException (string.Format ("Property {0} on {1} did not return IEnumerable<object[]>", _propertyName, type.FullName));
}

private object [] GetObjects (object [] parameterized, ParameterInfo [] parameters, IFixture fixture) {
    var result = new object [parameters.Length];
    for (int i = 0; i < parameters.Length; i ++) {
        if (i < parameterized.Length)
            result [i] = parameterized [i];
        else
            result [i] = CustomizeAndCreate (fixture, parameters [i]);
    }
    return result;
}

