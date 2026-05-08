/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:804706
*  Stack Overflow answer #:36024385
*  And Stack Overflow answer#:24829815
*/
public static void Main () {
    int a = 1234;
    int b = 4321;
    Console.WriteLine ("Before: a {0} and b {1}", a, b);
    b = b - a;
    a = a + b;
    b = a - b;
    Console.WriteLine ("After: a {0} and b {1}", a, b);
}

static void Main (string [] args) {
    var a = new object ();
    var b = new object ();
    var s = new Stopwatch ();
    Swap (ref a, ref b);
    s.Restart ();
    for (var i = 0; i < 500000000; i ++) {
        var temp = a;
        a = b;
        b = temp;
    }
    s.Stop ();
    Console.WriteLine ("Inline temp: " + s.Elapsed);
    s.Restart ();
    for (var i = 0; i < 500000000; i ++) {
        Swap (ref a, ref b);
    }
    s.Stop ();
    Console.WriteLine ("Call:        " + s.Elapsed);
    s.Restart ();
    for (var i = 0; i < 500000000; i ++) {
        b = Interlocked.Exchange (ref a, b);
    }
    s.Stop ();
    Console.WriteLine ("Interlocked: " + s.Elapsed);
    Console.ReadKey ();
}

