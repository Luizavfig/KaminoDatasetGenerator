/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:3129275
*  Stack Overflow answer #:3129530
*  And Stack Overflow answer#:3129527
*/
static void Main (string [] args) {
    if (! Environment.UserInteractive) {
        ServiceBase [] ServicesToRun;
        ServicesToRun = new ServiceBase [] {new Service ()};
        ServiceBase.Run (ServicesToRun);
        return;
    }
    MainLib lib = new MainLib ();
    lib.Start ();
}

static void Main (string [] args) {
    foreach (string arg in args) {
        if (arg.ToLower () == "-service") {
            ServiceBase [] servicesToRun = new ServiceBase [] {new Service1 ()};
            ServiceBase.Run (servicesToRun);
            return;
        }
    }
    Application.Run (new Form1 ());
}

