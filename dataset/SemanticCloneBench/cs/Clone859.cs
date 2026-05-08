/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:2538726
*  Stack Overflow answer #:2549018
*  And Stack Overflow answer#:2549018
*/
public IEnumerable < T > DequeueAll () {
    while (! shutDown) {
        do
            {
                T item;
                lock (queue)
                {
                    if (queue.Count == 0) {
                        if (shutDown)
                            break;
                        Monitor.Wait (queue);
                        if (queue.Count == 0)
                            break;
                    }
                    item = queue.Dequeue ();
                } yield return item;
            } while (! shutDown);
    }
}

public bool Enqueue (T item) {
    if (! shutDown) {
        lock (queue)
        {
            queue.Enqueue (item);
            if (queue.Count == 1) {
                Monitor.PulseAll (queue);
            }
        } return true;
    }
    return false;
}

