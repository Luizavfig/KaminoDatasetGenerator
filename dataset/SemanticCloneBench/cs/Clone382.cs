/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:33022993
*  Stack Overflow answer #:33025258
*  And Stack Overflow answer#:33025258
*/
protected override int CompareDerived (JObject x, JObject y) {
    int comp;
    foreach (var propertyComp in x.Properties ().OrderBy (p = > p.Name).Zip (y.Properties ().OrderBy (p = > p.Name), (xp, yp) = > JTokenComparer.Instance.Compare (xp, yp)))
        if (propertyComp != 0)
            return propertyComp;
    if ((comp = x.Count.CompareTo (y.Count)) != 0)
        return comp;
    return 0;
}

protected override int CompareDerived (JConstructor x, JConstructor y) {
    int comp;
    if ((comp = x.Name.CompareTo (y.Name)) != 0)
        return comp;
    if ((comp = CompareItemsInOrder (x, y)) != 0)
        return comp;
    return 0;
}

