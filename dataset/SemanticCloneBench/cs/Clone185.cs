/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:2708436
*  Stack Overflow answer #:2761741
*  And Stack Overflow answer#:2712643
*/
static void Main (string [] args) {
    var ns = new List < int > ();
    for (int i = 0; i < 1000; i ++)
        ns.Add (1);
    var s1 = Stopwatch.StartNew ();
    bool result = SubsetSum (ns, 1000);
    s1.Stop ();
    Console.WriteLine (result);
    Console.WriteLine (s1.Elapsed);
    Console.Read ();
}

static void Main (string [] args) {
    List < int > testList = new List < int > ();
    for (int i = 0; i < 1000; ++ i) {
        testList.Add (1);
    }
    Console.WriteLine (SubsetSum.Find (testList, 1000));
    foreach (int index in SubsetSum.GetLastResult (1000)) {
        Console.WriteLine (index);
    }
}

