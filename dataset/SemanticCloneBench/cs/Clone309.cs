/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:26129448
*  Stack Overflow answer #:37893821
*  And Stack Overflow answer#:26248170
*/
public override void WriteJson (JsonWriter writer, object value, JsonSerializer serializer) {
    var contextBase = value as ContextBase;
    var valueToken = JToken.FromObject (value, new ForcedObjectSerializer ());
    if (contextBase.Properties != null) {
        var propertiesToken = JToken.FromObject (contextBase.Properties);
        foreach (var property in propertiesToken.Children < JProperty > ()) {
            valueToken [property.Name] = property.Value;
        }
    }
    valueToken.WriteTo (writer);
}

public override void WriteJson (JsonWriter writer, object value, JsonSerializer serializer) {
    JProperty typeHintProperty = TypeHintPropertyForType (value.GetType ());
    JObject jo = new JObject ();
    if (typeHintProperty != null) {
        jo.Add (typeHintProperty);
    }
    foreach (PropertyInfo prop in value.GetType ().GetProperties ()) {
        if (prop.CanRead) {
            object propValue = prop.GetValue (value);
            if (propValue != null) {
                jo.Add (prop.Name, JToken.FromObject (propValue, serializer));
            }
        }
    }
    jo.WriteTo (writer);
}

