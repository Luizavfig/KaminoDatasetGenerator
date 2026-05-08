/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:10126460
*  Stack Overflow answer #:10127030
*  And Stack Overflow answer#:10233188
*/
static void Main (string [] args) {
    var input = Console.ReadLine ();
    var test = new ListArrayLoop (10000, 1000);
    switch (input) {
        case "1" :
            Test (test.ListSum);
            break;
        case "2" :
            Test (test.ArraySum);
            break;
        case "3" :
            test.ArraySum ();
            Test (test.ListSum);
            break;
        default :
            test.ListSum ();
            Test (test.ArraySum);
            break;
    }
}

static void Main (string [] args) {
    Process.GetCurrentProcess ().ProcessorAffinity = new IntPtr (2);
    System.Threading.Thread.BeginThreadAffinity ();
    Console.Write ("Enter test number (1|2): ");
    string input = Console.ReadLine ();
    ListArrayLoop warmup = new ListArrayLoop (10, 10);
    Console.WriteLine ("Performing warmup...");
    Test (warmup.ListSum);
    Test (warmup.ArraySum);
    Console.WriteLine ("Warmup complete...");
    Console.WriteLine ();
    ListArrayLoop test = new ListArrayLoop (10000, 10000);
    if (input == "1") {
        Test (test.ListSum);
        Test (test.ListSum);
        Test (test.ArraySum);
        Test (test.ListSum);
    } else {
        Test (test.ArraySum);
        Test (test.ArraySum);
        Test (test.ListSum);
        Test (test.ArraySum);
    }
}

