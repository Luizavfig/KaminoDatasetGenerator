/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:957783
*  Stack Overflow answer #:957809
*  And Stack Overflow answer#:15782807
*/
public bool ReflectiveEquals (object first, object second) {
    if (first == null && second == null) {
        return true;
    }
    if (first == null || second == null) {
        return false;
    }
    Type firstType = first.GetType ();
    if (second.GetType () != firstType) {
        return false;
    }
    foreach (PropertyInfo propertyInfo in firstType.GetProperties ()) {
        if (propertyInfo.CanRead) {
            object firstValue = propertyInfo.GetValue (first, null);
            object secondValue = propertyInfo.GetValue (second, null);
            if (! object.Equals (firstValue, secondValue)) {
                return false;
            }
        }
    }
    return true;
}

public bool ReflectiveEquals (LocalHdTicket serverTicket, LocalHdTicket localTicket) {
    if (serverTicket == null && localTicket == null)
        return true;
    if (serverTicket == null || localTicket == null)
        return false;
    var firstType = serverTicket.GetType ();
    if (localTicket.GetType () != firstType)
        throw new Exception ("Trying to compare two different object types!");
    return ! (from propertyInfo in firstType.GetProperties ()
        where propertyInfo.CanRead
        let serverValue = propertyInfo.GetValue (serverTicket, null)
        let localValue = propertyInfo.GetValue (localTicket, null)
        where ! Equals (serverValue, localValue)
        select serverValue).Any ();
}

