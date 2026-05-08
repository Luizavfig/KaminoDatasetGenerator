/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:2338402
*  Stack Overflow answer #:2338985
*  And Stack Overflow answer#:5005823
*/
int equi (int [] A) {
    int equi = - 1;
    long lower = 0;
    long upper = 0;
    foreach (int i in A)
        upper += i;
    for (int i = 0; i < A.Length; i ++) {
        upper -= A [i];
        if (upper == lower) {
            equi = i;
            break;
        } else
            lower += A [i];
    }
    return equi;
}

private static ArrayList equi (int [] A) {
    ArrayList answer = new ArrayList ();
    if ((answer.Count == null)) {
        answer.Add (- 1);
        return answer;
    }
    long sum0 = 0, sum1 = 0;
    for (int i = 0; i < A.Length; i ++)
        sum0 += A [i];
    for (int i = 0; i < A.Length; i ++) {
        sum0 -= A [i];
        if (i > 0) {
            sum1 += A [i - 1];
        }
        if (sum1 == sum0)
            answer.Add (i);
    }
    return answer;
}

