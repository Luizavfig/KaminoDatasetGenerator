/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:7346384
*  Stack Overflow answer #:7347389
*  And Stack Overflow answer#:7347389
*/
public void add (object entry) {
    node newNode = new node (entry);
    if (headNode == null)
        headNode = newNode;
    if (tailNode != null)
        tailNode.next = newNode;
    tailNode = newNode;
    ++ node_count;
}

static int Main () {
    linkedList ll = new linkedList ();
    ll.add (8);
    ll.add (2);
    ll.add (7);
    ll.add (4);
    ll.add (9);
    ll.add (10);
    ll.returnData ();
    return 0;
}

