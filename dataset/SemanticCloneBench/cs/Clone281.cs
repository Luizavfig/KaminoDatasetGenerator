/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:1475747
*  Stack Overflow answer #:1484960
*  And Stack Overflow answer#:19137392
*/
public override int Read (byte [] buffer, int offset, int count) {
    if (m_buffer == null) {
        m_dataReady.Reset ();
        m_dataReady.WaitOne ();
    }
    Buffer.BlockCopy (m_buffer, m_offset, buffer, offset, (count < m_count) ? count : m_count);
    m_buffer = null;
    return (count < m_count) ? count : m_count;
}

public override int Read (byte [] buffer, int offset, int count) {
    _DataReady.WaitOne ();
    byte [] lBuffer;
    if (! _Buffers.TryDequeue (out lBuffer)) {
        _DataReady.Reset ();
        return - 1;
    }
    if (! DataAvailable)
        _DataReady.Reset ();
    Array.Copy (lBuffer, buffer, lBuffer.Length);
    return lBuffer.Length;
}

