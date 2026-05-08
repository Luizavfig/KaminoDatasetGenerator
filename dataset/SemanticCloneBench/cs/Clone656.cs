/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:2691072
*  Stack Overflow answer #:2693810
*  And Stack Overflow answer#:2693810
*/
public void Run () {
    for (int i = 0; i < 50; i ++) {
        Thread newThread = new Thread (new Worker (ThreadDone).DoWork);
        newThread.IsBackground = true;
        waitingThreads.Enqueue (newThread);
    }
    LaunchWaitingThreads ();
    while (! done)
        Thread.Sleep (200);
}

void LaunchWaitingThreads () {
    lock (locker)
    {
        while ((activeThreads.Count < maxRunningThreads) && (waitingThreads.Count > 0)) {
            Thread nextThread = waitingThreads.Dequeue ();
            activeThreads.Add (nextThread.ManagedThreadId, nextThread);
            nextThread.Start ();
            Console.WriteLine ("Thread " + nextThread.ManagedThreadId.ToString () + " launched");
        }
        done = (activeThreads.Count == 0) && (waitingThreads.Count == 0);
    }}

