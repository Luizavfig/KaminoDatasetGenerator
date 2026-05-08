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

