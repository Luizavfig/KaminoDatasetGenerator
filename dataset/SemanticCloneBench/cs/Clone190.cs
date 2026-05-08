/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:18336856
*  Stack Overflow answer #:18336993
*  And Stack Overflow answer#:31016954
*/
protected virtual void Dispose (bool disposing) {
    if (! _disposed) {
        if (disposing) {
            id = 0;
            name = String.Empty;
            pass = String.Empty;
        }
        _disposed = true;
    }
}

protected virtual void Dispose (bool disposing) {
    if (! this.disposed) {
        if (disposing) {
            component.Dispose ();
        }
        CloseHandle (handle);
        handle = IntPtr.Zero;
        disposed = true;
    }
}

