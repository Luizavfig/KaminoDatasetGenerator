/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:2958921
*  Stack Overflow answer #:3046102
*  And Stack Overflow answer#:3046102
*/
private PropertyInfo GetPrimaryKeyInfo < T > () {
    PropertyInfo [] properties = typeof (T).GetProperties ();
    foreach (PropertyInfo pI in properties) {
        System.Object [] attributes = pI.GetCustomAttributes (true);
        foreach (object attribute in attributes) {
            if (attribute is EdmScalarPropertyAttribute) {
                if ((attribute as EdmScalarPropertyAttribute).EntityKeyProperty == true)
                    return pI;
            } else if (attribute is ColumnAttribute) {
                if ((attribute as ColumnAttribute).IsPrimaryKey == true)
                    return pI;
            }
        }
    }
    return null;
}

string GetEntityName < T > () {
    string name = typeof (T).Name;
    if (name.ToLower () == "person")
        return "People";
    else if (name.Substring (name.Length - 1, 1).ToLower () == "y")
        return name.Remove (name.Length - 1, 1) + "ies";
    else if (name.Substring (name.Length - 1, 1).ToLower () == "s")
        return name + "es";
    else
        return name + "s";
}

