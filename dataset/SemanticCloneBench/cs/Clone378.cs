/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:15870215
*  Stack Overflow answer #:15870570
*  And Stack Overflow answer#:15870570
*/
private void Dispose (bool disposing) {
    if (this.disposed)
        return;
    if (disposing && this.stream != null)
        this.stream.Dispose ();
    this.disposed = true;
}

private void Dispose (bool disposing) {
    if (disposing)
        GC.SuppressFinalize (this);
    if (this.path == null)
        return;
    try {
        File.Delete (this.path);
    }
    catch {
        Trace.TraceWarning ("Can't delete file " + this.path);
    }
    this.path = null;
}

