/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:14983713
*  Stack Overflow answer #:15080211
*  And Stack Overflow answer#:15075538
*/
public Message WrapB (int b, int millisecondsTimeout) {
    int count = 0;
    while (Interlocked.CompareExchange (ref pendingB, b, EMPTY) != EMPTY) {
        Thread.SpinWait ((4 << count ++));
        if (count > 10) {
            return new Message (null, b);
        }
    }
    while (Interlocked.CompareExchange (ref pendingB, EMPTY, EMPTY) == b) {
        Thread.SpinWait ((4 << count ++));
        if (count > 20) {
            int payload = Interlocked.CompareExchange (ref pendingB, EMPTY, b);
            return payload == b ? new Message (null, b) : null;
        }
    }
    return null;
}

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

