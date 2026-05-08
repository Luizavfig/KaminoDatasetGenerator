/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:3848387
*  Stack Overflow answer #:3849350
*  And Stack Overflow answer#:3849350
*/
public void Queue (Action action, bool urgent, int delay) {
    if (delay > 0) {
        Timer t = null;
        t = new Timer (_ = > {
            Queue (action, urgent, 0);
            t.Dispose ();
        }, null, delay, Timeout.Infinite);
        return;
    }
    lock (threads)
    {
        if (maxThreads > threads.Count) {
            Thread t = new Thread (new ThreadStart (ThreadProc));
            t.IsBackground = true;
            t.Priority = ThreadPriority.Lowest;
            t.Name = "Worker thread for " + name;
            t.Start ();
            threads.Add (t);
        }
    } lock (actions)
    {
        if (urgent) {
            actions.Insert (0, action);
        } else {
            actions.Add (action);
        }
        Monitor.Pulse (actions);
    }}

public static void Queue (string uniqueId, Action action, Action done, bool urgent, int delay) {
    Debug.Assert (uniqueId != null);
    Debug.Assert (action != null);
    Action workItem = () = > {
        try {
            action ();
        }
        catch (ThreadAbortException) {
        }
        catch (Exception ex) {
            Debug.Assert (false, "Async thread crashed! This must be fixed. " + ex.ToString ());
            Logger.ReportException ("Async thread crashed! This must be fixed. ", ex);
        }
        if (done != null)
            done ();
    };
    GetThreadPool (uniqueId).Queue (workItem, urgent, delay);
}

