/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:13840875
*  Stack Overflow answer #:13841146
*  And Stack Overflow answer#:13841146
*/
private static string DictionaryToString (IDictionary dict) {
    if (null == dict)
        throw new ArgumentNullException ("dict");
    var valueStrings = new List < string > ();
    foreach (DictionaryEntry item in dict) {
        valueStrings.Add (item.Key + ": " + item.Value);
    }
    return string.Join ("\n", valueStrings.ToArray ());
}

private static string Test (object value) {
    var dict = value as IDictionary;
    if (dict != null) {
        return DictionaryToString (dict);
    }
    if (value == null) {
        return null;
    }
    return value.ToString ();
}

