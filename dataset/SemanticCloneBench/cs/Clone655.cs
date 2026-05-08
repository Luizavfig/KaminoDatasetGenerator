/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:1196991
*  Stack Overflow answer #:9274326
*  And Stack Overflow answer#:26747560
*/
public static object GetPropertyValue (object srcobj, string propertyName) {
    if (srcobj == null)
        return null;
    object obj = srcobj;
    string [] propertyNameParts = propertyName.Split ('.');
    foreach (string propertyNamePart in propertyNameParts) {
        if (obj == null)
            return null;
        if (! propertyNamePart.Contains ("[")) {
            PropertyInfo pi = obj.GetType ().GetProperty (propertyNamePart);
            if (pi == null)
                return null;
            obj = pi.GetValue (obj, null);
        } else {
            int indexStart = propertyNamePart.IndexOf ("[") + 1;
            string collectionPropertyName = propertyNamePart.Substring (0, indexStart - 1);
            int collectionElementIndex = Int32.Parse (propertyNamePart.Substring (indexStart, propertyNamePart.Length - indexStart - 1));
            PropertyInfo pi = obj.GetType ().GetProperty (collectionPropertyName);
            if (pi == null)
                return null;
            object unknownCollection = pi.GetValue (obj, null);
            if (unknownCollection.GetType ().IsArray) {
                object [] collectionAsArray = unknownCollection as Array [];
                obj = collectionAsArray [collectionElementIndex];
            } else {
                System.Collections.IList collectionAsList = unknownCollection as System.Collections.IList;
                if (collectionAsList != null) {
                    obj = collectionAsList [collectionElementIndex];
                } else {
                }
            }
        }
    }
    return obj;
}

public static T FindNestedPropertyValue < T, N > (N model, string propName) {
    T retVal = default (T);
    bool found = false;
    PropertyInfo [] properties = typeof (N).GetProperties ();
    foreach (PropertyInfo property in properties) {
        var currentProperty = property.GetValue (model, null);
        if (! found) {
            try {
                retVal = GetPropValue < T > (currentProperty, propName);
                found = true;
            }
            catch {
            }
        }
    }
    if (! found) {
        throw new Exception ("Unable to find property: " + propName);
    }
    return retVal;
}

