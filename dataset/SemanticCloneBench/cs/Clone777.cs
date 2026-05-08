/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:3473787
*  Stack Overflow answer #:3474514
*  And Stack Overflow answer#:3474514
*/
public static LinkedList < T > SwapPairwise < T > (this LinkedList < T > source) {
    if (source == null)
        throw new ArgumentNullException ("source");
    var current = source.First;
    if (current == null)
        return source;
    while (current.Next != null) {
        current.SwapWith (current.Next);
        current = current.Next;
        if (current != null)
            current = current.Next;
    }
    return source;
}

public static void SwapWith < T > (this LinkedListNode < T > first, LinkedListNode < T > second) {
    if (first == null)
        throw new ArgumentNullException ("first");
    if (second == null)
        throw new ArgumentNullException ("second");
    var tmp = first.Value;
    first.Value = second.Value;
    second.Value = tmp;
}

