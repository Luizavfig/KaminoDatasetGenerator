/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:9900181
*  Stack Overflow answer #:9900282
*  And Stack Overflow answer#:9900215
*/
private ArrayList GetSameOf2AL (ArrayList first, ArrayList second) {
    ArrayList same = new ArrayList ();
    var one = from int i in first
        select i;
    var two = from int i in second
        select i;
    same.AddRange (one.Intersect (two).ToArray < int > ());
    return same;
}

private ArrayList GetSameOf2AL (ArrayList first, ArrayList second) {
    ArrayList same = new ArrayList ();
    var one = from int i in first
        select i;
    var two = from int i in second
        select i;
    var sameVal = one.Intersect (two);
    foreach (int i in sameVal)
        same.Add (i);
    return same;
}

