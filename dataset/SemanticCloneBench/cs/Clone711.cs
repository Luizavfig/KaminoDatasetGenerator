/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:2603436
*  Stack Overflow answer #:2603485
*  And Stack Overflow answer#:2603490
*/
public static IEnumerable < IEnumerable < T > > Segment < T > (IEnumerable < T > sequence, Func < T, T, int, bool > newSegmentIdentifier) {
    var index = - 1;
    using (var iter = sequence.GetEnumerator ())
    {
        var segment = new List < T > ();
        var prevItem = default (T);
        if (iter.MoveNext ()) {
            ++ index;
            segment.Add (iter.Current);
            prevItem = iter.Current;
        }
        while (iter.MoveNext ()) {
            ++ index;
            var isNewSegment = newSegmentIdentifier (iter.Current, prevItem, index);
            prevItem = iter.Current;
            if (! isNewSegment) {
                segment.Add (iter.Current);
                continue;
            }
            yield return segment;
            segment = new List < T > {iter.Current};
        }
        if (segment.Count > 0)
            yield return segment;
    }}

public static List < List < T > > PartitionData < T > (T [] arr, Func < T, bool > flagSelector) {
    List < List < T > > output = new List < List < T > > ();
    List < T > partition = null;
    bool first = true;
    foreach (T obj in arr) {
        if (flagSelector (obj) || first) {
            partition = new List < T > ();
            output.Add (partition);
            first = false;
        }
        partition.Add (obj);
    }
    return output;
}

