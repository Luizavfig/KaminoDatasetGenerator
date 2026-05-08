/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:35008715
*  Stack Overflow answer #:35009715
*  And Stack Overflow answer#:35009715
*/
public static int IndexOf (byte [] haystack, byte [] needle) {
    if (needle.Length == 0) {
        return 0;
    }
    int [] charTable = MakeCharTable (needle);
    int [] offsetTable = MakeOffsetTable (needle);
    for (int i = needle.Length - 1; i < haystack.Length;) {
        int j;
        for (j = needle.Length - 1; needle [j] == haystack [i]; -- i, -- j) {
            if (j == 0) {
                return i;
            }
        }
        i += Math.Max (offsetTable [needle.Length - 1 - j], charTable [haystack [i]]);
    }
    return - 1;
}

private static int [] MakeOffsetTable (byte [] needle) {
    int [] table = new int [needle.Length];
    int lastPrefixPosition = needle.Length;
    for (int i = needle.Length - 1; i >= 0; -- i) {
        if (IsPrefix (needle, i + 1)) {
            lastPrefixPosition = i + 1;
        }
        table [needle.Length - 1 - i] = lastPrefixPosition - i + needle.Length - 1;
    }
    for (int i = 0; i < needle.Length - 1; ++ i) {
        int slen = SuffixLength (needle, i);
        table [slen] = needle.Length - 1 - i + slen;
    }
    return table;
}

