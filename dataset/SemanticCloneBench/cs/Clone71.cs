/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:5002670
*  Stack Overflow answer #:5003483
*  And Stack Overflow answer#:5004112
*/
public virtual bool Equals (EntityBase other) {
    if (other == null) {
        return false;
    }
    if (ReferenceEquals (other, this)) {
        return true;
    }
    var otherType = NHibernateProxyHelper.GetClassWithoutInitializingProxy (other);
    var thisType = NHibernateProxyHelper.GetClassWithoutInitializingProxy (this);
    if (! otherType.Equals (thisType)) {
        return false;
    }
    bool otherIsTransient = Equals (other.Id, 0);
    bool thisIsTransient = Equals (Id, 0);
    if (otherIsTransient || thisIsTransient)
        return false;
    return other.Id.Equals (Id);
}

public virtual bool Equals (Entity other) {
    if (other == null) {
        return false;
    }
    if (IsTransient ^ other.IsTransient) {
        return false;
    }
    if (IsTransient && other.IsTransient) {
        return ReferenceEquals (this, other);
    }
    return EntityId.Equals (other.EntityId);
}

