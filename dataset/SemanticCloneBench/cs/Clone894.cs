/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:8554463
*  Stack Overflow answer #:8554803
*  And Stack Overflow answer#:8554803
*/
private static void Main (string [] args) {
    int threadCount = 2;
    using (ThreadData data = new ThreadData (threadCount))
    {
        Thread [] threads = new Thread [threadCount];
        for (int i = 0; i < threadCount; ++ i) {
            threads [i] = new Thread (DoOperations);
        }
        foreach (Thread thread in threads) {
            thread.Start (data);
        }
        Console.WriteLine ("Starting...");
        data.RunDispatcher ();
    } Console.WriteLine ("Shutdown.");
}

private static void DoOperations (object objData) {
    ThreadData data = (ThreadData) objData;
    try {
        for (int i = 0; i < 5; ++ i) {
            int t = Thread.CurrentThread.ManagedThreadId;
            int n = i;
            data.ExecuteTask (() = > SayHello (t, n));
        }
    }
    finally {
        data.OnThreadCompleted ();
    }
}

