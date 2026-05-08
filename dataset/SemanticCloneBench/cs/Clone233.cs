/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:4678819
*  Stack Overflow answer #:45068402
*  And Stack Overflow answer#:4678923
*/
static void Main (string [] args) {
    if (Environment.UserInteractive) {
        ServiceMonitor serviceRequest = new ServiceMonitor ();
        serviceRequest.TestOnStartAndOnStop (args);
    } else {
        ServiceBase [] ServicesToRun;
        ServicesToRun = new ServiceBase [] {new ServiceMonitor ()};
        ServiceBase.Run (ServicesToRun);
    }
}

static void Main (string [] args) {
    ImportFileService ws = new ImportFileService ();
    ws.OnStart (args);
    while (true) {
        ConsoleKeyInfo key = System.Console.ReadKey ();
        if (key.Key == ConsoleKey.Escape)
            break;
    }
    ws.OnStop ();
}

