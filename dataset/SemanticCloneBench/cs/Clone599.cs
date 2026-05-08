/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:2613932
*  Stack Overflow answer #:41997778
*  And Stack Overflow answer#:41997778
*/
private EventHandlerFunction popEvent () {
    EventHandlerFunction ret = null;
    lock (eventQueueLock)
    {
        int b = (queueOutIndex + 1) & 255;
        if (queueOutIndex == queueInIndex) {
            mainLoopWaitHandle.Reset ();
            return null;
        }
        ret = eventQueue [queueOutIndex];
        eventQueue [queueOutIndex] = null;
        queueOutIndex = b;
    } return ret;
}

public void run () {
    while (running) {
        mainLoopWaitHandle.WaitOne ();
        EventHandlerFunction f = null;
        while (running) {
            f = popEvent ();
            if (f == null)
                break;
            f ();
        }
    }
}

