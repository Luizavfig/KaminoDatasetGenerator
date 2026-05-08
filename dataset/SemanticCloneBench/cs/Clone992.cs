/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:1902384
*  Stack Overflow answer #:1907501
*  And Stack Overflow answer#:1907501
*/
private string DoSomething () {
    int max = 10;
    for (int i = 1; i <= max; i ++) {
        Thread.Sleep (_Random.Next (10, 1000));
        if (_BackgroundWorker.CancellationPending) {
            return "Job aborted!";
        }
        AddMessage (String.Format ("Currently working on item {0} of {1}", i, max));
        _BackgroundWorker.ReportProgress ((i * 100) / max);
    }
    return "Job is done.";
}

private void backgroundWorker_DoWork (object sender, DoWorkEventArgs e) {
    while (! _BackgroundWorker.CancellationPending) {
        if (_Commands.Count > 0) {
            AddMessage ("Starting waiting job...");
            AddMessage (_Commands.Dequeue ().Invoke ());
        }
        Thread.Sleep (1);
    }
}

