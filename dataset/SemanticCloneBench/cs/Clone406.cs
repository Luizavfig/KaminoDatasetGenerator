/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:884822
*  Stack Overflow answer #:884886
*  And Stack Overflow answer#:884939
*/
public static void Main () {
    try {
        Console.WriteLine ("Before throwing");
        throw new Exception ("Exception!");
    }
    finally {
        Console.WriteLine ("In finally");
        Console.ReadLine ();
    }
}

static void Main () {
    AppDomain.CurrentDomain.UnhandledException += delegate (object sender, UnhandledExceptionEventArgs e) {
        Console.Out.WriteLine ("In AppDomain.UnhandledException");
    };
    try {
        throw new Exception ("Exception!");
    }
    catch {
        Console.Error.WriteLine ("In catch");
        throw;
    }
    finally {
        Console.Error.WriteLine ("In finally");
    }
}

