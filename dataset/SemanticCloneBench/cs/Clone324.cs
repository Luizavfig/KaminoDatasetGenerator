/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:8868119
*  Stack Overflow answer #:15514201
*  And Stack Overflow answer#:18375526
*/
public static bool InheritsFrom (this Type t, Type baseType) {
    Type cur = t.BaseType;
    while (cur != null) {
        if (cur.Equals (baseType)) {
            return true;
        }
        cur = cur.BaseType;
    }
    return false;
}

public static bool InheritsFrom (this Type type, Type baseType) {
    if (type == null) {
        return false;
    }
    if (baseType == null) {
        return type.IsInterface || type == typeof (object);
    }
    if (baseType.IsInterface) {
        return type.GetInterfaces ().Contains (baseType);
    }
    var currentType = type;
    while (currentType != null) {
        if (currentType.BaseType == baseType) {
            return true;
        }
        currentType = currentType.BaseType;
    }
    return false;
}

