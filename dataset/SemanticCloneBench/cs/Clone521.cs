/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:9617785
*  Stack Overflow answer #:9617972
*  And Stack Overflow answer#:18496987
*/
public new bool Equals (object x, object y) {
    if (x is string)
        return x == y;
    else if (x is Guid)
        return x == y;
    else
        return EqualityComparer < object >.Default.Equals (x, y);
}

public bool Equals (MyObject other) {
    if (Object.ReferenceEquals (other, null))
        return false;
    if (Object.ReferenceEquals (this, other))
        return true;
    return Name.Equals (other.Name) && Value.Equals (other.Value) && ID.Equals (other.ID);
}

