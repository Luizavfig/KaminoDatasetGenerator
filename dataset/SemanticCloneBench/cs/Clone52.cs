/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:3823848
*  Stack Overflow answer #:17372444
*  And Stack Overflow answer#:33104179
*/
static void Main (string [] args) {
    Console.WriteLine ("Add First:");
    LinkedList myList1 = new LinkedList ();
    myList1.AddFirst ("Hello");
    myList1.AddFirst ("Magical");
    myList1.AddFirst ("World");
    myList1.printAllNodes ();
    Console.WriteLine ();
    Console.WriteLine ("Add Last:");
    LinkedList myList2 = new LinkedList ();
    myList2.AddLast ("Hello");
    myList2.AddLast ("Magical");
    myList2.AddLast ("World");
    myList2.printAllNodes ();
    Console.ReadLine ();
}

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

