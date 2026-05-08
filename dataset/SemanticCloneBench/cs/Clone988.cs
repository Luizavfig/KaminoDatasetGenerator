/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:4106862
*  Stack Overflow answer #:17096825
*  And Stack Overflow answer#:24058279
*/
public static IEnumerable < string > TSort (this IEnumerable < string > source, Func < string, IEnumerable < string > > dependencies) {
    TopologicalSorter.LastCyclicOrder.Clear ();
    List < ItemTag > allNodes = new List < ItemTag > ();
    HashSet < string > sorted = new HashSet < string > (StringComparer.OrdinalIgnoreCase);
    foreach (string item in source) {
        if (! allNodes.Where (n = > string.Equals (n.Item, item, StringComparison.OrdinalIgnoreCase)).Any ()) {
            allNodes.Add (new ItemTag (item));
        }
        foreach (string dep in dependencies (item)) {
            if (allNodes.Where (n = > string.Equals (n.Item, dep, StringComparison.OrdinalIgnoreCase)).Any ())
                continue;
            allNodes.Add (new ItemTag (dep));
        }
    }
    foreach (ItemTag tag in allNodes) {
        Visit (tag, allNodes, dependencies, sorted);
    }
    return sorted;
}

public static IEnumerable < T > TopologicalSort < T > (this IEnumerable < T > nodes, Func < T, IEnumerable < T > > connected) {
    var elems = nodes.ToDictionary (node = > node, node = > new HashSet < T > (connected (node)));
    while (elems.Count > 0) {
        var elem = elems.FirstOrDefault (x = > x.Value.Count == 0);
        if (elem.Key == null) {
            throw new ArgumentException ("Cyclic connections are not allowed");
        }
        elems.Remove (elem.Key);
        foreach (var selem in elems) {
            selem.Value.Remove (elem.Key);
        }
        yield return elem.Key;
    }
}

