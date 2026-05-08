/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:451950
*  Stack Overflow answer #:2493039
*  And Stack Overflow answer#:454597
*/
public static string GetAbsoluteXPath (this XElement element) {
    if (element == null) {
        throw new ArgumentNullException ("element");
    }
    Func < XElement, string > relativeXPath = e = > {
        int index = e.IndexPosition ();
        var currentNamespace = e.Name.Namespace;
        string name;
        if (currentNamespace == null) {
            name = e.Name.LocalName;
        } else {
            string namespacePrefix = e.GetPrefixOfNamespace (currentNamespace);
            name = namespacePrefix + ":" + e.Name.LocalName;
        }
        return (index == - 1) ? "/" + name : string.Format ("/{0}[{1}]", name, index.ToString ());
    };
    var ancestors = from e in element.Ancestors ()
        select relativeXPath (e);
    return string.Concat (ancestors.Reverse ().ToArray ()) + relativeXPath (element);
}

public static string GetAbsoluteXPath (this XElement element) {
    if (element == null) {
        throw new ArgumentNullException ("element");
    }
    Func < XElement, string > relativeXPath = e = > {
        int index = e.IndexPosition ();
        string name = e.Name.LocalName;
        return (index == - 1) ? "/" + name : string.Format ("/{0}[{1}]", name, index.ToString ());
    };
    var ancestors = from e in element.Ancestors ()
        select relativeXPath (e);
    return string.Concat (ancestors.Reverse ().ToArray ()) + relativeXPath (element);
}

