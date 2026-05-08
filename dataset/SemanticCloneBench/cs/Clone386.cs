/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:2344320
*  Stack Overflow answer #:40775015
*  And Stack Overflow answer#:2344340
*/
public static int LevenshteinDistance (string source, string target) {
    if (source == target)
        return 0;
    if (source.Length == 0)
        return target.Length;
    if (target.Length == 0)
        return source.Length;
    int [] v0 = new int [target.Length + 1];
    int [] v1 = new int [target.Length + 1];
    for (int i = 0; i < v0.Length; i ++)
        v0 [i] = i;
    for (int i = 0; i < source.Length; i ++) {
        v1 [0] = i + 1;
        for (int j = 0; j < target.Length; j ++) {
            var cost = (source [i] == target [j]) ? 0 : 1;
            v1 [j + 1] = Math.Min (v1 [j] + 1, Math.Min (v0 [j + 1] + 1, v0 [j] + cost));
        }
        for (int j = 0; j < v0.Length; j ++)
            v0 [j] = v1 [j];
    }
    return v1 [target.Length];
}

public static int LevenshteinDistance (string first, string second) {
    if (first == null) {
        throw new ArgumentNullException ("first");
    }
    if (second == null) {
        throw new ArgumentNullException ("second");
    }
    int n = first.Length;
    int m = second.Length;
    var d = new int [n + 1, m + 1];
    if (n == 0)
        return m;
    if (m == 0)
        return n;
    for (int i = 0; i <= n; d [i, 0] = i ++) {
    }
    for (int j = 0; j <= m; d [0, j] = j ++) {
    }
    for (int i = 1; i <= n; i ++) {
        for (int j = 1; j <= m; j ++) {
            int cost = (second.Substring (j - 1, 1) == first.Substring (i - 1, 1) ? 0 : 1);
            d [i, j] = Math.Min (Math.Min (d [i - 1, j] + 1, d [i, j - 1] + 1), d [i - 1, j - 1] + cost);
        }
    }
    return d [n, m];
}

