/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:2203975
*  Stack Overflow answer #:2204091
*  And Stack Overflow answer#:2207972
*/
public static void MoveDown (this TreeNode node) {
    TreeNode parent = node.Parent;
    TreeView view = node.TreeView;
    if (parent != null) {
        int index = parent.Nodes.IndexOf (node);
        if (index < parent.Nodes.Count - 1) {
            parent.Nodes.RemoveAt (index);
            parent.Nodes.Insert (index + 1, node);
        }
    } else if (view != null && view.Nodes.Contains (node)) {
        int index = view.Nodes.IndexOf (node);
        if (index < view.Nodes.Count - 1) {
            view.Nodes.RemoveAt (index);
            view.Nodes.Insert (index + 1, node);
        }
    }
}

public static void MoveDown (this TreeNode node) {
    TreeNode parent = node.Parent;
    if (parent != null) {
        int index = parent.Nodes.IndexOf (node);
        if (index < parent.Nodes.Count - 1) {
            parent.Nodes.RemoveAt (index);
            parent.Nodes.Insert (index + 1, node);
            node.TreeView.SelectedNode = node;
        }
    }
}

