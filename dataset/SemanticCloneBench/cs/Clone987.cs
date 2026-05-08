/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:29903320
*  Stack Overflow answer #:47379354
*  And Stack Overflow answer#:47379354
*/
public static void Main (string [] args) {
    Stopwatch t0 = new Stopwatch ();
    int maxNumber = 20;
    long start;
    t0.Start ();
    start = Orig (maxNumber);
    t0.Stop ();
    Console.WriteLine ("Original | {0:d}, {1:d}", maxNumber, start);
    Console.WriteLine ("Original | time elapsed = {0}.", t0.Elapsed);
    t0.Restart ();
    start = Test (maxNumber);
    t0.Stop ();
    Console.WriteLine ("Test | {0:d}, {1:d}", maxNumber, start);
    Console.WriteLine ("Test | time elapsed = {0}.", t0.Elapsed);
    Console.ReadLine ();
}

public static long Orig (int maxNumber) {
    bool found = false;
    long start = 0;
    while (! found) {
        start += maxNumber;
        found = true;
        for (int i = 2; i < 21; i ++) {
            if (start % i != 0)
                found = false;
        }
    }
    return start;
}

