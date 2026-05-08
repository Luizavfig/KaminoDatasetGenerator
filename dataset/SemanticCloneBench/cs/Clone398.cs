/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:4256928
*  Stack Overflow answer #:4257207
*  And Stack Overflow answer#:4257196
*/
static void Main (string [] args) {
    Stopwatch sw = new Stopwatch ();
    const int NUM_ITEMS = 10000;
    const int NUM_LOOPS2 = 1000000000;
    List < int > lst = new List < int > (NUM_ITEMS);
    IList < int > ilst = lst;
    for (int i = 0; i < NUM_ITEMS; i ++) {
        lst.Add (i);
    }
    int count = 0;
    sw.Reset ();
    sw.Start ();
    for (int i = 0; i < NUM_LOOPS2; i ++) {
        count = lst.Count;
    }
    sw.Stop ();
    Console.Out.WriteLine ("Took " + (sw.ElapsedMilliseconds) + "ms - 1.");
    sw.Reset ();
    sw.Start ();
    for (int i = 0; i < NUM_LOOPS2; i ++) {
        count = ilst.Count;
    }
    sw.Stop ();
    Console.Out.WriteLine ("Took " + (sw.ElapsedMilliseconds) + "ms - 2.");
}

static void Main (string [] args) {
    MyClass c = new MyClass ();
    c.InstanceMethod ();
    c.InterfaceMethod ();
    TestInterface (c, 1);
    TestConcrete (c, 1);
    Stopwatch watch = Stopwatch.StartNew ();
    watch.Start ();
    var x = watch.ElapsedMilliseconds;
    watch = Stopwatch.StartNew ();
    TestInterface (c, Int32.MaxValue - 2);
    var ms = watch.ElapsedMilliseconds;
    Console.WriteLine ("Interface: " + ms);
    watch = Stopwatch.StartNew ();
    TestConcrete (c, Int32.MaxValue - 2);
    ms = watch.ElapsedMilliseconds;
    Console.WriteLine ("Concrete: " + ms);
}

