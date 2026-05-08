/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:15386587
*  Stack Overflow answer #:15386976
*  And Stack Overflow answer#:15386659
*/
public override int GetHashCode () {
    unchecked {
        int hash = 17;
        hash = hash * 23 + Column.GetHashCode ();
        hash = hash * 23 + Row.GetHashCode ();
        hash = hash * 23 + TableID.GetHashCode ();
        return hash;
    }
}

public bool Equals (Vector other) {
    if (ReferenceEquals (other, null))
        return false;
    if (ReferenceEquals (this, other))
        return true;
    return Column.Equals (other.Column) && Row.Equals (other.Row) && TableID.Equals (other.TableID);
}

