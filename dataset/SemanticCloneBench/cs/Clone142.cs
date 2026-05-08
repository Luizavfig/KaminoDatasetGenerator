/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:8971530
*  Stack Overflow answer #:8971755
*  And Stack Overflow answer#:8971801
*/
public int Compare (string x, string y) {
    string [] xs = x.Split ('.');
    string [] ys = y.Split ('.');
    int maxLoop = Math.Min (xs.Length, ys.Length);
    for (int i = 0; i < maxLoop; i ++) {
        if (int.Parse (xs [i]) > int.Parse (ys [i])) {
            return 1;
        } else if (int.Parse (xs [i]) < int.Parse (ys [i])) {
            return - 1;
        }
    }
    if (xs.Length > ys.Length) {
        return 1;
    } else if (xs.Length < ys.Length) {
        return - 1;
    }
    return 0;
}

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

