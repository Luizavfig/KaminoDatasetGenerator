/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:24690559
*  Stack Overflow answer #:49833659
*  And Stack Overflow answer#:52226420
*/
public int solution (int [] A) {
    int flag = 1;
    A = A.OrderBy (x = > x).ToArray ();
    for (int i = 0; i < A.Length; i ++) {
        if (A [i] <= 0)
            continue;
        else if (A [i] == flag) {
            flag ++;
        }
    }
    return flag;
}

public int solution (int [] array) {
    HashSet < int > found = new HashSet < int > ();
    for (int i = 0; i < array.Length; i ++) {
        if (array [i] > 0) {
            found.Add (array [i]);
        }
    }
    int result = 1;
    while (found.Contains (result)) {
        result ++;
    }
    return result;
}

