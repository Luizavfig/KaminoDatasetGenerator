/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:11208446
*  Stack Overflow answer #:11208801
*  And Stack Overflow answer#:11208543
*/
public static IEnumerable < IEnumerable < T > > QuickPerm < T > (this IEnumerable < T > set) {
    int N = set.Count ();
    int [] a = new int [N];
    int [] p = new int [N];
    var yieldRet = new T [N];
    List < T > list = new List < T > (set);
    int i, j, tmp;
    for (i = 0; i < N; i ++) {
        a [i] = i + 1;
        p [i] = 0;
    }
    yield return list;
    i = 1;
    while (i < N) {
        if (p [i] < i) {
            j = i % 2 * p [i];
            tmp = a [j];
            a [j] = a [i];
            a [i] = tmp;
            for (int x = 0; x < N; x ++) {
                yieldRet [x] = list [a [x] - 1];
            }
            yield return yieldRet;
            p [i] ++;
            i = 1;
        } else {
            p [i] = 0;
            i ++;
        }
    }
}

private static bool NextPermutation (int [] numList) {
    var largestIndex = - 1;
    for (var i = numList.Length - 2; i >= 0; i --) {
        if (numList [i] < numList [i + 1]) {
            largestIndex = i;
            break;
        }
    }
    if (largestIndex < 0)
        return false;
    var largestIndex2 = - 1;
    for (var i = numList.Length - 1; i >= 0; i --) {
        if (numList [largestIndex] < numList [i]) {
            largestIndex2 = i;
            break;
        }
    }
    var tmp = numList [largestIndex];
    numList [largestIndex] = numList [largestIndex2];
    numList [largestIndex2] = tmp;
    for (int i = largestIndex + 1, j = numList.Length - 1; i < j; i ++, j --) {
        tmp = numList [i];
        numList [i] = numList [j];
        numList [j] = tmp;
    }
    return true;
}

