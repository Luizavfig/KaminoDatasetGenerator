/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:24335774
*  Stack Overflow answer #:24336124
*  And Stack Overflow answer#:24335995
*/
private TreeNode findValueStartingAtNode (TreeNode node, IComparable value) {
    Console.WriteLine ("looking for value {0}", value);
    if (node == null) {
        Console.WriteLine ("node is null -- returning null");
        return null;
    } else if (value.CompareTo (node.data) == 0) {
        Console.WriteLine ("value found at current node");
        Console.WriteLine ("current node data is {0}", node.data);
        Console.WriteLine ("done and returning node");
        return node;
    } else {
        Console.WriteLine ("checking left child");
        TreeNode left = findValueStartingAtNode (node.left_child, value);
        if (left != null)
            return left;
        Console.WriteLine ("checking right child");
        TreeNode right = findValueStartingAtNode (node.right_child, value);
        if (right != null)
            return right;
        Console.WriteLine ("value not found in either child");
        Console.WriteLine ("current node data is {0}", node.data);
        return null;
    }
}

private TreeNode findValueStartingAtNode (TreeNode node, IComparable value) {
    if (node == null)
        return null;
    int comp = value.CompareTo (node.data);
    if (comp == 0)
        return node;
    if (comp < 0)
        return findValueStartingAtNode (node.left_child, value);
    return findValueStartingAtNode (node.right_child, value);
}

