/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:6560675
*  Stack Overflow answer #:17564494
*  And Stack Overflow answer#:6588089
*/
protected override void OnCreate (Bundle bundle) {
    base.OnCreate (bundle);
    SetContentView (Resource.Layout.splashscreen);
    new Thread (new ThreadStart (() = > {
        Thread.Sleep (1500);
        Intent main = new Intent (this, typeof (MainActivity));
        this.StartActivity (main);
        this.Finish ();
    })).Start ();
}

public override void OnAttachedToWindow () {
    base.OnAttachedToWindow ();
    new Thread (new ThreadStart (() = > {
        while (DateTime.Now < _dt)
            Thread.Sleep (10);
        RunOnUiThread (Finish);
    })).Start ();
}

