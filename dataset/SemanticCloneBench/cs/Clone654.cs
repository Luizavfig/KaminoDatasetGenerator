/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:3286492
*  Stack Overflow answer #:3286731
*  And Stack Overflow answer#:3286731
*/
static void Main (string [] args) {
    Random r = new Random ();
    double [] data = Generate (() = > {
        var res = r.NextDouble ();
        return res < 0.5 ? res : Double.NaN;
    }, 1000000).ToArray ();
    Stopwatch sw = new Stopwatch ();
    sw.Start ();
    DoSomething (data);
    Console.WriteLine (sw.ElapsedTicks);
    sw.Reset ();
    sw.Start ();
    DoSomething2 (data);
    Console.WriteLine (sw.ElapsedTicks);
    Console.ReadKey ();
}

public static bool DoSomething (double [] args) {
    bool ret = false;
    for (int i = 0; i < args.Length; i ++) {
        if (double.IsNaN (args [i])) {
            ret = ! ret;
        }
    }
    return ret;
}

