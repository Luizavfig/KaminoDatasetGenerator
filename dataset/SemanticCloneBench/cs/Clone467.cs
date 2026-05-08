/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:16141643
*  Stack Overflow answer #:16141922
*  And Stack Overflow answer#:16141868
*/
public static bool IsAnagram (string s1, string s2) {
    if (string.IsNullOrEmpty (s1) || string.IsNullOrEmpty (s2))
        return false;
    if (s1.Length != s2.Length)
        return false;
    foreach (char c in s2) {
        int ix = s1.IndexOf (c);
        if (ix >= 0)
            s1 = s1.Remove (ix, 1);
        else
            return false;
    }
    return string.IsNullOrEmpty (s1);
}

public static bool IsAnagram (String s, String t) {
    if ((s == null) || (t == null) || (s.Length == 0) || (t.Length == 0) || (s.Length != t.Length))
        return false;
    var ta = t.ToCharArray ();
    foreach (char ch in s) {
        int x = Array.IndexOf (ta, ch);
        if (x < 0)
            return false;
        ta [x] = '\0';
    }
    return true;
}

