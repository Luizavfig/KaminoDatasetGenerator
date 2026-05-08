/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:7351289
*  Stack Overflow answer #:28020413
*  And Stack Overflow answer#:17705883
*/
private static bool DynamicCast (object source, Type destType, out object result) {
    Type srcType = source.GetType ();
    if (srcType == destType) {
        result = source;
        return true;
    }
    result = null;
    BindingFlags bf = BindingFlags.Static | BindingFlags.Public;
    MethodInfo castOperator = destType.GetMethods (bf).Union (srcType.GetMethods (bf)).Where (mi = > mi.Name == "op_Explicit" || mi.Name == "op_Implicit").Where (mi = > {
        var pars = mi.GetParameters ();
        return pars.Length == 1 && pars [0].ParameterType == srcType;
    }).Where (mi = > mi.ReturnType == destType).FirstOrDefault ();
    if (castOperator != null)
        result = castOperator.Invoke (null, new object [] {source});
    else
        return false;
    return true;
}

private static object DynamicCast (object source, Type destType) {
    Type srcType = source.GetType ();
    if (srcType == destType)
        return source;
    var paramTypes = new Type [] {srcType};
    MethodInfo cast = destType.GetMethod ("op_Implicit", paramTypes);
    if (cast == null) {
        cast = destType.GetMethod ("op_Explicit", paramTypes);
    }
    if (cast != null)
        return cast.Invoke (null, new object [] {source});
    if (destType.IsEnum)
        return Enum.ToObject (destType, source);
    throw new InvalidCastException ();
}

