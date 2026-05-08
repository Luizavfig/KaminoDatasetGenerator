/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:13560430
*  Stack Overflow answer #:13560832
*  And Stack Overflow answer#:13561422
*/
static void Main (string [] args) {
    long i = 0;
    int runs = 10 * 1000 * 1000;
    Task [] t = new Task [Environment.ProcessorCount];
    Stopwatch stp = Stopwatch.StartNew ();
    for (int k = 0; k < t.Length; k ++) {
        t [k] = Task.Run (() = > {
            for (int j = 0; j < runs; j ++) {
                i ++;
            }
        });
    }
    Task.WaitAll (t);
    stp.Stop ();
    Console.WriteLine ("i = {0}   should be = {1}  ms={2}", i, runs * t.Length, stp.ElapsedMilliseconds);
    Console.ReadLine ();
}

static void Main (string [] args) {
    Random random = new Random ();
    int value = 0;
    Thread incThread = new Thread (() = > {
        for (int y = 0; y < 2000000; y ++) {
            value ++;
        }
    });
    Thread decThread = new Thread (() = > {
        for (int z = 0; z < 2000000; z ++) {
            value --;
        }
    });
    incThread.Start ();
    decThread.Start ();
    incThread.Join ();
    decThread.Join ();
    Console.WriteLine (value);
}

