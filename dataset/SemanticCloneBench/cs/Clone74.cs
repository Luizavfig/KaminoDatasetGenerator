/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:30926684
*  Stack Overflow answer #:31135133
*  And Stack Overflow answer#:31135133
*/
public static HtmlNode TruncateInnerText (HtmlNode node, int length) {
    if (node == null)
        throw new ArgumentNullException ("node");
    if (node.InnerText.Length < length)
        return node;
    HtmlNode clone = node.CloneNode (false);
    TruncateInnerText (node, clone, clone, length);
    return clone;
}

private static void TruncateInnerText (HtmlNode source, HtmlNode root, HtmlNode current, int length) {
    HtmlNode childClone;
    foreach (HtmlNode child in source.ChildNodes) {
        int expectedSize = child.InnerText.Length + root.InnerText.Length;
        if (expectedSize <= length) {
            childClone = child.CloneNode (true);
            current.ChildNodes.Add (childClone);
            continue;
        }
        HtmlTextNode text = child as HtmlTextNode;
        if (text != null) {
            int remove = expectedSize - length;
            childClone = root.OwnerDocument.CreateTextNode (text.InnerText.Substring (0, text.InnerText.Length - remove));
            current.ChildNodes.Add (childClone);
            return;
        }
        childClone = child.CloneNode (false);
        current.ChildNodes.Add (childClone);
        TruncateInnerText (child, root, childClone, length);
    }
}

