/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:9956648
*  Stack Overflow answer #:45678003
*  And Stack Overflow answer#:43197653
*/
public static bool HasPropertyExist (dynamic settings, string name) {
    if (settings is System.Dynamic.ExpandoObject)
        return ((IDictionary < string, object >) settings).ContainsKey (name);
    if (settings is System.Web.Helpers.DynamicJsonObject)
        try {
            return settings [name] != null;
        }
        catch (KeyNotFoundException) {
            return false;
        }
    return settings.GetType ().GetProperty (name) != null;
}

public static bool HasProperty (dynamic obj, string name) {
    try {
        var value = obj [name];
        return true;
    }
    catch (KeyNotFoundException) {
        return false;
    }
}

