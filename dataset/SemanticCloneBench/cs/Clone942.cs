/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:682904
*  Stack Overflow answer #:682931
*  And Stack Overflow answer#:682967
*/
public static IEnumerable < TResult > Zip < TFirst, TSecond, TResult > (this IEnumerable < TFirst > first, IEnumerable < TSecond > second, Func < TFirst, TSecond, TResult > func) {
    if (first == null)
        throw new ArgumentNullException ("first");
    if (second == null)
        throw new ArgumentNullException ("second");
    if (func == null)
        throw new ArgumentNullException ("func");
    using (var ie1 = first.GetEnumerator ())
    using (var ie2 = second.GetEnumerator ())
    while (ie1.MoveNext () && ie2.MoveNext ())
        yield return func (ie1.Current, ie2.Current);
}

IEnumerable < KeyValuePair < T, U > > Merge < T, U > (IEnumerable < T > keyCollection, IEnumerable < U > valueCollection) {
    var keys = keyCollection.GetEnumerator ();
    var values = valueCollection.GetEnumerator ();
    try {
        keys.Reset ();
        values.Reset ();
        while (keys.MoveNext () && values.MoveNext ()) {
            yield return new KeyValuePair < T, U > (keys.Current, values.Current);
        }
    }
    finally {
        keys.Dispose ();
        values.Dispose ();
    }
}

