/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:200163
*  Stack Overflow answer #:208073
*  And Stack Overflow answer#:2111492
*/
private static void Main () {
    if (Environment.UserInteractive) {
        startWorkerThread ();
        Console.WriteLine ("======  Press ENTER to stop threads  ======");
        Console.ReadLine ();
        stopWorkerThread ();
        Console.WriteLine ("======  Press ENTER to quit  ======");
        Console.ReadLine ();
    } else {
        Run (this);
    }
}

static void Main (string [] args) {
    if (Array.Exists (args, delegate (string arg) {
        return arg == "/install";
    })) {
        System.Configuration.Install.TransactedInstaller ti = null;
        ti = new System.Configuration.Install.TransactedInstaller ();
        ti.Installers.Add (new ProjectInstaller ());
        ti.Context = new System.Configuration.Install.InstallContext ("", null);
        string path = System.Reflection.Assembly.GetExecutingAssembly ().Location;
        ti.Context.Parameters ["assemblypath"] = path;
        ti.Install (new System.Collections.Hashtable ());
        return;
    }
    if (Array.Exists (args, delegate (string arg) {
        return arg == "/uninstall";
    })) {
        System.Configuration.Install.TransactedInstaller ti = null;
        ti = new System.Configuration.Install.TransactedInstaller ();
        ti.Installers.Add (new ProjectInstaller ());
        ti.Context = new System.Configuration.Install.InstallContext ("", null);
        string path = System.Reflection.Assembly.GetExecutingAssembly ().Location;
        ti.Context.Parameters ["assemblypath"] = path;
        ti.Uninstall (null);
        return;
    }
    if (Array.Exists (args, delegate (string arg) {
        return arg == "/service";
    })) {
        ServiceBase [] ServicesToRun;
        ServicesToRun = new ServiceBase [] {new MyService ()};
        ServiceBase.Run (ServicesToRun);
    } else {
        Console.ReadKey ();
    }
}

