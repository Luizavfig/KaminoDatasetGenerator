/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:6039268
*  Stack Overflow answer #:6039379
*  And Stack Overflow answer#:6040373
*/
static void Main (string [] args) {
    try {
        using (TestClass t = new TestClass ())
        {
            Thread ts = new Thread (new ThreadStart (t.GetTest));
            ts.Start ();
        }}
    catch (Exception ex) {
        Console.WriteLine ("Error: " + ex.Message);
    }
}

static void Main (string [] args) {
    HttpWebResponse response = new HttpWebResponse ();
    try {
        response.GetResponse ();
    }
    catch (Exception ex) {
    }
    finally {
        response.Dispose ();
    }
}

