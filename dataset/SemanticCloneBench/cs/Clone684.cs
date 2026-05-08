/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:3334178
*  Stack Overflow answer #:3338305
*  And Stack Overflow answer#:3338305
*/
public void LaunchThreads () {
    for (int i = 0; i < 20; i ++) {
        Worker worker = new Worker ();
        worker.DoneCallBack = new WorkerCallbackDelegate (WorkerCallback);
        Thread thread = new Thread (worker.DoWork);
        thread.IsBackground = true;
        thread.Start ();
        lock (locker)
        {
            activeWorkers.Add (thread.ManagedThreadId, worker);
        }}
}

public void DoWork () {
    quitEarly = false;
    Console.WriteLine (Thread.CurrentThread.ManagedThreadId.ToString () + " started");
    DateTime startTime = DateTime.Now;
    while (! quitEarly && ((DateTime.Now - startTime).TotalSeconds < new Random ().Next (1, 10))) {
        Thread.Sleep (1000);
    }
    Console.WriteLine (Thread.CurrentThread.ManagedThreadId.ToString () + " stopped");
    DoneCallBack (Thread.CurrentThread.ManagedThreadId);
}

