/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:7210831
*  Stack Overflow answer #:7217120
*  And Stack Overflow answer#:7210881
*/
protected override void OnStartup (StartupEventArgs e) {
    MainWindow mw = new MainWindow ();
    if (e.Args != null && e.Args.Count () > 0) {
        this.Properties ["ArbitraryArgName"] = e.Args [0];
    }
    if (Application.Current.Properties ["ArbitraryArgName"] != null) {
        string fname = Application.Current.Properties ["ArbitraryArgName"].ToString ();
        mw.Show ();
        mw.readVcard (fname);
    } else if (e.Args.Count () == 0) {
        mw.Show ();
    }
}

protected override void OnStartup (StartupEventArgs e) {
    MainWindow mw = new MainWindow ();
    mw.Show ();
    if (e.Args != null && e.Args.Count () > 0) {
        this.Properties ["ArbitraryArgName"] = e.Args [0];
        string fname = Application.Current.Properties ["ArbitraryArgName"].ToString ();
        mw.readVcard (fname);
    }
}

