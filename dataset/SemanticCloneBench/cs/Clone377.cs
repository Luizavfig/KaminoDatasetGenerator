/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:3300845
*  Stack Overflow answer #:31692607
*  And Stack Overflow answer#:31692607
*/
protected override void OnCollectionChanged (NotifyCollectionChangedEventArgs e) {
    if (suppressNotification)
        return;
    base.OnCollectionChanged (e);
    if (CollectionChanged != null) {
        CollectionChanged.Invoke (this, e);
    }
}

protected override void OnCollectionChanged (NotifyCollectionChangedEventArgs e) {
    var handlers = CollectionChanged;
    if (handlers == null)
        return;
    foreach (NotifyCollectionChangedEventHandler handler in handlers.GetInvocationList ()) {
        var collectionView = handler.Target as ICollectionView;
        if (collectionView != null) {
            collectionView.Refresh ();
        } else {
            handler (this, e);
        }
    }
}

