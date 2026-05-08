/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:14886800
*  Stack Overflow answer #:14903514
*  And Stack Overflow answer#:51415620
*/
public static IDictionary < string, object > ToDictionary (this JObject @object) {
    var result = @object.ToObject < Dictionary < string, object > > ();
    var JObjectKeys = (from r in result
        let key = r.Key
        let value = r.Value
        where value.GetType () == typeof (JObject)
        select key).ToList ();
    var JArrayKeys = (from r in result
        let key = r.Key
        let value = r.Value
        where value.GetType () == typeof (JArray)
        select key).ToList ();
    JArrayKeys.ForEach (key = > result [key] = ((JArray) result [key]).Values ().Select (x = > ((JValue) x).Value).ToArray ());
    JObjectKeys.ForEach (key = > result [key] = ToDictionary (result [key] as JObject));
    return result;
}

public static object ToCollections (object o) {
    var jo = o as JObject;
    if (jo != null)
        return jo.ToObject < IDictionary < string, object > > ().ToDictionary (k = > k.Key, v = > ToCollections (v.Value));
    var ja = o as JArray;
    if (ja != null)
        return ja.ToObject < List < object > > ().Select (ToCollections).ToList ();
    return o;
}

