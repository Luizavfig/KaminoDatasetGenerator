/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:6486195
*  Stack Overflow answer #:6486341
*  And Stack Overflow answer#:6486819
*/
[STAThread] static void Main () {
    bool result;
    var mutex = new System.Threading.Mutex (true, "UniqueAppId", out result);
    if (! result) {
        MessageBox.Show ("Another instance is already running.");
        return;
    }
    Application.Run (new Form1 ());
    GC.KeepAlive (mutex);
}

[STAThread] static void Main () {
    if (! mutex.WaitOne (TimeSpan.FromSeconds (2), false)) {
        MessageBox.Show ("Application already started!", "", MessageBoxButtons.OK);
        return;
    }
    try {
        Application.EnableVisualStyles ();
        Application.SetCompatibleTextRenderingDefault (false);
        Application.Run (new Form1 ());
    }
    finally {
        mutex.ReleaseMutex ();
    }
}

