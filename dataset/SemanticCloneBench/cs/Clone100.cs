/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:46203215
*  Stack Overflow answer #:46212622
*  And Stack Overflow answer#:46204427
*/
Type MakeGenericType (Type type, Type parameter, ref bool replaced) {
    if (type.IsGenericParameter)
        if (replaced)
            return type;
        else {
            replaced = true;
            return parameter;
        }
    if (type.IsGenericTypeDefinition) {
        var parameters = type.GetTypeInfo ().GenericTypeParameters.ToArray ();
        parameters [0] = parameter;
        replaced = true;
        return type.MakeGenericType (parameters);
    }
    if (type.IsGenericType && type.ContainsGenericParameters) {
        var parameters = type.GenericTypeArguments.ToArray ();
        for (int i = 0; i < parameters.Length; i ++)
            parameters [i] = MakeGenericType (parameters [i], parameter, ref replaced);
        return type.GetGenericTypeDefinition ().MakeGenericType (parameters);
    }
    return type;
}

static Type MakeGenericType (Type definition, Type parameter) {
    var definitionStack = new Stack < Type > ();
    var type = definition;
    while (! type.IsGenericTypeDefinition) {
        definitionStack.Push (type.GetGenericTypeDefinition ());
        type = type.GetGenericArguments () [0];
    }
    type = type.MakeGenericType (parameter);
    while (definitionStack.Count > 0)
        type = definitionStack.Pop ().MakeGenericType (type);
    return type;
}

