/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:33673080
*  Stack Overflow answer #:33693432
*  And Stack Overflow answer#:39909027
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

