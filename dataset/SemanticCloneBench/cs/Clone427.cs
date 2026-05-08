/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:18908056
*  Stack Overflow answer #:31102487
*  And Stack Overflow answer#:18908871
*/
public int [] solution (int N, int [] A) {
    var currentMax = 0;
    var resetValue = 0;
    var counters = Enumerable.Range (1, N).ToDictionary (i = > i, i = > 0);
    foreach (var a in A) {
        if (a == N + 1)
            resetValue = currentMax;
        else {
            counters [a] = Math.Max (counters [a], resetValue) + 1;
            currentMax = Math.Max (currentMax, counters [a]);
        }
    }
    return counters.Values.Select (v = > Math.Max (v, resetValue)).ToArray ();
}

public int [] solution (int N, int [] A) {
    int [] result = new int [N];
    int maximum = 0;
    int resetLimit = 0;
    for (int K = 0; K < A.Length; K ++) {
        if (A [K] < 1 || A [K] > N + 1)
            throw new InvalidOperationException ();
        if (A [K] >= 1 && A [K] <= N) {
            if (result [A [K] - 1] < resetLimit) {
                result [A [K] - 1] = resetLimit + 1;
            } else {
                result [A [K] - 1] ++;
            }
            if (result [A [K] - 1] > maximum) {
                maximum = result [A [K] - 1];
            }
        } else {
            resetLimit = maximum;
        }
    }
    for (int i = 0; i < result.Length; i ++)
        result [i] = Math.Max (resetLimit, result [i]);
    return result;
}

