/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:2510975
*  Stack Overflow answer #:15773995
*  And Stack Overflow answer#:2572919
*/
public T GetFromPool () {
    T item = null;
    do
        {
            lock (this)
            {
                if (this.pool.Count == 0) {
                    if (this.currentSize < this.maxSize) {
                        item = this.constructor ();
                        this.currentSize ++;
                    }
                } else {
                    item = this.pool.Dequeue ();
                }
            } if (null == item) {
                this.poolReleasedEvent.WaitOne ();
            }
        } while (null == item);
    return item;
}

public T Fetch () {
    if (Count == 0)
        throw new InvalidOperationException ("The buffer is empty.");
    int startPosition = position;
    do
        {
            Advance ();
            Slot slot = slots [position];
            if (! slot.IsInUse) {
                slot.IsInUse = true;
                -- freeSlotCount;
                return slot.Item;
            }
        } while (startPosition != position);
    throw new InvalidOperationException ("No free slots.");
}

