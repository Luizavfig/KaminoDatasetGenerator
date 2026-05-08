/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:2294728
*  Stack Overflow answer #:9509677
*  And Stack Overflow answer#:2294834
*/
static int [,] GetLCSDifferenceMatrix < T > (Collection < T > baseline, Collection < T > revision) {
    int [,] matrix = new int [baseline.Count + 1, revision.Count + 1];
    for (int baselineIndex = 0; baselineIndex < baseline.Count; baselineIndex ++) {
        for (int revisionIndex = 0; revisionIndex < revision.Count; revisionIndex ++) {
            if (baseline [baselineIndex].Equals (revision [revisionIndex])) {
                matrix [baselineIndex + 1, revisionIndex + 1] = matrix [baselineIndex, revisionIndex] + 1;
            } else {
                int possibilityOne = matrix [baselineIndex + 1, revisionIndex];
                int possibilityTwo = matrix [baselineIndex, revisionIndex + 1];
                matrix [baselineIndex + 1, revisionIndex + 1] = Math.Max (possibilityOne, possibilityTwo);
            }
        }
    }
    return matrix;
}

private String longestCommonWord (String s1, String s2) {
    String [] seperators = new String [] {" ", ",", ".", "!", "?", ";"};
    var result = from w1 in s1.Split (seperators, StringSplitOptions.RemoveEmptyEntries)
        where (from w2 in s2.Split (seperators, StringSplitOptions.RemoveEmptyEntries)
            where w2 == w1
            select w2).Count () > 0
        orderby w1.Length descending
        select w1;
    if (result.Count () > 0) {
        return result.First ();
    } else {
        return null;
    }
}

