/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:283456
*  Stack Overflow answer #:284026
*  And Stack Overflow answer#:1807740
*/
public static List < Int32 > LocateSubset (Byte [] superSet, Byte [] subSet) {
    if ((superSet == null) || (subSet == null)) {
        throw new ArgumentNullException ();
    }
    if ((superSet.Length < subSet.Length) || (superSet.Length == 0) || (subSet.Length == 0)) {
        return new List < Int32 > ();
    }
    var result = new List < Int32 > ();
    Int32 currentIndex = 0;
    Int32 maxIndex = superSet.Length - subSet.Length;
    while (currentIndex < maxIndex) {
        Int32 matchCount = CountMatches (superSet, currentIndex, subSet);
        if (matchCount == subSet.Length) {
            result.Add (currentIndex);
        }
        currentIndex ++;
        if (matchCount > 0) {
            currentIndex += matchCount - 1;
        }
    }
    return result;
}

static public int SearchBytePattern (byte [] pattern, byte [] bytes) {
    int matches = 0;
    for (int i = 0; i < bytes.Length; i ++) {
        if (pattern [0] == bytes [i] && bytes.Length - i >= pattern.Length) {
            bool ismatch = true;
            for (int j = 1; j < pattern.Length && ismatch == true; j ++) {
                if (bytes [i + j] != pattern [j])
                    ismatch = false;
            }
            if (ismatch) {
                matches ++;
                i += pattern.Length - 1;
            }
        }
    }
    return matches;
}

