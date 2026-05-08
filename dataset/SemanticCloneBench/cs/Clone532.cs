/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:19995607
*  Stack Overflow answer #:19995685
*  And Stack Overflow answer#:19995678
*/
private void AddNode (int valueToBeInserted, Node current) {
    if (valueToBeInserted < current.value) {
        if (current.left == null)
            current.left = new Node (valueToBeInserted);
        else
            AddNode (valueToBeInserted, current.left);
    }
    if (valueToBeInserted > current.value) {
        if (current.right == null)
            current.right = new Node (valueToBeInserted);
        else
            AddNode (valueToBeInserted, current.right);
    }
}

public void AddNode (int valueToBeInserted) {
    if (this.root == null) {
        this.root = new Node (valueToBeInserted);
    }
    if (valueToBeInserted < this.root.value) {
        this.root.left = this.AddNode (valueToBeInserted);
        this.root = this.root.left;
    }
    if (valueToBeInserted > this.root.value) {
        this.root.right = this.AddNode (valueToBeInserted);
        this.root = this.root.right;
    }
}

