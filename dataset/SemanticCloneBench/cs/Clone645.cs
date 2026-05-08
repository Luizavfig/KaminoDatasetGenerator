/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:17484682
*  Stack Overflow answer #:17484778
*  And Stack Overflow answer#:17484975
*/
IEnumerable < Control > FindRecursive (Control c, Func < Control, bool > predicate) {
    if (predicate (c))
        yield return c;
    foreach (var child in c.Controls) {
        if (predicate (c))
            yield return c;
    }
    foreach (var child in c.Controls)
        foreach (var match in FindRecursive (c, predicate))
            yield return match;
}

protected void Page_PreRender (Object sender, EventArgs e) {
    string thisHtml = RenderControl (this.Form);
    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument ();
    doc.LoadHtml (thisHtml);
    var nodeColl = doc.DocumentNode.SelectNodes ("//*[contains(@class,'fooClass')]");
    Console.WriteLine ("Count: " + nodeColl.Count);
    var nodes = doc.DocumentNode.Descendants ().Where (d = > d.Attributes.Contains ("class") && d.Attributes ["class"].Value == "fooClass");
    Console.WriteLine ("Count: " + nodes.Count ());
}

