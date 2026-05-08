/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:9943727
*  Stack Overflow answer #:9944079
*  And Stack Overflow answer#:31155707
*/
private static void AddToBackingStore (Dictionary < string, object > backingStore, string prefix, object value) {
    IDictionary < string, object > d = value as IDictionary < string, object >;
    if (d != null) {
        foreach (KeyValuePair < string, object > entry in d) {
            AddToBackingStore (backingStore, MakePropertyKey (prefix, entry.Key), entry.Value);
        }
        return;
    }
    IList l = value as IList;
    if (l != null) {
        for (int i = 0; i < l.Count; i ++) {
            AddToBackingStore (backingStore, MakeArrayKey (prefix, i), l [i]);
        }
        return;
    }
    backingStore [prefix] = value;
}

private static object GetDeserializedObject (ControllerContext controllerContext) {
    if (! controllerContext.HttpContext.Request.ContentType.StartsWith ("application/json", StringComparison.OrdinalIgnoreCase)) {
        return null;
    }
    controllerContext.HttpContext.Request.InputStream.Position = 0;
    StreamReader reader = new StreamReader (controllerContext.HttpContext.Request.InputStream);
    string bodyText = reader.ReadToEnd ();
    if (String.IsNullOrEmpty (bodyText)) {
        return null;
    }
    JavaScriptSerializer serializer = new JavaScriptSerializer ();
    serializer.MaxJsonLength = 2147483647;
    object jsonData = serializer.DeserializeObject (bodyText);
    return jsonData;
}

