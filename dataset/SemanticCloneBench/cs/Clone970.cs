/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:3166172
*  Stack Overflow answer #:3166213
*  And Stack Overflow answer#:3166240
*/
public static Dictionary < int, string > GetListItems (Type enumType) {
    if (! enumType.IsEnum)
        throw new ApplicationException ("GetListItems does not support non-enum types");
    Dictionary < int, string > list = new Dictionary < int, string > ();
    foreach (FieldInfo field in enumType.GetFields (BindingFlags.Static | BindingFlags.GetField | BindingFlags.Public)) {
        int value;
        string display;
        value = (int) field.GetValue (null);
        display = Enum.GetName (enumType, value);
        foreach (Attribute currAttr in field.GetCustomAttributes (true)) {
            EnumValueDataAttribute valueAttribute = currAttr as EnumValueDataAttribute;
            if (valueAttribute != null)
                display = valueAttribute.Name;
        }
        list.Add (value, display);
    }
    return list;
}

public static string GetEnumDescription (Object value) {
    try {
        Type objType = value.GetType ();
        FieldInfo fldInf = objType.GetField (Enum.GetName (objType, value));
        Object [] attributes = fldInf.GetCustomAttributes (false);
        if (attributes.Length > 0) {
            DescriptionAttribute descAttr = (DescriptionAttribute) attributes [0];
            return descAttr.Description;
        } else {
            return value.ToString ();
        }
    }
    catch {
        return string.Empty;
    }
}

