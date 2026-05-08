/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:154256
*  Stack Overflow answer #:154335
*  And Stack Overflow answer#:154269
*/
public static IEnumerable < T > EnumToList < T > () where T : struct {
    Type enumType = typeof (T);
    if (enumType.BaseType != typeof (Enum))
        throw new ArgumentException ("T must be of type System.Enum");
    Array enumValArray = Enum.GetValues (enumType);
    List < T > enumValList = new List < T > ();
    foreach (T val in enumValArray) {
        enumValList.Add (val.ToString ());
    }
    return enumValList;
}

public static void Main () {
    Console.WriteLine ("The values of the Colors Enum are:");
    foreach (string s in Enum.GetNames (typeof (Colors)))
        Console.WriteLine (s);
    Console.WriteLine ();
    Console.WriteLine ("The values of the Styles Enum are:");
    foreach (string s in Enum.GetNames (typeof (Styles)))
        Console.WriteLine (s);
}

