/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:14280504
*  Stack Overflow answer #:14281353
*  And Stack Overflow answer#:14281240
*/
public void MethodA () {
    lock (key)
    {
        while (lockedType != this.GetType ()) {
            if (lockedType == null) {
                lockedType = this.GetType ();
                signal.Set ();
            } else if (lockedType != this.GetType ()) {
                signal.WaitOne ();
            }
        }
        Interlocked.Increment (ref threadsInMethodA);
    } semaphore.WaitOne ();
    try {
        MethodAImplementation ();
    }
    finally {
        lock (key)
        {
            semaphore.Release ();
            int threads = Interlocked.Decrement (ref threadsInMethodA);
            if (threads == 0) {
                lockedType = null;
                signal.Reset ();
            }
        }}
}

internal void MethodA () {
    lock (ClassA.setCurrentlyExcutingTypeLock)
    {
        while (! ((ClassA.currentlyExcutingType == null) || (ClassA.currentlyExcutingType == typeof (TDerived)))) {
            Monitor.Wait (ClassA.setCurrentlyExcutingTypeLock);
        }
        if (ClassA.currentlyExcutingType == null) {
            ClassA.currentlyExcutingType = typeof (TDerived);
        }
        ClassA.numberCurrentlyPossiblyExecutingThreads ++;
        Monitor.PulseAll (ClassA.setCurrentlyExcutingTypeLock);
    } try {
        ClassA < TDerived >.semaphore.WaitOne ();
        this.MethodACore ();
    }
    finally {
        ClassA < TDerived >.semaphore.Release ();
    }
    lock (ClassA.setCurrentlyExcutingTypeLock)
    {
        ClassA.numberCurrentlyPossiblyExecutingThreads --;
        if (ClassA.numberCurrentlyPossiblyExecutingThreads == 0) {
            ClassA.currentlyExcutingType = null;
            Monitor.Pulse (ClassA.setCurrentlyExcutingTypeLock);
        }
    }}

