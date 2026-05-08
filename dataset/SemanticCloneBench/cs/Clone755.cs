/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:14983713
*  Stack Overflow answer #:15075538
*  And Stack Overflow answer#:15116414
*/
public Message WrapB (int b, int millisecondsTimeout) {
    Message returnMessage = null;
    bool lockTaken = false;
    Monitor.TryEnter (gate, 100, ref lockTaken);
    if (lockTaken) {
        if (pendingB != null) {
            Monitor.Wait (gate, 100);
        }
        if (pendingB != null) {
            returnMessage = new Message (null, b);
        } else {
            pendingB = b;
            if (! Monitor.Wait (gate, millisecondsTimeout)) {
                pendingB = null;
                Monitor.Pulse (gate);
                returnMessage = new Message (null, b);
            }
        }
        Monitor.Exit (gate);
    } else {
        returnMessage = new Message (null, b);
    }
    return returnMessage;
}

public Message WrapB (int b, int millisecondsTimeout) {
    var timespentInLock = Stopwatch.StartNew ();
    lock (bMessageLock)
    {
        pendingB = b;
        CloseGate ();
        if (timespentInLock.ElapsedMilliseconds < millisecondsTimeout && gateOpen.WaitOne (millisecondsTimeout - (int) timespentInLock.ElapsedMilliseconds)) {
            lock (pendingBLock)
            {
                return null;
            }} else {
            lock (pendingBLock)
            {
                OpenGate ();
                pendingB = null;
                return new Message (null, b);
            }}
    }}

