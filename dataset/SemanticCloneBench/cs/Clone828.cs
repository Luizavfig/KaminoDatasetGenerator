/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:13634547
*  Stack Overflow answer #:13634841
*  And Stack Overflow answer#:13634692
*/
private void ImplementLongRunningOperation () {
    int id;
    string name;
    Task.Factory.StartNew (() = > {
        id = 42;
        name = "Jonh Doe";
    }).ContinueWith (t = > {
        label1.Text = id.ToString ();
        label2.Text = name;
    }, TaskScheduler.FromSynchronizationContext);
}

private void SetRandomProgress () {
    Random rnd = new Random ();
    int stp = this.progressBar1.Step * rnd.Next (- 1, 2);
    int newval = this.progressBar1.Value + stp;
    if (newval > this.progressBar1.Maximum)
        newval = this.progressBar1.Maximum;
    else if (newval < this.progressBar1.Minimum)
        newval = this.progressBar1.Minimum;
    this.progressBar1.Value = newval;
}

