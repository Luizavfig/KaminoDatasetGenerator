/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:15070743
*  Stack Overflow answer #:15072437
*  And Stack Overflow answer#:15070830
*/
private List < string > Process (IEnumerable < string > input) {
    List < string > data = new List < string > ();
    int preExpandCount = 0, offset = 0;
    foreach (string inputItem in input) {
        List < string > splitItems = inputItem.Split (',').ToList ();
        if (data.Count > 0)
            preExpandCount = ExpandList (data, splitItems.Count - 1);
        offset = 0;
        foreach (string splitItem in splitItems) {
            if (preExpandCount == 0)
                data.Add (splitItem);
            else {
                for (int i = 0; i < preExpandCount; i ++)
                    data [i + offset] = String.Format ("{0},{1}", data [i + offset], splitItem);
                offset += preExpandCount;
            }
        }
    }
    return data.OrderBy (e = > e).ToList ();
}

static IEnumerable < string > Permutations (IEnumerable < string > input, char separator) {
    var sepAsString = separator.ToString ();
    var enumerators = input.Select (s = > s.Split (separator).GetEnumerator ()).ToArray ();
    if (! enumerators.All (e = > e.MoveNext ()))
        yield break;
    while (true) {
        yield return String.Join (sepAsString, enumerators.Select (e = > e.Current));
        if (enumerators.Reverse ().All (e = > {
            bool finished = ! e.MoveNext ();
            if (finished) {
                e.Reset ();
                e.MoveNext ();
            }
            return finished;
        }))
            yield break;
    }
}

