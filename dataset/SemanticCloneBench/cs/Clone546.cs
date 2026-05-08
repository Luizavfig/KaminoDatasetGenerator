/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:14983713
*  Stack Overflow answer #:15075538
*  And Stack Overflow answer#:15116414
*/
public Message WrapA (int a, int millisecondsTimeout) {
    Message returnMessage = null;
    bool lockTaken = false;
    Monitor.TryEnter (gate, 100, ref lockTaken);
    if (lockTaken) {
        returnMessage = new Message (a, pendingB);
        pendingB = null;
        Monitor.Pulse (gate);
        Monitor.Exit (gate);
    } else {
        returnMessage = new Message (a, null);
    }
    return returnMessage;
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

