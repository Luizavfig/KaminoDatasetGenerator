/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:6406022
*  Stack Overflow answer #:6657101
*  And Stack Overflow answer#:6723928
*/
private int CountOccurrences (string TestString, string TestPattern) {
    int PatternCount = 0;
    int SearchIndex = 0;
    if (TestPattern.Length == 0)
        throw new ApplicationException ("CountOccurrences: Unable to process because TestPattern has zero length.");
    if (TestString.Length == 0)
        return 0;
    do
        {
            SearchIndex = TestString.IndexOf (TestPattern, SearchIndex);
            if (SearchIndex >= 0) {
                ++ PatternCount;
                SearchIndex += TestPattern.Length;
            }
        } while ((SearchIndex >= 0) && (SearchIndex < TestString.Length));
    return PatternCount;
}

public static IEnumerable < int > Find < T > (T [] pattern, T [] sequence, bool overlap) {
    int i = 0;
    while (i < sequence.Length - pattern.Length + 1) {
        if (pattern.SequenceEqual (sequence.Skip (i).Take (pattern.Length))) {
            yield return i;
            i += overlap ? 1 : pattern.Length;
        } else {
            i ++;
        }
    }
}

