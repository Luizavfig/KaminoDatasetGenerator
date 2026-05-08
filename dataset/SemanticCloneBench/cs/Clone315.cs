/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:1237810
*  Stack Overflow answer #:4440606
*  And Stack Overflow answer#:1249751
*/
public static bool CompareProperties (T newObject, T oldObject) {
    if (Equals (newObject, oldObject)) {
        return true;
    }
    PropertyInfo [] newProps = newObject.GetType ().GetProperties ();
    PropertyInfo [] oldProps = oldObject.GetType ().GetProperties ();
    if (newProps.Length != oldProps.Length) {
        return false;
    }
    foreach (PropertyInfo newProperty in newProps) {
        PropertyInfo oldProperty = oldProps.SingleOrDefault (pi = > pi.Name == newProperty.Name);
        if (oldProperty == null)
            return false;
        object newval = newProperty.GetValue (newObject, null);
        object oldval = oldProperty.GetValue (oldObject, null);
        if (! Equals (newval, oldval))
            return false;
    }
    return true;
}

public static bool CompareProperties (T newObject, T oldObject) {
    if (object.Equals (newObject, oldObject)) {
        return true;
    }
    if (newObject.GetType ().GetProperties ().Length != oldObject.GetType ().GetProperties ().Length) {
        return false;
    } else {
        var oldProperties = oldObject.GetType ().GetProperties ();
        foreach (PropertyInfo newProperty in newObject.GetType ().GetProperties ()) {
            try {
                PropertyInfo oldProperty = oldProperties.Single (pi = > pi.Name == newProperty.Name);
                if (! object.Equals (newProperty.GetValue (newObject, null), oldProperty.GetValue (oldObject, null))) {
                    return false;
                }
            }
            catch {
                return false;
            }
        }
        return true;
    }
}

