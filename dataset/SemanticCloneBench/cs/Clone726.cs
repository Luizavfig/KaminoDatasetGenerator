/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:5663395
*  Stack Overflow answer #:26676294
*  And Stack Overflow answer#:14410196
*/
private void NotifyObserversOfChange () {
    var collectionHandler = CollectionChanged;
    var propertyHandler = PropertyChanged;
    if (collectionHandler != null || propertyHandler != null) {
        _context.Post (s = > {
            if (collectionHandler != null) {
                collectionHandler (this, new NotifyCollectionChangedEventArgs (NotifyCollectionChangedAction.Reset));
            }
            if (propertyHandler != null) {
                propertyHandler (this, new PropertyChangedEventArgs ("Count"));
                propertyHandler (this, new PropertyChangedEventArgs ("Keys"));
                propertyHandler (this, new PropertyChangedEventArgs ("Values"));
            }
        }, null);
    }
}

public new bool Remove (TKey key) {
    TValue value;
    if (base.TryGetValue (key, out value)) {
        var item = new KeyValuePair < TKey, TValue > (key, base [key]);
        bool result = base.Remove (key);
        this.OnCollectionChanged (new NotifyCollectionChangedEventArgs (NotifyCollectionChangedAction.Remove, item, base.Keys.ToList ().IndexOf (key)));
        this.OnPropertyChanged (new PropertyChangedEventArgs (nameof (Count)));
        return result;
    }
    return false;
}

