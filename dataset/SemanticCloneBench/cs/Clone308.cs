/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:26129448
*  Stack Overflow answer #:37893821
*  And Stack Overflow answer#:33836697
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

