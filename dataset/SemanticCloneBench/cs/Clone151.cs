/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:33673080
*  Stack Overflow answer #:39909027
*  And Stack Overflow answer#:33673725
*/
public static int IndexOfLongestRun (string str) {
    var longestRunCount = 1;
    var longestRunIndex = 0;
    var isNew = false;
    var dic = new Dictionary < int, int > ();
    for (var i = 0; i < str.Length - 1; i ++) {
        if (str [i] == str [i + 1]) {
            if (isNew)
                longestRunIndex = i;
            longestRunCount ++;
            isNew = false;
        } else {
            isNew = true;
            dic.Add (longestRunIndex, longestRunCount);
            longestRunIndex = 0;
            longestRunCount = 1;
        }
    }
    return dic.OrderByDescending (x = > x.Value).First ().Key;
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

