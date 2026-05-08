/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:16315756
*  Stack Overflow answer #:16406422
*  And Stack Overflow answer#:16406422
*/
void TimeMethod2Threads (string description, Action a) {
    sharedResource = 0;
    Stopwatch sw = new Stopwatch ();
    using (Task t1 = new Task (() = > IterateAction (a, Iterations / 2)))
    using (Task t2 = new Task (() = > IterateAction (a, Iterations / 2)))
    {
        sw.Start ();
        t1.Start ();
        t2.Start ();
        Task.WaitAll (t1, t2);
        sw.Stop ();
    } Console.WriteLine ("{0:0.000} ({1})", (double) sw.ElapsedTicks * (double) 100 / (double) Iterations, description);
}

void TimeMethod (string description, Action a) {
    sharedResource = 0;
    Stopwatch sw = new Stopwatch ();
    sw.Start ();
    for (int i = 0; i < Iterations; i ++) {
        a ();
    }
    sw.Stop ();
    Console.WriteLine ("{0:0.000} ({1})", (double) sw.ElapsedTicks * 100d / (double) Iterations, description);
}

