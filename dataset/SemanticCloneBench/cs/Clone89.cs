/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:14506406
*  Stack Overflow answer #:34231251
*  And Stack Overflow answer#:14665575
*/
protected override void OnStartup (StartupEventArgs e) {
    const string appName = "MyAppName";
    bool createdNew;
    _mutex = new Mutex (true, appName, out createdNew);
    if (! createdNew) {
        Application.Current.Shutdown ();
    }
    base.OnStartup (e);
}

protected override void OnStartup (StartupEventArgs e) {
    bool result = Semaphore.TryOpenExisting ("SingleInstanceWPFApp", out sema);
    if (result) {
        App.Current.Shutdown ();
    } else {
        try {
            sema = new Semaphore (1, 1, "SingleInstanceWPFApp");
        }
        catch {
            App.Current.Shutdown ();
        }
    }
    if (! sema.WaitOne (0)) {
        App.Current.Shutdown ();
    } else {
        shouldRelease = true;
    }
    base.OnStartup (e);
}

