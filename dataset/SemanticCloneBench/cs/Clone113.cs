/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:158706
*  Stack Overflow answer #:1307180
*  And Stack Overflow answer#:349202
*/
private void Dispose (bool disposing) {
    if (m_disposed)
        return;
    if (disposing) {
    }
    Close ();
    m_disposed = true;
}

protected virtual void Dispose (bool disposing) {
    if (! m_disposed) {
        if (m_armed) {
            int refcnt = 0;
            do
                {
                    refcnt = System.Runtime.InteropServices.Marshal.ReleaseComObject (m_comObject);
                } while (refcnt > 0);
            m_comObject = default (T);
        }
        m_disposed = true;
    }
}

