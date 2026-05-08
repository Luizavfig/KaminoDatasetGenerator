/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:1387755
*  Stack Overflow answer #:2225173
*  And Stack Overflow answer#:39892660
*/
public static string Serialize < T > (T obj) {
    string returnVal = "";
    try {
        DataContractJsonSerializer serializer = new DataContractJsonSerializer (obj.GetType ());
        using (MemoryStream ms = new MemoryStream ())
        {
            serializer.WriteObject (ms, obj);
            returnVal = Encoding.Default.GetString (ms.ToArray ());
        }}
    catch (Exception) {
        returnVal = "";
    }
    return returnVal;
}

public override IDictionary < string, object > Serialize (object obj, JavaScriptSerializer serializer) {
    var jsonExample = new Dictionary < string, object > ();
    foreach (var prop in obj.GetType ().GetProperties ()) {
        var nullableobj = prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition () == typeof (Nullable < >);
        bool ignoreProp = prop.IsDefined (typeof (ScriptIgnoreAttribute), true);
        var value = prop.GetValue (obj, System.Reflection.BindingFlags.Public, null, null, null);
        int i;
        if (! (nullableobj == false && value != null && (int.TryParse (value.ToString (), out i) ? i : 1) == 0) && value != null && ! ignoreProp)
            jsonExample.Add (prop.Name, value);
    }
    return jsonExample;
}

