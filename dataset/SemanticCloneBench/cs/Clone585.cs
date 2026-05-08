/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:8733215
*  Stack Overflow answer #:8733460
*  And Stack Overflow answer#:8733460
*/
public bool Equals (int [] x, int [] y) {
    if (Object.ReferenceEquals (x, y))
        return true;
    if (Object.ReferenceEquals (x, null) || Object.ReferenceEquals (y, null))
        return false;
    if (x.Length != y.Length)
        return false;
    for (int i = 0; i < x.Length; i ++) {
        if (x [i] != y [i])
            return false;
    }
    return true;
}

public int GetHashCode (int [] intArray) {
    if (Object.ReferenceEquals (intArray, null))
        return 0;
    int hashCode = 0;
    bool isFirst = true;
    foreach (int i in intArray) {
        if (isFirst) {
            hashCode = i;
            isFirst = false;
        } else {
            hashCode = hashCode ^ i;
        }
    }
    return hashCode;
}

