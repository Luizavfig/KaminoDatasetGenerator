/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:19807573
*  Stack Overflow answer #:19809155
*  And Stack Overflow answer#:19809155
*/
static void Main (string [] args) {
    var data = Enumerable.Range (0, 1000);
    var typedWhere1 = data.TypedWhere (x = > x % 2 == 0);
    var typedWhere2 = typedWhere1.TypedWhere (x = > x % 3 == 0);
    var result = typedWhere2.Take (10).ToList ();
    Console.WriteLine ("Result: " + string.Join (",", result));
    Console.WriteLine ("Typed Where 1 Skipped: " + typedWhere1.Skipped);
    Console.WriteLine ("Typed Where 1 Returned: " + typedWhere1.Returned);
    Console.WriteLine ("Typed Where 2 Skipped: " + typedWhere2.Skipped);
    Console.WriteLine ("Typed Where 2 Returned: " + typedWhere2.Returned);
    Console.ReadLine ();
}

IEnumerator < T > IEnumerable < T >.GetEnumerator () {
    foreach (var o in source)
        if (filter (o)) {
            Returned ++;
            yield return o;
        } else
            Skipped ++;
}

