/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:14336750
*  Stack Overflow answer #:22026686
*  And Stack Overflow answer#:16367902
*/
protected override void OnCollectionChanged (NotifyCollectionChangedEventArgs e) {
    using (BlockReentrancy ())
    {
        var eh = CollectionChanged;
        if (eh == null)
            return;
        var dispatcher = (from NotifyCollectionChangedEventHandler nh in eh.GetInvocationList ()
            let dpo = nh.Target as DispatcherObject
            where dpo != null
            select dpo.Dispatcher).FirstOrDefault ();
        if (dispatcher != null && dispatcher.CheckAccess () == false) {
            dispatcher.Invoke (DispatcherPriority.DataBind, (Action) (() = > OnCollectionChanged (e)));
        } else {
            foreach (NotifyCollectionChangedEventHandler nh in eh.GetInvocationList ())
                nh.Invoke (this, e);
        }
    }}

void MainWindow_Loaded (object sender, RoutedEventArgs e) {
    Task.Factory.StartNew (() = > {
        foreach (var item in Enumerable.Range (1, 500)) {
            lock (_syncLock)
            {
                Items.Add (item);
            }}
    });
}

