/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:44456897
*  Stack Overflow answer #:44457069
*  And Stack Overflow answer#:44457505
*/
public int Compare (string s1, string s2) {
    if (IsNumeric (s1) && IsNumeric (s2)) {
        if (Convert.ToInt32 (s1) > Convert.ToInt32 (s2))
            return 1;
        if (Convert.ToInt32 (s1) < Convert.ToInt32 (s2))
            return - 1;
        if (Convert.ToInt32 (s1) == Convert.ToInt32 (s2))
            return 0;
    }
    if (IsNumeric (s1) && ! IsNumeric (s2))
        return 1;
    if (! IsNumeric (s1) && IsNumeric (s2))
        return - 1;
    return string.Compare (s1, s2, true);
}

public int Compare (string s1, string s2) {
    int i1, i2;
    bool b1 = int.TryParse (s1, out i1);
    bool b2 = int.TryParse (s2, out i2);
    if (b1 && b2) {
        return i1.CompareTo (i2);
    }
    if (b1)
        return 1;
    if (b2)
        return - 1;
    return string.Compare (s1, s2, true);
}

