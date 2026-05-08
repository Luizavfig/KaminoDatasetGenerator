/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:3823848
*  Stack Overflow answer #:33104179
*  And Stack Overflow answer#:33325874
*/
static void Main () {
    LinkedList < int > LL = new LinkedList < int > ();
    if (! LL.Contain (0))
        Console.WriteLine ("0 is not exist.");
    LL.Print ();
    LL.Add (0);
    LL.Add (1);
    LL.Add (2);
    LL.Add (2);
    if (LL.Contain (0))
        Console.WriteLine ("0 is exist.");
    LL.Print ();
    LL.Delete (0);
    LL.Delete (2);
    if (! LL.Delete (0))
        Console.WriteLine ("0 is not exist.");
    LL.Print ();
    Console.ReadLine ();
}

public T Remove (Node < T > node) {
    if (_head == null)
        return node.Value;
    if (_head == node) {
        _head = _head.Next;
        node.Next = null;
        return node.Value;
    }
    var current = _head;
    while (current.Next != null) {
        if (current.Next == node) {
            current.Next = node.Next;
            return node.Value;
        }
        current = current.Next;
    }
    return node.Value;
}

