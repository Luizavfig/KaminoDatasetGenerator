/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:21002797
*  Stack Overflow answer #:21007035
*  And Stack Overflow answer#:21002956
*/
private static void Main (string [] args) {
    Thread t = new Thread (ReaderFunc);
    t.Start ();
    int index = 0;
    while (! StopWriting.WaitOne (Timeout.Infinite)) {
        ++ index;
        Console.WriteLine (index.ToString ());
    }
    t.Join ();
}

static void Main (string [] args) {
    var w = new Writer ();
    var r = new Reader ();
    while (! r.finish) {
        w.enabled = true;
        string k = Console.ReadKey (false).KeyChar.ToString ();
        w.enabled = false;
        string line = k + Console.ReadLine ();
        r.Read (line);
    }
}

