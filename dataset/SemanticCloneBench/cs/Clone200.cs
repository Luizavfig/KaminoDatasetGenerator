/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:18472867
*  Stack Overflow answer #:18472932
*  And Stack Overflow answer#:18472981
*/
public bool Equality (byte [] a1, byte [] b1) {
    if (a1 == null || b1 == null)
        return false;
    int length = a1.Length;
    if (b1.Length != length)
        return false;
    while (length > 0) {
        length --;
        if (a1 [length] != b1 [length])
            return false;
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

