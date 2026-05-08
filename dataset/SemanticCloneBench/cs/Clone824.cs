/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:11161546
*  Stack Overflow answer #:11161782
*  And Stack Overflow answer#:11161804
*/
public Node FindNode (Node rootNode) {
    if (rootNode.Content.Contains (stringToFind))
        return rootNode;
    foreach (Node node in rootNode.Children) {
        if (node.Content.Contains (stringToFind))
            return node;
        else
            return FindNode (node);
    }
    return null;
}

Node FindNode2 (Node rootNode, string stringToFind) {
    var stack = new Stack < Node > (new [] {rootNode});
    while (stack.Any ()) {
        var n = stack.Pop ();
        if (n.Content == stringToFind)
            return n;
        foreach (var child in n.Children)
            stack.Push (child);
    }
    return null;
}

