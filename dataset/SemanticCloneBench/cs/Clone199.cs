/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:7439653
*  Stack Overflow answer #:7439725
*  And Stack Overflow answer#:7439667
*/
public void Enqueue (T item) {
    if (queue.Contains (item)) {
        queue.Remove (item);
    }
    queue.Add (item);
    while (queue.Count > maximumSize) {
        Dequeue ();
    }
}

public void Enqueue (T item) {
    if (_queue.Count > 5)
        throw new Exception ();
    if (this.Contains (item))
        throw new Exception ();
    _queue.Enqueue (item);
}

