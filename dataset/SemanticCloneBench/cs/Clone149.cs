/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:33673080
*  Stack Overflow answer #:33673435
*  And Stack Overflow answer#:39909027
*/
private static int IndexOfLongestRun (string str) {
    char [] array1 = str.ToCharArray ();
    Comparer comparer = new Comparer ();
    int counter = 1;
    int maxCount = 0;
    int idenxOf = 0;
    int i;
    for (i = 0; i < array1.Length - 1; i ++) {
        if (comparer.Compare (array1 [i], array1 [i + 1]) == 0) {
            counter ++;
        } else {
            if (maxCount < counter) {
                maxCount = counter;
                idenxOf = i - counter + 1;
            }
            counter = 1;
        }
    }
    if (maxCount < counter) {
        maxCount = counter;
        idenxOf = i - counter + 1;
    }
    return idenxOf;
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

