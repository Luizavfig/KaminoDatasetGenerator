/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:515876
*  Stack Overflow answer #:519590
*  And Stack Overflow answer#:515935
*/
static void Main (string [] args) {
    var x = new Example ();
    x.DoStuff = MethodForDelecate;
    x.DoStuffWithParameter = MethodForDelecate;
    x.DoStuffWithReturnValue = MethodWithReturnValue;
    x.DoStuff ();
    x.DoStuffWithParameter (10);
    int value = x.DoStuffWithReturnValue ();
    Console.WriteLine ("Return value " + value);
    Console.ReadLine ();
}

static void Main (string [] args) {
    var x = new Example () {DoStuff = () = > {
        Console.WriteLine ("Did Stuff");
    }, DoStuffWithParameter = (p) = > {
        Console.WriteLine ("Did Stuff with parameter " + p);
    }, DoStuffWithReturnValue = () = > {
        return 99;
    }};
    x.DoStuff ();
    x.DoStuffWithParameter (10);
    int value = x.DoStuffWithReturnValue ();
    Console.WriteLine ("Return value " + value);
    Console.ReadLine ();
}

