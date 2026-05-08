/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:33673080
*  Stack Overflow answer #:33693432
*  And Stack Overflow answer#:33673725
*/
static int IndexOfLongestRun (string input) {
    int longestRunStart = - 1, longestRunLength = 0;
    for (int i = 0; i < input.Length;) {
        var runValue = input [i];
        int runStart = i;
        while (++ i < input.Length && input [i] == runValue) {
        }
        int runLength = i - runStart;
        if (longestRunLength < runLength) {
            longestRunStart = runStart;
            longestRunLength = runLength;
        }
    }
    return longestRunStart;
}

int IndexOfLongestRun (string input) {
    int bestIndex = 0, bestScore = 0, currIndex = 0;
    for (var i = 0; i < input.Length; ++ i) {
        if (input [i] == input [currIndex]) {
            if (bestScore < i - currIndex) {
                bestIndex = currIndex;
                bestScore = i - currIndex;
            }
        } else {
            currIndex = i;
        }
    }
    return bestIndex;
}

