/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:23286752
*  Stack Overflow answer #:23287415
*  And Stack Overflow answer#:23287415
*/
static void Main (string [] args) {
    Stopwatch sw = new Stopwatch ();
    double [] input = Enumerable.Range (0, 10000000).Select (i = > (double) i).ToArray ();
    while (true) {
        sw.Start ();
        LinqStack (input);
        sw.Stop ();
        Console.WriteLine ("LinqStack(): {0}ms", sw.ElapsedMilliseconds);
        sw.Restart ();
        SimpleStack (input);
        sw.Stop ();
        Console.WriteLine ("SimpleStack(): {0}ms", sw.ElapsedMilliseconds);
        sw.Restart ();
        OriginalStack (input);
        sw.Stop ();
        Console.WriteLine ("OriginalStack(): {0}ms", sw.ElapsedMilliseconds);
        sw.Reset ();
        Console.ReadLine ();
    }
}

static double [] SimpleStack (params double [] input) {
    int length = input.Length;
    double [] output = new double [length * 2];
    for (int i = 0; i < length; i ++) {
        output [i] = input [i];
    }
    for (int i = 0; i < length; i ++) {
        output [i + length] = input [length - i - 1];
    }
    return output;
}

