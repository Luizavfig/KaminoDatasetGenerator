/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:2203975
*  Stack Overflow answer #:2204091
*  And Stack Overflow answer#:2207972
*/
public static void MoveUp (this TreeNode node) {
    TreeNode parent = node.Parent;
    TreeView view = node.TreeView;
    if (parent != null) {
        int index = parent.Nodes.IndexOf (node);
        if (index > 0) {
            parent.Nodes.RemoveAt (index);
            parent.Nodes.Insert (index - 1, node);
        }
    } else if (node.TreeView.Nodes.Contains (node)) {
        int index = view.Nodes.IndexOf (node);
        if (index > 0) {
            view.Nodes.RemoveAt (index);
            view.Nodes.Insert (index - 1, node);
        }
    }
}

public static void MoveUp (this TreeNode node) {
    TreeNode parent = node.Parent;
    if (parent != null) {
        int index = parent.Nodes.IndexOf (node);
        if (index > 0) {
            parent.Nodes.RemoveAt (index);
            parent.Nodes.Insert (index - 1, node);
            node.TreeView.SelectedNode = node;
        }
    }
}

