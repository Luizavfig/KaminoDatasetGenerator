/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:479410
*  Stack Overflow answer #:479453
*  And Stack Overflow answer#:479417
*/
public static string ToFriendlyString (this ErrorLevel me) {
    switch (me) {
        case ErrorLevel.None :
            return "Everything is OK";
        case ErrorLevel.Low :
            return "SNAFU, if you know what I mean.";
        case ErrorLevel.High :
            return "Reaching TARFU levels";
        case ErrorLevel.SoylentGreen :
            return "ITS PEOPLE!!!!";
        default :
            return "Get your damn dirty hands off me you FILTHY APE!";
    }
}

public static string GetDescription < T > (this T enumerationValue) where T : struct {
    Type type = enumerationValue.GetType ();
    if (! type.IsEnum) {
        throw new ArgumentException ("EnumerationValue must be of Enum type", "enumerationValue");
    }
    MemberInfo [] memberInfo = type.GetMember (enumerationValue.ToString ());
    if (memberInfo != null && memberInfo.Length > 0) {
        object [] attrs = memberInfo [0].GetCustomAttributes (typeof (DescriptionAttribute), false);
        if (attrs != null && attrs.Length > 0) {
            return ((DescriptionAttribute) attrs [0]).Description;
        }
    }
    return enumerationValue.ToString ();
}

