/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:17018795
*  Stack Overflow answer #:17018809
*  And Stack Overflow answer#:17019186
*/
static void Main () {
    string text = new string ('x', 100000);
    GC.Collect ();
    GC.WaitForPendingFinalizers ();
    var watch = Stopwatch.StartNew ();
    const int LOOP = 1000;
    for (int i = 0; i < LOOP; i ++) {
        var arr = text.ToCharArray ();
        Array.Reverse (arr);
        string y = new string (arr);
    }
    watch.Stop ();
    Console.WriteLine ("Array.Reverse: {0}ms", watch.ElapsedMilliseconds);
    GC.Collect ();
    GC.WaitForPendingFinalizers ();
    watch = Stopwatch.StartNew ();
    for (int i = 0; i < LOOP; i ++) {
        var reverse = new StringBuilder (text.Length);
        for (int j = text.Length - 1; j >= 0; j --) {
            reverse.Append (text [j]);
        }
        string y = reverse.ToString ();
    }
    watch.Stop ();
    Console.WriteLine ("StringBuilder: {0}ms", watch.ElapsedMilliseconds);
}

unsafe String Reverse (String s) {
    char [] sarr = new char [s.Length];
    fixed (char * c = s) fixed (char * d = sarr) {
        char * c1 = c;
        char * d1 = d + s.Length;
        while (d1 > d) {
            * -- d1 = * c1 ++;
        }
    } return new String (sarr);
}

