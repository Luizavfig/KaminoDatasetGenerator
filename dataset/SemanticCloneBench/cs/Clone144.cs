/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:8971530
*  Stack Overflow answer #:8971801
*  And Stack Overflow answer#:8971801
*/
private int Compare (string [] x, string [] y) {
    if (x.Length > y.Length)
        return - Compare (y, x);
    for (int i = 0; i != x.Length; ++ i) {
        int cmp = int.Parse (x [i]).CompareTo (int.Parse (y [i]));
        if (cmp != 0)
            return cmp;
    }
    return x.Length == y.Length ? 0 : - 1;
}

public int Compare (string x, string y) {
    if (ReferenceEquals (x, y))
        return 0;
    if (x == null)
        return - 1;
    if (y == null)
        return 1;
    try {
        return Compare (x.Split ('.'), y.Split ('.'));
    }
    catch (FormatException) {
        throw new ArgumentException ();
    }
}

