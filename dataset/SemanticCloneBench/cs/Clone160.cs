/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:15950704
*  Stack Overflow answer #:15971312
*  And Stack Overflow answer#:15966998
*/
static void RunExperiment (Experiment test, int loop) {
    GC.Collect (GC.MaxGeneration, GCCollectionMode.Forced);
    GC.Collect (GC.MaxGeneration, GCCollectionMode.Forced);
    GC.WaitForPendingFinalizers ();
    int threads = Environment.ProcessorCount;
    ManualResetEvent done = new ManualResetEvent (false);
    int workerLoop = Math.Max (1, loop / Environment.ProcessorCount);
    int writeRatio = 1000;
    int writes = Math.Max (workerLoop / writeRatio, 1);
    int reads = workerLoop / writes;
    var watch = Stopwatch.StartNew ();
    for (int t = 0; t < Environment.ProcessorCount; ++ t) {
        ThreadPool.QueueUserWorkItem ((state) = > {
            try {
                double val = 0;
                for (int j = 0; j < writes; ++ j) {
                    test.SetValue (j);
                    for (int i = 0; i < reads; i ++) {
                        val = test.GetValue ();
                    }
                }
            }
            finally {
                if (0 == Interlocked.Decrement (ref threads)) {
                    done.Set ();
                }
            }
        });
    }
    done.WaitOne ();
    watch.Stop ();
    Console.WriteLine ("{0}\t{1}ms", test.GetType ().Name, watch.ElapsedMilliseconds);
}

static void RunExperiment (Experiment test, int loop) {
    GC.Collect (GC.MaxGeneration, GCCollectionMode.Forced);
    GC.Collect (GC.MaxGeneration, GCCollectionMode.Forced);
    GC.WaitForPendingFinalizers ();
    double val = 0;
    var watch = Stopwatch.StartNew ();
    for (int i = 0; i < loop; i ++)
        val = test.GetValue ();
    watch.Stop ();
    if (val != 3.0)
        Console.WriteLine ("FAIL!");
    Console.WriteLine ("{0}\t{1}ms", test.GetType ().Name, watch.ElapsedMilliseconds);
}

