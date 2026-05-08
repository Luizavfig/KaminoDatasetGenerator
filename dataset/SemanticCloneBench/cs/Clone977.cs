/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:2537823
*  Stack Overflow answer #:34180127
*  And Stack Overflow answer#:24823445
*/
public bool Equals (T left, T right) {
    var leftProp = expr.Invoke (left);
    var rightProp = expr.Invoke (right);
    if (leftProp == null && rightProp == null)
        return true;
    else if (leftProp == null ^ rightProp == null)
        return false;
    else
        return leftProp.Equals (rightProp);
}

public static IEnumerable < TSource > Distinct < TSource, TResult > (this IEnumerable < TSource > source, Func < TSource, TResult > selector) {
    HashSet < TResult > set = new HashSet < TResult > ();
    foreach (var item in source) {
        var selectedValue = selector (item);
        if (set.Add (selectedValue))
            yield return item;
    }
}

