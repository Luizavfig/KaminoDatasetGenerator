/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:34769985
*  Stack Overflow answer #:34770038
*  And Stack Overflow answer#:34770056
*/
static void Main (string [] args) {
    Stopwatch stopWatch = new Stopwatch ();
    stopWatch.Start ();
    Thread.Sleep (10000);
    stopWatch.Stop ();
    TimeSpan ts = stopWatch.Elapsed;
    string elapsedTime = String.Format ("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
    Console.WriteLine ("RunTime " + elapsedTime);
}

static void Main () {
    Stopwatch stopwatch = new Stopwatch ();
    stopwatch.Start ();
    for (int i = 0; i < 1000; i ++) {
        Thread.Sleep (1);
    }
    stopwatch.Stop ();
    Console.WriteLine ("Time elapsed: {0}", stopwatch.Elapsed);
}

