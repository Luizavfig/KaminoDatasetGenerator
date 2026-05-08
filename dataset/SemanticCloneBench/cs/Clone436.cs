/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:10126460
*  Stack Overflow answer #:10127030
*  And Stack Overflow answer#:10233188
*/
private static void Test (Action toTest) {
    for (int i = 0; i < 100; i ++) {
        var sw = Stopwatch.StartNew ();
        toTest ();
        sw.Stop ();
        Console.WriteLine ("costs {0}", sw.ElapsedMilliseconds);
        sw.Reset ();
    }
}

private static void Test (Action test) {
    long totalElapsed = 0;
    for (int counter = 10; counter > 0; counter --) {
        try {
            var sw = Stopwatch.StartNew ();
            test ();
            totalElapsed += sw.ElapsedMilliseconds;
        }
        finally {
        }
        GC.Collect (0, GCCollectionMode.Forced);
        GC.WaitForPendingFinalizers ();
        for (int i = 0; i < 100; i ++)
            System.Threading.Thread.Sleep (0);
    }
    Console.WriteLine ("{0} averages {1}", test.Method.Name, totalElapsed / 10);
}

