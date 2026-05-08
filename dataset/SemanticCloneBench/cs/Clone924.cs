/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:17665977
*  Stack Overflow answer #:17666581
*  And Stack Overflow answer#:17666431
*/
public static IEnumerable < IList < T > > ChunkOn < T > (this IEnumerable < T > source, Func < T, bool > startChunk) {
    List < T > list = new List < T > ();
    foreach (var item in source) {
        if (startChunk (item) && list.Count > 0) {
            yield return list;
            list = new List < T > ();
        }
        list.Add (item);
    }
    if (list.Count > 0) {
        yield return list;
    }
}

private static IEnumerable < KeyValuePair < TKey, TSource > > AssignKeys < TSource, TKey > (IEnumerable < TSource > source, Func < TSource, bool > takeNextKey, Func < TSource, TKey > keySelector) {
    var key = default (TKey);
    foreach (var item in source) {
        if (takeNextKey (item))
            key = keySelector (item);
        yield return new KeyValuePair < TKey, TSource > (key, item);
    }
}

