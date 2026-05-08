/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:10294469
*  Stack Overflow answer #:10298870
*  And Stack Overflow answer#:10295960
*/
private void repairClientsToolStripMenuItem_Click (object sender, EventArgs e) {
    if (machineList.Count () != 0) {
        var task = Task.Factory.StartNew (() = > {
            foreach (string ws in machineList) {
                string capture = ws;
                Task.Factory.StartNew (() = > {
                    fixClient (capture);
                }, TaskCreationOptions.AttachedToParent);
            }
        }, TaskCreationOptions.LongRunning);
        task.ContinueWith ((parent) = > {
        }, TaskScheduler.FromCurrentSynchronizationContext);
    } else {
        MessageBox.Show ("Please import data before attempting this procedure");
    }
}

static void Main (string [] args) {
    int numTasks = 20;
    var rng = new Random ();
    using (var finishedSignal = new CountdownEvent (1))
    {
        for (int i = 0; i < numTasks; ++ i) {
            finishedSignal.AddCount ();
            Task.Factory.StartNew (() = > task (rng.Next (2000, 5000), finishedSignal));
        }
        finishedSignal.Signal ();
        Console.WriteLine ("Waiting for all tasks to complete...");
        finishedSignal.Wait ();
    } Console.WriteLine ("Finished waiting for all tasks to complete.");
}

