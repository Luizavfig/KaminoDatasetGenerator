/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:16612086
*  Stack Overflow answer #:16612122
*  And Stack Overflow answer#:16612711
*/
private int CompareNumbers (string x, string y) {
    for (int i = int.Max (x.Length, y.Length); i >= 0; i --) {
        char xc = GetEffectiveDigit (x, i);
        char yc = GetEffectiveDigit (y, i);
        int comparison = xc.CompareTo (yc);
        if (comparison != 0) {
            return comparison;
        }
    }
    return 0;
}

public static int CompareNumbers (string x, string y) {
    if (x.Length > y.Length)
        y = y.PadLeft (x.Length, '0');
    else if (y.Length > x.Length)
        x = x.PadLeft (y.Length, '0');
    for (int i = 0; i < x.Length; i ++) {
        if (x [i] < y [i])
            return - 1;
        if (x [i] > y [i])
            return 1;
    }
    return 0;
}

