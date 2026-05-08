/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:33786339
*  Stack Overflow answer #:33786605
*  And Stack Overflow answer#:33787738
*/
public HashSet < TEntity > GetCollection < TEntity > () {
    var type = typeof (TEntity);
    if (type == typeof (Bike))
        return (HashSet < TEntity >) (object) Bikes;
    if (type == typeof (Car))
        return (HashSet < TEntity >) (object) Cars;
    if (type == typeof (Truck))
        return (HashSet < TEntity >) (object) Trucks;
    throw new InvalidOperationException ();
}

public HashSet < TEntity > GetCollection < TEntity > () {
    var a = this.GetType ().GetProperties ();
    HashSet < TEntity > retVal = null;
    foreach (var name in a.Select (propertyInfo = > propertyInfo.Name)) {
        retVal = this.GetType ().GetProperty (name).GetValue (this, null) as HashSet < TEntity >;
        if (retVal != null) {
            break;
        }
    }
    return retVal;
}

