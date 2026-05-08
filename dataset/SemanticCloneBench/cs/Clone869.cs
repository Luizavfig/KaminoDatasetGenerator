/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:46413406
*  Stack Overflow answer #:46414303
*  And Stack Overflow answer#:46414303
*/
public override object ReadJson (JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
    var obj = JToken.ReadFrom (reader);
    if (objectType == typeof (Dictionary < string, TValue >)) {
        var comparer = obj.Value < string > ("Comparer");
        Dictionary < string, TValue > result;
        if (comparer == "OrdinalIgnoreCase") {
            result = new Dictionary < string, TValue > (StringComparer.OrdinalIgnoreCase);
        } else {
            result = new Dictionary < string, TValue > ();
        }
        obj ["Comparer"].Parent.Remove ();
        serializer.Populate (obj.CreateReader (), result);
        return result;
    }
    return obj.ToObject (objectType);
}

public override void WriteJson (JsonWriter writer, object value, JsonSerializer serializer) {
    var obj = JObject.FromObject (value);
    if (value is Dictionary < string, TValue >) {
        if ((value as Dictionary < string, TValue >).Comparer == StringComparer.OrdinalIgnoreCase)
            obj.Add ("Comparer", JToken.FromObject ("OrdinalIgnoreCase"));
    }
    obj.WriteTo (writer);
}

