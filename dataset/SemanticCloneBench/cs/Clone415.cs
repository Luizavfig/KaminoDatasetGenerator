/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:384918
*  Stack Overflow answer #:384920
*  And Stack Overflow answer#:384925
*/
public Boolean TryGetValue (TKey key, out TValue value) {
    internalLock.AcquireReaderLock (Timeout.Infine);
    try {
        return dictionary.TryGetValue (key, out value);
    }
    finally {
        internalLock.ReleaseReaderLock ();
    }
}

public bool TryGetValue (TKey key, out TValue value) {
    bool got = false;
    TValue tmp = default (TValue);
    WithReaderLock (delegate {
        got = dictionary.TryGetValue (key, out tmp);
    });
    value = tmp;
    return got;
}

