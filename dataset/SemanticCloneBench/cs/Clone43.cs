/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:15657637
*  Stack Overflow answer #:15657638
*  And Stack Overflow answer#:28154947
*/
public T Dequeue () {
    lock (q)
    {
        for (;;) {
            if (q.Count > 0) {
                return q.Dequeue ();
            }
            System.Threading.Monitor.Wait (q);
        }
    }}

public T Dequeue () {
    T t;
    lock (q)
    {
        while (q.Count == 0) {
            System.Threading.Monitor.Wait (q);
        }
        t = q.Dequeue ();
    } System.Threading.Monitor.Pulse (q);
    return t;
}

