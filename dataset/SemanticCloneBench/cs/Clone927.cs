/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:3113542
*  Stack Overflow answer #:3596315
*  And Stack Overflow answer#:3596315
*/
private static void SanitizeNode (HtmlNode node) {
    if (node.NodeType == HtmlNodeType.Element) {
        if (! Whitelist.ContainsKey (node.Name)) {
            if (! DeletableNodesXpath.Contains (node.Name)) {
                node.Name = "removeableNode";
                DeletableNodesXpath.Add (node.Name);
            }
            if (node.HasChildNodes) {
                SanitizeChildren (node);
            }
            return;
        }
        if (node.HasAttributes) {
            for (int i = node.Attributes.Count - 1; i >= 0; i --) {
                HtmlAttribute currentAttribute = node.Attributes [i];
                string [] allowedAttributes = Whitelist [node.Name];
                if (allowedAttributes != null) {
                    if (! allowedAttributes.Contains (currentAttribute.Name)) {
                        node.Attributes.Remove (currentAttribute);
                    }
                } else {
                    node.Attributes.Remove (currentAttribute);
                }
            }
        }
    }
    if (node.HasChildNodes) {
        SanitizeChildren (node);
    }
}

private static string StripHtml (string html, string xPath) {
    HtmlDocument htmlDoc = new HtmlDocument ();
    htmlDoc.LoadHtml (html);
    if (xPath.Length > 0) {
        HtmlNodeCollection invalidNodes = htmlDoc.DocumentNode.SelectNodes (@xPath);
        foreach (HtmlNode node in invalidNodes) {
            node.ParentNode.RemoveChild (node, true);
        }
    }
    return htmlDoc.DocumentNode.WriteContentTo ();
    ;}

