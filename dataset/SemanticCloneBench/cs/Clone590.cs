/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:16215319
*  Stack Overflow answer #:16215659
*  And Stack Overflow answer#:16215659
*/
private void textBox1_TextChanged (object sender, EventArgs e) {
    tokenSource.Cancel ();
    tokenSource = new CancellationTokenSource ();
    var token = tokenSource.Token;
    Task.Factory.StartNew ((s) = > {
        var q = Task.Factory.StartNew < IEnumerable < DemoData > > (() = > LongLastingDataQuery (textBox1.Text, token), token);
        if (! token.IsCancellationRequested)
            Task.Factory.StartNew (() = > BindData (q.Result));
    }, token);
}

private IEnumerable < DemoData > LongLastingDataQuery (string search, CancellationToken token) {
    List < DemoData > l = new List < DemoData > ();
    for (int i = 0; i < 10000 * search.Length; i ++) {
        if (token.IsCancellationRequested)
            return l;
        l.Add (new DemoData {ID = i, Text = search + i, Text1 = search + i + i, Text2 = search + i + i + i, Text3 = search + i + i + i + i});
    }
    Thread.Sleep (1000);
    return l;
}

