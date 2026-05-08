/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:6639219
*  Stack Overflow answer #:6647579
*  And Stack Overflow answer#:6647579
*/
public object CallMethod (object instance, MethodInfo methodInfo, Dictionary < string, string > parameters) {
    var methodParameters = methodInfo.GetParameters ();
    var parametersForInvocation = new List < object > ();
    foreach (var methodParameter in methodParameters) {
        string value;
        if (parameters.TryGetValue (methodParameter.Name, out value)) {
            var convertedValue = ConvertStringToNewType (value, methodParameter.ParameterType);
            parametersForInvocation.Add (convertedValue);
        } else {
            var defaultValue = Activator.CreateInstance (methodParameter.ParameterType);
            parametersForInvocation.Add (defaultValue);
        }
    }
    return methodInfo.Invoke (instance, parametersForInvocation.ToArray ());
}

public object ConvertStringToNewNonNullableType (string value, Type newType) {
    if (newType.IsArray) {
        Type singleItemType = newType.GetElementType ();
        var elements = new ArrayList ();
        foreach (var element in value.Split (',')) {
            var convertedSingleItem = ConvertSingleItem (element, singleItemType);
            elements.Add (convertedSingleItem);
        }
        return elements.ToArray (singleItemType);
    }
    return ConvertSingleItem (value, newType);
}

