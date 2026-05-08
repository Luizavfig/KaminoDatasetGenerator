/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:11340613
*  Stack Overflow answer #:11340764
*  And Stack Overflow answer#:11340764
*/
int IComparer < T >.Compare (T x, T y) {
    if (x == null)
        return y == null ? 0 : - 1;
    if (y == null)
        return 1;
    Type xType = x.GetType (), yType = y.GetType ();
    int delta = xType == yType ? 0 : string.Compare (xType.FullName, yType.FullName);
    if (delta == 0)
        delta = Comparer < T >.Default.Compare (x, y);
    return delta;
}

bool IEqualityComparer < T >.Equals (T x, T y) {
    if (ReferenceEquals (x, y))
        return true;
    if (x == null || y == null)
        return false;
    Type xType = x.GetType (), yType = y.GetType ();
    return xType == yType && EqualityComparer < T >.Default.Equals (x, y);
}

