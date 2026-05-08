/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:737151
*  Stack Overflow answer #:737159
*  And Stack Overflow answer#:24924381
*/
public static Dictionary < string, object > DictionaryFromType (object atype) {
    if (atype == null)
        return new Dictionary < string, object > ();
    Type t = atype.GetType ();
    PropertyInfo [] props = t.GetProperties ();
    Dictionary < string, object > dict = new Dictionary < string, object > ();
    foreach (PropertyInfo prp in props) {
        object value = prp.GetValue (atype, new object [] {});
        dict.Add (prp.Name, value);
    }
    return dict;
}

public List < string > GetPropertiesNameOfClass (object pObject) {
    List < string > propertyList = new List < string > ();
    if (pObject != null) {
        foreach (var prop in pObject.GetType ().GetProperties ()) {
            propertyList.Add (prop.Name);
        }
    }
    return propertyList;
}

