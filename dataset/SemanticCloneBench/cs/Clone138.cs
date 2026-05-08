/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:1181561
*  Stack Overflow answer #:5009211
*  And Stack Overflow answer#:4974888
*/
public static void FlushLogs () {
    int queueCount;
    bool isProcessingLogs;
    while (true) {
        m_waitingThreadEvent.WaitOne ();
        lock (m_isProcessingLogsSync)
        {
            isProcessingLogs = m_isProcessingLogs;
        } lock (m_loggerQueueSync)
        {
            queueCount = m_loggerQueue.Count;
        } if (queueCount == 0 && ! isProcessingLogs)
            break;
        Thread.Sleep (400);
    }
}

public static void FlushLogs () {
    bool queueHasValues = true;
    while (queueHasValues) {
        m_waitingThreadEvent.WaitOne ();
        lock (m_loggerQueueSync)
        {
            queueHasValues = m_loggerQueue.Count > 0;
        }}
    foreach (MEL.LogSource logSource in MEL.Logger.Writer.TraceSources.Values) {
        foreach (TraceListener listener in logSource.Listeners) {
            listener.Flush ();
        }
    }
}

