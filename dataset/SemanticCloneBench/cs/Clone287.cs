/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:4185521
*  Stack Overflow answer #:26429045
*  And Stack Overflow answer#:32309776
*/
public static string GetFriendlyName (this Type type) {
    string friendlyName = type.Name;
    if (type.IsGenericType) {
        int iBacktick = friendlyName.IndexOf ('`');
        if (iBacktick > 0) {
            friendlyName = friendlyName.Remove (iBacktick);
        }
        friendlyName += "<";
        Type [] typeParameters = type.GetGenericArguments ();
        for (int i = 0; i < typeParameters.Length; ++ i) {
            string typeParamName = GetFriendlyName (typeParameters [i]);
            friendlyName += (i == 0 ? typeParamName : "," + typeParamName);
        }
        friendlyName += "><![CDATA[";
    }
    return friendlyName;
}

public static string GetFriendlyName (this Type type) {
    var friendlyName = type.Name;
    if (! type.IsGenericType)
        return friendlyName;
    var iBacktick = friendlyName.IndexOf ('`');
    if (iBacktick > 0)
        friendlyName = friendlyName.Remove (iBacktick);
    var genericParameters = type.GetGenericArguments ().Select (x = > x.GetFriendlyName ());
    friendlyName += "<" + string.Join (", ", genericParameters) + "><![CDATA[";
    return friendlyName;
}

