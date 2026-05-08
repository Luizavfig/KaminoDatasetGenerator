/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:13370440
*  Stack Overflow answer #:13370586
*  And Stack Overflow answer#:13370669
*/
static void Main (string [] args) {
    Test1 ("just a little test string.");
    GC.Collect ();
    GC.WaitForPendingFinalizers ();
    Stopwatch timer = new Stopwatch ();
    timer.Start ();
    for (int i = 0; i < 10000; i ++) {
        Test1 ("just a little test string.");
    }
    timer.Stop ();
    Console.WriteLine (timer.Elapsed);
}

static void Main (string [] args) {
    var timer = new Stopwatch ();
    timer.Restart ();
    for (int i = 0; i < 1000; i ++)
        Test1 ("just a little test string.");
    timer.Stop ();
    TimeSpan elapsed1 = timer.Elapsed;
    timer.Restart ();
    for (int i = 0; i < 1000; i ++)
        Test2 ("just a little test string.");
    timer.Stop ();
    TimeSpan elapsed2 = timer.Elapsed;
    timer.Restart ();
    for (int i = 0; i < 1000; i ++)
        Test3 ("just a little test string.");
    timer.Stop ();
    TimeSpan elapsed3 = timer.Elapsed;
    Console.WriteLine (elapsed1);
    Console.WriteLine (elapsed2);
    Console.WriteLine (elapsed3);
    Console.Read ();
}

