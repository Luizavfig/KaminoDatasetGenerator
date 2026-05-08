/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:26129448
*  Stack Overflow answer #:33836697
*  And Stack Overflow answer#:26248170
*/
public override void WriteJson (JsonWriter writer, object value, JsonSerializer serializer) {
    Type valueType = value.GetType ();
    if (valueType.IsArray) {
        var jArray = new JArray ();
        foreach (var item in (IEnumerable) value)
            jArray.Add (JToken.FromObject (item, serializer));
        jArray.WriteTo (writer);
    } else {
        JProperty typeHintProperty = TypeHintPropertyForType (value.GetType ());
        var jObj = new JObject ();
        if (typeHintProperty != null)
            jo.Add (typeHintProperty);
        foreach (PropertyInfo property in valueType.GetProperties (BindingFlags.Public | BindingFlags.Instance)) {
            if (property.CanRead) {
                object propertyValue = property.GetValue (value);
                if (propertyValue != null)
                    jObj.Add (property.Name, JToken.FromObject (propertyValue, serializer));
            }
        }
        jObj.WriteTo (writer);
    }
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

