/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:5565395
*  Stack Overflow answer #:5566115
*  And Stack Overflow answer#:5566115
*/
public IDisposable Enter (string key) {
    Locker locker;
    lock (this.globalLock)
    {
        if (! this.locks.TryGetValue (key, out locker)) {
            this.locks [key] = locker = new Locker (this, key);
        }
        locker.WaitCount ++;
    } locker.Enter ();
    locker.WaitCount --;
    return locker;
}

private void Exit () {
    lock (this.provider.globalLock)
    {
        try {
            if (this.WaitCount == 0) {
                this.provider.locks.Remove (this.key);
            }
        }
        finally {
            Monitor.Exit (this.keyLock);
        }
    }}

