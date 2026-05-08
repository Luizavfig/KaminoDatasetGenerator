/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:18472867
*  Stack Overflow answer #:18473432
*  And Stack Overflow answer#:18472981
*/
public bool Equality (byte [] a1, byte [] b1) {
    if (a1.Length != b1.Length) {
        return false;
    }
    if (object.ReferenceEquals (a1, b1)) {
        return true;
    }
    for (int i = 0; i < a1.Length; i ++) {
        if (a1 [i] != b1 [i]) {
            return false;
        }
    }
    return true;
}

public bool Equality (byte [] a1, byte [] b1) {
    int i;
    if (a1.Length == b1.Length) {
        i = 0;
        while (i < a1.Length && (a1 [i] == b1 [i])) {
            i ++;
        }
        if (i == a1.Length) {
            return true;
        }
    }
    return false;
}

