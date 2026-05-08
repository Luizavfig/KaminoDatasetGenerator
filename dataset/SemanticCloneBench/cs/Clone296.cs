/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:7764088
*  Stack Overflow answer #:41783380
*  And Stack Overflow answer#:7764451
*/
static void Main (string [] args) {
    if (Environment.UserInteractive) {
        Start (args);
        Console.WriteLine ("Press any key to stop...");
        Console.ReadKey (true);
        Stop ();
    } else {
        using (var service = new Service ())
        {
            ServiceBase.Run (service);
        }}
}

static void Main (string [] args) {
    if (! Environment.UserInteractive)
        using (var service = new Service ())
        ServiceBase.Run (service);
    else {
        Start (args);
        Console.WriteLine ("Press any key to stop...");
        Console.ReadKey (true);
        Stop ();
    }
}

