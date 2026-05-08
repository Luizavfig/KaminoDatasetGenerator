/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:6601611
*  Stack Overflow answer #:30769838
*  And Stack Overflow answer#:23446622
*/
public static void Swap < T > (ref T obj, Func < T, T > cloner, Action < T > op) where T : class {
    while (true) {
        var objBefore = Volatile.Read (ref obj);
        var newObj = cloner (objBefore);
        op (newObj);
        if (Interlocked.CompareExchange (ref obj, newObj, objBefore) == objBefore)
            return;
    }
}

public void Add (T item) {
    try {
        this._lock.EnterWriteLock ();
        this._list.Add (item);
    }
    finally {
        this._lock.ExitWriteLock ();
    }
}

