/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:24331540
*  Stack Overflow answer #:24332088
*  And Stack Overflow answer#:24331806
*/
static void Main (string [] args) {
    double d = double.NaN;
    for (int test = 0; test < 10; ++ test) {
        var sw1 = Stopwatch.StartNew ();
        bool result1 = false;
        for (int ix = 0; ix < 1000 * 1000; ++ ix) {
            result1 |= double.IsNaN (d);
        }
        sw1.Stop ();
        var sw2 = Stopwatch.StartNew ();
        bool result2 = false;
        for (int ix = 0; ix < 1000 * 1000; ++ ix) {
            result2 |= IsNaN (d);
        }
        sw2.Stop ();
        Console.WriteLine ("{0} - {1} x {2}%", sw1.Elapsed, sw2.Elapsed, 100 * sw2.ElapsedTicks / sw1.ElapsedTicks, result1, result2);
    }
    Console.ReadLine ();
}

public static void Main () {
    int iterations = 500 * 1000 * 1000;
    double nan = double.NaN;
    double notNan = 42;
    Stopwatch sw = Stopwatch.StartNew ();
    bool isNan;
    for (int i = 0; i < iterations; i ++) {
        isNan = IsNaN (nan);
        isNan = IsNaN (notNan);
    }
    sw.Stop ();
    Console.WriteLine ("IsNaN: {0}", sw.ElapsedMilliseconds);
    sw = Stopwatch.StartNew ();
    for (int i = 0; i < iterations; i ++) {
        isNan = double.IsNaN (nan);
        isNan = double.IsNaN (notNan);
    }
    sw.Stop ();
    Console.WriteLine ("double.IsNaN: {0}", sw.ElapsedMilliseconds);
    Console.Read ();
}

