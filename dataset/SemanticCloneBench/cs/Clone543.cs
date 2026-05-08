/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:14983713
*  Stack Overflow answer #:15080211
*  And Stack Overflow answer#:15116414
*/
public Message WrapA (int a, int millisecondsTimeout) {
    int ? b;
    int count = 0;
    while ((b = Interlocked.Exchange (ref pendingB, EMPTY)) == EMPTY) {
        if (count % 7 == 0) {
            Thread.Sleep (0);
        } else if (count % 23 == 0) {
            Thread.Sleep (1);
        } else {
            Thread.Yield ();
        }
        if (++ count == 480) {
            return new Message (a, null);
        }
    }
    return new Message (a, b);
}

public Message WrapA (int a, int millisecondsTimeout) {
    if (IsGateOpen ()) {
        return new Message (a, null);
    } else {
        lock (pendingBLock)
        {
            OpenGate ();
            var message = new Message (a, pendingB);
            pendingB = null;
            return message;
        }}
}

