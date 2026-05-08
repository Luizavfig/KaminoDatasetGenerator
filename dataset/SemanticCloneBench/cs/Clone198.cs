/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:1314155
*  Stack Overflow answer #:1314165
*  And Stack Overflow answer#:6584661
*/
static void Main (string [] args) {
    BackgroundWorker bg = new BackgroundWorker ();
    bg.DoWork += new DoWorkEventHandler (bg_DoWork);
    bg.RunWorkerCompleted += new RunWorkerCompletedEventHandler (bg_RunWorkerCompleted);
    bg.RunWorkerAsync ();
    while (! done) {
        Console.WriteLine ("Waiting in Main, tid " + Thread.CurrentThread.ManagedThreadId);
        Thread.Sleep (100);
    }
}

void Main () {
    object value = null;
    var thread = new Thread (() = > {
        value = "Hello World";
    });
    thread.Start ();
    thread.Join ();
    Console.WriteLine (value);
}

