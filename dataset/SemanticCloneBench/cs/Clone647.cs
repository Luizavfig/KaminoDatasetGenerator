/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:2799427
*  Stack Overflow answer #:2799472
*  And Stack Overflow answer#:26200748
*/
public static int Count < TSource > (this IEnumerable < TSource > source) {
    checked {
        if (source == null) {
            throw Error.ArgumentNull ("source");
        }
        ICollection < TSource > collection = source as ICollection < TSource >;
        if (collection != null) {
            return collection.Count;
        }
        ICollection collection2 = source as ICollection;
        if (collection2 != null) {
            return collection2.Count;
        }
        int num = 0;
        using (IEnumerator < TSource > enumerator = source.GetEnumerator ())
        {
            while (enumerator.MoveNext ()) {
                num ++;
            }
        } return num;
    }
}

private static IEnumerable < TSource > UnionIterator < TSource > (IEnumerable < TSource > first, IEnumerable < TSource > second, IEqualityComparer < TSource > comparer) {
    Set < TSource > set = new Set < TSource > (comparer);
    foreach (TSource source in first) {
        if (set.Add (source))
            yield return source;
    }
    foreach (TSource source in second) {
        if (set.Add (source))
            yield return source;
    }
}

