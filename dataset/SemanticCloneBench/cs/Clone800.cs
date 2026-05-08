/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:2767007
*  Stack Overflow answer #:2767338
*  And Stack Overflow answer#:2768156
*/
public static IEnumerable < T > MergePreserveOrder4 < T, TOrder > (this IEnumerable < IEnumerable < T > > aa, Func < T, TOrder > orderFunc) where TOrder : IComparable < TOrder > {
    var items = aa.Select (xx = > xx.GetEnumerator ()).Where (ee = > ee.MoveNext ()).Select (ee = > Tuple.Create (orderFunc (ee.Current), ee)).OrderBy (ee = > ee.Item1).ToList ();
    while (items.Count > 0) {
        yield return items [0].Item2.Current;
        var next = items [0];
        items.RemoveAt (0);
        if (next.Item2.MoveNext ()) {
            var value = orderFunc (next.Item2.Current);
            var ii = 0;
            for (; ii < items.Count; ++ ii) {
                if (value.CompareTo (items [ii].Item1) <= 0) {
                    items.Insert (ii, Tuple.Create (value, next.Item2));
                    break;
                }
            }
            if (ii == items.Count)
                items.Add (Tuple.Create (value, next.Item2));
        } else
            next.Item2.Dispose ();
    }
}

public static IEnumerable < T > MergePreserveOrder < T, TOrder > (this IEnumerable < IEnumerable < T > > sources, Func < T, TOrder > orderFunc) where TOrder : IComparable < TOrder > {
    Dictionary < TOrder, List < IEnumerable < T > > > keyedSources = sources.Select (source = > source.GetEnumerator ()).Where (e = > e.MoveNext ()).GroupBy (e = > orderFunc (e.Current)).ToDictionary (g = > g.Key, g = > g.ToList ());
    while (keyedSources.Any ()) {
        KeyValuePair < TOrder, List < IEnumerable < T > > > firstPair = keyedSources.OrderBy (kvp = > kvp.Key).First ();
        keyedSources.Remove (firstPair.Key);
        foreach (IEnumerable < T > e in firstPair.Value) {
            yield return e.Current;
            if (e.MoveNext ()) {
                TOrder newKey = orderFunc (e.Current);
                if (! keyedSources.ContainsKey (newKey)) {
                    keyedSources [newKey] = new List < IEnumerable < T > > () {e};
                } else {
                    keyedSources [newKey].Add (e);
                }
            }
        }
    }
}

