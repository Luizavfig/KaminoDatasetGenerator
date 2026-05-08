/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:30320493
*  Stack Overflow answer #:30320753
*  And Stack Overflow answer#:30320704
*/
public bool MoveNext () {
    if (idx == - 1) {
        idx = 0;
        current = 1;
    } else {
        current = current * 2;
    }
    return true;
}

public bool MoveNext () {
    int size = reeks.Count - 1;
    if (idx < size) {
        idx ++;
        reeks.Add (reeks [size] * 2);
        return true;
    }
    return false;
}

