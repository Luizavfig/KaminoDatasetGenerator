/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:1579438
*  Stack Overflow answer #:1579505
*  And Stack Overflow answer#:1579478
*/
public static string EnumValue (this MyEnum e) {
    switch (e) {
        case MyEnum.First :
            return "First Friendly Value";
        case MyEnum.Second :
            return "Second Friendly Value";
        case MyEnum.Third :
            return "Third Friendly Value";
    }
    return "Horrible Failure!!";
}

public static String GetEnumerationDescription (Enum e) {
    Type type = e.GetType ();
    FieldInfo fieldInfo = type.GetField (e.ToString ());
    DescriptionAttribute [] da = (DescriptionAttribute []) (fieldInfo.GetCustomAttributes (typeof (DescriptionAttribute), false));
    if (da.Length > 0) {
        return da [0].Description;
    }
    return e.ToString ();
}

