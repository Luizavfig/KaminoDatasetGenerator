/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:3388128
*  Stack Overflow answer #:3388213
*  And Stack Overflow answer#:3388391
*/
static void Main (string [] args) {
    string stringtotal = "";
    string chartotal = "";
    Stopwatch stringconcat = new Stopwatch ();
    Stopwatch charconcat = new Stopwatch ();
    stringconcat.Start ();
    for (int i = 0; i < 100000; i ++) {
        stringtotal += ".";
    }
    stringconcat.Stop ();
    charconcat.Start ();
    for (int i = 0; i < 100000; i ++) {
        chartotal += '.';
    }
    charconcat.Stop ();
    Console.WriteLine ("String: " + stringconcat.Elapsed.ToString ());
    Console.WriteLine ("Char  : " + charconcat.Elapsed.ToString ());
    Console.ReadLine ();
}

static void Main (string [] args) {
    TimeSpan throwAwayString = StringTest (100);
    TimeSpan throwAwayChar = CharTest (100);
    TimeSpan realStringTime = StringTest (10000000);
    TimeSpan realCharTime = CharTest (10000000);
    Console.WriteLine ("string time: {0}", realStringTime);
    Console.WriteLine ("char time: {0}", realCharTime);
    Console.ReadLine ();
}

