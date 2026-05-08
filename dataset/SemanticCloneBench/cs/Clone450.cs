/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:30175911
*  Stack Overflow answer #:30176629
*  And Stack Overflow answer#:30179162
*/
public override void WriteJson (JsonWriter writer, object value, JsonSerializer serializer) {
    if (value == null) {
        writer.WriteNull ();
        return;
    }
    var model = value as MyModel;
    if (model == null)
        throw new JsonSerializationException ();
    writer.WriteStartObject ();
    writer.WritePropertyName ("name");
    writer.WriteValue (model.Name);
    writer.WritePropertyName ("details");
    writer.WriteStartObject ();
    writer.WritePropertyName ("size");
    serializer.Serialize (writer, model.Size);
    writer.WritePropertyName ("weight");
    writer.WriteValue (model.Weight);
    writer.WriteEndObject ();
    writer.WriteEndObject ();
}

public override void WriteJson (JsonWriter writer, object value, JsonSerializer serializer) {
    using (new PushValue < bool > (true, () = > CannotWrite, val = > CannotWrite = val))
    {
        var obj = JObject.FromObject (value, serializer);
        var details = new JObject ();
        obj.Add ("details", details);
        obj ["size"].MoveTo (details);
        obj ["weight"].MoveTo (details);
        obj.WriteTo (writer);
    }}

