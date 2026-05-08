/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:38467146
*  Stack Overflow answer #:38468111
*  And Stack Overflow answer#:38468966
*/
public bool Seq_Check (int [] elems, int k) {
    for (int i = elems.Length; i > 0; i --) {
        if (elems [i] == k) {
            int curr = k - 1;
            for (; i > 0 && curr > 0; i --) {
                if (elems [i] != curr) {
                    if (elems [i] == k) {
                        curr = k - 1;
                        continue;
                    }
                    break;
                }
                curr --;
            }
            if (curr == 0) {
                return true;
            }
        }
    }
    return false;
}

public static bool Seq_Check (int [] A, int k) {
    Array.Sort (A);
    int start = 1, end = k;
    if (A [0] != start)
        return false;
    int expected = start + 1;
    int currUnique = A [0];
    for (int i = 1; i < A.Length; i ++) {
        if (A [i] != A [i - 1]) {
            currUnique = A [i];
            if (currUnique != expected || expected > end)
                return false;
            expected ++;
        }
    }
    return true;
}

