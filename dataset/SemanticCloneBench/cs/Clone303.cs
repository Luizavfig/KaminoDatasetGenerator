/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:708205
*  Stack Overflow answer #:708406
*  And Stack Overflow answer#:708306
*/
public static bool AreSame (Type sourceType, Type destinationType) {
    if (sourceType == null || destinationType == null) {
        return false;
    }
    if (sourceType == destinationType) {
        return true;
    }
    Type tempDestinationType = destinationType;
    while (tempDestinationType.BaseType != typeof (object)) {
        tempDestinationType = tempDestinationType.BaseType;
    }
    if (tempDestinationType.IsAssignableFrom (sourceType)) {
        return true;
    }
    var query = from d in destinationType.GetInterfaces ()
        join s in sourceType.GetInterfaces () on d.Name equals s.Name
        select s;
    if (query != Enumerable.Empty < Type > ()) {
        return true;
    }
    return false;
}

private bool AreSame (Type a, Type b) {
    if (a == b)
        return true;
    if (a == null || b == null)
        return false;
    if (a.IsSubclassOf (b) || b.IsSubclassOf (a))
        return true;
    return a.BaseType == b.BaseType;
}

