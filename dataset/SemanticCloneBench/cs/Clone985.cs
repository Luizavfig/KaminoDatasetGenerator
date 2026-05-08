/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:41319
*  Stack Overflow answer #:3576549
*  And Stack Overflow answer#:41365
*/
public static bool IsEmpty < T > (this IEnumerable < T > list) {
    if (list == null) {
        throw new ArgumentNullException ("list");
    }
    var genericCollection = list as ICollection < T >;
    if (genericCollection != null) {
        return genericCollection.Count == 0;
    }
    var nonGenericCollection = list as ICollection;
    if (nonGenericCollection != null) {
        return nonGenericCollection.Count == 0;
    }
    return ! list.Any ();
}

public static int Count < T > (this IEnumerable < T > list) {
    if (list is IList < T >)
        return ((IList < T >) list).Count;
    int i = 0;
    foreach (var t in list)
        i ++;
    return i;
}

