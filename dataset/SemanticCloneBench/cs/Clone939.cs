/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:49116840
*  Stack Overflow answer #:49119918
*  And Stack Overflow answer#:49117787
*/
int IComparer < string >.Compare (string x, string y) {
    if (x == y)
        return 0;
    string [] x1, y1;
    if (! table.TryGetValue (x, out x1)) {
        x1 = Regex.Split (x.Replace (" ", ""), "([0-9]+)");
        table.Add (x, x1);
    }
    if (! table.TryGetValue (y, out y1)) {
        y1 = Regex.Split (y.Replace (" ", ""), "([0-9]+)");
        table.Add (y, y1);
    }
    int returnVal;
    for (int i = 0; i < x1.Length && i < y1.Length; i ++) {
        if (x1 [i] != y1 [i]) {
            returnVal = PartCompare (x1 [i], y1 [i]);
            return isAscending ? returnVal : - returnVal;
        }
    }
    if (y1.Length > x1.Length) {
        returnVal = 1;
    } else if (x1.Length > y1.Length) {
        returnVal = - 1;
    } else {
        returnVal = 0;
    }
    return isAscending ? returnVal : - returnVal;
}

public int Compare (string s1, string s2) {
    var list1 = _Regex.Matches (s1).Cast < Match > ().Select (m = > m.Value.Trim ()).ToList ();
    var list2 = _Regex.Matches (s2).Cast < Match > ().Select (m = > m.Value.Trim ()).ToList ();
    var min = Math.Min (list1.Count, list2.Count);
    int comp = 0;
    for (int i = 0; i < min; i ++) {
        int intx, inty;
        if (int.TryParse (list1 [i], out intx) && int.TryParse (list2 [i], out inty))
            comp = intx - inty;
        else
            comp = String.Compare (list1 [i], list2 [i]);
        if (comp != 0)
            return comp;
    }
    return list1.Count - list2.Count;
}

