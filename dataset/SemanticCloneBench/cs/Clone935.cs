/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:43500
*  Stack Overflow answer #:43353457
*  And Stack Overflow answer#:43518
*/
static void Main () {
    var dict = new Dictionary < string, int > ();
    dict.Add ("cat", 2);
    dict.Add ("dog", 3);
    dict.Add ("x", 4);
    var dict2 = new Dictionary < string, int > ();
    dict2.Add ("cat", 2);
    dict2.Add ("dog", 3);
    dict2.Add ("x", 4);
    bool equal = false;
    if (dict.Count == dict2.Count) {
        equal = true;
        foreach (var pair in dict) {
            int value;
            if (dict2.TryGetValue (pair.Key, out value)) {
                if (value != pair.Value) {
                    equal = false;
                    break;
                }
            } else {
                equal = false;
                break;
            }
        }
    }
    Console.WriteLine (equal);
}

public static bool IsEqual (this List < int > InternalList, List < int > ExternalList) {
    if (InternalList.Count != ExternalList.Count) {
        return false;
    } else {
        for (int i = 0; i < InternalList.Count; i ++) {
            if (InternalList [i] != ExternalList [i])
                return false;
        }
    }
    return true;
}

