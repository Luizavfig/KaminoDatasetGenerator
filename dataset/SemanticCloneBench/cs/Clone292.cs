/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:36570725
*  Stack Overflow answer #:36571176
*  And Stack Overflow answer#:36571176
*/
public override void WriteJson (JsonWriter writer, object value, JsonSerializer serializer) {
    JToken t = JToken.FromObject (value);
    if (t.Type != JTokenType.Object) {
        t.WriteTo (writer);
        return;
    }
    JObject o = (JObject) t;
    writer.WriteStartObject ();
    WriteJson (writer, o);
    writer.WriteEndObject ();
}

private void WriteJson (JsonWriter writer, JObject value) {
    foreach (var p in value.Properties ()) {
        if (p.Value is JObject)
            WriteJson (writer, (JObject) p.Value);
        else
            p.WriteTo (writer);
    }
}

