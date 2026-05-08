/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:11456948
*  Stack Overflow answer #:24623628
*  And Stack Overflow answer#:11458422
*/
public static StreamReader LoadWeb (string URL) {
    if (! URL.StartsWith ("http")) {
        URL = "http://" + URL;
    }
    HttpWebResponse myResponse = null;
    HttpWebRequest myRequest = (HttpWebRequest) WebRequest.Create (new Uri (URL));
    System.IO.Stream myStream = null;
    StreamReader myStreamReader = null;
    myRequest.Method = "GET";
    myRequest.Proxy = null;
    myRequest.Timeout = 60000;
    myRequest.KeepAlive = false;
    try {
        myResponse = (HttpWebResponse) myRequest.GetResponse ();
    }
    catch (Exception ex) {
        System.Windows.Forms.MessageBox.Show ("Error : " + ex.Message);
        return null;
    }
    if (myResponse != null) {
        if (myResponse.StatusCode == System.Net.HttpStatusCode.OK) {
            myStream = myResponse.GetResponseStream ();
            myStreamReader = new StreamReader (myStream);
        }
    }
    return myStreamReader;
}

static void Main (string [] args) {
    for (int i = 0; i < 100; i ++) {
        waitingWorkers.Enqueue (new Worker (new WorkerDoneDelegate (WorkerDone)));
    }
    lock (waitLock)
    {
        while (waitingWorkers.Count > 0) {
            if (activeWorkers.Count > maxThreads) {
                Monitor.Wait (waitLock);
            }
            Worker worker = waitingWorkers.Dequeue ();
            Thread thread = new Thread (worker.SendSomething);
            thread.IsBackground = true;
            activeWorkers [thread.ManagedThreadId] = worker;
            thread.Start ();
        }
    } Console.WriteLine ("Queue empty");
    Console.ReadKey ();
}

